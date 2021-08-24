using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using VerstaTestTask.Models;

namespace VerstaTestTask.Filters
{
    public class ValidateOrderViewModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("order", out object obj) && obj is OrderViewModel order)
            {
                if (order.PickUpDate.Date < DateTime.Now.Date)
                    context.ModelState.AddModelError(nameof(order.PickUpDate), "Дата не может быть меньше текущей");
                if (order.SenderAddress.Equals(order.RecipientAddress))
                    context.ModelState.AddModelError(nameof(order.SenderAddress), "Адрес отправителя и получателя не может совпадать");
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new ViewResult()
                {
                    ViewName = "Index",
                };
            }

            base.OnActionExecuting(context);
        }
    }
}
