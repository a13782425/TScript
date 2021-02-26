using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using static TScript.Common.LexerConfig;

namespace TScript.Compile
{
    /// <summary>
    /// 词法分析器
    /// 通过输入的文本生成对应的Token
    /// </summary>
    public partial class TSLexer
    {
        private string _strBuffer = "";
        private string _packageName = "";
        private TokenData _token = null;
        /// <summary>
        /// 代码读取结束
        /// </summary>
        private bool END_SCRIPT = false;
        /// <summary>
        /// 当前读到的位置
        /// </summary>
        private Position _pos = default;
        /// <summary>
        /// 当前读到的字符
        /// </summary>
        private char _curChar = END_CHAR;
        /// <summary>
        /// 临时缓存字符
        /// </summary>
        private char _tempChar = END_CHAR;
        /// <summary>
        /// 需要解析的文件长度
        /// </summary>
        private int _length = -1;
        /// <summary>
        /// 当前解析到的字符串
        /// </summary>
        private int _curIndex = -1;
        /// <summary>
        /// 当前行
        /// </summary>
        private int _curRow = -1;
        /// <summary>
        /// 当前列
        /// </summary>
        private int _curCol = -1;

        /// <summary>
        /// 当前缓存的字符串
        /// </summary>
        private StringBuilder _builder = new StringBuilder();
        public TSLexer() { }

        /// <summary>
        /// 获取到Token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public TokenData GetTokens(string code, string packageName)
        {
            _packageName = packageName;
            _strBuffer = code;
            _length = _strBuffer.Length;
            _pos = new Position(-1, 1, 0);
            return GetTokens();
        }

        /// <summary>
        /// 获取到Token
        /// </summary>
        /// <returns></returns>
        public TokenData GetTokens()
        {
            _token = new TokenData(_packageName);
            _token.Start = _pos.Copy();
            _curChar = END_CHAR;
            _builder.Clear();
            _curRow = 1;
            while (_curIndex < _length && !END_SCRIPT)
            {
                this._curChar = ReadChar();
                switch (this._curChar)
                {
                    case '\n':
                        AddLine();
                        break;
                    case ' ':
                    case '\r':
                    case '\t':
                        break;
                    case '+':
                        AddToken(TokenType.PLUS);
                        break;
                    case '-':
                        AddToken(TokenType.MINUS);
                        break;
                    case '*':
                        AddToken(TokenType.MUL);
                        break;
                    case '/':
                        AddToken(TokenType.DIV);
                        break;
                    case '(':
                        AddToken(TokenType.LEFT_PAR);
                        break;
                    case ')':
                        AddToken(TokenType.RIGHT_PAR);
                        break;
                    default:
                        if (char.IsDigit(this._curChar))
                        {
                            ReadNumber();
                        }
                        break;
                }
            }
            _token.End = _pos.Copy();
            return _token;
        }


    }




    public partial class TSLexer
    {
        /// <summary>
        /// 添加标记
        /// </summary>
        /// <param name="token"></param>
        private void AddToken(TokenType token)
        {
            AddToken(token, _curChar);
        }
        /// <summary>
        /// 添加标记
        /// </summary>
        /// <param name="token"></param>
        /// <param name="value"></param>
        private void AddToken(TokenType token, object value)
        {
            AddToken(token, value, new Position(_curIndex, _curRow, _curCol));
        }
        private void AddToken(TokenType type, object lexeme, Position start)
        {
            AddToken(type, lexeme, start, new Position(_curIndex, _curRow, _curCol));
        }
        private void AddToken(TokenType type, object lexeme, Position start, Position end)
        {
            _token.AddToken(new Token(_packageName, type, lexeme, start, end));
            _builder.Clear();
        }

        /// <summary>
        /// 读取下一个字符并前进异步
        /// </summary>
        /// <returns></returns>
        private char ReadChar()
        {
            this._curIndex++;
            this._curCol++;
            if (_curIndex < _length)
            {
                return _strBuffer[_curIndex];
            }
            else if (_curIndex == _length)
            {
                END_SCRIPT = true;
                return END_CHAR;
            }
            throw new LexerException(this._pos, "End of source reached.");
        }
        /// <summary>
        /// 读取下一个字符但不前进
        /// </summary>
        /// <returns></returns>
        private char PeekChar()
        {
            int index = this._curIndex + 1;
            if (index < _length)
            {
                return _strBuffer[index];
            }
            else if (index == _length)
            {
                return END_CHAR;
            }
            throw new LexerException(this._pos, "End of source reached.");
        }
        /// <summary>
        /// 后退一步
        /// </summary>
        private void UndoChar()
        {
            this._curIndex--;
            this._curCol--;
        }

        private void AddLine()
        {
            this._curCol = -1;
            this._curRow++;
        }
        /// <summary>
        /// 读取数字
        /// </summary>
        /// <param name="lexer"></param>
        private void ReadNumber()
        {
            _builder.Append(_curChar);
            int dot_coumt = 0;
            Position start = new Position(_curIndex, _curRow, _curCol);
            do
            {
                _tempChar = ReadChar();
                if (char.IsDigit(_tempChar))
                {
                    _builder.Append(_tempChar);
                }
                else if (_tempChar == '.')
                {
                    if (dot_coumt == 1)
                        throw new LexerException(this._pos, "数字解析失败");
                    dot_coumt += 1;
                    _builder.Append(_tempChar);
                }
                else
                {
                    UndoChar();
                    if (dot_coumt > 0)
                    {
                        AddToken(TokenType.DOUBLE_NUM, double.Parse(_builder.ToString()), start);
                    }
                    else
                    {
                        AddToken(TokenType.LONG_NUM, long.Parse(_builder.ToString()), start);
                    }
                    break;
                }
            } while (true);
        }
    }
}
