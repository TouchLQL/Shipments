using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGame.Models
{
    public class CodaResponseModelInfo
    {
        public string txn_id { get; set; }
        public string txn_timeout { get; set; }
        public string result_code { get; set; }
        public string total_price { get; set; }
        public string pay_instructions { get; set; }
        public string profile { get; set; }
    }
}