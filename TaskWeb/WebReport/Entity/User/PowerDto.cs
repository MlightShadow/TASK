using System;

namespace WebReport.Entity.User
{
    public class PowerDto
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public int pageId { get; set; }
        public DateTime createDate { get; set; }
        public int creator { get; set; }
        public DateTime? editDate { get; set; }
        public int? editor { get; set; }
        public bool isDeleted { get; set; }
    }
}