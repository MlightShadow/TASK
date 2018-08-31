
namespace WebReport.Entity.User
{
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string nickName { get; set; }
        public string remarks { get; set; }
        public string roleName { get; set; }
        public bool isDeleted { get; set; }
        public int? roleId { get; set; }
    }
}