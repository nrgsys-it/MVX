using System;

namespace MVX
{
  public interface IDispatchActions
  {
    void Invoke(Action action);
  }
}