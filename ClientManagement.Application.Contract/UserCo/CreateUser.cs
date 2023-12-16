namespace ClientManagement.Application.Contract.UserCo
{
    public class CreateUser
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public CreateUser()
        {
        }

        public CreateUser(string fullName, string userName, string password)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
        }
    }
}
