namespace Task.Entities
{
    public class BaseInfo
    {
        protected string id {get;set;}

        protected UserInfo publisher { get; set; }

        protected string publishTime { get; set; }

        protected string status { get; set; }
    }
}
