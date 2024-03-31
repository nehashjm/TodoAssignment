using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Helpers;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
		public string Title { get { return $"Todo({todoModels.Count(x => !x.IsDone)}) Completed({todoModels.Count(x => x.IsDone)})"; }  }
		private ObservableCollection<TodoModel> todoModels = new ObservableCollection<TodoModel>();

		public ObservableCollection<TodoModel> TodoModels
        {
			get { return todoModels; }
			set { todoModels = value; }
		}
		private string _todoTitle;

		public string TodoTitle
        {
			get { return _todoTitle; }
			set { _todoTitle = value; OnPropertyChanged(nameof(TodoTitle)); }
		}

		private string _todoDescription;

       
        public string TodoDescription
        {
			get { return _todoDescription; }
			set { _todoDescription = value; OnPropertyChanged(nameof(TodoDescription)); }
		}
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
		public ICommand AddCommand { get; set; }
        internal void AddTodo()
        {
			if (string.IsNullOrEmpty(_todoTitle)) return;
            if (string.IsNullOrEmpty(_todoDescription)) return;
            TodoModel todo = new TodoModel {Title = _todoTitle , Description=_todoDescription };
			todo.PropertyChanged += Todo_PropertyChanged;
			TodoModels.Add(todo);
            TodoTitle = string.Empty;
            TodoDescription = string.Empty;
			OnPropertyChanged(nameof(Title));
        }

        private void Todo_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Title));
        }

        public TodoViewModel() 
		{
			AddCommand = new AddCommand(this);
			
		}

	}
}
