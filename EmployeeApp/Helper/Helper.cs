namespace EmployeeApp.Helper
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7214/");
            return client;
        }
    }
}