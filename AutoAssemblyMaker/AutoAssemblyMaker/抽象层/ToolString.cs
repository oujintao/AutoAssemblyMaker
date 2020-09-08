using System.Collections.Generic;
using System.IO;

namespace AutoAssemblyMaker.抽象层
{
    public class ToolString
    {
        /// <summary>
        /// 这个类主要是帮助生成代码，把代码分割成几分东西，只要装嵌起来就好
        /// </summary>
        public string funcNameDisableType;
        public string funcNameEnableType;
        public string funcNameSetValueType;
        public string funcNameSetModeType;
        public string funcNameSetModeTypeSingle;

        public string funcNameReadEnablType;
        public string funcNameReadValueType;
        public string funcNameReadModeType;

        public string disable1;
        public string disable2;
        public string enable1;
        public string enable2;

        public string setValue;
        public string setValue_seize;

        public string setValueGetNum;
        public string setValueCheckMinValue;
        public string setValueCheckMaxValue;
        public string setValueLocalScopeEnd;

        public string setMode_notParam;
        public string setMode_notParam_seize;

        public string setMode_param_branch;
        public string setMode_param_getValue;
        public string setMode_param_store;
        public string setMode_param_store_seize;

        public string readR1;
        public string readR2;

        public string stackPop1;
        public string stackPop2;
        public string stackPop3;
        public string stackPop4;

        public string stackPush1;
        public string stackPush2;
        public string stackPush3;
        public string stackPush4;

        public string retString;

        public List<string> funcNameSet = new List<string>();
        public List<string> pseudoIRMouldSet = new List<string>();
        public string CDefineCode = "";
        //上面的都是靠读取文件得到的

        /// <summary>
        /// 这是用来生成.h文件的 C的函数声明
        /// </summary>
        public string getCFuncCode = "";
        /// <summary>
        /// 这是用来生成.h文件的 C的宏定义
        /// </summary>
        public string getCDefineCode = "";

        /// <summary>
        /// 这是生成伪指令
        /// </summary>
        /// <param name="baseAddrSet">设备名字</param>
        /// <param name="baseAddrNumSet">基地址</param>
        /// <param name="regNameSet">寄存器名字</param>
        /// <param name="regNameNumSet">偏移地址</param>
        /// <returns></returns>
        public string GeneratePseudoIR(List<string> baseAddrSet, List<string> baseAddrNumSet, List<string> regNameSet, List<string> regNameNumSet)
        {
            string resultCode = "";
            for (int i = 0; i < baseAddrSet.Count; i++)
            {
                resultCode += pseudoIRMouldSet[0];
                resultCode = resultCode.Replace("[baseAddr]", baseAddrSet[i]);
                resultCode = resultCode.Replace("[baseAddrNum]", baseAddrNumSet[i]);
            }
            resultCode += '\n';
            for (int i = 0; i < regNameSet.Count; i++)
            {
                resultCode += pseudoIRMouldSet[1];
                resultCode = resultCode.Replace("[regName]", regNameSet[i]);
                resultCode = resultCode.Replace("[regNameNum]", regNameNumSet[i]);
            }
            return resultCode;
        }

        /// <summary>
        /// 这是生成汇编代码用的函数
        /// </summary>
        /// <param name="writeOrRead">0 write 1 read</param>
        /// <param name="seizeReg">是不是一个寄存器里面才有一个值域</param>
        /// <param name="type">disable 1 enable2、设置数值型3、设置模式型4 设置模式不带参数型5</param>
        /// <param name="funcType1">1：enable系列 2：设置数值型系列 3：设置模式型系列</param>
        /// <param name="funcType2">配functype1 11： disable1 12：disable2 类推 21：无局部范围 22：有局部范围 31：带参数 32：不带参数</param>
        /// <param name="baseAddr"></param>
        /// <param name="regName"></param>
        /// <param name="bit"></param>
        /// <param name="bitName"></param>
        /// <param name="bitMaxValue"></param>
        /// <param name="bitAvailableValue">设置模式下，单独生成函数时，模式的数值</param>
        /// <param name="setValueLocalScope"></param>
        /// <param name="availableValueSet">模式的数值集合(不是单独生成的时候用)</param>
        /// <param name="modeString">模式的名字（不是数值）（单独生成的时候用）</param>
        /// <param name="bitFiledLength"></param>
        /// <returns></returns>
        public string RunBackAssemblyFunc(int writeOrRead, bool seizeReg, int type, int funcType1, int funcType2, string baseAddr, string regName,
            string bit, string bitName, string bitMaxValue, string bitAvailableValue, bool setValueLocalScope, List<string> availableValueSet, string modeString, string bitFiledLength)
        {
            string resultCode = "";
            resultCode += RunBackFuncStatementPart(writeOrRead, type, regName, bitName, modeString);
            resultCode += RunBackFuncStackPushPart(writeOrRead, seizeReg, funcType1, funcType2);
            resultCode += RunBackFuncOperatePart(writeOrRead, seizeReg, funcType1, funcType2, baseAddr, regName, bit, bitName, bitMaxValue, bitAvailableValue, setValueLocalScope, availableValueSet);
            resultCode += RunBackFuncStackPopPart(writeOrRead, seizeReg, funcType1, funcType2);
            resultCode += retString;

            resultCode = ReplaceAllLabel(resultCode, writeOrRead, seizeReg, type, funcType1, funcType2, baseAddr, regName,
                bit, bitName, bitMaxValue, bitAvailableValue, setValueLocalScope, availableValueSet, modeString);

            GenerateCFuncCode(writeOrRead, funcType1, funcType2, baseAddr, regName, bitName, setValueLocalScope, availableValueSet, modeString, bitFiledLength);
            return resultCode;
        }

