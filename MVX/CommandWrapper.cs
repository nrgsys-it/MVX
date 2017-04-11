using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVX
{
  public class CommandWrapper<TViewModel> : ICommand
  {
    private readonly IDispatchableAction<TViewModel> _action;
    private readonly TViewModel _viewModel;
    private bool _canExecute;

    public event EventHandler CanExecuteChanged;

    public CommandWrapper(IDispatchableAction<TViewModel> action, TViewModel viewModel)
    {
      _action = action;
      _viewModel = viewModel;
      _canExecute = true;
    }

    bool ICommand.CanExecute(object parameter)
    {
      return _canExecute;
    }

    void ICommand.Execute(object parameter)
    {
      Dispatch(parameter);
    }

    public Task Dispatch(object parameter = null)
    {
      ChangeCanExecuteTo(false);
      return _action
//        .Execute(parameter, _viewModel, (TViewModel) _viewModel.CopyStores())
        .Execute(parameter, _viewModel, (TViewModel) _viewModel.Copy<object>())
        .ContinueWith(t => ChangeCanExecuteTo(true), new CancellationToken());
    }

    private void ChangeCanExecuteTo(bool boolean)
    {
      _canExecute = boolean;
      RaiseCanExecuteChanged();
    }

    private void RaiseCanExecuteChanged()
    {
      if (CanExecuteChanged == null) return;
      Task.Run(() => ApplicationDispatcherHelper.Invoke(() => CanExecuteChanged(this, EventArgs.Empty)));
    }
  }
}