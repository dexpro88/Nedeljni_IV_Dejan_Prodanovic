using Nedeljni_IV_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_IV_Dejan_Prodanovic.Service
{
    interface IUserService
    {
        List<tblUser> GetUsers();
        tblUser AddUser(tblUser user);
        tblUser GetUserByUserNameAndPassword(string username, string password);
        tblUser GetUserByUserName(string username);
        //tblUser GetUserByJMBG(string JMBG);
        //void DeleteUser(int UserId);
        void SendRequest(tblUser sendUser, tblUser recieveUser);
    }
}
