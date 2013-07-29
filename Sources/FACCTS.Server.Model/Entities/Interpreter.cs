using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class Interpreter : PersonBase
    {
        public Interpreter()
        {
        }
        public string Language { get; set; }

        public long? CourtCaseForInterpreterId { get; set; }

        public CourtCase CourtCaseForInterpreter { get; set; }

        public PartyFor InterpreterFor { get; set; }
    }
}
