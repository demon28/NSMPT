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
using Winner.Framework.Utils;

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
            Log.Info("==========NapEMail服务启动============");
             System.Timers.Timer  SendTimer = new System.Timers.Timer();

            SendTimer.Interval = 1000;  //设置计时器事件间隔执行时间

            SendTimer.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);

            SendTimer.Enabled = true;

            System.Timers.Timer GetTimer= new System.Timers.Timer();
            GetTimer.Interval = 60000;  //设置计时器事件间隔执行时间

            GetTimer.Elapsed += new System.Timers.ElapsedEventHandler(timer2_Elapsed);

            GetTimer.Enabled = true;

        }

        private void timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            ReceiveFacade receiveFacade = new ReceiveFacade();
            receiveFacade.ServiceGetAllMail();
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
            Log.Info(" ========== NapEMail服务终止 ============ ");
        }
    }
}
