﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(AttorneysViewModel))]
    public class AttorneysViewModel : ViewModelBase
    {
        public AttorneysViewModel() : base()
        {
            this.DisplayName = "Attorneys";
        }
    }
}