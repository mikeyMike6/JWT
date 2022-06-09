namespace jwt_token.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public string UserName { get; }
        public UserAlreadyExistsException(string userName) : base($"{userName} jest juz zajete")
        {
            UserName = userName;
        }
    }
}
