using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls
{
    public class NameValueWrapper<T>
    {
        private Expression<Func<T, string>> _getName;
        private string _nullStringValue;

        public NameValueWrapper(T underlyingObject)
        {
            UnderlyingObject = underlyingObject;
        }

        public NameValueWrapper(T underlyingObject, Expression<Func<T, string>> getName, string nullStringValue = "Null")
            : this(underlyingObject)
        {
            _getName = getName;
            _nullStringValue = nullStringValue;
        }

        public T UnderlyingObject
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                if (_getName == null)
                    return UnderlyingObject.ToString();
                MemberExpression member = (MemberExpression)_getName.Body;
                Expression strExpr = member.Expression;
                if (strExpr.Type == typeof(String))
                {
                    String str = Expression.Lambda<Func<String>>(strExpr).Compile()();
                    return str;
                }
                if (UnderlyingObject != null)
                {
                    string propertyName = member.Member.Name;
                    Object value = _getName.Compile()(UnderlyingObject);
                    return value != null ? value.ToString() : _nullStringValue;
                }
                else
                {
                    return _nullStringValue;
                }
                
            }
        }
    
    }
}