        /// <summary>
        /// 所有标签进行替换 [baseAddr] 替换成真正的baseAddr
        /// </summary>
        /// <param name="code"></param>
        /// <param name="writeOrRead"></param>
        /// <param name="seizeReg"></param>
        /// <param name="type"></param>
        /// <param name="funcType1"></param>
        /// <param name="funcType2"></param>
        /// <param name="baseAddr"></param>
        /// <param name="regName"></param>
        /// <param name="bit"></param>
        /// <param name="bitName"></param>
        /// <param name="bitMaxValue"></param>
        /// <param name="bitAvailableValue"></param>
        /// <param name="setValueLocalScope"></param>
        /// <param name="availableValueSet"></param>
        /// <param name="modeString"></param>
        /// <returns></returns>
        private string ReplaceAllLabel(string code, int writeOrRead, bool seizeReg, int type, int funcType1, int funcType2, string baseAddr, string regName,
            string bit, string bitName, string bitMaxValue, string bitAvailableValue, bool setValueLocalScope,List<string> availableValueSet, string modeString)
        {
            string resultCode = "";
            resultCode = code.Replace("[baseAddr]", baseAddr);
            resultCode = resultCode.Replace("[regName]", regName);
            resultCode = resultCode.Replace("[bit]", bit);
            resultCode = resultCode.Replace("[bitName]", bitName);
            resultCode = resultCode.Replace("[bitMaxValue]", bitMaxValue);
            resultCode = resultCode.Replace("[bitAvailableValue]", bitAvailableValue);
            if(setValueLocalScope)
            {
                if(availableValueSet.Count == 1)
                {
                    resultCode = resultCode.Replace("[setValueMaxValue]", availableValueSet[0]);
                }
                else if(availableValueSet.Count == 2)
                {
                    resultCode = resultCode.Replace("[setValueMinValue]", availableValueSet[0]);
                    resultCode = resultCode.Replace("[setValueMaxValue]", availableValueSet[1]);
                }
            }
            resultCode = resultCode.Replace("[modeString]", modeString);
            return resultCode;
        }

        /// <summary>
        /// RunBack系列函数 这是上面的public的函数的分函数
        /// </summary>
        /// <param name="type"></param>
        /// <param name="regName"></param>
        /// <param name="bitName"></param>
        /// <param name="modeString"></param>
        /// <returns></returns>
        private string RunBackFuncStatementPart(int writeOrRead, int type, string regName, string bitName, string modeString)
        {
            string resultCode = "";
            if(writeOrRead == 0)
            {
                if (type == 1) resultCode += funcNameDisableType; //disable
                else if (type == 2) resultCode += funcNameEnableType; //enable
                else if (type == 3) resultCode += funcNameSetValueType; //setValue
                else if (type == 4) resultCode += funcNameSetModeType; //setMode
                else if (type == 5)
                {
                    resultCode += funcNameSetModeTypeSingle; //setModeSingle
                    resultCode.Replace("[modeString]", modeString);
                }
            }
            else if(writeOrRead == 1)
            {
                if (type == 1) resultCode += funcNameReadEnablType; //disable
                else if (type == 2) resultCode += funcNameReadEnablType; //enable
                else if (type == 3) resultCode += funcNameReadValueType; //setValue
                else if (type == 4) resultCode += funcNameReadModeType; //setMode
                else if (type == 5) resultCode += funcNameReadModeType; //setModeSingle
            }
            return resultCode;
        }

