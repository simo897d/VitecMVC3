using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecMVC3.Models
{
    public class Subscription {
        public string SubscriptionType { get; set; }
        public double Price { get; set; }
        public DateTime StartDate{get;set;}
        public DateTime EndDate { get; set; }
    }
}
