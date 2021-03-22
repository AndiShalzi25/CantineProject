using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineCantineAPI.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Description { get; set; } = "Hi there everyone!!!";
        public string Code { get; set; } = "It's a secret";

        public bool isActive { get; set; } = true;
    }
}
