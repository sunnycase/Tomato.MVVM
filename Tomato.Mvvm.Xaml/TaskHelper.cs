using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm
{
    class TaskHelper
    {
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            return
#if NETFX_40
                TaskEx
#else
                Task
#endif
                .FromResult(result);
        }
    }
}
