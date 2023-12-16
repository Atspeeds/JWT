using ClientManagement.Domain.TokenAgg;
using System;

namespace ClientManagement.Domain.UserAgg
{
    public class User
    {
        public Guid KeyID { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string PassWoardHash { get; private set; }
        public bool IsActive { get; private set; }

        //Relation
        public Token Token { get; private set; }

        public User(string fullName, string userName, string passWoardHash)
        {
            FullName = fullName;
            UserName = userName;
            PassWoardHash = passWoardHash;
            IsActive = false;
        }

    }
}
