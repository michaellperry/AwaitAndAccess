using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaitAndAccess
{
    public static class TaskExtensions
    {
        public static Task<B> AndThen<A,B>(this Task<A> a, Func<A, B> ab)
        {
            return a.ContinueWith(ta => ab(ta.Result));
        }

        public static async Task<B> AndThen<A,B>(this Task<A> a, Func<A, Task<B>> ab)
        {
            return await await a.ContinueWith(ta => ab(ta.Result));
        }
    }
}
