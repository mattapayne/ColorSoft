namespace ColorSoft.Web.Services
{
    public interface ITemplateUrlGenerationService : IApplicationService
    {
        string Generate(string name);
    }
}
