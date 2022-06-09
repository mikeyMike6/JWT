using System.Text.Json.Serialization;

namespace jwt_token
{
    public class User
    {
        public string UserName { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public User(string name, string role, string pass)
        {
            Password = pass;
            UserName = name;
            Role = role;
        }
    }
}
