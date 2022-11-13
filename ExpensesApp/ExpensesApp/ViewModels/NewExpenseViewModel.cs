using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExpensesApp.Models;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpenseViewModel : INotifyPropertyChanged
    {
        private string expenseName;

        public string ExpenseName
        {
            get { return expenseName; }
            set
            {
                expenseName = value;
                OnPropertyChanged(nameof(ExpenseName));
            }
        }

        private string expenseDescription;

        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged(nameof(ExpenseDescription));
            }
        }

        private float expenseAmount;

        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged(nameof(ExpenseAmount));
            }
        }

        private DateTime expenseDate;

        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged(nameof(ExpenseDate));
            }
        }

        private string expenseCategory;

        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged(nameof(ExpenseCategory));
            }
        }

        public Command SaveExpenseCommand { get; set; }

        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<ExpenseStatus> ExpenseStatuses { get; set; }

        public NewExpenseViewModel()
        {
            ExpenseDate = DateTime.Today;
            ExpenseStatuses = new ObservableCollection<ExpenseStatus>();
            SaveExpenseCommand = new Command(InsertExpense);
            Categories = new ObservableCollection<string>();
            GetCategories();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void InsertExpense()
        {
            var vm = this;

            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            int response = Expense.InsertExpense(expense);

            if (response > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "Ok");
            }
        }

        public void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void GetExpenseStatus()
        {
            ExpenseStatuses.Clear();
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 2",
                Status = true
            });
            ExpenseStatuses.Add(new ExpenseStatus
            {
                Name = "Random 3",
                Status = false
            });
        }

        public class ExpenseStatus
        {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}

