using ClientManagement.Application.Contract.UserCo;
using ClientManagement.Domain.TokenAgg;
using ClientManagement.Domain.UserAgg;
using FrameWorkUni.FW.Auth;
using FrameWorkUni.TokenService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace ClientManagement.Infrastrure.EFCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ClientContext _context;

        private readonly AuthHelper _authHelper;
        public UserRepository(ClientContext context,AuthHelper authHelper)
        {
            _context = context;
            _authHelper = authHelper;
        }

        public bool CreateUser(CreateUser command)
        {
            var user = _context.Users.AnyAsync(x => x.UserName == command.UserName);

            if (user.IsCompleted)
                return false;

            _context.Users.Add(new User(command.FullName
                ,command.UserName,command.Password));


            _context.SaveChanges();


            return true;
        }

        public string LoginUser(string userName, string password)
        {

            var user = _context.Users.Include(x=>x.Token)
                .FirstOrDefault(x => x.UserName == userName
                                && x.PassWoardHash==password);


            if (user.Token is null)
            {
                var token = new CreateToken().GetToken(user.KeyID.ToString(),user.FullName);

                _context.Tokens.Add(new Token(user.KeyID,token,DateTime.Now.AddDays(1),"NonModel"));
                _context.SaveChanges();
            }
         
            _authHelper.SingIn(new AuthViewModel()
            {
                FullName = user.UserName,
                UserName = user.UserName,
            });

            return user.Token.TokenHash;

        }
    }
}
