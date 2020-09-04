.section .text
.align 2
.globl [regName]_Set[bitName]Value

[regName]_Set[bitName]Value:
    addi sp,sp,-12
    sw t0,0(sp)
    sw t1,4(sp)
    sw t2,8(sp)

    li t2,[BitMaxValue]
    and a0,a0,t2
    slli t2,t2,[Bit]
    slli a0,a0,[Bit]

    li t0,[baseAddr]
    lw t1,[regName](t0)

    or t1,t1,t2
    xor t1,t1,t2
    or t1,t1,a0
    
    sw t1,[regName](t0)

    lw t2,8(sp)
    lw t1,4(sp)
    lw t0,0(sp)
    addi sp,sp,12
    ret