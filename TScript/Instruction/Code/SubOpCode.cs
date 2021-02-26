using System;
using System.Collections.Generic;
using System.Text;
using TScript.Runtime;

namespace TScript.Instruction
{
    public sealed class SubOpCode : BaseCode
    {
        public override OpCode Code => OpCode.Sub;
        public override void Run(TSRuntime runtime, TSContext context)
        {
            object right = runtime.CalStack.Pop();
            object left = runtime.CalStack.Pop();
            double d = double.Parse(left.ToString()) - double.Parse(right.ToString());
            runtime.CalStack.Push(d);
        }
    }
}
