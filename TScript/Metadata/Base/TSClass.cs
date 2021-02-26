using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Metadata
{
    /// <summary>
    /// 类元数据
    /// </summary>
    public abstract class TSClass : TSMetadata
    {
        public readonly string ClassName = default;

        public TSClass(int onlyId, string packageName, string className) : base(onlyId, packageName)
        {
            this.ClassName = className;
        }
    }
}
