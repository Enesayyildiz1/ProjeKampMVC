using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.PostSharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect:OnMethodBoundaryAspect
    {
         int _interval;
        [NonSerialized]
        Stopwatch _stopwatch;

        public PerformanceCounterAspect(int interval=5)
        {
            _interval = interval;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("ayyildiz_enes66@hotmail.com", "*");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds>_interval)
            {
                mailMessage.From = new MailAddress("ayyildiz_enes66@hotmail.com");
                mailMessage.To.Add ( "ayyildiz_enes66@hotmail.com");
                mailMessage.Body = "Performance:"+args.Method.DeclaringType.FullName+args.Method.Name+"-->"+_stopwatch.Elapsed.TotalSeconds;
                istemci.Send(mailMessage);   
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
