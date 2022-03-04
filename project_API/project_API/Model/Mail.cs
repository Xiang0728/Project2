using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class GMail
    {
        public string Msg { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
    }

public class MailData :GMail
{
    public string Date { get; set; }
    public string Time { get; set; }

    public string Message { get; set; }

}

