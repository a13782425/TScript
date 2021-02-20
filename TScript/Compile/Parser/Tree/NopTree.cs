using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;

namespace TScript.Compile.Parser
{
    /// <summary>
    /// 空指令树
    /// </summary>
    public sealed class NopTree : BaseTree
    {
        public NopTree(Token token) : base(token)
        {
        }

        public override TreeCode Code => TreeCode.NOP;
    }
}
