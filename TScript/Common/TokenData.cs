using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Common
{
    /// <summary>
    /// Token数据
    /// </summary>
    public sealed class TokenData
    {
        /// <summary>
        /// 当前token数据所属的包名
        /// </summary>
        public readonly string PackageName = default;
        /// <summary>
        /// 文件开始
        /// </summary>
        public Position Start;
        /// <summary>
        /// 文件结束
        /// </summary>
        public Position End;
        /// <summary>
        /// 所有的Token
        /// </summary>
        private List<Token> Tokens = new List<Token>();
        /// <summary>
        /// 当前读取的索引
        /// </summary>
        private int _index = -1;
        public TokenData(string packageName)
        {
            PackageName = packageName;
        }

        /// <summary>
        /// 重置Token解析到的索引
        /// </summary>
        public void Reset()
        {
            _index = -1;
        }

        /// <summary>
        /// 读取一个Token,索引+1
        /// </summary>
        public Token ReadToken()
        {
            _index = _index + 1;
            return Tokens[_index];
        }
        /// <summary>
        /// 返回下一个Token,但是不增加索引
        /// </summary>
        /// <returns></returns>
        public Token PeekToken()
        {
            int num = _index + 1;
            return Tokens[num];
        }
        /// <summary>
        /// 后退一个Token,索引-1
        /// </summary>
        /// <returns></returns>
        public Token PreviousToken()
        {
            _index = _index - 1;
            return Tokens[_index];
        }
        /// <summary>
        /// 返回下一个Token,但是不减少索引
        /// </summary>
        /// <returns></returns>
        public Token ReverseToken()
        {
            int num = _index - 1;
            return Tokens[num];
        }

        /// <summary>
        /// 添加新的Token
        /// </summary>
        /// <param name="token"></param>
        public void AddToken(Token token)
        {
            Tokens.Add(token);
        }
    }
}
