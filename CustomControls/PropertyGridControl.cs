/******************************************************************************************
 * 
 * Copyright (c) 2012 WU WAI FAN DENNIS
 * 
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software 
 * is furnished to do so, subject to the following conditions:
 * 
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN 
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
******************************************************************************************/

using System;
using System.Reflection;
using System.Windows.Forms;

using DennisWuWorks.InteractiveBuilder.Rule;

namespace DennisWuWorks.InteractiveBuilder
{
	public class PropertyGridControl: PropertyGrid
	{
		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public PropertyGridControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods - Private

		/// <summary>
		/// 
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// PropertyGridControl
			// 
			this.PropertyValueChanged += PropertyGridControl_PropertyValueChanged;
			this.ResumeLayout( false );

		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// 
		/// </summary>
		/// <param name="s"></param>
		/// <param name="e"></param>
		private static void PropertyGridControl_PropertyValueChanged( object s, PropertyValueChangedEventArgs e )
		{
			RuleBaseAttribute rule;
			Type classType;
			string propertyName;
			PropertyInfo propertyInfo;
			object[] attributes;

			classType = e.ChangedItem.PropertyDescriptor.ComponentType;
			propertyName = e.ChangedItem.PropertyDescriptor.Name;
			propertyInfo = classType.GetProperty( propertyName );
			attributes = propertyInfo.GetCustomAttributes( true );

			if ( ( attributes != null ) && ( attributes.Length > 0 ) )
			{
				foreach ( object attribute in attributes )
				{
					// Is this Attribute a RuleBaseAttribute
					rule = attribute as RuleBaseAttribute;
					if ( rule != null )
					{
						// Validate the data using the rule
						if ( rule.IsValid( e.ChangedItem.Value ) == false )
						{
							// Data was invalid - show the error
							MessageBox.Show( rule.ErrorMessage, "Data Entry Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error );
						}
					}
				}
			}
		}

		#endregion
	}
}
