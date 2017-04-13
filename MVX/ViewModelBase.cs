using System;
using System.ComponentModel;

namespace MVX
{
  public abstract class ViewModelBase<TStore> : INotifyPropertyChanged where TStore : ViewStoreBase, new()
  {
    public TStore ViewStore { get; set; }

    protected ViewModelBase()
    {
      ViewStore = new TStore();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void UpdateViewStore(Action<TStore> actionToCommit)
    {
      ApplicationDispatcher.Invoke(() =>
      {
        actionToCommit(ViewStore);
        ViewStore.Refresh();
      });
    }

    protected void RegenerateStore()
    {
      ApplicationDispatcher.Invoke(() =>
      {
        ViewStore = new TStore();
        Refresh();
      });
    }

    private void Refresh()
    {
      if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
      if (ViewStore != null) ViewStore.Refresh();
    }
  }
}