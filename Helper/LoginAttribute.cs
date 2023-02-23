
namespace BookApi.Helper
{
    [AttributeUsage(AttributeTargets.All)]
    public class LoginAttribute : Attribute
    {
        public string MailAdress { get; set; }
        public string Password { get; set; }
        public LoginAttribute(string mailAdress,string password)
        {
            this.MailAdress = mailAdress;
            this.Password = password;
        }
    }
}
