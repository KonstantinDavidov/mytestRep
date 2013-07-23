using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities.Validation
{
    public interface IValidatableObject : IDataErrorInfo
    {
        IList<string> Errors { get; }
        bool IsValid { get; }
    }
}
