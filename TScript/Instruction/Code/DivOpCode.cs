using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Instruction
{
    public sealed class DivOpCode : BaseCode
    {
        public override OpCode Code => OpCode.Div;
    }
}
