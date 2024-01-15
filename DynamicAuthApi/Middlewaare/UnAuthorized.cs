using Microsoft.AspNetCore.Identity;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
namespace DynamicAuthApi.Middlewaare
{
    public class UnAuthorized : IMiddleware
    {
        
        public  async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            //var endpoint = context.GetEndpoint();

            //var hasAuthorizeAttribute = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>() != null;
           
                int statusCode = context.Response.StatusCode;

                switch (statusCode)
                {
                    case 200:
                        
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("success access.");
                        break;

                    case 302:
                       
                        context.Response.ContentType = "text/plain";
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized access.");
                        break;


                    default:
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("Unauthorized access Or default error.");
 
                        break;
                
                }


        }
    }
}
