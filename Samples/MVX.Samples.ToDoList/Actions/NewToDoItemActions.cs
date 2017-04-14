using System.Threading.Tasks;
using MVX.Samples.ToDoList.Data;
using MVX.Samples.ToDoList.Models;
using MVX.Samples.ToDoList.ViewModels;

namespace MVX.Samples.ToDoList.Actions
{
  internal class NewToDoItemActions
  {
    private readonly ToDoItemsBag _toDoItemsBag;

    public NewToDoItemActions(ToDoItemsBag toDoItemsBag)
    {
      _toDoItemsBag = toDoItemsBag;
    }

    public DispatchableAction<RootViewModel> SetText
    {
      get => async (parameter, viewModel, storesSnapshot) =>
      {
        viewModel.UpdateToDoItemText((string) parameter);
        await viewModel.DispatchCheckNewToDoText.Dispatch();
      };
    }

    public DispatchableAction<RootViewModel> CheckText
    {
      get => (parameter, viewModel, storesSnapshot) => 
        Task.Run(() => viewModel.UpdateNewToDoCanBeAdded(!string.IsNullOrWhiteSpace(storesSnapshot.NewToDoItemText)));
    }

    public DispatchableAction<RootViewModel> Add
    {
      get => async (parameter, viewModel, storesSnapshot) =>
      {
        _toDoItemsBag.Add(new ToDoItem {Text = storesSnapshot.NewToDoItemText});
        viewModel.UpdateAddedToDo(_toDoItemsBag.GetAll());
        await viewModel.DispatchCheckNewToDoText.Dispatch();
      };
    }
  }
}