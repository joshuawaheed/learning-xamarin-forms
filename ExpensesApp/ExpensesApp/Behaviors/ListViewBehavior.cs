using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;

namespace ExpensesApp.Behaviors
{
    public class ListViewBehavior : Behavior<ListView>
	{
        ListView listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            listView = bindable;
            listView.ItemSelected += ListView_ItemSelected;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            listView.ItemSelected -= ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Expense selectedExpense = listView.SelectedItem as Expense;
            ExpenseDetailsPage expenseDetailsPage = new ExpenseDetailsPage(selectedExpense);
            Application.Current.MainPage.Navigation.PushAsync(expenseDetailsPage);
        }
    }
}

