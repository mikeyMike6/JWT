namespace jwt_token
{
    public class UserRepository
    {
        List<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
            _users.Add(new User("jacek", "admin", "qwerty123"));
            _users.Add(new User("blażej", "mode", "qwerty123"));
            _users.Add(new User("sylwek", "user", "2022"));
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
        public bool Exists(string? userName)
        {
            return _users.Any(x => x.UserName == userName);
        }
        public User GetByName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
        public List<User> GetAll()
        {
            return _users;
        }
        public bool CredentialAreCorrect(string userName, string password)
        {
            var user = GetByName(userName);
            if(user != null)
            {
                if (user.UserName == userName && user.Password == password) return true;
            }
            return false;
        }
    }
}
