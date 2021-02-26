using System;
using System.Collections.Generic;
using System.Text;
using TScript.Runtime;

namespace TScript.Instruction
{
    public sealed class DoubleOpCode : BaseCode
    {
        public override OpCode Code => OpCode.Push;
        public double Value { get; set; }

        public override void Run(TSRuntime runtime, TSContext context)
        {
            runtime.CalStack.Push(Value);
        }
    }
}
