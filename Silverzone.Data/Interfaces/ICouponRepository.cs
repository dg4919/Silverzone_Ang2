using Silverzone.Entities;
namespace Silverzone.Data
{
    public interface ICouponRepository : IRepository<Coupon>
    {
        Coupon GetByName(string Name);
        bool Iscoupon_Exist(int Id, string Name, CouponType type);
        bool check_Coupon(string Name, CouponType type);

    }
}
