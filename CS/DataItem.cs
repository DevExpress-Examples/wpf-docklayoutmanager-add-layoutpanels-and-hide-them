using DevExpress.Mvvm;
using DevExpress.Xpf.Docking;

namespace DockingThreads {
    public class DataItem : BindableBase, IMVVMDockingProperties {
        public string Name {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int Value {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public bool IsHidden {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public string TargetName { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}
