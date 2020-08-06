using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Docking;

namespace DockingThreads
{

    public interface ICustomService {
        void BeginUpdate();
        void EndUpdate();
    }

    public class CustomService : ServiceBaseGeneric<DockLayoutManager>, ICustomService {
        public void BeginUpdate() {
            this.AssociatedObject.BeginUpdate();
        }
        public void EndUpdate() {
            this.AssociatedObject.EndUpdate();
        }
    }
}