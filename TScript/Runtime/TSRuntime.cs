using System;
using System.Collections.Generic;
using System.Text;
using TScript.Instruction;

namespace TScript.Runtime
{
    /// <summary>
    /// 运行时,根据对应的OpCode进行相对应的操作
    /// </summary>
    public sealed class TSRuntime
    {
        private TSContext _curContext;

        /// <summary>
        /// 计算栈
        /// </summary>
        public Stack<object> CalStack { get; private set; }

        /// <summary>
        /// 变量列表
        /// </summary>
        public List<object> VarList { get; private set; }
        public TSRuntime()
        {
            _curContext = new TSContext();
            CalStack = new Stack<object>();
            VarList = new List<object>();
        }



        public void Run(TScriptData scriptData)
        {
            Run(scriptData.CodeList);
        }

        private void Run(List<BaseCode> codes)
        {
            foreach (var item in codes)
            {
                item.Run(this, _curContext);
            }
            Console.WriteLine(CalStack.Pop());
        }

    }
}
