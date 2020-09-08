    j [baseAddr]_[regName]_SetMode_[bitName]_End

[baseAddr]_[regName]_SetMode_Hit:
    slli t2,t2,[bit]
    slli a0,a0,[bit]

    li t0,[baseAddr]
    lw t1,[regName](t0)

    or t1,t1,t2
    xor t1,t1,t2
    or t1,t1,a0

    sw t1,[regName](t0)

[baseAddr]_[regName]_SetMode_[bitName]_End:
