using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Compile;
using TScript.Instruction;

namespace TScript.Metadata
{
    /// <summary>
    /// 程序包
    /// 一个文件为一个包
    /// </summary>
    public sealed class TSPackage : TSMetadata
    {

        /// <summary>
        /// 当前包包含了哪些包
        /// key:OnlyId Value:程序包
        /// </summary>
        private Dictionary<int, TSPackage> _includePackageDic = new Dictionary<int, TSPackage>();


        /// <summary>
        /// 类元数据集合
        /// </summary>
        public Dictionary<int, TSClass> ClassMetadataDic = new Dictionary<int, TSClass>();

        private List<BaseCode> _onceCodeList = new List<BaseCode>();
        /// <summary>
        /// 只执行一次的指令集
        /// </summary>
        public List<BaseCode> OnceCodeList => _onceCodeList;

        /// <summary>
        /// 当前包所在的程序及
        /// </summary>
        private readonly TSAssembly _assembly;
        public TSPackage(TSAssembly assembly, int onlyId, string packageName) : base(onlyId, packageName)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// 编译代码
        /// </summary>
        /// <param name="code">代码字节</param>
        public void CompileCode(TSLexer lexer, string code)
        {
            //编译步骤
            //第一步:词法分析
            TokenData tokenData = lexer.GetTokens(code, this.PackageName);
            //第二部:词法解释器,根据上下文无关文法(例如BNF巴科斯范式)生成抽象语法树
            TSParser parser = new TSParser(tokenData);
            parser.Parse();
        }
    }
}
