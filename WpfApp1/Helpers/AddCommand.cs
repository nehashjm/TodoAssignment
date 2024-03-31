using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.ViewModels;

namespace WpfApp1.Helpers
{
    class AddCommand : ICommand
    {
        private readonly TodoViewModel vm;

        public event EventHandler? CanExecuteChanged;
        public AddCommand(TodoViewModel vm)
        {
            this.vm = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            vm.AddTodo();
        }
    }
}
