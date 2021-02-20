using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Instruction;

namespace TScript.Compile.Parser
{
    /// <summary>
    /// 树基类
    /// </summary>
    public abstract class BaseTree
    {
        public BaseTree(Token token)
        {
            Chunk = token.chunk;
            Start = token.start;
            End = token.end;
            type = token.type;
        }
        public abstract TreeCode Code { get; }
        protected TokenType type { get; private set; }
        /// <summary>
        /// 代码块名称
        /// </summary>
        public string Chunk { get; private set; }

        public virtual void Compile(TScriptData scriptData)
        {
        }

        /// <summary>
        /// 开始
        /// </summary>
        public Position Start { get; private set; }
        /// <summary>
        /// 结束
        /// </summary>
        public Position End { get; private set; }
    }
}
