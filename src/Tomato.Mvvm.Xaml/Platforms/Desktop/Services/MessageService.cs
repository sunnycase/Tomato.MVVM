using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tomato.Mvvm.Services
{
    /// <summary>
    /// 弹出信息服务
    /// </summary>
    [Export(typeof(IMessageService))]
    public class MessageService : IMessageService
    {
        public Task<MessageResult> ShowAsync(string message, string caption = "", MessageButton button = MessageButton.OK, MessageImage icon = MessageImage.None)
        {
            return ShowAsyncCore(message, caption, button, icon);
        }

        public Task<MessageResult> ShowErrorAsync(Exception exception)
        {
            return ShowErrorAsync(exception.Flatten());
        }

        public Task<MessageResult> ShowErrorAsync(string message, string caption = "")
        {
            return ShowAsync(message, caption, MessageButton.OK, MessageImage.Error);
        }

        public Task<MessageResult> ShowInformationAsync(string message, string caption = "")
        {
            return ShowAsync(message, caption, MessageButton.OK, MessageImage.Information);
        }

        public Task<MessageResult> ShowWarningAsync(string message, string caption = "")
        {
            return ShowAsync(message, caption, MessageButton.OK, MessageImage.Warning);
        }

        private static Task<MessageResult> ShowAsyncCore(string message, string caption, MessageButton button, MessageImage icon)
        {
            return
#if NET40
                TaskEx
#else
                Task
#endif
                .FromResult(ConvertResult(MessageBox.Show(message, caption, ConvertButton(button), ConvertImage(icon))));
        }

        private static MessageBoxButton ConvertButton(MessageButton button)
        {
            MessageBoxButton boxButton;
            switch (button)
            {
                case MessageButton.OK:
                    boxButton = MessageBoxButton.OK;
                    break;
                case MessageButton.OKCancel:
                    boxButton = MessageBoxButton.OKCancel;
                    break;
                case MessageButton.YesNo:
                    boxButton = MessageBoxButton.YesNo;
                    break;
                case MessageButton.YesNoCancel:
                    boxButton = MessageBoxButton.YesNoCancel;
                    break;
                default:
                    throw new NotSupportedException("不支持的 Button。");
            }
            return boxButton;
        }

        private static MessageBoxImage ConvertImage(MessageImage image)
        {
            MessageBoxImage boxImage;
            switch (image)
            {
                case MessageImage.None:
                    boxImage = MessageBoxImage.None;
                    break;
                case MessageImage.Information:
                    boxImage = MessageBoxImage.Information;
                    break;
                case MessageImage.Question:
                    boxImage = MessageBoxImage.Question;
                    break;
                case MessageImage.Exclamation:
                    boxImage = MessageBoxImage.Exclamation;
                    break;
                case MessageImage.Error:
                    boxImage = MessageBoxImage.Error;
                    break;
                case MessageImage.Stop:
                    boxImage = MessageBoxImage.Stop;
                    break;
                case MessageImage.Warning:
                    boxImage = MessageBoxImage.Warning;
                    break;
                default:
                    throw new NotSupportedException("不支持的 Image。");
            }
            return boxImage;
        }

        private static MessageResult ConvertResult(MessageBoxResult boxResult)
        {
            MessageResult result;
            switch (boxResult)
            {
                case MessageBoxResult.None:
                    result = MessageResult.None;
                    break;
                case MessageBoxResult.OK:
                    result = MessageResult.OK;
                    break;
                case MessageBoxResult.Cancel:
                    result = MessageResult.Cancel;
                    break;
                case MessageBoxResult.Yes:
                    result = MessageResult.Yes;
                    break;
                case MessageBoxResult.No:
                    result = MessageResult.No;
                    break;
                default:
                    throw new NotSupportedException("不支持的 Result。");
            }
            return result;
        }
    }
}
