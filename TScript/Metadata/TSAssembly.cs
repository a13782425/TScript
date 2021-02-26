using System;
using System.Collections.Generic;
using System.Text;
using TScript.Compile;

namespace TScript.Metadata
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

        private Dictionary<int, TSClass> _classDic = new Dictionary<int, TSClass>();
        /// <summary>
        /// 所有类
        /// </summary>
        public Dictionary<int, TSClass> ClassDic => _classDic;

        private Dictionary<string, int> _packageKey = new Dictionary<string, int>();
        /// <summary>
        /// 程序包名对应的唯一Id
        /// </summary>
        public Dictionary<string, int> PackageKey => _packageKey;

        /// <summary>
        /// 词法分析器
        /// </summary>
        private TSLexer _lexer;

        /// <summary>
        /// 代码运行中间库
        /// </summary>
        private TScript _script;

        public TSAssembly(TScript script)
        {
            _script = script;
            _lexer = new TSLexer();
        }

        /// <summary>
        /// 加载字符串
        /// </summary>
        /// <param name="code">字符串</param>
        /// <param name="packageName">包名</param>
        /// <returns>解析好的程序包</returns>
        public TSPackage LoadPackage(string code, string packageName = null)
        {
            if (string.IsNullOrWhiteSpace(packageName))
            {
                packageName = PACKAGE_NAME;
            }

            TSPackage package = GetPackageMetaData(packageName);
            if (package == null)
            {
                package = new TSPackage(this, GetOnlyId(), packageName);
                _packageKey.Add(packageName, package.OnlyId);
                _packageDic.Add(package.OnlyId, package);
            }
            package.CompileCode(_lexer, code);
            return package;
        }

        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="package">程序集合</param>
        /// <returns>唯一Id</returns>
        public int RegisteredPackage(TSPackage package)
        {
            int onlyId = 0;
            if (_packageKey.ContainsKey(package.PackageName))
            {
                onlyId = _packageKey[package.PackageName];
            }
            else
            {
                onlyId = GetOnlyId();
                _packageKey.Add(package.PackageName, onlyId);
                PackageDic.Add(onlyId, package);
            }
            return onlyId;
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
        /// <summary>
        /// 根据包Id, 获取包的元数据
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public TSPackage GetPackageMetaData(int packageId)
        {
            if (_packageDic.ContainsKey(packageId))
            {
                return _packageDic[packageId];
            }
            return null;
        }
        /// <summary>
        /// 根据包名, 获取包的元数据
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public TSPackage GetPackageMetaData(string packageName)
        {
            if (_packageKey.ContainsKey(packageName))
            {
                return GetPackageMetaData(_packageKey[packageName]);
            }
            return null;
        }

        public TSClass GetClassMetaData(int classId)
        {
            return null;
        }
        public TSClass GetClassMetaData(string className)
        {
            return null;
        }
    }
}
