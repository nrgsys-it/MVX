using System.Threading.Tasks;

namespace MVX
{
  public interface IDispatchableAction<in TViewModel>
  {
    Task Execute(object parameter, TViewModel viewModel, TViewModel storesSnapshot);
  }

  public delegate Task DispatchableAction<in TViewModel>(object parameter, TViewModel viewModel, TViewModel storesSnapshot);
}