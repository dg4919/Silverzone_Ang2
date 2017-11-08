namespace Silverzone.Api.ViewModel.Admin
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int? CouponId { get; set; }
    }

}