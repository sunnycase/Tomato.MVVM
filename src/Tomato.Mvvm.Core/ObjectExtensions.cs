using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato
{
    public static class ObjectExtensions
    {
        public static void Ignore(this object @object)
        {

        }

        public static void Ignore(this Task task)
        {
            task.ContinueWith(t =>
            {
                try
                {
                    t.Wait();
                }
                catch
                {

                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
