using JewelleryApp.Classes;
using JewelleryApp.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JewelleryApp.ViewModel
{
    public class EstimationScreenViewModel : INotifyPropertyChanged
    {

        private string _welcomeUser;

        public string WelcomeUser
        {
            get
            {
                return _welcomeUser;
            }
            set
            {
                _welcomeUser = value;
                OnPropertyChanged("WelcomeUser");
            }
        }


        private double _goldPrice;

        public double GoldPrice
        {
            get
            {
                return _goldPrice;
            }
            set
            {
                _goldPrice = value;
                OnPropertyChanged("GoldPrice");
            }
        }

        private double _grams;
        public double Grams
        {
            get
            {
                return _grams;
            }
            set
            {
                _grams = value;
                OnPropertyChanged("Grams");
            }
        }

        private double _totalPrice;
        public double TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        private double _discount;
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                OnPropertyChanged("Discount");
            }
        }

        private bool _isDiscountAvailable;
        public bool IsDiscountAvailable
        {
            get
            {
                return _isDiscountAvailable;
            }
            set
            {
                _isDiscountAvailable = value;
                OnPropertyChanged("IsDiscountAvailable");
            }
        }

        private Visibility _isPrivileged;
        public Visibility IsPrivileged
        {
            get
            {
                return _isPrivileged;
            }
            set
            {
                _isPrivileged = value;
                OnPropertyChanged("IsPrivileged");
            }
        }


        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion

        #region ICommands

        private ICommand _calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                return _calculateCommand;
            }
            set
            {
                _calculateCommand = value;
            }
        }


        private ICommand _printToScreenCommand;
        public ICommand PrintToScreenCommand
        {
            get
            {
                return _printToScreenCommand;
            }
            set
            {
                _printToScreenCommand = value;
            }
        }

        private ICommand _printToFileCommand;
        public ICommand PrintToFileCommand
        {
            get
            {
                return _printToFileCommand;
            }
            set
            {
                _printToFileCommand = value;
            }
        }

        private ICommand _printToPaperCommand;
        public ICommand PrintToPaperCommand
        {
            get
            {
                return _printToPaperCommand;
            }
            set
            {
                _printToPaperCommand = value;
            }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand;
            }
            set
            {
                _closeCommand = value;
            }
        }


        #endregion

        public EstimationScreenViewModel(Users _user)
        {
            Discount = 2;
            _calculateCommand = new RelayCommand(CalculateExecute, CalculateCanExecute);
            _closeCommand = new RelayCommand(CloseExecute, CloseCanExecute);
            _printToScreenCommand = new RelayCommand(PrintToScreenExecute, PrintToScreenCanExecute);
            _printToFileCommand = new RelayCommand(PrintToFileExecute, PrintToFileCanExecute);
            _printToPaperCommand = new RelayCommand(PrintToPaperExecute, PrintToPaperCanExecute);

            IsDiscountAvailable = _user.PrivilegedUser;
            SetUser(IsDiscountAvailable);
        }

        private void SetUser(bool _setuser)
        {
            if (_setuser)
            {
                WelcomeUser = "Privileged User";
                IsPrivileged = Visibility.Visible;
            }
            else
            {
                WelcomeUser = "Regular User";
                IsPrivileged = Visibility.Collapsed;
            }
        }

        #region Buttons

        #region Calculate Button

        public void CalculateExecute(object obj)
        {
            if (WelcomeUser == "Privileged User")
            {
                if (Discount == 0)
                {
                    TotalPrice = (GoldPrice * Grams);
                }
                else
                {
                    double temp = ((GoldPrice * Grams) * Discount) / 100;
                    TotalPrice = (GoldPrice * Grams) - temp;
                }
            }
            else
            {
                TotalPrice = (GoldPrice * Grams);
            }

        }

        public bool CalculateCanExecute(object obj)
        {
            return true;
        }

        #endregion

        #region Close Button

        public void CloseExecute(object obj)
        {
            Application.Current.Shutdown();
        }

        public bool CloseCanExecute(object obj)
        {
            return true;
        }

        #endregion

        #region PrintToScreen Button

        public void PrintToScreenExecute(object obj)
        {
            MessageBox.Show("Total Price is :" + TotalPrice, "Information", MessageBoxButton.OK);
        }

        public bool PrintToScreenCanExecute(object obj)
        {
            return true;
        }

        #endregion

        #region PrintToFile Button

        public void PrintToFileExecute(object obj)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            File.WriteAllText(path + "Output.txt", "The total Price is" + " " + Convert.ToString(TotalPrice));
        }

        public bool PrintToFileCanExecute(object obj)
        {
            return true;
        }

        #endregion

        #region PrintToPaper Button

        public void PrintToPaperExecute(object obj)
        {
            //Dummy
        }

        public bool PrintToPaperCanExecute(object obj)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
