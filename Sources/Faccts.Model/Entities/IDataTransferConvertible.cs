﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public interface IDataTransferConvertible<T>
    {
        T ToDTO();
    }
}
