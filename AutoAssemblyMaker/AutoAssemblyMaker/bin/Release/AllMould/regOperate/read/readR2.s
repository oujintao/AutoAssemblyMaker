	li t0,[baseAddr]
	lw a0,[regName](t0)

	srli a0,a0,[bit]
	andi a0,a0,[bitMaxValue]
