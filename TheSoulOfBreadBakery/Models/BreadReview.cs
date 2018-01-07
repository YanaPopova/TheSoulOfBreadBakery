namespace TheSoulOfBreadBakery.Models
{
    public class BreadReview
    {
        public int BreadReviewId { get; set; }
        public Bread Bread { get; set; }
        public string Review { get; set; }
    }
}