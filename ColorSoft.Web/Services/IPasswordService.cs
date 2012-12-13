namespace ColorSoft.Web.Services
{
    public interface IPasswordService : IApplicationService
    {
        string Generate(string clearTextPassword);
        bool Matches(string suppliedPassword, string hashedPassword);
    }
}