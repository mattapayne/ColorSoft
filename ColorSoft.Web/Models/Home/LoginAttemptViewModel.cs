namespace ColorSoft.Web.Models.Home
{
    public class LoginAttemptViewModel
    {
        public LoginAttemptViewModel()
        {
            Failed = false;
        }

        public string Username { get; set; }
        public bool Failed { get; set; }
    }
}