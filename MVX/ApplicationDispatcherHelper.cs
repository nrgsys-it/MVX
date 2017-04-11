using System;
using System.Windows;

namespace MVX
{
  internal static class ApplicationDispatcherHelper
  {
    public static void Invoke(Action action)
    {
      Application.Current.Dispatcher.Invoke(action);
    }
  }
}