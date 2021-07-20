using System;
using System.Net;
using System.Threading.Tasks;
using Application.Errors;
using Application.Exceptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
    
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var errorCode = "internal_server_error";
            var message = "Something went wrong on server side.";

            var exceptionType = exception.GetType();
            
            HttpStatusCode statusCode;


            switch(exception)
            {
                case InternalException e when exceptionType == typeof(InternalException):
                    statusCode = HttpStatusCode.InternalServerError;
                break;

                case ServiceException e when exceptionType == typeof(ServiceException):
                    statusCode = HttpStatusCode.UnprocessableEntity;
                    errorCode = e.Code;
                    message = e.Message;
                break;
                
                case EntityDoesNotExistException e when exceptionType == typeof(EntityDoesNotExistException):
                    statusCode = HttpStatusCode.NotFound;
                    errorCode = e.Code;
                    message = e.Message;
                break;

                case EntityAlreadyExistsException e when exceptionType == typeof(EntityAlreadyExistsException):
                    statusCode = HttpStatusCode.Conflict;
                    errorCode = e.Code;
                    message = e.Message;
                break;

                case AccessDeniedException e when exceptionType == typeof(AccessDeniedException):
                    statusCode = HttpStatusCode.Forbidden;
                    errorCode = e.Code;
                    message = e.Message;
                break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                break;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;

            var exceptionResponse = new ExceptionResponse(errorCode, message);
            var response = JsonConvert.SerializeObject(exceptionResponse);

            return httpContext.Response.WriteAsync(response);
        }


        private class ExceptionResponse
        {
            public string code {get; protected set;}
            public string message {get; protected set;}
            public ExceptionResponse(string code, string message)
            {
                this.code = code;
                this.message = message;
            }
        }
    }
}