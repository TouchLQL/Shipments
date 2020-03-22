using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGame.Models
{
    public class CodaModelInfo
    {
        public string api_key { get; set; }
        public string order_id { get; set; }
        public string lang { get; set; }
        public string merchant_name { get; set; }
        public string pay_type { get; set; }
        public string mno_code { get; set; }
        public string msisdn { get; set; }
        public string type { get; set; }
        public List<Item> items { get; set; }
        public string profile { get; set; }
    }
    public class Item
    {
        public string code { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}