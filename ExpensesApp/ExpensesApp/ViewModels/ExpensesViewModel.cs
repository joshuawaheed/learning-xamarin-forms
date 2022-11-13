using ExpensesApp.Models;
using System;
using System.Collections.ObjectModel;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        public ObservableCollection<Expense> Expenses { get; set; }

        public ExpensesViewModel()
        {
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
    }
}

