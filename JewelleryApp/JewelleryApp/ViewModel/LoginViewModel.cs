using JewelleryApp.Classes;
using JewelleryApp.Commands;
using JewelleryApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace JewelleryApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region ICommands

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand;
            }
            set
            {
                _loginCommand = value;
            }
        }


        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand;
            }
            set
            {
                _cancelCommand = value;
            }
        }

        #endregion

        #region Properties

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }


        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private ObservableCollection<Users> _listUsers;
        public ObservableCollection<Users> ListUsers
        {
            get { return _listUsers; }
            set
            {
                _listUsers = value;
                OnPropertyChanged("ListUsers");
            }
        }

        #endregion

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

        public LoginViewModel()
        {
            ListUsers = new ObservableCollection<Users>();
            ReadUserFromXmlFile();
            _loginCommand = new RelayCommand(LoginExecute, LoginCanExecute);
            _cancelCommand = new RelayCommand(CancelExecute, CancelCanExecute);
        }

        #region Login Button

        public void LoginExecute(object obj)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    Users list = ListUsers.Where(x => x.Username == Username).FirstOrDefault();
                    if (list != null)
                    {
                        if (Username == list.Username)
                        {
                            if (Password == list.Password)
                            {
                                MainWindowViewModel.MainWindowViewModelObj.CurrentView = new EstimationScreenView(list);
                            }
                            else
                            {
                                MessageBox.Show("Entered Password is wrong!", "Information", MessageBoxButton.OK);
                                ClearTextBoxValues();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username doesn't exist!", "Information", MessageBoxButton.OK);
                        ClearTextBoxValues();
                    }

                }
                else
                {
                    MessageBox.Show("Password cannot be empty!", "Information", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Username cannot be empty!", "Information", MessageBoxButton.OK);
            }

        }

        public bool LoginCanExecute(object obj)
        {
            if ((string.IsNullOrEmpty(Username)) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Cancel Button

        public void CancelExecute(object obj)
        {
            ClearTextBoxValues();
        }

        public bool CancelCanExecute(object obj)
        {
            return true;
        }

        #endregion

        public void ReadUserFromXmlFile()
        {

            string filename = AppDomain.CurrentDomain.BaseDirectory + "Users.xml";

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(filename);
            reader.Read();
            doc.Load(reader);

            string username = string.Empty, password = string.Empty;
            bool privileged = false;
            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("User");
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {

                    for (int z = 0; z < list[i].ChildNodes.Count; z++)
                    {
                        XmlNode child = list[i].ChildNodes[z];

                        if (child.Name == "Username")
                        {
                            username = child.InnerText;
                        }
                        if (child.Name == "Password")
                        {
                            password = child.InnerText;
                        }
                        if (child.Name == "Privileged")
                        {
                            privileged = Convert.ToBoolean(child.InnerText.ToString());

                            var obj = new Users()
                            {
                                Username = username,
                                Password = password,
                                PrivilegedUser = privileged
                            };
                            ListUsers.Add(obj);
                        }
                    }
                }
            }

        }

        private void ClearTextBoxValues()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
