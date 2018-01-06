using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Models.Auth
{
    public class BakeryClaimTypes
    {
        public static List<string> ClaimsList { get; set; } = new List<string> { "Delete Bread", "Add Bread", "Age for ordering" };
    }
}
