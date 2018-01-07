using System.Collections.Generic;

namespace TheSoulOfBreadBakery.Models
{
    interface IBreadReviewRepository
    {
        void AddBreadReview(BreadReview breadReview);
        IEnumerable<BreadReview> GetReviewsForBread(int breadId);
    }
}
