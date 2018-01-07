//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TheSoulOfBreadBakery.Models
//{
//    public class BreadReviewRepository : IBreadReviewRepository
//    {
//        private readonly AppDbContext _appDbContext;

//        public BreadReviewRepository(AppDbContext appDbContext)
//        {
//            _appDbContext = appDbContext;
//        }

//        public void AddBreadReview(BreadReview breadReview)
//        {
//            //_appDbContext.BreadReviews.Add(breadReview);
//            //_appDbContext.SaveChanges();
//        }

//        public IEnumerable<BreadReview> GetReviewsForBread(int breadId)
//        {
//            //return _appDbContext.BreadReviews.Where(b => b.Bread.BreadId == breadId);
//        }
//    }
//}
