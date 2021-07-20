using System;
using Application.Commands;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public abstract class ApiControllerBase : Controller
    {
        protected Guid AccountId => User?.Identity?.IsAuthenticated==true?
            Guid.Parse(User.Identity.Name) : Guid.Empty;
        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IQueryDispatcher QueryDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            CommandDispatcher = commandDispatcher;
            QueryDispatcher = queryDispatcher;
        }
    }
}