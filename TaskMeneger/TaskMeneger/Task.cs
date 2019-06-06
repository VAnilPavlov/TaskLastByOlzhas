using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskMeneger
{
    public class Task
    {
        public int Id { set; get; }                
        public string TaskName { set; get; }

        public DateTime? TimeStart { set; get; }
        //email
        public string HeadMessage { set; get; }
        public string BodyMessage { set; get; }
        public string PostName { set; get; }
        //download
        public string FromDownloadPath { set; get; }        
        public string NameFile { set; get; }
        //moveCatalog
        public string MovePath { set; get; }
        public string Catalog { set; get; }
       
    }
}
