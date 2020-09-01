using Nedeljni_IV_Dejan_Prodanovic.Command;
using Nedeljni_IV_Dejan_Prodanovic.Model;
using Nedeljni_IV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_IV_Dejan_Prodanovic.ViewModelBase
{
    class UserMainViewModel:ViewModelBase
    {
        UserMain view;
        public UserMainViewModel(UserMain userView, tblUser userLogedIn)
        {
            view = userView;
            User = userLogedIn;
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
        private ICommand showUsers;
        public ICommand ShowUsers
        {
            get
            {
                if (showUsers == null)
                {
                    showUsers = new RelayCommand(param => ShowUsersExecute(), 
                        param => CanShowUsersExecute());
                }
                return showUsers;
            }
        }

        private void ShowUsersExecute()
        {
            try
            {
                Users users = new Users(User);
                users.ShowDialog();
                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowUsersExecute()
        {
            return true;
        }
        private ICommand showRequests;
        public ICommand ShowRequests
        {
            get
            {
                if (showRequests == null)
                {
                    showRequests = new RelayCommand(param => ShowRequestsExecute(),
                        param => CanShowRequestsExecute());
                }
                return showRequests;
            }
        }

        private void ShowRequestsExecute()
        {
            try
            {
                FriendRequests requests = new FriendRequests(User);
                requests.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowRequestsExecute()
        {
            return true;
        }
        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
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
 
