using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;

namespace TScript.Compile
{
    /// <summary>
    /// 语法解释器
    /// 通过输入的Tokens生成对应的抽象语法树
    /// </summary>
    public sealed partial class TSParser
    {
        private List<Token> _tokens = default;
        private TokenData _tokenData = default;
        private int _index = -1;
        private Token _curToken = default;
        private RootTree _rootTree = default;
        public TSParser(List<Token> tokens)
        {
            this._tokens = tokens;
            _index = -1;
        }
        public TSParser(TokenData tokenData)
        {
            this._tokenData = tokenData;
            _tokenData.Reset();
            _index = -1;
        }

        public RootTree Parse()
        {
            //AST Root Node
            Advance();
            _rootTree = new RootTree(_curToken);
            int length = _tokens.Count;
            Advance();
            do
            {
                BaseTree tree = expr();
                if (tree != null)
                {
                    _rootTree.Bodys.Add(tree);
                }

            } while (this._index < length && this._curToken.type != TokenType.END);
            return _rootTree;
        }
        /// <summary>
        /// 分析位置+1
        /// </summary>
        /// <param name="curChar">当前字符</param>
        private void Advance()
        {
            this._index += 1;
            this.UpdateCurToken();
        }
        /// <summary>
        /// 分析位置-1
        /// </summary>
        /// <param name="amount">往前几步,默认一步</param>
        private void Reverse(int amount = 1)
        {
            this._index -= amount;
            this.UpdateCurToken();
        }
        /// <summary>
        /// 更新当前token
        /// 如果往前了几步，那么当前的token也需要更新成前几步对应的token
        /// </summary>
        /// <param name=""></param>
        private void UpdateCurToken()
        {
            if (this._index >= 0 && this._index < this._tokens.Count)
                this._curToken = this._tokens[this._index];
        }
    }

    public sealed partial class TSParser
    {
        /// <summary>
        /// 因子
        /// </summary>
        private BaseTree factor()
        {
            switch (_curToken.type)
            {
                case TokenType.LONG_NUM:
                    return new LongTree(_curToken);
                case TokenType.DOUBLE_NUM:
                    return new DoubleTree(_curToken);
                case TokenType.END:
                    return new NopTree(_curToken);
            }

            return null;
        }

        private BaseTree expr()
        {
            BaseTree res = term();
            this.Advance();
            while (this._curToken.type == TokenType.PLUS || this._curToken.type == TokenType.MINUS)
            {
                Token op = this._curToken;
                this.Advance();
                BaseTree right = term();
                BaseTree left = res;
                res = new BinaryTree(op);
                ((BinaryTree)res).LeftTree = left;
                ((BinaryTree)res).RightTree = right;
                this.Advance();
            }
            if (this._curToken.type != TokenType.END)
            {
                this.Reverse();
            }
            return res;
        }
        private BaseTree term()
        {
            BaseTree res = factor();
            this.Advance();
            while (this._curToken.type == TokenType.MUL || this._curToken.type == TokenType.MUL)
            {
                Token op = this._curToken;
                this.Advance();
                BaseTree right = factor();
                BaseTree left = res;
                res = new BinaryTree(op);
                ((BinaryTree)res).LeftTree = left;
                ((BinaryTree)res).RightTree = right;
                this.Advance();
            }
            if (this._curToken.type != TokenType.END)
            {
                this.Reverse();
            }
            return res;
        }

    }
}