        private string RunBackFuncStackPushPart(int writeOrRead, bool seizeReg, int funcType1,int funcType2)
        {
            string resultCode = "";
            if (writeOrRead == 1)
            {
                resultCode += stackPush1;
                return resultCode;
            }
            if (funcType1 == 1) //enable
            {
                if (funcType2 == 1) resultCode += stackPush1; //disable1
                else if (funcType2 == 2) resultCode += stackPush3; //disable2
                else if (funcType2 == 3) resultCode += stackPush2; //enable1
                else if (funcType2 == 4) resultCode += stackPush3; //enable2
            }
            else if (funcType1 == 2) resultCode += stackPush3; //setValue
            else if (funcType1 == 3) 
            { 
                if(funcType2 == 2)
                {
                    if(seizeReg)
                    {
                        resultCode += stackPush3;
                        return resultCode;
                    }
                }
                resultCode += stackPush4; 
            } //setMode
            return resultCode;
        }

        private string RunBackFuncOperatePart(int writeOrRead, bool seizeReg, int funcType1, int funcType2,string baseAddr,string regName,
            string bit,string bitName, string bitMaxValue,string bitAvailableValue, bool setValueLocalScope, List<string> availableValueSet)
        {
            string resultCode = "";
            if(writeOrRead == 1)
            {
                if(seizeReg) resultCode += readR1;
                else
                {
                    resultCode += readR2;
                }
                return resultCode;
            }
            if (funcType1 == 1) //enable
            {
                if (funcType2 == 1) resultCode += disable1; //disable1
                else if (funcType2 == 2) { resultCode += disable2;}//disable2
                else if (funcType2 == 3) resultCode += enable1; //enable1
                else if (funcType2 == 4) { resultCode += enable2;} //enable2
            }
            else if (funcType1 == 2)  //setValue
            {
                if(setValueLocalScope)
                {
                    resultCode += setValueGetNum;
                    if(availableValueSet.Count == 1)
                    {
                        resultCode += setValueCheckMaxValue;
                    }
                    else
                    {
                        resultCode += setValueCheckMinValue;
                        resultCode += setValueCheckMaxValue;
                    }
                }
                if(seizeReg)
                {
                    if (bitMaxValue[0] == '-')
                    {
                        resultCode += setValue_seize.Substring(41);
                    }
                    else
                    {
                        resultCode += setValue_seize;
                    }
                }
                else
                {
                    if (bitMaxValue[0] == '-')
                    {
                        resultCode += setValue_seize.Substring(83);
                    }
                    else
                    {
                        resultCode += setValue_seize;
                    }
                }
                if (setValueLocalScope)
                {
                    resultCode += setValueLocalScopeEnd;
                }
            }
            else if (funcType1 == 3)
            {
                if(funcType2 == 1)  //setMode
                {
                    resultCode += setMode_param_getValue;
                    for (int i = 0; i < availableValueSet.Count; i++)
                    {
                        resultCode += setMode_param_branch;
                        resultCode = resultCode.Replace("[availableValue]", availableValueSet[i]);  //这里一定要现在替换，因为这个模式值是多个的
                    }
                    if (seizeReg)
                    {
                        resultCode += setMode_param_store_seize;
                    }
                    else
                    {
                        resultCode += setMode_param_store;
                    }
                }
                else if(funcType2 == 2) //setModeSingle
                {
                    if (seizeReg)
                    {
                        resultCode += setMode_notParam_seize;
                    }
                    else
                    {
                        resultCode += setMode_notParam;
                    }
                }
            }
            return resultCode;
        }

        private string RunBackFuncStackPopPart(int writeOrRead, bool seizeReg, int funcType1,int funcType2)
        {
            string resultCode = "";
            resultCode += '\n';
            if (writeOrRead == 1)
            {
                resultCode += stackPop1;
                return resultCode;
            }
            if (funcType1 == 1) //enable
            {
                if (funcType2 == 1) resultCode += stackPop1; //disable1
                else if (funcType2 == 2) resultCode += stackPop3; //disable2
                else if (funcType2 == 3) resultCode += stackPop2; //enable1
                else if (funcType2 == 4) resultCode += stackPop3; //enable2
            }
            else if (funcType1 == 2) resultCode += stackPop3; //setValue
            else if (funcType1 == 3)
            {
                if (funcType2 == 2)
                {
                    if (seizeReg)
                    {
                        resultCode += stackPop3;
                        return resultCode;
                    }
                }
                resultCode += stackPop4;
            } //setMode
            return resultCode;
        }

