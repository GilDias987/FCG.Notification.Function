using FCG.Notification.Func.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCG.Notification.Func.Interface
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessageDto email);
    }
}
