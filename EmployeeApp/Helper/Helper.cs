namespace EmployeeApp.Helper
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7213/");
            return client;
        }
    }
}