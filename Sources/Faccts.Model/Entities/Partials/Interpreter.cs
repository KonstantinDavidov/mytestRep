using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Interpreter : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Interpreter>
    {

        public Interpreter() : base()
        {

        }

        public Interpreter(FACCTS.Server.Model.DataModel.Interpreter dto) : this()
        {
            if (dto == null)
                return;

            this.Id = dto.Id;
            this.PartyFor = dto.InterpreterFor;
            this.EntityType = dto.EntityType;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Sex = dto.Sex;
            this.DateOfBirth = dto.DateOfBirth;
            this.Contact = dto.Contact;
            this.Age = dto.Age;
            this.AddressInfo = new AddressInfo(dto.AddressInfo);
            this.Email = dto.Email;
            this.PersonType = FACCTS.Server.Model.Enums.PersonType.Interpreter;
            this.Language = dto.Language;
            //this.Appearances = 
            this.MarkAsUnchanged();
        }

        FACCTS.Server.Model.DataModel.Interpreter IDataTransferConvertible<FACCTS.Server.Model.DataModel.Interpreter>.ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Interpreter()
            {
                Id = this.Id,
                EntityType = this.EntityType,
                //InterpreterFor = this.PartyFor == Entities.PartyFor.Party1 ? this.CourtCase.Party1.ConvertToDTO() : this.CourtCase.Party2.ConvertToDTO(),
                FirstName = this.FirstName,
                LastName = this.LastName,
                Language = this.Language,
                InterpreterFor = this.PartyFor,
                CourtCaseForInterpreterId = this.CourtCaseId > 0 ? (long?)this.CourtCaseId : null,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
