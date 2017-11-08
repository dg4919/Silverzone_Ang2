using Silverzone.Data;
using System.Web.Http.ExceptionHandling;

namespace Silverzone.Api
{
    // use to handle if any error occur in WEB API while running the methods of it
    public class GlobalExceptionHandler : ExceptionLogger
    {
        IErrorLogsRepository errorLogsRepository = new ErrorLogsRepository(
                                                   new Entities.SilverzoneContext()
                                                 );

        public override void Log(ExceptionLoggerContext context)
        {
            errorLogsRepository.logError(context.Exception);
        }

    }
}