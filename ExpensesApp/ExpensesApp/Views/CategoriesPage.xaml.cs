using System;
using System.Collections.Generic;
using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel ViewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as CategoriesViewModel;

            SizeChanged += CategoriesPage_SizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpensesPerCategory();
        }

        private void CategoriesPage_SizeChanged(object sender, EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";

            VisualStateManager.GoToState(titleLabel, visualState);
        }

        private void ExampleButton_Pressed(System.Object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(exampleButton, "Focused");
        }

        private void ExampleButton_Released(System.Object sender, System.EventArgs e)
        {
            VisualStateManager.GoToState(exampleButton, "Normal");
        }
    }
}

