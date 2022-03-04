using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace project_API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class SendMailController : Controller
    {
        [HttpPost("Send")]
        public IActionResult Send(GMail mail)
        {
            try
            {
                string messages = "姓名 : " + mail.Name + " 信箱 : " + mail.Mail + " 留言 : " + mail.Msg;
                MailMessage msg = new MailMessage(
                    "decision088@gmail.com",
                    "yuchen04040404@gmail.com",
                    "【系統訊息】用戶通知 ",
                    messages);

                // send email
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(@"decision088@gmail.com", @"pdauoyvkprdklgva");

                    //Gmial 的 smtp 使用 SSL
                    smtp.EnableSsl = true;

                    smtp.Send(msg);


                }

                SaveLog(mail);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        public void SaveLog(GMail mail)
        {

                DateTime currentTime = DateTime.Now;
                string Date = currentTime.ToString("d");
                string Time = currentTime.ToString("t");
                string Mail = mail.Mail;
                string Name = mail.Name;
                string Message = mail.Msg;
                string connString = "server=127.0.0.1;port=3306;user id=root;database=MailServer;charset=utf8;";
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = connString;
                    string sqlSTR = @"Insert into MailData values (@mail,@name,@message,@date,@time)";
                    conn.Query(sqlSTR, new { Mail, Name, Message, Date, Time });
                };
          
        }
    }
}
