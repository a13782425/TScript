using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Compile
{
    /// <summary>
    /// 语法树节点类型
    /// </summary>
    public enum TreeCode
    {
        /// <summary>
        /// 根节点
        /// </summary>
        ROOT,

        /// <summary>
        /// 64位整型
        /// </summary>
        LONG_NUM,
        /// <summary>
        /// 双精度浮点
        /// </summary>
        DOUBLE_NUM,
        /// <summary>
        /// 二元表达式
        /// </summary>
        BINARY,

        /// <summary>
        /// 空指令
        /// </summary>
        NOP,
    }
}
