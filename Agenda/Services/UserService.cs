using Agenda.Models;
using Agenda.Models.Helpers;
using Agenda.Models.Request;
using Agenda.Services.Interfaces;
using Agenda.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Services
{
    public class UserService : IUserService
    {
        private readonly agendaContext _context;
        private readonly AppSettings _appSettings;

        public UserService(agendaContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public UserRequest Auth(AuthRequest model)
        {
            UserRequest userRequest = new UserRequest();
            try
            {
                var usuario = _context.Users.Where(u => u.Email == model.Email 
                && u.Contrasena == Encrypt.GetSHA256(model.Contrasena)).FirstOrDefault();

                if (usuario == null) return null;

                userRequest.Email = usuario.Email;
                userRequest.Token = GetToken(usuario);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

            return userRequest;
        }

        private string GetToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Email),
                        new Claim(ClaimTypes.Actor, usuario.Nombre)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
