using System;
using System.Collections.Generic;
using System.Text;
using TScript.Runtime;

namespace TScript.Instruction.Code
{
    public sealed class AddOpCode : BaseCode
    {
        public override OpCode Code => OpCode.Add;
        public override void Run(TSRuntime runtime, TSContext context)
        {
            object left = runtime.CalStack.Pop();
            object right = runtime.CalStack.Pop();
            double d = double.Parse(left.ToString()) + double.Parse(right.ToString());
            runtime.CalStack.Push(d);
        }
    }
}
