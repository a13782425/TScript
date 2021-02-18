using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Compile.Common
{
    public static class LexerConfig
    {
        /// <summary>
        /// 换行符
        /// </summary>
        public const char NEW_LINE = '\n';
        /// <summary>
        /// 读取完毕
        /// </summary>
        public const char END_CHAR = char.MaxValue;

        /// <summary>
        /// 关键字
        /// </summary>
        public readonly static HashSet<string> KEYWORDS = new HashSet<string>();

        static LexerConfig()
        {
            KEYWORDS.Add("var");
        }
    }
}
