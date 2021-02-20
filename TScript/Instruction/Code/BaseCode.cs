using System;
using System.Collections.Generic;
using System.Text;
using TScript.Runtime;

namespace TScript.Instruction.Code
{
    /// <summary>
    /// 指令载体
    /// </summary>
    public abstract class BaseCode
    {
        public abstract OpCode Code { get; }

        public virtual void Run(TSRuntime runtime, TSContext context)
        {

        }
    }
}
