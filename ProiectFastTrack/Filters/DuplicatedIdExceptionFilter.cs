﻿using Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProiectFastTrack.Filters
{
    public class DuplicatedIdExceptionFilter : IActionFilter ,IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is DuplicatedIdException ex)
            {
                context.Result = new ObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status409Conflict
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
