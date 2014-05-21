using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace HelloOwin.Middleware
{
    public class MiddlewareDemo
    {
        private readonly AppFunc _next;

        public MiddlewareDemo(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            using (var writer = new StreamWriter((Stream)env["owin.ResponseBody"]))
            {
                writer.Write("Modification to the stream...");
                writer.Flush();
            }
            return _next(env);
        }
    }
}
