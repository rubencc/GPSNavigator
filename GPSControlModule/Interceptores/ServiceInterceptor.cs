using System;
using System.Text;
using Castle.DynamicProxy;

namespace GPSControlModule.Interceptores
{
    public class ServiceInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Metodo: {0} {1}", invocation.GetConcreteMethod(), Environment.NewLine);
            sb.AppendFormat("Hora: {0} {1}", DateTime.Now, Environment.NewLine);

            invocation.Proceed();

            this.Write(sb);
        }

        public void Write(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());
        }
    }
}
