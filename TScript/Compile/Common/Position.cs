using System;
using System.Collections.Generic;
using System.Text;
using static TScript.Compile.Common.LexerConfig;

namespace TScript.Compile.Common
{
    /// <summary>
    /// 代码所在在位置
    /// </summary>
    public sealed class Position
    {
        /// <summary>
        /// 索引号
        /// </summary>
        public int Index;
        /// <summary>
        /// 行号
        /// </summary>
        public int Row;
        /// <summary>
        /// 列号
        /// </summary>
        public int Col;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">索引</param>
        /// <param name="row">行号</param>
        /// <param name="col">列号</param>
        public Position(int index, int row, int col)
        {
            this.Index = index;
            this.Row = row;
            this.Col = col;
        }
        /// <summary>
        /// 分析位置+1
        /// </summary>
        /// <param name="curChar">当前字符</param>
        public void Advance(char curChar = END_CHAR)
        {
            this.Index += 1;
            this.Col += 1;
            if (curChar == NEW_LINE)
            {
                this.Col = 0;
                this.Row += 1;
            }
        }
        /// <summary>
        /// 分析位置-1
        /// </summary>
        public void Reverse()
        {
            if (this.Index == 0)
                throw new LexerException(this, "Cannot retreat char beyond start of source.");
            this.Index -= 1;
            this.Col -= 1;
        }

        public Position Copy()
        {
            return new Position(this.Index, this.Row, this.Col);
        }
    }
}
