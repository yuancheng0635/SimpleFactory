using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    /// <summary>
    /// 运算类
    /// </summary>
    public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;

        /// <summary>
        /// 数字A
        /// </summary>
        public double NumberA
        {
            get
            {
                return _numberA;
            }
            set
            {
                _numberA = value;
            }
        }

        /// <summary>
        /// 数字B
        /// </summary>
        public double NumberB
        {
            get
            {
                return _numberB;
            }
            set
            {
                _numberB = value;
            }
        }

        /// <summary>
        /// 得到运算结果
        /// </summary>
        /// <returns></returns>
        public virtual double getResult()
        {
            double result = 0;
            return result;
        }
    }

    /// <summary>
    /// 加法类
    /// </summary>
    class OperationAdd : Operation
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }

    /// <summary>
    /// 减法类
    /// </summary>
    class OperationSub : Operation
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }

    /// <summary>
    /// 乘法类
    /// </summary>
    class OperationMul : Operation
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }

    /// <summary>
    /// 除法类
    /// </summary>
    class OperationDiv : Operation
    {
        public override double getResult()
        {
            double result = 0;
            if (NumberB == 0)
                throw new Exception("除数不能为0。");
            result = NumberA / NumberB;
            return result;
        }
    }


    /// <summary>
    /// 运算类工厂
    /// </summary>
    class OperationFactory
    {
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    {
                        oper = new OperationAdd();
                        break;
                    }
                case "-":
                    {
                        oper = new OperationSub();
                        break;
                    }
                case "*":
                    {
                        oper = new OperationMul();
                        break;
                    }
                case "/":
                    {
                        oper = new OperationDiv();
                        break;
                    }
            }
            return oper;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入数字A：");
            string strNumberA = Console.ReadLine();
            Console.Write("请选择运算符号(+、-、*、/)：");
            string strOperate = Console.ReadLine();
            Console.Write("请输入数字B：");
            string strNumberB = Console.ReadLine();
            string strResult = "";

            Operation oper;
            oper = OperationFactory.createOperate(strOperate);
            oper.NumberA = Convert.ToDouble(strNumberA);
            oper.NumberB = Convert.ToDouble(strNumberB);
            strResult = oper.getResult().ToString();

            Console.WriteLine("结果是：" + strResult);
            Console.ReadLine();
        }
    }
}
