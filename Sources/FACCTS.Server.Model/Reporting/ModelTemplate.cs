

using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FACCTS.Server.Model.ViewModels
{
    
			
	public partial class NewCourtCaseDialogViewModel
	{
		private string _caseNumber;
		public string CaseNumber
		{
			get{return _caseNumber;}
			set{
				if(_caseNumber!=value){
					_caseNumber = value;
				}
			}
		}
		
		private bool _isEditing;
		public bool IsEditing
		{
			get{return _isEditing;}
			set{
				if(_isEditing!=value){
					_isEditing = value;
				}
			}
		}
				
	}
	
}

