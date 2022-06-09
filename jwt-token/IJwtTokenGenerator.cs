namespace jwt_token
{
    public interface IJwtTokenGenerator
    {
        string Generate(string user, string role);
    }
}
