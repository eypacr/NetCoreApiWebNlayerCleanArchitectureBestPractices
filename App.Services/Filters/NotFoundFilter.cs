﻿using App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Services.Filters;

public class NotFoundFilter<T, TId>(IGenericRepository<T, TId> genericRepository)
        : Attribute, IAsyncActionFilter where T : class where TId : struct
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionArguments.TryGetValue("id", out var idAsObject) && idAsObject is TId id)
        {
            if (!await genericRepository.AnyAsync(id))
            {
                var entityName = typeof(T).Name;
                var actionName = context.ActionDescriptor.RouteValues["action"];

                context.Result = new NotFoundObjectResult(ServiceResult.Fail(
                    $"Veri bulunamadı. (Varlık: {entityName}, İşlem: {actionName})"
                ));
                return;
            }
        }

        await next();
    }
}

