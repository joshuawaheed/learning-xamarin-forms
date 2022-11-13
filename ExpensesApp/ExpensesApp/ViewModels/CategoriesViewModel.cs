using System;
using System.Collections.ObjectModel;
using System.Linq;
using ExpensesApp.Models;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel
    {
        public ObservableCollection<string> Categories { get; set; }

        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
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

        public void GetExpensesPerCategory()
        {
            CategoryExpensesCollection.Clear();
            float totalExpensesAmount = Expense.TotalExpensesAmount();

            foreach (var c in Categories)
            {
                var expenses = Expense.GetExpenses(c);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);

                CategoryExpenses ce = new CategoryExpenses
                {
                    Category = c,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };

                CategoryExpensesCollection.Add(ce);
            }
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
        }
    }
}

