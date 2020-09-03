using Nedeljni_IV_Dejan_Prodanovic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_IV_Dejan_Prodanovic.ViewModelBase
{
    class PostDto
    {

        public int PostID { get; set; }
        public Nullable<System.DateTime> DateOfPost { get; set; }
        public string PostText { get; set; }
        public Nullable<int> NumberOfLikes { get; set; }
        public Nullable<int> UserID { get; set; }
        public tblUser User { get; set; }

        
    }
}