        /// <summary>
        /// 生成C语言的函数声明
        /// </summary>
        /// <param name="writeOrRead">0 write 1 read</param>
        /// <param name="funcType1">1：enable系列 2：设置数值型系列 3：设置模式型系列</param>
        /// <param name="funcType2">配functype1 11： disable1 12：disable2 类推 21：无局部范围 22：有局部范围 31：带参数 32：不带参数</param>
        /// <param name="baseAddr"></param>
        /// <param name="regName"></param>
        /// <param name="bitName"></param>
        /// <param name="setValueLocalScope"></param>
        /// <param name="availableValueSet"></param>
        /// <param name="modeString">模式的名字（不是数值）</param>
        /// <param name="bitFiledLength"></param>
        private void GenerateCFuncCode(int writeOrRead, int funcType1, int funcType2, string baseAddr, string regName, 
            string bitName, bool setValueLocalScope, List<string> availableValueSet, string modeString, string bitFiledLength)
        {
            getCFuncCode += "extern ";
            if (writeOrRead == 0)
            {
                if (funcType1 == 1) //enable
                {
                    if (funcType2 == 1) getCFuncCode += funcNameSet[0]; //disable1
                    else if (funcType2 == 2) { getCFuncCode += funcNameSet[0]; }//disable2
                    else if (funcType2 == 3) getCFuncCode += funcNameSet[1]; //enable1
                    else if (funcType2 == 4) { getCFuncCode += funcNameSet[1]; } //enable2
                }
                else if (funcType1 == 2)  //setValue
                {
                    getCFuncCode += funcNameSet[2];
                    if(setValueLocalScope)
                    {
                        if(availableValueSet.Count == 1)
                        {
                            getCFuncCode = getCFuncCode.Replace("[param]", "data0To" + availableValueSet[0].ToString());
                        }
                        else if(availableValueSet.Count == 2)
                        {
                            getCFuncCode = getCFuncCode.Replace("[param]", "data" + availableValueSet[0].ToString() + "To" + availableValueSet[1].ToString());
                        }
                    }
                }
                else if (funcType1 == 3)
                {
                    if (funcType2 == 1)  //setMode
                    {
                        getCFuncCode += funcNameSet[3];
                    }
                    else if (funcType2 == 2) //setModeSingle
                    {
                        getCFuncCode += funcNameSet[4];
                    }
                }
            }
            else if(writeOrRead == 1)
            {
                if (funcType1 == 1) //enable
                {
                    getCFuncCode += funcNameSet[5];
                }
                else if (funcType1 == 2)  //setValue
                {
                    getCFuncCode += funcNameSet[6];
                }
                else if (funcType1 == 3)
                {
                    getCFuncCode += funcNameSet[7];
                }
            }

            getCFuncCode = getCFuncCode.Replace("[baseAddr]", baseAddr);
            getCFuncCode = getCFuncCode.Replace("[regName]", regName);
            getCFuncCode = getCFuncCode.Replace("[bitName]", bitName);
            getCFuncCode = getCFuncCode.Replace("[modeString]", modeString);
            getCFuncCode = getCFuncCode.Replace("[param]", "data" + bitFiledLength + "Bit");

            getCFuncCode += '\n';
        }

        /// <summary>
        /// 生成C语言的宏定义 主要是设置模式这个模式下用的
        /// </summary>
        /// <param name="baseName"></param>
        /// <param name="regName"></param>
        /// <param name="bitAvailableValue">模式的数值</param>
        /// <param name="modeString">模式的名字（不是数值）</param>
        public void GenerateDefineCode(string baseName, string regName, string bitAvailableValue, string modeString)
        {
            string resultCode = "";
            resultCode += CDefineCode;
            resultCode = resultCode.Replace("[baseAddr]", baseName);
            resultCode = resultCode.Replace("[regName]", regName);
            resultCode = resultCode.Replace("[bitAvailableValue]", bitAvailableValue);
            resultCode = resultCode.Replace("[modeString]", modeString);
            resultCode += "\n";
            getCDefineCode += resultCode;
        }

        /// <summary>
        /// 获取所有的代码部分，对应在AllMould文件夹里面的.s文件
        /// </summary>
        public void UpdateAllString()
        {
            UpdateFuncNameDisableType();
            UpdateFuncNameEnableType();
            UpdateFuncNameSetValueType();
            UpdateFuncNameSetModeType();
            UpdateFuncNameSetModeTypeSingle();

            UpdateFuncNameReadEnableType();
            UpdateFuncNameReadValueType();
            UpdateFuncNameReadModeType();

            UpdateDisable1();
            UpdateDisable2();
            UpdateEnable1();
            UpdateEnable2();

            UpdateSetValue();
            UpdateSetValue_Seize();

            UpdateSetValueGetNum();
            UpdateSetValueCheckMinValue();
            UpdateSetValueCheckMaxValue();
            UpdateSetValueLocalScopeEnd();

            UpdateSetMode_notParam();
            UpdateSetMode_notParam_Seize();
            UpdateSetMode_param_GetValue();
            UpdateSetMode_param_Branch();
            UpdateSetMode_param_store();
            UpdateSetMode_param_store_seize();

            UpdateReadR1();
            UpdateReadR2();

            UpdateStackPop1();
            UpdateStackPop2();
            UpdateStackPop3();
            UpdateStackPop4();
            UpdateStackPush1();
            UpdateStackPush2();
            UpdateStackPush3();
            UpdateStackPush4();

            UpdateRetString();

            UpdateFuncNameSet();
            UpdateDefineCodeSet();
            UpdatePseudoIRSet();
        }

