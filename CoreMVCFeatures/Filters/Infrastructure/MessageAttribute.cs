using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Infrastructure
{
    public class MessageAttribute : ResultFilterAttribute
    {
        private readonly string _message;
        public MessageAttribute(string msg) => _message = msg;

        public override void OnResultExecuting(ResultExecutingContext context)
            => WriteMessage(context, $"<div>Before Result:{_message}</div>");

        public override void OnResultExecuted(ResultExecutedContext context) 
            => WriteMessage(context, $"<div>After Result:{_message}</div>");

        private void WriteMessage(FilterContext context, string msg)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div>{msg}</div>");
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
        }
    }
}