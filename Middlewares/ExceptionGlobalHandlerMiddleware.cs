using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using svietnamAPI.Dtos.ApiResponse;
using svietnamAPI.Helper.Exceptions;
using svietnamAPI.Helper.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using svietnamAPI.Dtos.ValueDtos;

namespace svietnamAPI.Middlewares
{
    public class ExceptionGlobalHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ExceptionGlobalHandlerMiddleware> _logger;

        public ExceptionGlobalHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionGlobalHandlerMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var statusCode = 0;
                var responseCode = 0;
                var message = "";
                string stackTrace = null;
                string exceptionMessage = null;
                switch (error)
                {
                    case AppJwtTokenException e:
                        // custom application error
                        statusCode = (int)HttpStatusCode.BadRequest;
                        responseCode = 11001;
                        message = ResponseCodeConst.E11001;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case AppSystemException e:
                        // unhandled error
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    default:
                        // unhandled error
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                if (_env.IsDevelopment() == true)
                {
                    stackTrace = error.StackTrace;
                    exceptionMessage = error.Message;
                    _logger.LogError(error.StackTrace);
                }   

                await context.Response.WriteErrorResponseAsync(statusCode, responseCode, message);
            }
        }

    }
}
