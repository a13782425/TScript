using System;
using System.Collections.Generic;
using System.Text;

namespace TScript.Runtime
{
    /// <summary>
    /// 程序集
    /// </summary>
    public sealed class TSAssembly
    {

        /// <summary>
        /// 默认程序包名
        /// </summary>
        private const string PACKAGE_NAME = "Undefined";
        /// <summary>
        /// 全局的唯一Id
        /// </summary>
        private int _onlyId = int.MinValue;

        private Dictionary<int, TSPackage> _packageDic = new Dictionary<int, TSPackage>();
        /// <summary>
        /// 所有的程序包
        /// </summary>
        public Dictionary<int, TSPackage> PackageDic => _packageDic;

        private Dictionary<string, int> _packageKey = new Dictionary<string, int>();
        /// <summary>
        /// 程序包名对应的唯一Id
        /// </summary>
        public Dictionary<string, int> PackageKey => _packageKey;


        public TSAssembly()
        {

        }

        /// <summary>
        /// 加载字符串
        /// </summary>
        /// <param name="code">字符串</param>
        /// <param name="packageName">包名</param>
        public void LoadPackage(string code, string packageName =null)
        {
            packageName = packageName ?? PACKAGE_NAME;
        }

        /// <summary>
        /// 获取全局唯一Id
        /// </summary>
        /// <returns></returns>
        public int GetOnlyId()
        {
            int id = _onlyId;
            _onlyId++;
            if (_onlyId == int.MaxValue)
            {
                throw new StackOverflowException("一个程序集所包含公共的变量,类,包不能超过21亿个");
            }
            return _onlyId;
        }
    }
}
