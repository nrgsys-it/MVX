using System.ComponentModel;

namespace MVX
{
  public abstract class ViewStoreBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public void Refresh()
    {
      var handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(string.Empty));
    }
  }
}