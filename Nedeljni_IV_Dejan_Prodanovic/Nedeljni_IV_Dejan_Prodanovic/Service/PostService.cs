using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nedeljni_IV_Dejan_Prodanovic.Model;

namespace Nedeljni_IV_Dejan_Prodanovic.Service
{
    class PostService : IPostService
    {
        public tblPost AddPost(tblPost post)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {

                    tblPost newPost = new tblPost();
                    newPost.PostText = post.PostText;
                    newPost.DateOfPost = DateTime.Now;
                    newPost.UserID = post.UserID;

                    context.tblPosts.Add(newPost);
                    context.SaveChanges();

                    return newPost;


                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPost GetPostById(int id)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {


                    tblPost post = (from x in context.tblPosts
                                    where x.PostID == id

                                    select x).First();

                    return post;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblPost> GetPosts()
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {
                    List<tblPost> list = new List<tblPost>();
                    list = (from x in context.tblPosts select x).ToList();


                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void LikePost(tblPost post, tblUser user)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {


                    tblPost postInDB = (from x in context.tblPosts
                                    where x.PostID==post.PostID

                                    select x).First();

                    tblUser userInDb = (from x in context.tblUsers
                                        where x.UserID == user.UserID

                                        select x).First();

                    if (postInDB.NumberOfLikes==null)
                    {
                        postInDB.NumberOfLikes = 1;
                    }
                    else
                    {
                        postInDB.NumberOfLikes += 1;
                    }
                    postInDB.tblUsers.Add(userInDb);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                 
            }
        }

        public List<tblUser> UsersThatLikedPost(int id)
        {
            try
            {
                using (SocialNetworkDbEntities context = new SocialNetworkDbEntities())
                {


                    tblPost postInDB = (from x in context.tblPosts
                                        where x.PostID == id

                                        select x).First();





                    return postInDB.tblUsers.ToList();
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
