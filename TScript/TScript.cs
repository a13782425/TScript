using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Compile;
using TScript.Instruction;
using TScript.Metadata;
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
        private TSAssembly _curAssembly;

        public TScript()
        {
            _curRuntime = new TSRuntime();
            _curAssembly = new TSAssembly(this);
        }
        ///// <summary>
        ///// 加载字符串
        ///// </summary>
        //public void LoadString(string str, string chunk = null)
        //{
        //    chunk = chunk ?? Undefined;
        //    TSLexer lexer = new TSLexer(str);
        //    List<Token> tokens = lexer.GetTokens();
        //    TSParser tsp = new TSParser(tokens);
        //    TSCompile complie = new TSCompile(tsp.Parse());
        //    TScriptData scriptData = complie.Complie();
        //    _curRuntime.Run(scriptData);
        //}

        /// <summary>
        /// 执行字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="packageName"></param>
        public void DoString(string code, string packageName = null)
        {
            TSPackage package = _curAssembly.LoadPackage(code, packageName);
            //TSLexer lexer = new TSLexer(str, packageName);
            //List<Token> tokens = lexer.GetTokens();
            //TSParser tsp = new TSParser(tokens);
            //TSCompile complie = new TSCompile(tsp.Parse());
            //TScriptData scriptData = complie.Complie();
            //_curRuntime.Run(scriptData);
        }
    }
}
