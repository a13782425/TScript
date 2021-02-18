using System;
using System.Collections.Generic;
using System.Text;
using TScript.Compile.Common;
using static TScript.Compile.Common.LexerConfig;

namespace TScript.Compile.Lexer
{
    /// <summary>
    /// 词法分析器
    /// </summary>
    public partial class TSLexer
    {
        private string _strBuffer = "";
        private string _chunk = "";
        private List<Token> _tokens = null;
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
        public TSLexer(string text, string chunk = null)
        {
            _chunk = chunk ?? "Undefined";
            _strBuffer = text;
            _length = _strBuffer.Length;
            _tokens = new List<Token>();
            _pos = new Position(-1, 1, 0);
        }


        public List<Token> GetTokens()
        {
            _curChar = END_CHAR;
            _tokens.Clear();
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
            return _tokens;
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
            AddToken(token, value, _curRow, _curCol);
        }
        private void AddToken(TokenType type, object lexeme, int startRow, int startCol)
        {
            _tokens.Add(new Token(_chunk, type, lexeme, startRow, startCol, _curRow, _curCol));
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
            int startRow = _curRow;
            int startCol = _curCol;
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
                        AddToken(TokenType.DOUBLE_NUM, double.Parse(_builder.ToString()), startRow, startCol);
                    }
                    else
                    {
                        AddToken(TokenType.LONG_NUM, long.Parse(_builder.ToString()), startRow, startCol);
                    }
                    break;
                }
            } while (true);
        }
    }
}
