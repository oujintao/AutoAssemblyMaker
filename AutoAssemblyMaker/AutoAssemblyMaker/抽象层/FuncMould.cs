using System.Collections.Generic;

namespace AutoAssemblyMaker.抽象层
{
    class FuncMould
    {
        /// <summary>
        /// 用在li t0,name中  比如li t0,GPIO_CTRL_ADDR
        /// </summary>
        private string baseAddrName;
        /// <summary>
        /// 用在sw t1,regName(t0) 比如 sw t1,OUTPUT_VAL(t0)
        /// </summary>
        private string regName;
        /// <summary>
        /// write就是0，只是写入一个数，不需要返回数据。read就是1，需要读出寄存器的值 都要就是3
        /// </summary>
        private int writeOrRead;
        /// <summary>
        /// 要不要对t0,t1,t2,t3等数据进行保护
        /// </summary>
        private bool stackSaveRegTX;
        /// <summary>
        /// 这是表明这个寄存器只有一个域是有效的，比如IP系列的，就是32位只有一个位有效
        /// 主要是这样的话就不需要只是清空局外的值，流程简单
        /// </summary>
        private bool seizeReg;
        /// <summary>
        /// 要不要定义一些宏定义，这样函数使用的时候就可以在传参的时候用这些宏
        /// </summary>
        private bool defineSomeValue;
        /// <summary>
        /// 高位的数据位的下标
        /// </summary>
        private int highIndexBit;
        /// <summary>
        /// 低位的数据为的下标
        /// </summary>
        private int lowIndexBit;
        /// <summary>
        /// 使能位  比如一个数据位控制一个功能的使用
        /// </summary>
        private bool enableType;
        /// <summary>
        /// 数据位的位置
        /// </summary>
        private int enableBit;
        /// <summary>
        /// bit的定义是什么
        /// </summary>
        private string bitName;
        /// <summary>
        /// 这是对于多个位，可以设置不同的值，而且选择的值域是连续的
        /// </summary>
        private bool setValueType;
        /// <summary>
        /// setValue模式具有最大值，也就是局部范围
        /// </summary>
        private bool setValueLocalScope;
        /// <summary>
        /// 这个是记录值域的最大值
        /// </summary>
        private FuncMould_AvailableValue setValueType_AvailableValueSet = new FuncMould_AvailableValue();
        /// <summary>
        /// 这是对于多个位，可以设置不同的值，是可以选择不连续值域的值，看上去就像一个状态的设置
        /// </summary>
        private bool setModeType;
        /// <summary>
        /// 对应setModeType的的注释，用来记录断开的值域，这个是一个一个的记录的
        /// </summary>
        private FuncMould_AvailableValue setModeType_AvailableValueSet = new FuncMould_AvailableValue();
        /// <summary>
        /// 模式的名字。比如，定时器中的  always
        /// </summary>
        private List<string> modeStringSet = new List<string>();
        /// <summary>
        /// 是不是设置模式的生成中，每个模式单独使能，就是多少模式产生多少函数
        /// </summary>
        private bool setModeSingleType = true;

        /// <summary>
        /// 作用：构造函数
        /// </summary>
        public FuncMould()
        {
            baseAddrName = "";
            regName = "";
            writeOrRead = 0;
            stackSaveRegTX = true;
            seizeReg = false;
            defineSomeValue = false;
            highIndexBit = -1;
            lowIndexBit = -1;
            enableType = false;
            enableBit = 0;
            bitName = "";
            setValueType = false;
            setValueLocalScope = false;
            setValueType_AvailableValueSet.InitAllData();
            setModeType = false;
            setModeType_AvailableValueSet.InitAllData();
            modeStringSet.Clear();
            setModeSingleType = true;
        }

        /// <summary>
        /// Set系列的都是填充信息的
        /// </summary>
        /// <param name="baseAddrNamee"></param>
        public void SetBaseAddrName(string baseAddrNamee) { baseAddrName = baseAddrNamee; }

        /// <summary>
        /// 设置寄存器的名字
        /// </summary>
        /// <param name="regNamee"></param>
        public void SetRegName(string regNamee) { regName = regNamee; }

        /// <summary>
        /// 作用：设置writeOrRead，和GUI的复选框对应
        /// </summary>
        /// <param name="value"></param>
        public void SetWriteOrRead(int value) { writeOrRead = value; }

        /// <summary>
        /// 作用：设置stackSaveRegTX，和GUI的复选框对应
        /// </summary>
        /// <param name="value"></param>
        public void SetStackSaveRegTX(bool value) { stackSaveRegTX = value; }

        /// <summary>
        /// 作用：设置seizeReg，和GUI的复选框对应
        /// </summary>
        /// <param name="value"></param>
        public void SetSeizeReg(bool value) { seizeReg = value; }

