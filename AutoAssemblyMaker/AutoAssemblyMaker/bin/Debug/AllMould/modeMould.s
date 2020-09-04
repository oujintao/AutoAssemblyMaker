.section .text
.align 2
.globl [regName]_SetMode_[bitName]

[regName]_SetMode_[bitName]:
    addi sp,sp,-16
    sw t0,0(sp)
    sw t1,4(sp)
    sw t2,8(sp)
    sw t3,12(sp)

    li t2,[bitMaxValue]
    and a0,a0,t2

    li t3,[availableValue]
    beq a0,t3[regName]_SetMode_[bitName]_Hit
    li t3,[availableValue]
    beq a0,t3[regName]_SetMode_[bitName]_Hit
    j [regName]_SetMode_[bitName]_End

[regName]_SetMode_[bitName]_Hit:
    slli t2,t2,[bit]
    slli a0,a0,[bit]

    li t0,[baseAddr]
    lw t1,[regName](t0)

    or t1,t1,t2
    xor t1,t1,t2
    or t1,t1,a0

    sw t1,[regName](t0)

[regName]_SetMode_[bitName]_End:
    lw t3,12(sp)
    lw t2,8(sp)
    lw t1,4(sp)
    lw t0,0(sp)
    addi sp,sp,16
    ret

.section .text
.align 2
.globl [regName]_Set[modeString]Mode_[bitName]

[regName]_Set[modeString]Mode_[bitName]:
    addi sp,sp,-16
    sw t0,0(sp)
    sw t1,4(sp)
    sw t2,8(sp)
    sw t3,12(sp)

    li t2,[bitMaxValue]
    li t3,[bitAvailableValue]
    slli t2,t2,[bit]
    slli t3,t3,[bit]

    li t0,[baseAddr]
    lw t1,[regName](t0)

    or t1,t1,t2
    xor t1,t1,t2
    or t1,t1,t3

    sw t1,[regName](t0)

    lw t3,12(sp)
    lw t2,8(sp)
    lw t1,4(sp)
    lw t0,0(sp)
    addi sp,sp,16
    ret