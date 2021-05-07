using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Event_Portal.Models;
using Microsoft.IdentityModel.Tokens;

namespace Event_Portal.Extensions
{
    public class GetToken
    {

public GetToken(Ico) {

}

    private string GenerateJSONWebToken(Login loginInfo)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, loginInfo.Email),
        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
      };

      var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

      var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
      return encodetoken;

    }

    

    }


}