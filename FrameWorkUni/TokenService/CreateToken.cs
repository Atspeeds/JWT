using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkUni.TokenService
{
    public class CreateToken
    {
        public string GetToken(string id,string name)
        {

            var claims = new List<Claim>
                {
                    new Claim ("UserId", id.ToString()),
                    new Claim ("Name",  name),
                };
            string key = "{041944FD-AC22-4A62-A590-D0FA79990A11}";
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenexp = DateTime.Now.AddDays(2);

            var token = new JwtSecurityToken(
                issuer: "Univer",
                audience: "Univer",
                expires: tokenexp,
                notBefore: DateTime.Now,
                claims: claims,
                signingCredentials: credentials
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
