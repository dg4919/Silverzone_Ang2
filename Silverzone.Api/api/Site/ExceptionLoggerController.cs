using Silverzone.Data;
using System;
using System.Web.Http;

namespace Silverzone.Api.api.Site
{
    public class ExceptionLoggerController : ApiController
    {
        private IErrorLogsRepository errorLogsRepository;

        public ExceptionLoggerController(IErrorLogsRepository _errorLogsRepository)
        {
            errorLogsRepository = _errorLogsRepository;
        }     

        public void logError(Exception ex)
        {
            errorLogsRepository.logError(ex);
        }



    }
}
