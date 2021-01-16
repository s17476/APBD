using Cw7.DTO.Requests;
using Cw7.DTO.Responses;
using Cw7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cw7.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentDbService _service;
        public IConfiguration Configuration { get; set; }

        public StudentsController(IStudentDbService DbService, IConfiguration configuration)
        {
            _service = DbService;
            Configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_service.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentsByIndex(string id)
        {
            return Ok(_service.GetStudent(id));
        }

        [HttpPost]
        public IActionResult LogIn(LoginRequest request)
        {
            StudentLoginResponse slr = _service.Login(request);

            if(slr == null)
            {
                return NotFound("Incorrect login or password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, slr.IndexNumber),
                new Claim(ClaimTypes.Name, slr.Name),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Employee")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "Gakko",
                    audience: "Students",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                );
            var refreshToken = Guid.NewGuid();

            //add new refresh token to DB
            _service.AddRefreshToken(slr.IndexNumber, refreshToken.ToString());

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = refreshToken

            });
        }

        [HttpPost("refresh-token/{token}")]
        public IActionResult RefreshToken(string token)
        {
            var oldRefToken = token;
            var newRefToken = Guid.NewGuid().ToString();

           StudentLoginResponse slr = _service.UpdateRefreshToken(oldRefToken, newRefToken);

            if (slr == null)
            {
                return BadRequest("Refresh token expired");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, slr.IndexNumber),
                new Claim(ClaimTypes.Name, slr.Name),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Employee")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var newJwtToken = new JwtSecurityToken
                (
                    issuer: "Gakko",
                    audience: "Students",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(newJwtToken),
                refreshToken = newRefToken

            });
        }
    }
}
