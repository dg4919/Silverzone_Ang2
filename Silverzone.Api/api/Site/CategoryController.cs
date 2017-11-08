using Silverzone.Data;
using System.Linq;
using System.Web.Http;

namespace Silverzone.Api.api.Site
{
    public class CategoryController : ApiController
    {
        ICategoryRepository categoryRepository;
        
        [HttpGet]
        public IHttpActionResult category_List()
        {
            // where category contains a list<a> > anonymous type 
            var category = (from data in categoryRepository.GetByStatus(true)
                            select new
                            {
                                id = data.Id,
                                name = data.Name
                            });

            return Ok(new { result = category });
        }

        
        // *****************  Constructor  ********************************

        public CategoryController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

    }
}
