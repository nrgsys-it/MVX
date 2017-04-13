using System;

namespace MVX
{
  public static class ApplicationDispatcher
  {
    public static IDispatchActions Dispatcher { get; set; }

    static ApplicationDispatcher()
    {
      Dispatcher = new CurrentApplicationDispatcher();
    }

    internal static void Invoke(Action action)
    {
      Dispatcher.Invoke(action);
    }
  }
}