using System;
using System.Diagnostics;
using System.Windows.Input;

namespace WpfMahAppsMetro.Mvvm;

internal class BaseCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public BaseCommand(Action execute) : this(execute, null)
    {
    }

    public BaseCommand(Action execute, Func<bool> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    [DebuggerStepThrough]
    public bool CanExecute(object? parameter)
        => _canExecute is null || _canExecute();

    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            _canExecute();
        }
    }

    public void RaiseCanExecuteChanged()
        => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    public event EventHandler? CanExecuteChanged;
}