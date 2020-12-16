using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Utitly;
using WebApi.Core.Entity.User;
using WebApi.EntityFramework;
using WebApi.IApplication.Dto.Account;
using WebApi.IApplication.IServices.IAccount;
using WebApi.IApplication.IServices.IRedis;
using WebApi.Repository.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.Application.Services
{
    public class AccountServices : BaseServices, IAccountServices
    {
        private IRepositoryServices<DbAccountUser> _accountUserRepository = null;
        private IConfiguration _configuration = null;
        private IRepositoryServices<DbUser> _userRepository = null;
        private IHttpContextAccessor _httpContextAccessor = null;
        private IRedisListServices _redisListServices = null;

        public AccountServices(IRepositoryServices<DbAccountUser> accountUserRepository, IConfiguration configuration,
            IRepositoryServices<DbUser> userRepository, IHttpContextAccessor httpContextAccessor, IRedisListServices redisListServices)
        {
            _accountUserRepository = accountUserRepository;
            _configuration = configuration;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _redisListServices = redisListServices;
        }

        public async Task<LoginInOutput> LoginIn(LoginInput input)
        {
            var entities = await _accountUserRepository.FindAllEntity();
            var loginUser = entities.FirstOrDefault(c => c.UserName == input.UserName);
            if (loginUser == null)
            {
                return new LoginInOutput
                {
                    Result = "用户名错误"
                };
            }

            string pwdMd5 = EncryptUtitly.CreateMD5Encrypt(input.Password);
            if (pwdMd5 != loginUser.Password)
            {
                return new LoginInOutput
                {
                    Result = "密码错误"
                };
            }

            string token = await CreateJwtSecretKey(loginUser.UserName);

            var currentUser = await _userRepository.FindSingleEntity(loginUser.Id);
            string userStr = JsonConvert.SerializeObject(currentUser, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            _httpContextAccessor.HttpContext.Session.SetString(loginUser.DbUser.Id.ToString(), userStr);

            return new LoginInOutput
            {
                AccountSatus = Core.Enum.User.AccountSatusEnum.Disabled,
                Result = token
            };
        }

        /// <summary>
        /// 登出  清除session  将token拉入黑名单 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public LoginOutOutput LoginOut(LoginOutInput input)
        {
            var sessions = _httpContextAccessor.HttpContext.Session;

            if (sessions.Keys.Contains(input.UserId.ToString()))
            {
                sessions.Remove(input.UserId.ToString());
                string headerAuth = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if (!string.IsNullOrEmpty(headerAuth))
                {
                    var token = headerAuth.Split(' ')[1];
                    string currentUserRedisKey = CreateCurentUserRedisKey(input.UserId);
                    _redisListServices.AddItemAfterList(currentUserRedisKey, token);
                }

                return new LoginOutOutput
                {
                    Message = "Exit  Successfully"
                };
            }

            return new LoginOutOutput
            {
                Message = "Exit  Error"
            };
        }

        /// <summary>
        /// 创建Jwt Token
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private async Task<string> CreateJwtSecretKey(string username)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),                                           // 用户名
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),               // token 生效时间
            };
            claimsIdentity.AddClaims(claims);

            string jwtScrect = _configuration.GetSection("Jwt:Secret").Value;
            var authSingingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtScrect));

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt: Issure").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSingingKey, SecurityAlgorithms.HmacSha256)
                );

            await _httpContextAccessor.HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
