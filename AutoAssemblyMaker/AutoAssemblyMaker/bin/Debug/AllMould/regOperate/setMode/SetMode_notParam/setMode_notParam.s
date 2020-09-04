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
