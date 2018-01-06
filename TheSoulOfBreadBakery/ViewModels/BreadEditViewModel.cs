using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TheSoulOfBreadBakery.Models;

namespace TheSoulOfBreadBakery.ViewModels
{
    public class BreadEditViewModel
    {
        public Bread Bread { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
