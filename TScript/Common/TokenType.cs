using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Common
{
    /// <summary>
    /// 脚本的表征类型
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// 开始
        /// </summary>
        BEGIN,
        /// <summary>
        /// {
        /// </summary>
        LEFT_BRACE,
        /// <summary>
        /// }
        /// </summary>
        RIGHT_BRACE,
        /// <summary>
        /// (
        /// </summary>
        LEFT_PAR,
        /// <summary>
        /// )
        /// </summary>
        RIGHT_PAR,
        /// <summary>
        /// [
        /// </summary>
        LEFT_BRACKET,
        /// <summary>
        /// ]
        /// </summary>
        RIGHT_BRACKET,
        /// <summary>
        /// .
        /// </summary>
        DOT,
        /// <summary>
        /// 整数数字 20
        /// </summary>
        LONG_NUM,
        /// <summary>
        /// 小数数字 3.1
        /// </summary>
        DOUBLE_NUM,
        /// <summary>
        /// 加号 +
        /// </summary>
        PLUS,
        /// <summary>
        /// 减号 -
        /// </summary>
        MINUS,
        /// <summary>
        /// 乘号 *
        /// </summary>
        MUL,
        /// <summary>
        /// 除号 /
        /// </summary>
        DIV,

        /// <summary>
        /// 结束
        /// </summary>
        END,
    }
}
