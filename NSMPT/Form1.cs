﻿using NSMPT.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSMPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TimerSender timerSender = new TimerSender();
            timerSender.Send();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ReceiveFacade receiveFacade = new ReceiveFacade();
            receiveFacade.ServiceGetAllMail();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GroupSender groupSender = new GroupSender();
            groupSender.Send();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            GroupTimeSender groupTimeSender = new GroupTimeSender();
            groupTimeSender.Send();
        }
    }
}
