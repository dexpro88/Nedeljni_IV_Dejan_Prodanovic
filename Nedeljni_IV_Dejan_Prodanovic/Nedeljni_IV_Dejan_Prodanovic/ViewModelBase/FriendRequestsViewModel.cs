using Nedeljni_IV_Dejan_Prodanovic.Command;
using Nedeljni_IV_Dejan_Prodanovic.Model;
using Nedeljni_IV_Dejan_Prodanovic.Service;
using Nedeljni_IV_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


        private ICommand accept;
        public ICommand Accept
        {
            get
            {
                if (accept == null)
                {
                    accept = new RelayCommand(param => AcceptExecute(),
                        param => CanAcceptExecute());
                }
                return accept;
            }
        }

        private void AcceptExecute()
        {
            try
            {
                userService.AcceptRequest(SelectedUser, User);
                string friend = SelectedUser.Username;

                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {
                    tblUser userInDb = (from x in context.tblUsers
                                        where x.UserID == User.UserID
                                        select x).First();
                    UserList = userInDb.tblUsers.ToList();
                }
                Thread.Sleep(1000);
                string str = string.Format("You are now friend with {0} .", friend);
                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAcceptExecute()
        {
          

            return true;
        }

        private ICommand refuse;
        public ICommand Refuse
        {
            get
            {
                if (refuse == null)
                {
                    refuse = new RelayCommand(param => RefuseExecute(),
                        param => CanRefuseExecute());
                }
                return refuse;
            }
        }

        private void RefuseExecute()
        {
            try
            {
                userService.RefuseRequest(SelectedUser,User);
                string friend = SelectedUser.Username;

                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {
                    tblUser userInDb = (from x in context.tblUsers
                                        where x.UserID == User.UserID
                                        select x).First();
                    UserList = userInDb.tblUsers.ToList();
                }

                Thread.Sleep(1000);
                string str = string.Format("You refused friend request from {0} .", friend);
                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRefuseExecute()
        {


            return true;
        }
    }
}
