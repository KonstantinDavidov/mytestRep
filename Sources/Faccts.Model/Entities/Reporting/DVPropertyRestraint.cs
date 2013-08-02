using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DVPropertyRestraint : ReactiveBase, IDVPropertyRestraint
    {
        private bool _isProtectedHasPropertyRestraint;
        private bool _isRestrainedHasPropertyRestraint;

        public DVPropertyRestraint()
        {
        }

        public DVPropertyRestraint(IDVPropertyRestraint propertyRestraint)
        {
            IsProtectedHasPropertyRestraint = propertyRestraint.IsProtectedHasPropertyRestraint;
            IsRestrainedHasPropertyRestraint = propertyRestraint.IsRestrainedHasPropertyRestraint;
        }

        public bool IsProtectedHasPropertyRestraint
        {
            get { return _isProtectedHasPropertyRestraint; }
            set
            {
                if (value.Equals(_isProtectedHasPropertyRestraint)) return;
                _isProtectedHasPropertyRestraint = value;
                OnPropertyChanged();
            }
        }

        public bool IsRestrainedHasPropertyRestraint
        {
            get { return _isRestrainedHasPropertyRestraint; }
            set
            {
                if (value.Equals(_isRestrainedHasPropertyRestraint)) return;
                _isRestrainedHasPropertyRestraint = value;
                OnPropertyChanged();
            }
        }
    }
}