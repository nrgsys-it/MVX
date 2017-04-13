using System;
using System.Windows;

namespace MVX
{
  internal class CurrentApplicationDispatcher : IDispatchActions
  {
    public void Invoke(Action action)
    {
      Application.Current.Dispatcher.Invoke(action);
    }
  }
}