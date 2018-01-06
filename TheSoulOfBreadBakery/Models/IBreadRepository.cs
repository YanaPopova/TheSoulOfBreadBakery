using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Models
{
    public interface IBreadRepository
    {
        IEnumerable<Bread> Breads { get; }
        IEnumerable<Bread> BreadsOfTheWeek { get; }

        Bread GetBreadById(int breadId);

        void CreateBread(Bread bread);

        void UpdateBread(Bread bread);
    }
}
