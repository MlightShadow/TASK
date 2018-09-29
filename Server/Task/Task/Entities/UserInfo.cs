

namespace Task.Entities
{
    public class UserInfo
    {
        public string id { get; set; }
        public string name { get; set; }

        public string gender { get; set; }

        public string remark { get; set; }
        
        public AccountInfo accountInfo { get; set; }
    }
}
