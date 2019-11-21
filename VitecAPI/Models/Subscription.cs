using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecAPI.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public string SubscriptionType { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
