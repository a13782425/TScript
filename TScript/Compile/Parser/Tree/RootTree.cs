using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;

namespace TScript.Compile
{
    /// <summary>
    /// 树根
    /// </summary>
    public sealed class RootTree : BaseTree
    {
        public RootTree(Token token) : base(token)
        {
            Bodys = new List<BaseTree>();
        }

        public override TreeCode Code => TreeCode.ROOT;

        public List<BaseTree> Bodys { get; set; }
    }
}
