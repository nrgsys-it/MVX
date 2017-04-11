using System.Threading.Tasks;

namespace MVX
{
  public static class CommandExtensions
  {
    public static CommandWrapper<TViewModel> ToCommand<TViewModel>(this IDispatchableAction<TViewModel> action, TViewModel rootViewModel)
    {
      return new CommandWrapper<TViewModel>(action, rootViewModel);
    }

    public static Task Dispatch<TViewModel>(this IDispatchableAction<TViewModel> action, TViewModel rootViewModel, object parameter = null)
    {
      return new CommandWrapper<TViewModel>(action, rootViewModel).Dispatch(parameter);
    }

    public static CommandWrapper<TViewModel> ToCommand<TViewModel>(this DispatchableAction<TViewModel> action, TViewModel rootViewModel)
    {
      return new CommandWrapper<TViewModel>(new DispatchableActionWrapper<TViewModel>(action), rootViewModel);
    }

    public static Task Dispatch<TViewModel>(this DispatchableAction<TViewModel> action, TViewModel rootViewModel, object parameter = null)
    {
      return new CommandWrapper<TViewModel>(new DispatchableActionWrapper<TViewModel>(action), rootViewModel).Dispatch(parameter);
    }
  }
}