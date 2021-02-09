using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Lexer
{
    public readonly struct Token
    {
        public readonly TokenType type;
        public readonly string value;

        public Token(TokenType type, string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
