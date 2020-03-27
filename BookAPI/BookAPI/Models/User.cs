using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string userName { get; set; }
        public string userAddress { get; set; }
        public string userContactNumber { get; set; }
    }
}
