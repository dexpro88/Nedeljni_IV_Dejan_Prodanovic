using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nedeljni_IV_Dejan_Prodanovic.Model;

namespace Nedeljni_IV_Dejan_Prodanovic.Service
{
    class UserService : IUserService
    {
        public tblUser AddUser(tblUser user)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {

                    tblUser newUser = new tblUser();
                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;
                    newUser.Email = user.Email;
                    newUser.Gender = user.Gender;
                    newUser.Location = user.Location;
                    newUser.DateOfBirth = user.DateOfBirth;
                    newUser.Username = user.Username;
                    newUser.Password = user.Password;

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();

                    return newUser;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void SendRequest(tblUser sendUser, tblUser recieveUser)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {

                    tblUser sendUserInDb = (from u in context.tblUsers
                                          where u.UserID == sendUser.UserID
                                          select u).First();

                    tblUser recieveUserInDb = (from u in context.tblUsers
                                            where u.UserID == recieveUser.UserID
                                            select u).First();

                    recieveUserInDb.tblUsers.Add(sendUserInDb);
                    //recieveUserInDb.tblUsers.Add(sendUserInDb);


                    context.SaveChanges();



                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());

            }
        }

        public tblUser GetUserByUserName(string username)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {


                    tblUser user = (from x in context.tblUsers
                                    where x.Username.Equals(username)

                                    select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblUser GetUserByUserNameAndPassword(string username, string password)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {


                    tblUser user = (from x in context.tblUsers
                                    where x.Username.Equals(username)
                                    && x.Password.Equals(password)
                                    select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblUser> GetUsers()
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();

                     
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
