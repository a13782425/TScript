using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Instruction
{
    /// <summary>
    /// 指令码
    /// </summary>
    public enum OpCode
    {
        /// <summary>
        /// 压栈
        /// </summary>
        Push = 1,
        /// <summary>
        /// 相加
        /// </summary>
        Add = 2,
        /// <summary>
        /// 相减
        /// </summary>
        Sub = 3,
        /// <summary>
        /// 相乘
        /// </summary>
        Mul = 4,
        /// <summary>
        /// 相减
        /// </summary>
        Div = 5,
    }
}
