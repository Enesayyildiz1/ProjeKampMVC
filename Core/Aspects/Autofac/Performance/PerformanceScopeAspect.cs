using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceScopeAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceScopeAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("ayyildiz_enes66@hotmail.com", "*");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;

            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                mailMessage.From = new MailAddress("ayyildiz_enes66@hotmail.com");
                mailMessage.To.Add("ayyildiz_enes66@hotmail.com");
                mailMessage.Body = "Performance:" + invocation.Method.DeclaringType.FullName + invocation.Method.Name + "-->" + _stopwatch.Elapsed.TotalSeconds;
                istemci.Send(mailMessage);
            }
            _stopwatch.Reset(); 
         
        }
    }
}
