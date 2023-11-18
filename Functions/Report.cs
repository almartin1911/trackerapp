using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace TrackerApp
{
    public class Report
    {
        private readonly ILogger _logger;
        private ReportService _reportService; //TODO: DI

        public Report(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Report>();
            _reportService = new ReportService();
        }

        [Function("Report")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var employeeID = req.Query["employeeID"];
            var startDate = req.Query["startDate"];
            var endDate = req.Query["endDate"];
            
            var serviceResult = _reportService.getReport(employeeID, startDate, endDate);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");


            // response.WriteString($"Welcome to Azure Functions! {req.Query["employeeID"]}");
            response.WriteString(serviceResult);

            return response;
        }
    }
}
