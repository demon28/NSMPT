﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSMPT.Entites
{
    public enum MarkKey
    {
        收件人名称 = 1,
        收件人邮箱= 2,
        收件人电话= 3
    }

    public enum Status {
        正常=0,
        删除=1
    }


    public enum EmailFlagStatus
    {
        已发送 = 0,
        发送中= 1,
        发送失败=2,
        定时邮件=3
    }


    class EnumType
    {
    }
}
