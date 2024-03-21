using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GerenciamentoBibliotecaDbContext _context;

        public LoginController(GerenciamentoBibliotecaDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Email == login.Login && u.Senha == login.Senha);

            if (usuarioExistente != null)
            {
                var token = GerarToken();
                return Ok(new { token });
            }
            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique e tente novamente." });
        }

        private string GerarToken()
        {
            string chaveSecreta = "4a813e5f-5f28-4ed3-beed-a78a483f0277";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("Nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken(
                issuer: "empresa",//emissor do token
                audience: "aplicacao",//destinatário= aplicação que irá usar o token
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
