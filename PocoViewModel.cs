using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace POCOViewModelsWithChangesTracking
{
    [POCOViewModel]
    public class PocoViewModel : ViewModelBase
    {
        public ChangeTracker ChangeTracker { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsChanged { get; protected set; }
        public static PocoViewModel Create()
        {
           return ViewModelSource.Create(() => new PocoViewModel());
        }

        protected PocoViewModel() 
        {
            Name = string.Empty;
            ChangeTracker = new(this);
            ChangeTracker.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(ChangeTracker.IsChanged))
                {
                    IsChanged = ChangeTracker.IsChanged;
                }
            };
        }

        [Command]
        public void AcceptChanges() 
        {
            ChangeTracker.AcceptChanges();
        }
    }
}
