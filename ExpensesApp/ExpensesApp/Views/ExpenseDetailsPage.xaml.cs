using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class ExpenseDetailsPage : ContentPage
	{
		ExpenseDetailsViewModel ViewModel;

		public ExpenseDetailsPage()
		{
			InitializeComponent();
		}

		public ExpenseDetailsPage(Models.Expense expense)
		{
			InitializeComponent();

			ViewModel = Resources["vm"] as ExpenseDetailsViewModel;
			ViewModel.Expense = expense;
		}
	}
}

