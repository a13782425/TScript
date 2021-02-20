using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Common
{
    public readonly struct Token
    {
        public readonly string chunk;
        public readonly TokenType type;
        public readonly object value;

        public readonly Position start;
        public readonly Position end;

        public Token(string chunk, TokenType type, object value, Position start, Position end)
        {
            this.chunk = chunk;
            this.type = type;
            this.value = value;
            this.start = start;
            this.end = end;

        }
    }
}
