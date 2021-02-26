using System;
using System.Collections.Generic;
using System.Text;
using TScript.Runtime;

namespace TScript.Instruction
{
    /// <summary>
    /// long整形指令
    /// </summary>
    public sealed class LongOpCode : BaseCode
    {
        public override OpCode Code => OpCode.Push;
        public long Value { get; set; }
        public override void Run(TSRuntime runtime, TSContext context)
        {
            runtime.CalStack.Push(Value);
        }
    }
}
