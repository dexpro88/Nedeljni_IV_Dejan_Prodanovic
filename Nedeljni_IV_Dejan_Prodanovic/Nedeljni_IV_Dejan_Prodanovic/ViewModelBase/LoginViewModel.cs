using Nedeljni_IV_Dejan_Prodanovic.Command;
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
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        

        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
           
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string password = (obj as PasswordBox).Password;



            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }
            

            //string encryptedString = EncryptionHelper.Encrypt(password);

            //tblUser user = userService.GetUserByUserNameAndPassword(UserName, encryptedString);
            //if (user != null)
            //{
            //    tblAdmin admin = adminService.GetAdminByUserId(user.UserID);

            //    if (admin != null)
            //    {
            //        if (admin.AdministratorType.Equals("System"))
            //        {
            //            AdminMainView adminMainView = new AdminMainView(admin);
            //            adminMainView.Show();
            //            view.Close();
            //            return;
            //        }
            //        else if (admin.AdministratorType.Equals("Local"))
            //        {
            //            LocaldAminMainView localAdminView = new LocaldAminMainView();
            //            localAdminView.Show();
            //            view.Close();
            //            return;
            //        }
            //        else if (admin.AdministratorType.Equals("Team"))
            //        {
            //            TeamAdminView teamAdminView = new TeamAdminView();
            //            teamAdminView.Show();
            //            view.Close();
            //            return;
            //        }

            //    }

            //    tblManager manager = managerService.GetManagerByUserId(user.UserID);

            //    if (manager != null)
            //    {
            //        if (string.IsNullOrEmpty(manager.ResponsibilityLevel))
            //        {
            //            string str1 = string.Format("You can not login\nLocal Admin has not gave you" +
            //                " responsibility level yet");
            //            MessageBox.Show(str1);
            //            return;
            //        }
            //        ManagerMainView managerMainView = new ManagerMainView(manager);
            //        managerMainView.Show();
            //        view.Close();
            //        return;
            //    }
            //    tblEmployee employee = employeeService.GetEmployeeByUserId(user.UserID);

            //    if (employee != null)
            //    {

            //        EmployeeMainView employeeMainView = new EmployeeMainView(employee);
            //        employeeMainView.Show();
            //        view.Close();
            //        return;
            //    }

            //    MessageBox.Show("Wrong username or password");
            //}
            

            
            //else
            //{
            //    MessageBox.Show("Wrong username or password");

            //}


        }

        //private ICommand register;
        //public ICommand Register
        //{
        //    get
        //    {
        //        if (register == null)
        //        {
        //            register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
        //        }
        //        return register;
        //    }
        //}

        //private void RegisterExecute()
        //{
        //    try
        //    {
        //        RegisterView register = new RegisterView();
        //        register.Show();
        //        view.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //private bool CanRegisterExecute()
        //{

        //    return true;
        //}

       
    }
}
