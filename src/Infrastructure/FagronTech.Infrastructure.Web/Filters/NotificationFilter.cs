using FluentValidation.Results;
using FagronTech.Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Web.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotification _notification;

        public NotificationFilter(INotification notification)
        {
            this._notification = notification;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            IEnumerable<ValidationFailure> failures = this._notification.GetFailures();

            if (failures.Count() > 0 )
            {
                ICollection<object> prettyFailures = new List<object>();

                foreach(ValidationFailure failure in failures)
                {
                    object fail = new { Tipo = "error", Descricao = failure.ErrorMessage };

                    prettyFailures.Add(fail);
                }

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = contractResolver };

                var notifications = JsonConvert.SerializeObject(prettyFailures, jsonSerializerSettings);
                await context.HttpContext.Response.WriteAsync(notifications);
                return;
            }

            await next();
        }
    }
}
