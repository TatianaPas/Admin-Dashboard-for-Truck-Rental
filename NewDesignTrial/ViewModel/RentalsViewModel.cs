using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewDesignTrial.Core;

namespace NewDesignTrial.ViewModel
{
    internal class RentalsViewModel : ObservableOject
    {
        public RelayCommand RentalsCommand { get; set; }
        public RelayCommand TruckViewCommand { get; set; }
        public RelayCommand CustomersCommand { get; set; }

        public RentalsViewModel RentalsVM { get; set; }
        public TrucksViewModel TrucksVM { get; set; }
        public CustomersViewModel CustomersVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public RentalsViewModel()
        {
            RentalsVM = new RentalsViewModel();
            CustomersVM = new CustomersViewModel();
            TrucksVM = new TrucksViewModel();
            CurrentView = RentalsVM;

            RentalsCommand = new RelayCommand(o =>
            {
                CurrentView = RentalsVM;
            });
            TruckViewCommand = new RelayCommand(o =>
            {
                CurrentView = TrucksVM;
            });
            CustomersCommand = new RelayCommand(o =>
            {
                CurrentView = CustomersVM;

            });
        }

    }
}
