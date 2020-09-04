    li t2,[bitMaxValue]
    and a0,a0,t2

    li t0,[baseAddr]
    sw a0,[regName](t0)
