using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Models
{
    public class BreadRepository : IBreadRepository
    {
        private readonly AppDbContext _appDbContext;

        public BreadRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Bread> Breads
        {
            get
            {
                return _appDbContext.Breads.Include(c => c.Category);
            }
        }

        public IEnumerable<Bread> BreadsOfTheWeek
        {
            get
            {
                return _appDbContext.Breads.Include(c => c.Category).Where(b => b.IsBreadOfTheWeek);
            }
        }

        public Bread GetBreadById(int breadId)
        {
            return _appDbContext.Breads.FirstOrDefault(b => b.BreadId == breadId);
        }

        public void UpdateBread(Bread bread)
        {
            _appDbContext.Breads.Update(bread);
            _appDbContext.SaveChanges();
        }

        public void CreateBread(Bread bread)
        {
            _appDbContext.Breads.Add(bread);
            _appDbContext.SaveChanges();
        }
    }
}