        /// <summary>
        /// 作用：设置SetDefineSomeValue，和GUI的复选框对应
        /// </summary>
        /// <param name="value"></param>
        public void SetDefineSomeValue(bool value) { defineSomeValue = value; }

        /// <summary>
        /// 设置高低位的值 比如31..28 这里的high就是31   low 28
        /// </summary>
        /// <param name="value"></param>
        public void SetHighLowIndexBit(int high, int low)
        {
            if (low > high) return;
            if (high >= 0)
            {
                highIndexBit = high;
            }
            if (low >= 0)
            {
                lowIndexBit = low;
            }
            setValueType_AvailableValueSet.SetAvailablebit(high - low + 1);
            setModeType_AvailableValueSet.SetAvailablebit(high - low + 1);
        }

        /// <summary>
        /// 数值的存放
        /// </summary>
        /// <param name="enableBitt"></param>
        public void SetEnableBit(int enableBitt) { enableBit = enableBitt; }

        /// <summary>
        /// 数值的存放
        /// </summary>
        /// <param name="bitNamee"></param>
        public void SetBitName(string bitNamee) { bitName = bitNamee; }

        /// <summary>
        /// 作用：设置生成的汇编类型，和GUI（多个控件）对应
        /// </summary>
        /// <param name="value"></param>
        public void SetType(int value)
        {
            if (value == 0) { enableType = true; setValueType = false; setModeType = false; }
            else if (value == 1) { enableType = false; setValueType = true; setModeType = false; }
            else if (value == 2) { enableType = false; setValueType = false; setModeType = true; }
            else { enableType = false; setValueType = false; setModeType = false; }
        }
        /// <summary>
        /// 设置是不是存在局部范围
        /// </summary>
        /// <param name="localScope"></param>
        public void SetSetValueLocalScope(bool localScope) { setValueLocalScope = localScope; }

        /// <summary>
        /// 得知最大最小值，设置局部的范围
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public void SetSetValueMaxValue(string minValue, string maxValue)
        {
            setValueType_AvailableValueSet.availableValueSet.Clear();
            setValueType_AvailableValueSet.availableValueSet.Add(minValue);
            setValueType_AvailableValueSet.availableValueSet.Add(maxValue);
        }

        /// <summary>
        /// 设置局部范围，就是0-maxValue
        /// </summary>
        /// <param name="maxValue"></param>
        public void SetSetValueMaxValue(string maxValue)
        {
            setValueType_AvailableValueSet.availableValueSet.Clear();
            setValueType_AvailableValueSet.availableValueSet.Add(maxValue);
        }

        /// <summary>
        /// 添加可用的模式值
        /// </summary>
        /// <param name="modeNum"></param>
        public void AddModeNum(string modeNum) { setModeType_AvailableValueSet.availableValueSet.Add(modeNum); }

        /// <summary>
        /// 清空目前得到的模式（数字）
        /// </summary>
        public void ClearModeNum() { setModeType_AvailableValueSet.availableValueSet.Clear(); }

        /// <summary>
        /// 这是添加模式的形容string 下标要保证和GUI的一致
        /// </summary>
        /// <param name="modeString"></param>
        public void AddModeString(string modeString) { modeStringSet.Add(modeString); }

        /// <summary>
        /// 清空模式名字集合
        /// </summary>
        public void ClearModeString() { modeStringSet.Clear(); }

        /// <summary>
        /// 是一个一个的生成 true 否则 false
        /// </summary>
        /// <param name="setModeSingleTypee"></param>
        public void SetModeSingleType(bool setModeSingleTypee) { setModeSingleType = setModeSingleTypee; }

        /// <summary>
        /// 作用：在生成代码之前对所收集的数据进行正确性的检查
        /// </summary>
        /// <returns></returns>
        public string CheckFuncMouldVaildity()
        {
            if (enableType || setValueType || setModeType) return "No Set Type";
            if (highIndexBit == -1) return "No Set HighIndexBit";
            if (lowIndexBit == -1) return "No Set LowIndexBit";
            if (highIndexBit < lowIndexBit) return "highIndexBit lower than lowIndexBit";
            //if (highIndexBit > FuncMould.maxIndexBit) return "highIndexBit higher than maxIndexBit";
            if (!setValueType_AvailableValueSet.CheckAvailableValueValidity()) { return "about SetValueType_valueSet"; }
            if (!setModeType_AvailableValueSet.CheckAvailableValueValidity()) { return "about SetModeType_valueSet"; };
            return "";
        }

