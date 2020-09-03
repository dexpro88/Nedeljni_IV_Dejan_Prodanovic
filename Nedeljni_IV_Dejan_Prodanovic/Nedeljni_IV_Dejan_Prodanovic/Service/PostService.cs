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
    }
}
