using System;
using System.Collections.Generic;
using System.Text;
using TScript.Compile.Parser;
using TScript.Instruction;

namespace TScript.Compile
{
    /// <summary>
    /// 编译器
    /// </summary>
    public sealed partial class TSCompile
    {
        private RootTree _rootTree;
        public TSCompile(RootTree rootTree)
        {
            _rootTree = rootTree;
        }

        internal TScriptData Complie()
        {
            TScriptData scriptData = new TScriptData();
            foreach (var item in _rootTree.Bodys)
            {
                item.Compile(scriptData);
            }
            return scriptData;
        }
    }
}
