﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Common
{
    public static class EnumHelper
    {
        // Get the Name value of the Display attribute if the   
        // enum has one, otherwise use the value converted to title case.  
        public static string GetDisplayName<TEnum>(this TEnum value)
            where TEnum : struct, IConvertible
        {
            var attr = value.GetAttributeOfType<TEnum, DescriptionAttribute>();
            return attr == null ? value.ToString() : attr.Description;
        }

        // Get the ShortName value of the Display attribute if the   
        // enum has one, otherwise use the value converted to title case.  
        public static string GetDisplayShortName<TEnum>(this TEnum value)
            where TEnum : struct, IConvertible
        {
            var attr = value.GetAttributeOfType<TEnum, DescriptionAttribute>();
            return attr == null ? value.ToString() : attr.Description;
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="value">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        private static T GetAttributeOfType<TEnum, T>(this TEnum value)
            where TEnum : struct, IConvertible
            where T : Attribute
        {

            return value.GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttributes(false)
                        .OfType<T>()
                        .LastOrDefault();
        }
    }
}
