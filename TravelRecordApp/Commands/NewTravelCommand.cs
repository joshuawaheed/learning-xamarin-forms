using System;
using System.Windows.Input;
using TravelRecordApp.ViewModels;

namespace TravelRecordApp.Commands
{
    public class NewTravelCommand : ICommand
    {
        private readonly HomeViewModel _homeViewModel;

        public event EventHandler CanExecuteChanged;

        public NewTravelCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _homeViewModel.NewTravelNavigation();
        }
    }
}
