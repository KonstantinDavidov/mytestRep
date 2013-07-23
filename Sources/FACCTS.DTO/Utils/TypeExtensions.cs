using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO.Utils
{
    internal static class TypeExtensions
    {
        public static bool AssignableToTypeName(this Type type, string fullTypeName, out Type match)
        {
            for (Type type1 = type; type1 != (Type)null; type1 = BaseType(type1))
            {
                if (string.Equals(type1.FullName, fullTypeName, StringComparison.Ordinal))
                {
                    match = type1;
                    return true;
                }
            }
            foreach (MemberInfo memberInfo in type.GetInterfaces())
            {
                if (string.Equals(memberInfo.Name, fullTypeName, StringComparison.Ordinal))
                {
                    match = type;
                    return true;
                }
            }
            match = (Type)null;
            return false;
        }

        public static bool AssignableToTypeName(this Type type, string fullTypeName)
        {
            Type match;
            return AssignableToTypeName(type, fullTypeName, out match);
        }

        public static Type BaseType(this Type type)
        {
            return type.BaseType;
        }
    }
}
