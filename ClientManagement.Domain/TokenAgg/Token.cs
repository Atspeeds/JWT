using ClientManagement.Domain.UserAgg;
using System;

namespace ClientManagement.Domain.TokenAgg
{
    public class Token
    {
        public long Id { get; private set; }
        public string TokenHash { get; private set; }
        public DateTime TokenExp { get; private set; }
        public string ModelPhone { get; private set; }
        public Guid Userid { get; private set; }

        //Relation
        public User User { get; private set; }

        public Token()
        {
        }

        public Token(Guid guid,string tokenHash, DateTime tokenExp, string modelPhone)
        {
            Userid = guid;
            TokenHash = tokenHash;
            TokenExp = tokenExp;
            ModelPhone = modelPhone;
        }

    }
}
