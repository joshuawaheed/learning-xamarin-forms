using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using ExpensesApp.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public Command AddExpenseCommand { get; set; }

        public ExpensesViewModel()
        {
            Expenses = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
            GetExpenses();
        }

        public void GetExpenses()
        {
            var expenses = Expense.GetExpenses();

            Expenses.Clear();

            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }

        public void AddExpense()
        {
            ShareReport();
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }

        public void ShareReport()
        {
            IShare shareDependency = DependencyService.Get<IShare>();
            shareDependency.Show("", "", "");
        }
    }
}

