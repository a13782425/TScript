using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Runtime
{
    /// <summary>
    /// 程序包
    /// 一个文件为一个包
    /// </summary>
    public sealed class TSPackage
    {
        /// <summary>
        /// 程序包唯一Id
        /// </summary>
        public readonly int OnlyId;
        /// <summary>
        /// 程序包名
        /// </summary>
        public readonly string PackageName = default;
        /// <summary>
        /// 当前包包含了哪些包
        /// key:OnlyId Value:程序包
        /// </summary>
        private Dictionary<int, TSPackage> _includePackageDic = new Dictionary<int, TSPackage>();
        public TSPackage(string packageName)
        {
            this.PackageName = packageName;
        }
    }
}
