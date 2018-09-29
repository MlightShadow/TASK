namespace Task.Entities
{
    public class UserAuthInfo
    {
        public UserInfo userInfo { get; set; }

        public string token { get; set; }

        public string expTime { get; set; }
    }
}
