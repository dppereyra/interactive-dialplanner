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

using System.Text.RegularExpressions;

namespace DennisWuWorks.InteractiveBuilder.Rule
{
	/// <summary>
	/// Validate the input data against a Regular Expression
	/// </summary>
	public class PatternRuleAttribute : RuleBaseAttribute
	{
		#region Data Members

		private readonly string _pattern;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pattern"></param>
		public PatternRuleAttribute( string pattern )
		{
			this._pattern = pattern;
		}

		#endregion

		#region Methods - Public

		/// <summary>
		/// Validate the input data
		/// </summary>
		/// <param name="dataObject"></param>
		/// <returns></returns>
		public override bool IsValid( object dataObject )
		{
			this.ErrorMessage = string.Empty;

			if ( dataObject is string )
			{
				string data = (string)dataObject;
				if ( Regex.IsMatch( data, this._pattern ) )
				{
					return ( true );
				}
			}

			this.ErrorMessage = string.Format(
				"The value you entered: {0} doesn't match the given pattern.",
				dataObject );

			return ( false );
		}

		#endregion
	}
}

