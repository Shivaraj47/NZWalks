﻿using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Model.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repository
{
	public class TokenHandler : ITokenHandler
	{
		private readonly IConfiguration configuration;

		public TokenHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public Task<string> CreateTokenAsync(User user)
		{


			//Create claims
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.GivenName, user.FirtName),
				new Claim(ClaimTypes.Surname, user.LastName),
				new Claim(ClaimTypes.Email, user.EmailAddress)
			};

			//loop into roles of users
			user.Roles.ForEach((role) =>
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			});

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
			var credentals = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				configuration["Jwt:Issuer"],
				configuration["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: credentals);

			return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));





		}
	}
}
