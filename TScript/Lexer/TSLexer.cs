using System;
using System.Collections.Generic;
using System.Text;
using static TScript.Lexer.LexerConfig;

namespace TScript.Lexer
{
    /// <summary>
    /// 词法分析器
    /// </summary>
    public unsafe class TSLexer
    {
        private string _text = "";
        private List<Token> _tokens = null;
        private Position* _pos = default;
        private char _curChar = default;
        private int _length = -1;//需要解析的文件长度
        public TSLexer(string text)
        {
            _text = text;
            _length = _text.Length;

            _tokens = new List<Token>();
            Position pos = new Position(0, 0, 0);
            _pos = &pos;
        }

        public void MakeTokens()
        {
            ReadOnlySpan<char> _span = _text.AsSpan();
            this._curChar = _span[0];
            while (this._curChar != null)
            {
                char ch = this._curChar;
                if (ch == ' ' || ch == '\t')
                {
                    this.advance();
                }
                else
                {
                    this.advance();
                }
            }

        }

        /// <summary>
        /// 分析位置+1
        /// </summary>
        private void advance()
        {
            this._pos->advance(this._curChar); //index+1
            if (this._pos->Index < _length)
            {
                this._curChar++;
            }
            else
            {
                this._curChar = default;
            }

        }
    }


    public unsafe struct Position
    {
        /// <summary>
        /// 索引号
        /// </summary>
        public int Index;
        /// <summary>
        /// 行号
        /// </summary>
        public int Row;
        /// <summary>
        /// 列号
        /// </summary>
        public int Col;

        public Position(int index, int row, int col)
        {
            this.Index = index;
            this.Row = row;
            this.Col = col;
        }
        /// <summary>
        /// 分析位置+1
        /// </summary>
        /// <param name="curChar">当前字符</param>
        public void advance(char curChar)
        {
            this.Index += 1;
            this.Col += 1;
            if (curChar == NEW_LINE)
            {
                this.Col = 0;
                this.Row += 1;
            }
        }
    }
}
