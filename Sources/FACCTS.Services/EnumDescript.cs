using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services
{
    public struct EnumDescript<T>
        where T : struct
    {
        private T _enumValue;

        public T Value
        {
            get
            {
                return _enumValue;
            }
        }

        public EnumDescript(T value)
        {
            _enumValue = value;
        }

        public string ToDescription()
        {
            FieldInfo fi = _enumValue.GetType().GetField(_enumValue.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return _enumValue.ToString();
        }

        private static T EnumFromDescription(string description)
        {
            foreach (var field in typeof(T).GetFields())
            {
                DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute == null)
                    continue;
                if (attribute.Description == description)
                {
                    return (T)field.GetValue(null);
                }
            }
            return default(T);
        }

        public string ToString()
        {
            return this.ToDescription();
        }

        public static implicit operator T(EnumDescript<T> enumDescript)
        {
            return enumDescript._enumValue;
        }

        public static implicit operator EnumDescript<T>(T value)
        {
            return new EnumDescript<T>(value);
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.Value.GetType())
            {
                return false;
            }
            // If parameter cannot be cast to Point return false.
            EnumDescript<T> p = (EnumDescript<T>)obj;

            return p._enumValue.Equals(this._enumValue);
        }

        public override int GetHashCode()
        {
            return this._enumValue.GetHashCode();
        }
    }
}
