	addi t2,zero,1
	slli t2,t2,[bit]

	li t0,[baseAddr]

	lw t1,[regName](t0)
	or t1,t1,t2
	xor t1,t1,t2
	sw t1,[regName](t0)
