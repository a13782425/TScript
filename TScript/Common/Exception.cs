using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Common
{
    /// <summary>
    /// 解析异常
    /// </summary>
    public class LexerException : System.Exception
    {
        public LexerException(Position pos, string message) : base($"行号:{pos.Row + 1} 列号:{pos.Col} : {message}") { }
        public LexerException(string chunk, int row, int col, string message) : base($"文件:{chunk} 行号:{row} 列号:{col} : {message}") { }
    }
}
