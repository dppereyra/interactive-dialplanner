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

using DennisWuWorks.InteractiveBuilder.Data;

namespace DennisWuWorks.InteractiveBuilder.Data
{
	public class DataListAttribute : ListAttribute, IAddNew
	{
		#region Data Members

		private readonly string _dllName;
		private readonly string _className;
		private readonly string _path;
		private readonly bool _isStatic;
		private readonly bool _addNew;
		private readonly string _eventHandler;

		#endregion

		#region Constructor
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="path">Path to the list of items for display in the GridComboBox</param>
		public DataListAttribute( string path )
		{
			this._path = path;
			this._isStatic = false;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="path">Path to the list of items for display in the GridComboBox</param>
		/// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
		public DataListAttribute( string path, bool allowNew )
			: this( path )
		{
			this._addNew = allowNew;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="path">Path to the list of items for display in the GridComboBox</param>
		/// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
		/// <param name="eventHandler">On Add Callback Notification Method - Must be of type delegate ObjectAddedEventHandler</param>
		public DataListAttribute( string path, bool allowNew, string eventHandler )
			: this( path, allowNew )
		{
			this._eventHandler = eventHandler;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dllName">The name of the dll the class belongs to</param>
		/// <param name="className">The name of the class</param>
		/// <param name="path">Path to the list of items for display in the GridComboBox</param>
		public DataListAttribute( string dllName, string className, string path )
			: this( path )
		{
			this._isStatic = true;
			this._dllName = dllName;
			this._className = className;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dllName">The name of the dll the class belongs to</param>
		/// <param name="className">The name of the class</param>
		/// <param name="path">Path to the list of items for display in the GridComboBox</param>
		/// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
		public DataListAttribute( string dllName, string className, string path, bool allowNew )
			: this( dllName, className, path )
		{
			this._addNew = allowNew;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dllName">The name of the dll the class belongs to</param>
		/// <param name="className">The name of the class</param>
		/// <param name="path">Path to the list of items for display in the GridComboBox</param>
		/// <param name="allowNew">True - Allow new object to be created and added to list of items</param>
		/// <param name="eventHandler">On Add Callback Notification Method - Must be of type delegate ObjectAddedEventHandler</param>
		public DataListAttribute( string dllName, string className, string path, bool allowNew, string eventHandler )
			: this( dllName, className, path, allowNew )
		{
			this._eventHandler = eventHandler;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set for ClassName
		/// </summary>
		public string ClassName
		{
			get { return ( _className ); }
		}

		/// <summary>
		/// Get/Set for DllName
		/// </summary>
		public string DllName
		{
			get { return ( _dllName ); }
		}

		/// <summary>
		/// Get for Path
		/// </summary>
		public string Path
		{
			get { return ( _path ); }
		}

		/// <summary>
		/// Get for IsStatic
		/// </summary>
		public bool IsStatic
		{
			get { return ( _isStatic ); }
		}

		/// <summary>
		/// Get for AddNew
		/// </summary>
		public bool AddNew
		{
			get { return ( _addNew ); }
		}

		/// <summary>
		/// Get for EventHandler
		/// </summary>
		public string EventHandler
		{
			get { return ( _eventHandler ); }
		}

		#endregion
	}
}