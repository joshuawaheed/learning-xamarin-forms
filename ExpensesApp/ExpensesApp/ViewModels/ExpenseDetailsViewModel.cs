using ExpensesApp.Models;
using System.ComponentModel;

namespace ExpensesApp.ViewModels
{
    public class ExpenseDetailsViewModel : INotifyPropertyChanged
	{
		private Expense _expense;

		public Expense Expense
		{
			get { return _expense; }
			set
			{
				_expense = value;
				OnPropertyChanged(nameof(Expense));
			}
		}

		public ExpenseDetailsViewModel()
		{
		}

        public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}

