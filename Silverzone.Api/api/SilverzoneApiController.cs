using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Silverzone.Web.api
{
    public class SilverzoneApiController : ApiController
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            GC.SuppressFinalize(this);

            base.Dispose(disposing);
        }


    }
}
