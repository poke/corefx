// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Pipelines
{
    internal sealed class ThreadPoolScheduler : PipeScheduler
    {
        public override void Schedule(Action action)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(s_actionCallback, action, preferLocal: false);
        }

        public override void Schedule(Action<object> action, object state)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(action, state, preferLocal: false);
        }

        private static readonly Action<Action> s_actionCallback = state => state();
    }
}