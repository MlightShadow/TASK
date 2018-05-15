using System.Collections.Generic;

namespace TaskWeb.Models
{
    public class ListByPage<T> where T : new()
    {
        public int totalNum { set; get; }
        public int totalPage { set; get; }
        public int pageSize { set; get; }
        public int currentPage { set; get; }
        public List<T> list { set; get; }
    }
}