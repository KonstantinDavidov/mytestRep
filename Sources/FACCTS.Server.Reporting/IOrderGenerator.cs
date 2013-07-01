﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FACCTS.Server.Reporting
{
    public interface IOrderGenerator
    {
        void Run(string pathToPdf, Dictionary<string, string> mapper, object data);
    }
}