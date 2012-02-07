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
using System.Collections.Generic;
using System.Text;

namespace Interaction.Graph
{
    public static class ClassType
    {
        /// <summary>
        /// Get the class type object
        /// </summary>
        /// <param name="assemblyQualifiedName">Assembly-qualified name of the Type containing DLL, class name, version, culture, public key</param>
        /// <returns>The type object of the class</returns>
        public static Type GetType(string assemblyQualifiedName)
        {
            return (Type.GetType(assemblyQualifiedName));
        }


        /// <summary>
        /// Get the class type object
        /// </summary>
        /// <param name="dllName">DLL where the class is defined</param>
        /// <param name="className">Fully qualified name of the class</param>
        /// <returns>The type object of the class</returns>
        public static Type GetType(string dllName, string className)
        {
            string format = string.Format("{0}, {1}", className, dllName);
            return (GetType(format));
        }

        /// <summary>
        /// Get the class type object
        /// </summary>
        /// <param name="dllName">DLL where the class is defined</param>
        /// <param name="className">Fully qualified name of the class</param>
        /// <param name="version">The specific version to create</param>
        /// <param name="culture">The culture information</param>
        /// <param name="publicKeyToken">Public Key Token</param>
        /// <returns>The type object of the class</returns>
        public static Type GetType(string dllName, string className, Version version, string culture, string publicKeyToken)
        {
            string format = string.Format("{0}, {1}, Version={2}, Culture={3}, PublicKeyToken={4}",
                className, dllName, version, culture, publicKeyToken);

            return (GetType(format));
        }
    }
}
