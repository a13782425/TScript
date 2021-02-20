using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Compile;
using TScript.Compile.Lexer;
using TScript.Compile.Parser;
using TScript.Instruction;
using TScript.Runtime;

namespace TScript
{
    /// <summary>
    /// 代码入口
    /// </summary>
    public partial class TScript
    {
        private const string Undefined = "Undefined";                   //Undefined

        /// <summary>
        /// 当前运行时
        /// </summary>
        private TSRuntime _curRuntime;
        /// <summary>
        /// 当前程序集
        /// </summary>
        private TSAssembly _curassembly;

        public TScript()
        {
            _curRuntime = new TSRuntime();
            _curassembly = new TSAssembly();
        }
        /// <summary>
        /// 加载字符串
        /// </summary>
        public void LoadString(string str, string chunk = null)
        {
            chunk = chunk ?? Undefined;
            TSLexer lexer = new TSLexer(str);
            List<Token> tokens = lexer.GetTokens();
            TSParser tsp = new TSParser(tokens);
            TSCompile complie = new TSCompile(tsp.Parse());
            TScriptData scriptData = complie.Complie();
            _curRuntime.Run(scriptData);
        }

        public void DoString(string str, string packageName = null)
        {
            TSLexer lexer = new TSLexer(str, packageName);
            List<Token> tokens = lexer.GetTokens();
            TSParser tsp = new TSParser(tokens);
            TSCompile complie = new TSCompile(tsp.Parse());
            TScriptData scriptData = complie.Complie();
            _curRuntime.Run(scriptData);
        }
    }
}
