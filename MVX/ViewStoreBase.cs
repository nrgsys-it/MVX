using System.ComponentModel;

namespace MVX
{
  public abstract class ViewStoreBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public void Refresh()
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
    }
  }
}