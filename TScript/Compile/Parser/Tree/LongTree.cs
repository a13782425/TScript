using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Instruction;
using TScript.Instruction.Code;

namespace TScript.Compile.Parser
{
    public sealed class LongTree : BaseTree
    {
        public LongTree(Token token) : base(token)
        {
            Value = (long)token.value;
        }
        public long Value { get; private set; }
        public override TreeCode Code => TreeCode.LONG_NUM;
        public override void Compile(TScriptData scriptData)
        {
            scriptData.CodeList.Add(new LongOpCode() { Value = Value });
        }
    }
}
