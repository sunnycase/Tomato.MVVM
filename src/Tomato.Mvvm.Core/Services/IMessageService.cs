using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm.Services
{
    public enum MessageResult
    {
        //
        // 摘要:
        //     No result available.
        None = 0,
        //
        // 摘要:
        //     Message is acknowledged.
        OK = 1,
        //
        // 摘要:
        //     Message is canceled.
        Cancel = 2,
        //
        // 摘要:
        //     Message is acknowledged with yes.
        Yes = 3,
        //
        // 摘要:
        //     Message is acknowledged with no.
        No = 4
    }
    public enum MessageButton
    {
        //
        // 摘要:
        //     OK button.
        OK = 1,
        //
        // 摘要:
        //     OK and Cancel buttons.
        OKCancel = 2,
        //
        // 摘要:
        //     Yes and No buttons.
        YesNo = 4,
        //
        // 摘要:
        //     Yes, No and Cancel buttons.
        YesNoCancel = 8
    }
    public enum MessageImage
    {
        //
        // 摘要:
        //     Show no image.
        None = 0,
        //
        // 摘要:
        //     Information image.
        Information = 1,
        //
        // 摘要:
        //     Question image.
        Question = 2,
        //
        // 摘要:
        //     Exclamation image.
        Exclamation = 3,
        //
        // 摘要:
        //     Error image.
        Error = 4,
        //
        // 摘要:
        //     Stop image.
        Stop = 5,
        //
        // 摘要:
        //     Warning image.
        Warning = 6
    }

    public interface IMessageService
    {
        //
        // 摘要:
        //     Shows the specified message and returns the result.
        //
        // 参数:
        //   message:
        //     The message.
        //
        //   caption:
        //     The caption.
        //
        //   button:
        //     The button.
        //
        //   icon:
        //     The icon.
        //
        // 返回结果:
        //     The Catel.Services.MessageResult.
        //
        // 异常:
        //   T:System.ArgumentException:
        //     The message is null or whitespace.
        Task<MessageResult> ShowAsync(string message, string caption = "", MessageButton button = MessageButton.OK, MessageImage icon = MessageImage.None);
        //
        // 摘要:
        //     Shows an error message to the user and allows a callback operation when the message
        //     is completed.
        //
        // 参数:
        //   exception:
        //     The exception.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The exception is null.
        Task<MessageResult> ShowErrorAsync(Exception exception);
        //
        // 摘要:
        //     Shows an error message to the user and allows a callback operation when the message
        //     is completed.
        //
        // 参数:
        //   message:
        //     The message.
        //
        //   caption:
        //     The caption.
        //
        // 异常:
        //   T:System.ArgumentException:
        //     The message is null or whitespace.
        Task<MessageResult> ShowErrorAsync(string message, string caption = "");
        //
        // 摘要:
        //     Shows an information message to the user and allows a callback operation when
        //     the message is completed.
        //
        // 参数:
        //   message:
        //     The message.
        //
        //   caption:
        //     The caption.
        //
        // 异常:
        //   T:System.ArgumentException:
        //     The message is null or whitespace.
        Task<MessageResult> ShowInformationAsync(string message, string caption = "");
        //
        // 摘要:
        //     Shows a warning message to the user and allows a callback operation when the
        //     message is completed.
        //
        // 参数:
        //   message:
        //     The message.
        //
        //   caption:
        //     The caption.
        //
        // 异常:
        //   T:System.ArgumentException:
        //     The message is null or whitespace.
        Task<MessageResult> ShowWarningAsync(string message, string caption = "");
    }
}
