    j [regName]_SetMode_[bitName]_End

[regName]_SetMode_Hit:
    li t0,[baseAddr]
    sw a0,[regName](t0)

[regName]_SetMode_[bitName]_End:
