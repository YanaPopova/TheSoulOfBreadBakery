using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSoulOfBreadBakery.Models;

namespace TheSoulOfBreadBakery.ViewModels
{
    public class BreadListViewModel
    {
        public IEnumerable<Bread> Breads { get; set; }
        public string CurrentCategory { get; set; }
    }
}
