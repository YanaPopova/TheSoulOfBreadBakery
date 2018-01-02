using System.Collections.Generic;
using TheSoulOfBreadBakery.Models;

namespace TheSoulOfBreadBakery.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bread> BreadsOfTheWeek { get; set; }
    }
}
