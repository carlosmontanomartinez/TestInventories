using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CinepolisApiKey.Core;
using CinepolisApiKey.Helpers;
using Inventories.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Inventories.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<string, string> _params;
        public ApiKeyMiddleware(
            RequestDelegate next, 
            Dictionary<string, string> settings
            )
        {
            _next = next;
            _params = settings;
        }

        public Task Invoke(HttpContext context, IApiConfigurable errorsConfiguration)
        {
            try
            {
                string msg;
                if (context.Request.Headers.TryGetValue("api_key", out var key))
                {
                    string apiKey = key;
                    
                    switch (Generic.ValidateApikey(apiKey, "MX", _params, out var genericApplication))
                    {
                        case Constants.ValidateApikeyResult.Ok:
                            var cultureInfo = new CultureInfo("es-MX");
                            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                            break;
                        case Constants.ValidateApikeyResult.Unauthorized:
                            msg = "ApiKey Unauthorized";
                            throw new ApplicationException(msg);

                            //default:
                            //throw GetHttpResponseException(ApiErrors.Constants.Types.apikey, ApiErrors.Constants.Codes.ApiKeyInternalServerError);
                    }

                    return _next(context);
                }
                msg = "ApiKey Non-supplied";
                throw new ApplicationException(msg);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiKeyExtensions
    {
        public static IApplicationBuilder UseApiKey( this IApplicationBuilder builder, IConfiguration configuration)
        {
            var apikeyParameters = new Dictionary<string, string>
            {
                {
                    Constants.ConnectionStringKey,
                    configuration.GetSection("ConnectionStrings:ApiKey:MongoDB").Value
                },
                {
                    Constants.AppSettingKeyDB,
                    configuration.GetSection("Cinepolis:ApiKey:mongoDB:DB").Value
                },
                {
                    Constants.ConnectionStringKeyRedis,
                    configuration.GetSection("ConnectionStrings:ApiKey:Redis").Value

                },
                {
                    Constants.AppSettingKeyExpiryTime,
                    configuration.GetSection("Cinepolis:ApiKey:Redis:ExpiryTime").Value

                },
                {
                    Constants.AppSettingKeyDBRedis,
                    configuration.GetSection("Cinepolis:ApiKey:Redis:DB").Value

                },
                {
                    Constants.AppSettingKeyEnabled,
                    configuration.GetSection("Cinepolis:ApiKey:Redis:Enabled").Value

                }
            };
            return builder.UseMiddleware<ApiKeyMiddleware>(apikeyParameters);
        }
    }
}
