using System;
using System.Collections.Generic;
using System.Text;
using TScript.Common;
using TScript.Instruction;

namespace TScript.Compile
{
    /// <summary>
    /// 二元表达式树
    /// </summary>
    public sealed class BinaryTree : BaseTree
    {
        public BinaryTree(Token token) : base(token)
        {
        }

        public override TreeCode Code => TreeCode.BINARY;

        public BaseTree LeftTree { get; set; }
        public BaseTree RightTree { get; set; }
        public override void Compile(TScriptData scriptData)
        {
            LeftTree.Compile(scriptData);
            RightTree.Compile(scriptData);
            switch (type)
            {
                case TokenType.PLUS:
                    scriptData.CodeList.Add(new AddOpCode());
                    break;
                case TokenType.MINUS:
                    scriptData.CodeList.Add(new SubOpCode());
                    break;
                case TokenType.MUL:
                    scriptData.CodeList.Add(new MulOpCode());
                    break;
                case TokenType.DIV:
                    scriptData.CodeList.Add(new DivOpCode());
                    break;
                default:
                    break;
            }
        }
    }
}
