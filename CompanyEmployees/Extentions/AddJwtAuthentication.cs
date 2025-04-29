

using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationExtentions
{
    public static class JwtAuthenticationExtention
    {
        public static AuthenticationBuilder AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options=>{
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>{
                options.SaveToken=true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience=false,
                    ValidateIssuer=false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qazwsxedcrfvtgbyhnujmik,ol.p;/[']"))
                };
            });
            return new AuthenticationBuilder(services);
        }
    }
}