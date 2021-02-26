using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Instruction;

namespace TScript.Compile
{
    public sealed class DoubleTree : BaseTree
    {
        public DoubleTree(Token token) : base(token)
        {
            Value = (double)token.value;
        }
        public double Value { get; private set; }
        public override TreeCode Code => TreeCode.DOUBLE_NUM;
        public override void Compile(TScriptData scriptData)
        {
            scriptData.CodeList.Add(new DoubleOpCode() { Value = Value });
        }
    }
}
