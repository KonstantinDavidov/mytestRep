﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class ThirdPartyData
    {
        partial void Initialize()
        {
            this.Attorney = new Attorneys();
        }
    }
}