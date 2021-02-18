using System;
using System.Collections.Generic;
using System.Text;
using TScript.Compile.Common;
using TScript.Compile.Lexer;
using TScript.Compile.Parser;

namespace TScript
{
    /// <summary>
    /// 代码入口
    /// </summary>
    public partial class TScript
    {
        private const string Undefined = "Undefined";                   //Undefined


        /// <summary>
        /// 加载字符串
        /// </summary>
        public void LoadString(string str, string chunk = null)
        {
            chunk = chunk ?? Undefined;
            TSLexer lexer = new TSLexer(str);
            List<Token> tokens = lexer.GetTokens();
            TSParser tsp = new TSParser(tokens);
            tsp.Parse();
        }
    }
}
