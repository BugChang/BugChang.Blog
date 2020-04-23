namespace BugChang.Blog.WebApi.Models
{
    public class CustomerError
    {
        public string Error { get; set; }
        public static CustomerError Default(string error)
        {
            return new CustomerError
            {
                Error = error
            };
        }
    }
}
