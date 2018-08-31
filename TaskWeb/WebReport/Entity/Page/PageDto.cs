
namespace WebReport.Entity.Page
{
    public class PageDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string controller { get; set; }
        public string param { get; set; }
        public int fId { get; set; }
        public int type { get; set; }
        public bool isDeleted { get; set; }
        public int? sort { get; set; }
        public string icon { get; set; }
    }
}