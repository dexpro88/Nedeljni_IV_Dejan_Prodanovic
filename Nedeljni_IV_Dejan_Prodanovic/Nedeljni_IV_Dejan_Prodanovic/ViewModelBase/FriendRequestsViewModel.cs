using Nedeljni_IV_Dejan_Prodanovic.Command;
using Nedeljni_IV_Dejan_Prodanovic.Model;
using Nedeljni_IV_Dejan_Prodanovic.Service;
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
    class FriendRequestsViewModel:ViewModelBase
    {
        FriendRequests view;
        IUserService userService;

        public FriendRequestsViewModel(FriendRequests friendRequests, tblUser userLogedIn)
        {
            view = friendRequests;
            User = userLogedIn;
            userService = new UserService();

            var listOfUsers = userService.GetUsers().Where(u => u.UserID != User.UserID).ToList();
           

            using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
            {
                 
                    tblUser userInDb = (from x in context.tblUsers
                                        where x.UserID == User.UserID
                                        select x).First();

                UserList = userInDb.tblUsers.ToList();



            }

            SelectedUser = UserList.FirstOrDefault();
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

        private tblUser selectedUser;
        public tblUser SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
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


        private ICommand sendRequest;
        public ICommand SendRequest
        {
            get
            {
                if (sendRequest == null)
                {
                    sendRequest = new RelayCommand(param => SendRequestExecute(),
                        param => CanSendRequestExecute());
                }
                return sendRequest;
            }
        }

        private void SendRequestExecute()
        {
            try
            {
                //MessageBox.Show("Poslao");
                //userService.SendRequest(User, SelectedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSendRequestExecute()
        {
            using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
            {
                if (SelectedUser != null)
                {
                    tblUser userInDb = (from x in context.tblUsers
                                        where x.UserID == User.UserID
                                        select x).First();

                    var list = userInDb.tblUsers.Select(item => item.UserID).ToList();

                    if (list.Contains(SelectedUser.UserID))
                    {
                        return false;
                    }
                }

            }

            return true;
        }
    }
}
