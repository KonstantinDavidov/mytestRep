using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FACCTS.Server.Model.OrderModels
{
    public interface IDataItem
    {
        string Name {get; set;}
        string Description { get; set; }
    }
}
