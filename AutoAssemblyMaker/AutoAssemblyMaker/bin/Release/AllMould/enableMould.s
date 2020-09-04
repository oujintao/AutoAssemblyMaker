.section .text
.align 2
.globl [regName]_Enable[bitName]

[regName]_Enable[bitName]:
	addi sp,sp,-8
	sw t0,0(sp)
	sw t1,4(sp)

	li t0,[baseAddr]
	addi t1,zero,1
	sw t1,[regName](t0)

	lw t1,4(sp)
	lw t0,0(sp)
	addi sp,sp,8
	ret

.section .text
.align 2
.globl [regName]_Disable[bitName]

[regName]_Disable[bitName]:
	addi sp,sp,-4
	sw t0,0(sp)

	li t0,[baseAddr]
	sw zero,[regName](t0)

	lw t0,0(sp)
	addi sp,sp,4
	ret

.section .text
.align 2
.globl [regName]_Enable[bitName]

[regName]_Enable[bitName]:
	addi sp,sp,-12
	sw t0,0(sp)
	sw t1,4(sp)
	sw t2,8(sp)

	addi t2,zero,1
	slli t2,t2,[bit]

	li t0,[baseAddr]

	lw t1,[regName](t0)
	or t1,t1,t2
	sw t1,[regName](t0)

	lw t2,8(sp)
	lw t1,4(sp)
	lw t0,0(sp)
	addi sp,sp,12
	ret

.section .text
.align 2
.globl [regName]_Disable[bitName]

[regName]_Disable[bitName]:
	addi sp,sp,-12
	sw t0,0(sp)
	sw t1,4(sp)
	sw t2,8(sp)

	addi t2,zero,1
	slli t2,t2,[bit]

	li t0,[baseAddr]

	lw t1,[regName](t0)
	or t1,t1,t2
	xor t1,t1,t2
	sw t1,[regName](t0)

	lw t2,8(sp)
	lw t1,4(sp)
	lw t0,0(sp)
	addi sp,sp,12
	ret

