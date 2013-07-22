using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Calls a method on an object
        /// </summary>
        /// <param name="MethodName">Method name</param>
        /// <param name="Object">Object to call the method on</param>
        /// <param name="InputVariables">(Optional)input variables for the method</param>
        /// <typeparam name="ReturnType">Return type expected</typeparam>
        /// <returns>The returned value of the method</returns>
        public static ReturnType CallMethod<ReturnType>(this object Object, string MethodName, params object[] InputVariables)
        {
            if (Object == null)
                throw new ArgumentNullException("Object");
            if (string.IsNullOrEmpty(MethodName))
                throw new ArgumentNullException("MethodName");
            if (InputVariables == null)
                InputVariables = new object[0];
            Type ObjectType = Object.GetType();
            Type[] MethodInputTypes = new Type[InputVariables.Length];
            for (int x = 0; x < InputVariables.Length; ++x)
                MethodInputTypes[x] = InputVariables[x].GetType();
            MethodInfo Method = ObjectType.GetMethod(MethodName, MethodInputTypes);
            if (Method == null)
                throw new NullReferenceException("Could not find method " + MethodName + " with the appropriate input variables.");
            return (ReturnType)Method.Invoke(Object, InputVariables);
        }

        /// <summary>
        /// Creates an instance of the type and casts it to the specified type
        /// </summary>
        /// <typeparam name="ClassType">Class type to return</typeparam>
        /// <param name="Type">Type to create an instance of</param>
        /// <param name="args">Arguments sent into the constructor</param>
        /// <returns>The newly created instance of the type</returns>
        public static ClassType CreateInstance<ClassType>(this Type Type, params object[] args)
        {
            if (Type == null)
                throw new ArgumentNullException("Type");
            return (ClassType)Type.CreateInstance(args);
        }

        /// <summary>
        /// Creates an instance of the type
        /// </summary>
        /// <param name="Type">Type to create an instance of</param>
        /// <param name="args">Arguments sent into the constructor</param>
        /// <returns>The newly created instance of the type</returns>
        public static object CreateInstance(this Type Type, params object[] args)
        {
            if (Type == null)
                throw new ArgumentNullException("Type");
            return Activator.CreateInstance(Type, args);
        }

        /// <summary>
        /// Gets the attribute from the item
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="Provider">Attribute provider</param>
        /// <param name="Inherit">When true, it looks up the heirarchy chain for the inherited custom attributes</param>
        /// <returns>Attribute specified if it exists</returns>
        public static T GetAttribute<T>(this ICustomAttributeProvider Provider, bool Inherit = true) where T : Attribute
        {
            return Provider.IsDefined(typeof(T), Inherit) ? Provider.GetAttributes<T>(Inherit)[0] : default(T);
        }

        /// <summary>
        /// Gets the attributes from the item
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="Provider">Attribute provider</param>
        /// <param name="Inherit">When true, it looks up the heirarchy chain for the inherited custom attributes</param>
        /// <returns>Array of attributes</returns>
        public static T[] GetAttributes<T>(this ICustomAttributeProvider Provider, bool Inherit = true) where T : Attribute
        {
            return Provider.IsDefined(typeof(T), Inherit) ? Provider.GetCustomAttributes(typeof(T), Inherit).Select(x => (T)x).ToArray() : new T[0];
        }

        /// <summary>
        /// Gets the value of property
        /// </summary>
        /// <param name="Object">The object to get the property of</param>
        /// <param name="Property">The property to get</param>
        /// <returns>Returns the property's value</returns>
        public static object GetProperty(this object Object, PropertyInfo Property)
        {
            if (Object == null)
                throw new ArgumentNullException("Object");
            if (Property == null)
                throw new ArgumentNullException("Property");
            return Property.GetValue(Object, null);
        }

        /// <summary>
        /// Gets the value of property
        /// </summary>
        /// <param name="Object">The object to get the property of</param>
        /// <param name="Property">The property to get</param>
        /// <returns>Returns the property's value</returns>
        public static object GetProperty(this object Object, string Property)
        {
            if (Object == null)
                throw new ArgumentNullException("Object");
            if (string.IsNullOrEmpty(Property))
                throw new ArgumentNullException("Property");
            string[] Properties = Property.Split(new string[] { "." }, StringSplitOptions.None);
            object TempObject = Object;
            Type TempObjectType = TempObject.GetType();
            PropertyInfo DestinationProperty = null;
            for (int x = 0; x < Properties.Length - 1; ++x)
            {
                DestinationProperty = TempObjectType.GetProperty(Properties[x]);
                TempObjectType = DestinationProperty.PropertyType;
                TempObject = DestinationProperty.GetValue(TempObject, null);
                if (TempObject == null)
                    return null;
            }
            DestinationProperty = TempObjectType.GetProperty(Properties[Properties.Length - 1]);
            return TempObject.GetProperty(DestinationProperty);
        }
    }
}
