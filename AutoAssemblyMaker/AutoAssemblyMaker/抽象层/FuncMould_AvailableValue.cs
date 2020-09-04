using System;
using System.Collections.Generic;

namespace AutoAssemblyMaker.抽象层
{
    class FuncMould_AvailableValue
    {
        /// <summary>
        /// 这是这个值域有多少个有效位 比如4Bit
        /// </summary>
        public int availableBit;
        /// <summary>
        /// 这是上面的值域有效的值，不同的FuncMould的Type是对应不同的涵义，详细看FuncMould中有关这个类的注释
        /// </summary>
        public List<string> availableValueSet = new List<string>();
        /// <summary>
        /// 这是一个方便比较的数值，availableBit改变就改变，是判断加入的有效值是不是有效的依据（unsigned int）
        /// </summary>
        private double maxValue;
        /// <summary>
        /// 这是最大值，double转过来的
        /// </summary>
        public int maxValueInt;

        /// <summary>
        /// 作用：接收一个数据，这是代表多少位有效的bit。会检查是不是大于0
        ///       不返回数据
        /// </summary>
        /// <param name="bitNum"></param>
        public void SetAvailablebit(int bitNum)
        {
            if(bitNum > 0)
            {
                availableBit = bitNum;
                maxValue = Math.Pow(2, bitNum);
                maxValue = maxValue - 1;
                maxValueInt = (int)maxValue;
            }
        }

        /// <summary>
        /// 作用：检查即将添加的有效值是不是符合设定的数据位的大小
        ///       举例：比如是4bit 那么就是0-15 所以输入的value要看看是不是在0-15里面
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckValueAvailable(int value)
        {
            return ((value <= maxValue)&&value>=0);
        }

        /// <summary>
        /// 作用：添加一个有效值，首先会检查是不是有效的（CheckValueAvailable）然后才会添加
        ///       不返回数据
        /// </summary>
        /// <param name="value"></param>
        public void SetAvailableValue(int value)
        {
            if(CheckValueAvailable(value))
            {
                availableValueSet.Add(value.ToString());
            }
        }

        /// <summary>
        /// 作用：在生成代码之前对所收集的数据进行正确性的检查，不过这里暂时没想到用什么
        /// </summary>
        /// <returns></returns>
        public bool CheckAvailableValueValidity()
        {
            return true;
        }
        
        /// <summary>
        /// 作用：这是初始化所有的登记的数据
        /// </summary>
        public void InitAllData()
        {
            availableBit = 0;
            availableValueSet.Clear();
            maxValue = 0;
        }
    }
}
