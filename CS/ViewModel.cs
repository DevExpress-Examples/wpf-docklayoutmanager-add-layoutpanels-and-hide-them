using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DockingThreads
{
    public class ViewModel : ViewModelBase {
        public ICustomService DockLayoutManagerService { get { return this.GetService<ICustomService>(); } }
        public ICommand AddNewCommand { get; private set; }
        public ICommand HideAllCommand { get; private set; }
        
        public ObservableCollection<DataItem> Source {
            get { return GetValue<ObservableCollection<DataItem>>(); }
            set { SetValue(value); }
        }

        public ViewModel() {
            Source = new ObservableCollection<DataItem>();
            for (int i = 0; i < 10; i++) {
                Source.Add(new DataItem() { Name = "Name" + i.ToString(), Value = i, TargetName = "host" });
            }            
            AddNewCommand = new DelegateCommand(AddNew);
            HideAllCommand = new DelegateCommand(HideAll);
        }

        void AddNew() {
            DockLayoutManagerService.BeginUpdate();
            for (int i = 0; i < 10; i++) {
                Source.Add(new DataItem() { Name = "Name" + i.ToString(), Value = i, TargetName = "host" });
            }
            DockLayoutManagerService.EndUpdate();
        }
        void HideAll() {
            DockLayoutManagerService.BeginUpdate();
            Source.ToList().ForEach(x => x.IsHidden = true);
            DockLayoutManagerService.EndUpdate();
        }

    }
}
