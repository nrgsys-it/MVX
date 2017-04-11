using System.Threading.Tasks;

namespace MVX
{
  internal class DispatchableActionWrapper<TViewModel> : IDispatchableAction<TViewModel>
  {
    private readonly DispatchableAction<TViewModel> _action;

    public DispatchableActionWrapper(DispatchableAction<TViewModel> action)
    {
      _action = action;
    }

    public Task Execute(object parameter, TViewModel viewModel, TViewModel storesSnapshot)
    {
      return _action(parameter, viewModel, storesSnapshot);
    }
  }
}