        /// <summary>
        /// 利用toolString来生成代码
        /// </summary>
        /// <param name="toolString"></param>
        /// <returns></returns>
        public string GenerateAssemblyCode(ToolString toolString,bool defineSomeTarget,bool multipDevInfTarget)
        {
            string resultCode = "";
            if (writeOrRead == 2)  //rw
            {
                resultCode += GenerateAssemblyCode_writeOrRead(toolString, 1);
                resultCode += GenerateAssemblyCode_writeOrRead(toolString, 0);
            }
            else if (writeOrRead == 1) //r
            {
                resultCode += GenerateAssemblyCode_writeOrRead(toolString, 1);
            }
            else if (writeOrRead == 0)  //w
            {
                resultCode += GenerateAssemblyCode_writeOrRead(toolString, 0);
            }
            if (setModeType && defineSomeTarget && !multipDevInfTarget)
            {
                for (int i = 0; i < setModeType_AvailableValueSet.availableValueSet.Count; i++)
                {
                    toolString.GenerateDefineCode(baseAddrName, regName, setModeType_AvailableValueSet.availableValueSet[i], modeStringSet[i]);
                }
            }
            return resultCode;
        }

        /// <summary>
        /// 生成宏定义
        /// </summary>
        /// <param name="toolString"></param>
        /// <param name="defineSomeTarget"></param>
        public void GenerateAssemblyCode_Define(ToolString toolString, bool defineSomeTarget)
        {
            if (setModeType && defineSomeTarget)
            {
                for (int i = 0; i < setModeType_AvailableValueSet.availableValueSet.Count; i++)
                {
                    toolString.GenerateDefineCode(baseAddrName, regName, setModeType_AvailableValueSet.availableValueSet[i], modeStringSet[i]);
                }
            }
        }

        /// <summary>
        /// 这是调用最终生成的汇编的函数的启动器
        /// </summary>
        /// <param name="toolString"></param>
        /// <param name="writeOrRead"></param>
        /// <returns></returns>
        private string GenerateAssemblyCode_writeOrRead(ToolString toolString, int writeOrRead)
        {
            string resultCode = "";
            if (enableType)
            {
                if (lowIndexBit == 0 && highIndexBit == 0)  //采用不可能出现的? + * 来表示生成有错，这是用户用的时候才知道的（假设真的出错）
                {
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 2, 1, 3, baseAddrName, regName,
                        enableBit.ToString(), bitName, "?", "??", false, setModeType_AvailableValueSet.availableValueSet, "???", "1");
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 1, 1, 1, baseAddrName, regName,
                        enableBit.ToString(), bitName, "?", "??", false, setModeType_AvailableValueSet.availableValueSet, "???", "1");
                }
                else
                {
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 2, 1, 4, baseAddrName, regName,
                        enableBit.ToString(), bitName, "?", "??", false, setModeType_AvailableValueSet.availableValueSet, "???", "1");
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 1, 1, 2, baseAddrName, regName,
                        enableBit.ToString(), bitName, "?", "??", false, setModeType_AvailableValueSet.availableValueSet, "???", "1");
                }
            }
            else if (setValueType)
            {
                if (setValueLocalScope)
                {
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 3, 2, 2, baseAddrName, regName,
                            lowIndexBit.ToString(), bitName, setValueType_AvailableValueSet.maxValueInt.ToString(), "+", setValueLocalScope, setValueType_AvailableValueSet.availableValueSet, "++", setValueType_AvailableValueSet.availableBit.ToString());
                }
                else
                {
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 3, 2, 1, baseAddrName, regName,
                            lowIndexBit.ToString(), bitName, setValueType_AvailableValueSet.maxValueInt.ToString(), "+", setValueLocalScope, setValueType_AvailableValueSet.availableValueSet, "++", setValueType_AvailableValueSet.availableBit.ToString());
                }
            }
            else if (setModeType)
            {
                if (setModeSingleType)
                {
                    for (int i = 0; i < setModeType_AvailableValueSet.availableValueSet.Count; i++)
                    {
                        resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 5, 3, 2, baseAddrName, regName,
                            lowIndexBit.ToString(), bitName, setModeType_AvailableValueSet.maxValueInt.ToString(), setModeType_AvailableValueSet.availableValueSet[i], false,
                            setModeType_AvailableValueSet.availableValueSet, modeStringSet[i], setModeType_AvailableValueSet.availableBit.ToString());
                        if (writeOrRead == 1) { break; }
                    }
                }
                else
                {
                    resultCode += toolString.RunBackAssemblyFunc(writeOrRead, seizeReg, 4, 3, 1, baseAddrName, regName,
                            lowIndexBit.ToString(), bitName, setModeType_AvailableValueSet.maxValueInt.ToString(), "*", false,
                            setModeType_AvailableValueSet.availableValueSet, "**", setModeType_AvailableValueSet.availableBit.ToString());
                }
            }
            return resultCode;
        }
    }
}