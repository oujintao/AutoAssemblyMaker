# AutoAssemblyMaker
这款软件设计的初衷是应用于RISC-V的核，生成可以对外围设备对应的寄存器对应位域读写的汇编函数以及C的函数声明。 分成了三种模式: 1、使能位模式，比如寄存器A里面有1bit是用来使能一项功能，例如中断开关。 2、设置数值类型，比如寄存器A里面有3bit是用来控制PWM的中断阈值，就是0-7用来设置。 3、设置模式类型，比如寄存器A里面有2bit是控制计数器的工作模式 0 是关闭 1是只运行一次（oneshot） 2是一直工作（always） 本软件的错误检查机制做的不完善，所以需要保证输入的信息是正确的，这样才能百分百确定生成地函数是对的。 sofeware文件夹是包括了软件和Allmould文件夹，注意，需要确定AllMould文件夹及其里面的文件在和软件同目录下，才可以运行。 AutoAssemblyMaker文件夹就是工程源码，C#项目 4.7.2。