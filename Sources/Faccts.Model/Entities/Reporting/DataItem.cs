using FACCTS.Server.Model.OrderModels;
using FACCTS.Server.Model.Reporting.Entities;

namespace Faccts.Model.Entities.Reporting
{
    public class DataItem : ReactiveBase, IDataItem
    {
        private string _description;
        private string _name;

        public DataItem()
        {
        }

        public DataItem(IDataItem dataItem)
        {
            Name = dataItem.Name;
            Description = dataItem.Description;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}