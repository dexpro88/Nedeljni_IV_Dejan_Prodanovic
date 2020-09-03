using Nedeljni_IV_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_IV_Dejan_Prodanovic.Service
{
    interface IPostService
    {
        tblPost AddPost(tblPost post);
        List<tblPost> GetPosts();
    }
}
