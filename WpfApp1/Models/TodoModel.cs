using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class TodoModel : INotifyPropertyChanged
    {
		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; OnPropertyChanged(nameof(Title)); 
			}
			
		}
		private string _desription;

		public string Description
		{
			get { return _desription; }
			set { _desription = value; OnPropertyChanged(nameof(Description));
			}
		}

		private bool _isDone;

       
        public bool IsDone
		{
			get { return _isDone; }
			set { _isDone = value; OnPropertyChanged(nameof(IsDone));
			}
		}
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
