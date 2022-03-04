using Dapper;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace project_API.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class GetMailController : ControllerBase
    {

      


        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                string connString = "server=127.0.0.1;port=3306;user id=root;database=MailServer;charset=utf8;";
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = connString;
                    string sqlSTR = @"select * from MailData ";
                    var res = conn.Query<MailData>(sqlSTR).ToList();

                    return Ok(res);
                };
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }


       
    }
}
