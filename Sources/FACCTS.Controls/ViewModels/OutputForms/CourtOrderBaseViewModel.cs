using System.Collections.Generic;
using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Enums;
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    public abstract class CourtOrderBaseViewModel<T> : CourtOrderWithTypeViewModel where T : OrderBase
    {
        public T Order { get; set; }
    }
}