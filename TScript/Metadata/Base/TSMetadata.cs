using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Metadata
{
    /// <summary>
    /// 元数据
    /// </summary>
    public abstract class TSMetadata
    {
        /// <summary>
        /// 程序包唯一Id
        /// </summary>
        public readonly int OnlyId;
        /// <summary>
        /// 程序包名
        /// </summary>
        public readonly string PackageName;

        public TSMetadata(int onlyId, string packageName)
        {
            OnlyId = onlyId;
            this.PackageName = packageName;
        }
    }
}
