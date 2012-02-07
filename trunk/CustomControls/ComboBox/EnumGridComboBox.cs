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
using System.ComponentModel;
using DennisWuWorks.InteractiveBuilder.Data;

namespace DennisWuWorks.InteractiveBuilder.ComboBox
{
	public class EnumGridComboBox : GridComboBox
	{
		#region Overrides

		/// <summary>
		/// Get the object selected in the ComboBox
		/// </summary>
		/// <returns>Selected Object</returns>
		protected override object GetDataObjectSelected( ITypeDescriptorContext context )
		{
			return ( base.ListBox.SelectedItem );
		}

		/// <summary>
		/// Find the list of data items to populate the ComboBox
		/// </summary>
		/// <param name="context"></param>
		protected override void RetrieveDataList( ITypeDescriptorContext context )
		{
			// Find the Attribute that has the path to the Enumerations list
			foreach ( Attribute attribute in context.PropertyDescriptor.Attributes )
			{
				if ( attribute is EnumListAttribute )
				{
					base.ListAttribute = attribute as EnumListAttribute;
					break;
				}
			}

			// If we found the Attribute, find the Data List
			if ( base.ListAttribute != null )
			{
				// Save the DataList
				base.DataList = Enum.GetValues( ((EnumListAttribute)base.ListAttribute).EnumType ); 
			}
		}

		#endregion
	}
}