﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMeneger
{
    static public class TaskAction
    {
        static public bool IsActiv { set; get; } = true;

        static public void SendMessages(object task)
        {
            while (IsActiv)
            {
                if ((task as Task).TimeStart < DateTime.Now)
                {                    
                    var fromAddress = new MailAddress("olzhas.barakpaev@gmail.com");
                    var toAddress = new MailAddress((task as Task).PostName);                    

                    const string fromPassword = "titivi032312";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    smtp.EnableSsl = true;
                    using (var message = new MailMessage(fromAddress, toAddress)
                    { Subject = (task as Task).HeadMessage, Body = (task as Task).BodyMessage })
                    {
                        smtp.Send(message);
                    }

                    (task as Task).TimeStart = (task as Task).TimeStart.Value.AddYears(1);
                    Thread.Sleep(200);
                }
            }
        }

        static public void DownloadFile(object task)
        {
            while (IsActiv)
            {
                if ((task as Task).TimeStart < DateTime.Now)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile((task as Task).FromDownloadPath, (task as Task).NameFile);
                    }

                (task as Task).TimeStart = (task as Task).TimeStart.Value.AddYears(1);
                    Thread.Sleep(200);
                }
            }
        }

        static public void MoveCaralog(object task)
        {
            while (IsActiv)
            {
                if ((task as Task).TimeStart < DateTime.Now)
                {
                    DirectoryInfo dir = new DirectoryInfo((task as Task).Catalog);
                    dir.MoveTo((task as Task).MovePath + @"\NewFile");

                    (task as Task).TimeStart = (task as Task).TimeStart.Value.AddYears(1);
                    Thread.Sleep(200);
                }
            }
        }
    }
}