        /// <summary>
        /// 以下的私有函数都是为了上面那个更新所有代码的函数的分函数
        /// </summary>
        private void UpdateFuncNameDisableType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\disableType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameDisableType = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateFuncNameEnableType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\enableType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameEnableType = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateFuncNameSetValueType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\setValueType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameSetValueType = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateFuncNameSetModeType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\setModeType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameSetModeType = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateFuncNameSetModeTypeSingle()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\setModeTypeSingle.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameSetModeTypeSingle = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateFuncNameReadEnableType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\read\\enableType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameReadEnablType = readFile.ReadToEnd();
        }
        private void UpdateFuncNameReadValueType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\read\\valueType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameReadValueType = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateFuncNameReadModeType()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\FuncName\\read\\modeType.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            funcNameReadModeType = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateDisable1()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\enableType\\disable1.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            disable1 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateDisable2()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\enableType\\disable2.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            disable2 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateEnable1()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\enableType\\enable1.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            enable1 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateEnable2()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\enableType\\enable2.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            enable2 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }

        private void UpdateSetValue()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setValueType\\setValue.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setValue = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetValue_Seize()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setValueType\\setValue_seize.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setValue_seize = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetValueGetNum()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setValueType\\setValueGetNum.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setValueGetNum = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetValueCheckMinValue()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setValueType\\setValueCheckMinNum.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setValueCheckMinValue = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetValueCheckMaxValue()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setValueType\\setValueCheckMaxNum.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setValueCheckMaxValue = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetValueLocalScopeEnd()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setValueType\\setValueLocalScopeEnd.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setValueLocalScopeEnd = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }

        private void UpdateSetMode_notParam()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setMode\\SetMode_notParam\\setMode_notParam.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setMode_notParam = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetMode_notParam_Seize()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setMode\\SetMode_notParam\\setMode_notParam_seize.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setMode_notParam_seize = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }

        private void UpdateSetMode_param_GetValue()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setMode\\SetMode_Param\\setMode_param_GetValue.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setMode_param_getValue = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateSetMode_param_Branch()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setMode\\SetMode_Param\\setMode_param_Branch.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setMode_param_branch = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateSetMode_param_store()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setMode\\SetMode_Param\\setMode_param_store.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setMode_param_store = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateSetMode_param_store_seize()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\setMode\\SetMode_Param\\setMode_param_store_seize.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            setMode_param_store_seize = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateReadR1()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\read\\readR1.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            readR1 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        
        private void UpdateReadR2()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\regOperate\\read\\readR2.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            readR2 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }

        private void UpdateStackPop1()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPop1.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPop1 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPop2()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPop2.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPop2 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPop3()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPop3.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPop3 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPop4()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPop4.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPop4 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPush1()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPush1.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPush1 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPush2()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPush2.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPush2 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPush3()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPush3.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPush3 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }
        private void UpdateStackPush4()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\stackPushPop\\stackPush4.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            stackPush4 = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        } 
        
        private void UpdateRetString()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\ret.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            retString = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }

        private void UpdateFuncNameSet()
        {
            string fileContent = "";
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\CFuncName\\funcName.c", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            fileContent = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();

            funcNameSet = new List<string>(fileContent.Split('\n'));
        } 
        
        private void UpdateDefineCodeSet()
        {
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\CDefine\\definemake.c", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            CDefineCode = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();
        }        

        private void UpdatePseudoIRSet()
        {
            string fileContent = "";
            FileStream mouldCode;
            mouldCode = new FileStream(".\\AllMould\\pseudoIR\\pseudoIR.s", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(mouldCode);
            fileContent = readFile.ReadToEnd();
            readFile.Close();
            mouldCode.Close();

            pseudoIRMouldSet = new List<string>(fileContent.Split('\n'));
        }
    }
}
