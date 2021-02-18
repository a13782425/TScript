using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Compile.Common
{
    public readonly struct Token
    {
        public readonly string chunk;
        public readonly TokenType type;
        public readonly object value;

        public readonly int startRow;
        public readonly int startCol;
        public readonly int endRow;
        public readonly int endCol;
        public Token(string chunk, TokenType type, object value, int startRow, int startCol, int endRow, int endCol)
        {
            this.chunk = chunk;
            this.type = type;
            this.value = value;
            this.startRow = startRow;
            this.startCol = startCol;
            this.endRow = endRow;
            this.endCol = endCol;
        }
    }
}
