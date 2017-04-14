using System.Collections.Generic;
using MVX.Samples.ToDoList.Actions;
using MVX.Samples.ToDoList.Models;

namespace MVX.Samples.ToDoList.ViewModels
{
  /* le funzionalità da implementare saranno:
  * aggiungere to-do
  * modificare testo to-do
  * eliminare to-do
  * segnare to-do come fatti(archivio)
  * vedere to-do: tutti, da fare, completati */
  internal class RootViewModel : ViewModelBase<RootViewModel.State>
  {
    private readonly NewToDoItemActions _newToDoItemActions;

    public RootViewModel(NewToDoItemActions newToDoItemActions)
    {
      _newToDoItemActions = newToDoItemActions;
      DispatchCheckNewToDoText = _newToDoItemActions.CheckText.ToCommand(this);
      DispatchAddToDo = _newToDoItemActions.Add.ToCommand(this);
    }

    public string NewToDoItemText
    {
      get => ViewStore.NewToDoItemText;
      set => _newToDoItemActions.SetText.Dispatch(this, value);
    }

    public CommandWrapper<RootViewModel> DispatchCheckNewToDoText { get; }

    public CommandWrapper<RootViewModel> DispatchAddToDo { get; }

    public void UpdateToDoItemText(string parameter)
    {
      UpdateViewStore(store => store.NewToDoItemText = parameter);
    }

    public void UpdateNewToDoCanBeAdded(bool parameter)
    {
      UpdateViewStore(store => store.CanAddNewToDoItem = parameter);
    }

    public void UpdateAddedToDo(List<ToDoItem> toDoItems)
    {
      UpdateViewStore(store =>
      {
        store.ToDoItems = toDoItems;
        store.NewToDoItemText = string.Empty;
      });
    }

    internal class State : ViewStoreBase
    {
      public string NewToDoItemText { get; set; }
      public bool CanAddNewToDoItem { get; set; }
      public List<ToDoItem> ToDoItems { get; set; }
    }
  }
}