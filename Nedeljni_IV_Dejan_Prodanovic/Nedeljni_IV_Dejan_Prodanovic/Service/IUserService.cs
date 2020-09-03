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
        List<tblUser> GetFriends(tblUser user);
        tblUser AddUser(tblUser user);
        tblUser GetUserByUserNameAndPassword(string username, string password);
        tblUser GetUserByUserName(string username);
        tblUser GetUserById(int id);
        //tblUser GetUserByJMBG(string JMBG);
        //void DeleteUser(int UserId);
        void SendRequest(tblUser sendUser, tblUser recieveUser);
        void RefuseRequest(tblUser sendUser, tblUser recieveUser);
        void AcceptRequest(tblUser sendUser, tblUser recieveUser);
    }
}
