using System;
using System.Threading.Tasks;
using FluentValidation;
using LocalGoods.BLL.Exceptions.BadRequestException;
using LocalGoods.BLL.Exceptions.NotFoundException;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LocalGoods.PL.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = exception switch
            {
                NotFoundException _ => StatusCodes.Status404NotFound,
                BadRequestException _ => StatusCodes.Status400BadRequest,
                ValidationException _ => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new {message = exception.Message}));
        }
    }
}