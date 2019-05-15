using NSMPT.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NSMPT.WinService
{
    public partial class TimerSend : ServiceBase
    {
        public TimerSend()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

             System.Timers.Timer  timer1 = new System.Timers.Timer();

            timer1.Interval = 1000;  //设置计时器事件间隔执行时间

            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

            timer1.Enabled = true;

        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimerSender timerSender = new TimerSender();
            timerSender.Send();

            GroupSender groupSender = new GroupSender();
            groupSender.Send();

            GroupTimeSender groupTimeSender = new GroupTimeSender();
            groupTimeSender.Send();

        }

        protected override void OnStop()
        {
        }
    }
}
