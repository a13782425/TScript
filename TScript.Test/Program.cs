using System;
using TScript;
using System.Collections.Generic;
using System.Diagnostics;

namespace TScript.Test
{
    class Program
    {
        static Program()
        {

        }
        const int LENGTH = 10000;
        const int TEST = 100;
        static void Main(string[] args)
        {
            TScript ts = new TScript();
            ts.DoString("12+1.3+1+10+20-4.3");
            //ts.LoadString("12+1.3+1+10+20-4.3");

            //TSLexer lexer = new TSLexer("12+1.3");
            //lexer.GetTokens();
            //ScriptTest();
            //double b = 1.1;
            //int a = 12;
            //b = a - b;
            //b = a + b;
            //b = a - b;
            //b = a * b;
            //b = a / b;
            //b = -b;
            //var c = b + "1";
            //int b = 1 + 1 * 2 + (2 + 3) / 5 - 10;
            //DicTest();
            //SwitchTest();
            //StrDicTest2();
            //StrDicTest();
            //IntDicTest2();
            //Console.WriteLine(b);
            //    goto Te;
            //    Test();
            //Te: a = Test();
            Console.ReadLine();
        }
        static int Test()
        {
            return 1;
        }
        static void ScriptTest()
        {
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < TEST; i++)
            {
                //TScript ts = new TScript();
                //ts.LoadString("12+1.3+1+10+20-4.3");
                Console.WriteLine(12 + 1.3 + 1 + 10 + 20 - 4.3);
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            Console.WriteLine("ScriptTest：{0}(毫秒)", timespan.TotalMilliseconds);  //总毫秒数
        }
        static void StrDicTest()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string str = "";
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                string temp = Guid.NewGuid().ToString();
                if (i == 0)
                {
                    str = temp;
                }
                int num = random.Next(0, 10000);

                if (num < 5000)
                {
                    str = temp;
                }
                dic.Add(temp, temp);
            }
            long res = 0;
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < TEST; i++)
            {
                if (dic.ContainsKey(str))
                {
                    res++;
                }
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            Console.WriteLine("strDic：{0}(毫秒)", timespan.TotalMilliseconds);  //总毫秒数
            Console.WriteLine("strDic:" + res);
        }

        static void StrDicTest2()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string str = "";
            Random random = new Random();
            for (int i = 0; i < LENGTH; i++)
            {
                string temp = Guid.NewGuid().ToString();
                if (i == 0)
                {
                    str = temp;
                }
                int num = random.Next(0, 10000);

                if (num < 5000)
                {
                    str = temp;
                }
                dic.Add(temp, temp);
            }
            long res = 0;
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < TEST; i++)
            {
                if (dic.ContainsKey(str))
                {
                    res++;
                }
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            Console.WriteLine("strDic2：{0}(毫秒)", timespan.TotalMilliseconds);  //总毫秒数
            Console.WriteLine("strDic2:" + res);
        }
        static void IntDicTest2()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int num = 0;
            Random random = new Random();
            for (int i = 0; i < LENGTH; i++)
            {
                int temp = random.Next(0, 10000);

                if (temp < 5000)
                {
                    num = temp;
                }
                dic.Add(i, i);
            }
            long res = 0;
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < TEST; i++)
            {
                if (dic.ContainsKey(num))
                {
                    res++;
                }
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            Console.WriteLine("intDic2：{0}(毫秒)", timespan.TotalMilliseconds);  //总毫秒数
            Console.WriteLine("intDic2:" + res);
        }
        /// <summary>
        /// dicTest
        /// </summary>
        static void DicTest()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < 30; i++)
            {
                dic.Add(i, i);
            }
            long res = 0;
            Random random = new Random();
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < TEST; i++)
            {
                int num = random.Next(0, 30);
                res += dic[num];
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            Console.WriteLine("dic：{0}(毫秒)", timespan.TotalMilliseconds);  //总毫秒数
            Console.WriteLine("dic:" + res);
        }
        static void SwitchTest()
        {
            long res = 0;
            Random random = new Random();
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            for (int i = 0; i < TEST; i++)
            {
                int num = random.Next(0, 100);
                switch (num)
                {
                    case 0:
                        res += num;
                        break;
                    case 1:
                        res += num;
                        break;
                    case 2:
                        res += num;
                        break;
                    case 3:
                        res += num;
                        break;
                    case 4:
                        res += num;
                        break;
                    case 5:
                        res += num;
                        break;
                    case 6:
                        res += num;
                        break;
                    case 7:
                        res += num;
                        break;
                    case 8:
                        res += num;
                        break;
                    case 9:
                        res += num;
                        break;
                    case 10:
                        res += num;
                        break;
                    case 11:
                        res += num;
                        break;
                    case 12:
                        res += num;
                        break;
                    case 13:
                        res += num;
                        break;
                    case 14:
                        res += num;
                        break;
                    case 15:
                        res += num;
                        break;
                    case 16:
                        res += num;
                        break;
                    case 17:
                        res += num;
                        break;
                    case 18:
                        res += num;
                        break;
                    case 19:
                        res += num;
                        break;
                    case 20:
                        res += num;
                        break;
                    case 21:
                        res += num;
                        break;
                    case 22:
                        res += num;
                        break;
                    case 23:
                        res += num;
                        break;
                    case 24:
                        res += num;
                        break;
                    case 25:
                        res += num;
                        break;
                    case 26:
                        res += num;
                        break;
                    case 27:
                        res += num;
                        break;
                    case 28:
                        res += num;
                        break;
                    case 29:
                        res += num;
                        break;
                    case 30:
                        res += num;
                        break;
                    default:
                        res += num;
                        break;
                }
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            Console.WriteLine("switch：{0}(毫秒)", timespan.TotalMilliseconds);  //总毫秒数
            Console.WriteLine("switch:" + res);
        }
    }
}
