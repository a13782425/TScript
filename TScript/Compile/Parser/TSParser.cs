using System;
using System.Collections.Generic;
using System.Text;
using TScript.Compile.Common;

namespace TScript.Compile.Parser
{
    /// <summary>
    /// 解析器
    /// </summary>
    public class TSParser
    {
        private List<Token> _tokens = default;
        private int _index = -1;
        private Token _curToken = default;
        public TSParser(List<Token> tokens)
        {
            this._tokens = tokens;
        }

        public void Parse()
        {
            //AST Root Node
        }
        /// <summary>
        /// 分析位置+1
        /// </summary>
        /// <param name="curChar">当前字符</param>
        public void Advance()
        {
            this._index += 1;
            this.UpdateCurToken();
        }
        /// <summary>
        /// 分析位置-1
        /// </summary>
        /// <param name="amount">往前几步,默认一步</param>
        public void Reverse(int amount = 1)
        {
            this._index -= amount;
            this.UpdateCurToken();
        }
        /// <summary>
        /// 更新当前token
        /// 如果往前了几步，那么当前的token也需要更新成前几步对应的token
        /// </summary>
        /// <param name=""></param>
        public void UpdateCurToken()
        {
            if (this._index >= 0 && this._index < this._tokens.Count)
                this._curToken = this._tokens[this._index];
        }        
    }
}
