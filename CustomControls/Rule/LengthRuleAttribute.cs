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

namespace DennisWuWorks.InteractiveBuilder.Rule
{
	/// <summary>
	/// Validate the input data meets a minimum length and doesn't exceed a maximum
	/// </summary>
	public class LengthRuleAttribute : RuleBaseAttribute
	{
		#region Data Members

		private readonly int _minLength;
		private readonly int _maxLength;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="minLength"></param>
		/// <param name="maxLength"></param>
		public LengthRuleAttribute( int minLength, int maxLength )
		{
			this._minLength = minLength;
			this._maxLength = maxLength;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set for MinLength
		/// </summary>
		public int MinLength
		{
			get { return ( _minLength ); }
		}

		/// <summary>
		/// Get/Set for MaxLength
		/// </summary>
		public int MaxLength
		{
			get { return ( _maxLength ); }
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
				if ( ( _minLength <= data.Length ) && ( data.Length <= _maxLength ) )
				{
					return ( true );
				}
			}

			this.ErrorMessage = string.Format(
				"The value you entered: {0} is not between {1} and {2}.",
				dataObject, _minLength, _maxLength );

			return ( false );
		}

		#endregion
	}
}

