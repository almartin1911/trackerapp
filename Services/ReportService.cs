public class ReportService
{    
    public ReportService() { }

    public string getReport(string employeeID, string startDate, string endDate) {
        var response = "YOLO";

        ReportWrapper report = new ReportWrapper();
        List<Activity> activities = new List<Activity>();
        try {
            

        } catch (Exception) {
            throw;
        }

        return response;    
    }
}

public class Activity {
    public int id {get; set;}
}

public class ReportWrapper {
    public int id {get; set;}
}