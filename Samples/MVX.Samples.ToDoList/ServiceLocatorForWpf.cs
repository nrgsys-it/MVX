using MVX.Samples.ToDoList.Actions;
using MVX.Samples.ToDoList.Data;
using MVX.Samples.ToDoList.ViewModels;

/* evitiamo di usare un ioc container, però serve cmq un service locator per wpf
per il db usiamo una semplice concurrentbag injectata dal service locator */

namespace MVX.Samples.ToDoList
{
  internal class ServiceLocatorForWpf
  {
    private readonly ToDoItemsBag _toDoItemsBag;

    public ServiceLocatorForWpf()
    {
      _toDoItemsBag = new ToDoItemsBag();
    }

    public RootViewModel RootViewModel => new RootViewModel(new NewToDoItemActions(_toDoItemsBag));
  }
}
