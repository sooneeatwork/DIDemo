namespace DIDemo.Configuration
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; } = "smtp.example.com";
        public int Port { get; set; } = 587;
        public string Username { get; set; } = "user@example.com";
        public string Password { get; set; } = "password";
    }
}