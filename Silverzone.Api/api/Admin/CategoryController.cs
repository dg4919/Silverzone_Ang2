using Silverzone.Data;
using Silverzone.Entities;
using Silverzone.Api.ViewModel.Admin;
using System.Linq;
using System.Web.Http;

namespace Silverzone.Api.api.Admin
{
    public class CategoryController : ApiController
    {
        ICategoryRepository categoryRepository;
        ICouponRepository couponRepository;

        [HttpPost]
        public IHttpActionResult Create(CategoryViewModel model)
        {
            if (model != null)
            {
                if (categoryRepository.GetByName(model.Name).Count == 0)
                {
                    categoryRepository.Create(new Category()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        is_Active = true,
                        CouponId = model.CouponId                        
                    });

                    return Ok(new { result = "Success" });
                }
            }
            return Ok(new { result = "error" });
        }

        [HttpGet]
        public IHttpActionResult List()
        {
            // anonymous properties
            var category = categoryRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Name,
                x.Description,
                Status = x.is_Active,
                x.Coupons.Coupon_name,
                x.CouponId,
                x.CreationDate,
                x.CreatedBy,
                x.UpdationDate,
                x.UpdatedBy
            });

            return Ok(new { result = category });
        }

        [HttpPost]  // automatically assign value if send from ajax in a single model
        public IHttpActionResult Edit(CategoryViewModel model)
        {
            if (model != null)
            {
                // if record is not exist only the update
                if (!categoryRepository.Iscategory_Exist(model.Name, model.Id))
                {
                    //  find record and update data which is nescessary
                    var category = categoryRepository.GetById(model.Id);
                    category.Name = model.Name;
                    category.Description = model.Description;
                    category.is_Active = model.Status;
                    category.CouponId = model.CouponId;

                    // update records
                    categoryRepository.Update(category);
                    return Ok(new { result = "Success" });
                }
            }

            return Ok(new { result = "error" });
        }

        [HttpGet]
        public IHttpActionResult Delete(int categoryId)
        {
            if (categoryId != 0)
            {
                categoryRepository.Delete(categoryRepository.
                    GetById(categoryId));

                return Ok(new { result = "Category deleted sucessfully" });
            }
            return Ok(new { result = "Category is not found" });
        }

        [HttpGet]
        public IHttpActionResult Search(string name, bool status)
        {
            var List = name == null ?
                         categoryRepository.GetByStatus(status) :
                         categoryRepository.GetByNameAndStatus(name, status);

            var result = List.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = x.is_Active,
                CouponId = x.Coupons.Id,
                CreatedBy = x.CreatedBy,
                CreationDate = x.CreationDate,
                UpdatedBy = x.UpdatedBy,
                UpdationDate = x.UpdationDate
            });

            return Ok(new { result = result });
        }


        // *****************  Coupon for Category of Book code start from Here  ****************************

        [HttpPost]
        public IHttpActionResult coupon_Create(Coupon model)
        {
            if (model != null)
            {
                if (couponRepository.check_Coupon(model.Coupon_name, model.DiscountType))
                    return Ok(new { result = "exist" });

                model.is_Active = true;
                couponRepository.Create(model);

                return Ok(new { result = "Success" });
            }
            return Ok(new { result = "error" });
        }

        [HttpGet]
        public IHttpActionResult coupon_names()
        {
            // anonymous properties
            var category = couponRepository.GetAll()
                .Where(x => x.is_Active == true)
                .Select(x => new
                {
                    x.Id,
                    x.Coupon_name
                });

            return Ok(new { result = category });
        }


        [HttpGet]
        public IHttpActionResult coupon_List()
        {
            // anonymous properties
            var category = couponRepository.GetAll()
                .Select(x => new
                {
                    x.Id,
                    x.Coupon_name,
                    x.Description,
                    x.Coupon_amount,
                    x.Start_time,
                    x.End_time,
                    x.is_Active,
                    DiscountType = x.DiscountType,
                    DiscountName = x.DiscountType == CouponType.FlatDiscount ? "Flat Discount" : "Percentage Discount"
                });

            return Ok(new { result = category });
        }

        [HttpPost]
        public IHttpActionResult coupon_Edit(Coupon model)
        {
            if (model != null && ModelState.IsValid)
            {
                // if record is not exist only the update
                if (couponRepository.Iscoupon_Exist(model.Id, model.Coupon_name, model.DiscountType))
                    return Ok(new { result = "exist" });

                // update records > no need to find model > bcoz model is already have same & updated type
                couponRepository.Update(model);
                return Ok(new { result = "Success" });
            }

            return Ok(new { result = "error" });
        }

        [HttpGet]
        public IHttpActionResult coupon_Delete(int couponId, bool status)
        {
            if (couponId != 0)
            {
                var _model = couponRepository.FindById(couponId);
                _model.is_Active = status;

                couponRepository.Update(_model);

                return Ok(new { result = "success" });
            }
            return Ok(new { result = "notfound" });
        }

        // *****************  Constructor  ********************************

        public CategoryController(ICategoryRepository _categoryRepository, ICouponRepository _couponRepository)
        {
            categoryRepository = _categoryRepository;
            couponRepository = _couponRepository;
        }


    }
}
