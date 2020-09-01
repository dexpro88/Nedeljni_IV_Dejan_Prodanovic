using Nedeljni_IV_Dejan_Prodanovic.Command;
using Nedeljni_IV_Dejan_Prodanovic.Model;
using Nedeljni_IV_Dejan_Prodanovic.Service;
using Nedeljni_IV_Dejan_Prodanovic.Validation;
using Nedeljni_IV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_IV_Dejan_Prodanovic.ViewModelBase
{
    class RegisterViewModel:ViewModelBase
    {
        Register view;
        IUserService userService;

        public RegisterViewModel(Register registerView)
        {
            view = registerView;
            userService = new UserService();



            User = new tblUser();
         

        }


        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string gender = "male";
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }

        private void SaveExecute(object parameter)
        {
            try
            {
               
                //int age = ValidationClass.CountAge(dateOfBirth);
                //if (age < 18)
                //{
                //    string str1 = string.Format("JMBG is not valid\nEmployee has " +
                //        "to be at least 18 years old");
                //    MessageBox.Show(str1);
                //    return;
                //}

                //tblUser userInDb = userService.GetUserByUserName(User.Username);

                //if (userInDb != null)
                //{
                //    string str1 = string.Format("User with this username exists\n" +
                //        "Enter another username");
                //    MessageBox.Show(str1);
                //    return;
                //}

                //userInDb = userService.GetUserByJMBG(User.JMBG);

                //if (userInDb != null)
                //{
                //    string str1 = string.Format("User with this JMBG exists\n" +
                //        "Enter another JMBG");
                //    MessageBox.Show(str1);
                //    return;
                //}
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                string encryptedString = EncryptionHelper.Encrypt(password);
                User.Gender = Gender;
                User.DateOfBirth = DateOfBirth;
                User.Password = encryptedString;
                User = userService.AddUser(User);

                MessageBox.Show("You registered your account");
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object parameter)
        {

            if (String.IsNullOrEmpty(User.FirstName) || String.IsNullOrEmpty(User.LastName)
                ||String.IsNullOrEmpty(User.Email)
                || String.IsNullOrEmpty(User.Username) || parameter as PasswordBox == null
                ||   String.IsNullOrEmpty((parameter as PasswordBox).Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                LoginView registerView = new LoginView();
                registerView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
