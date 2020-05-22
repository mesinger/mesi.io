using System;
using System.Threading.Tasks;
using Mesi.Io.Api.User.Except;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Mesi.Io.Api.User.MiddleWare
{
    public class ExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private void HandleException(HttpContext context, Exception ex)
        {
            string msg;
            int code;
            
            switch (ex)
            {
                case EmailAlreadyRegisteredException _:
                    msg = JsonConvert.SerializeObject(new {message = "User with this email is already registered"});
                    code = 400;
                    break;
                case UserNameAlreadyRegisteredException _:
                    msg = JsonConvert.SerializeObject(new {message = "User with this username is already registered"});
                    code = 400;
                    break;
                case InvalidInputException _:
                    msg = JsonConvert.SerializeObject(new {message = "Invalid arguments"});
                    code = 400;
                    break;
                default:
                    msg = JsonConvert.SerializeObject(new {message = "Internal server error"});
                    code = 500;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            context.Response.WriteAsync(msg);
        }
    }
}