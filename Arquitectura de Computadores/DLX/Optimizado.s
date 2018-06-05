.data

; datos de entrada

a1: 
  .float 1.0 
a3:
  .float 2.0
a2: 
  .float 2.0
a4:
  .float 1.0



; Output matrix

M: 
  .float 0.0,0.0,0.0,0.0
  .float 0.0,0.0,0.0,0.0
  .float 0.0,0.0,0.0,0.0
  .float 0.0,0.0,0.0,0.0 

uno:
  .float 1.0

.text
.global main

main:


; carga datos

ld f20, a1
ld f22, a2

addf f5, f21, f20 ;M31
lf f31, uno


; guarda en registros las tres matrices
multf f6, f5, f5 ;M32
subf f7, f20, f21 ;M33
multf f8, f7, f7 ;M34
addf f9, f21, f23 ;M21

; determinante de la tercera matriz
multf f28, f8, f5
addf f3, f20, f22 ;M11
multf f29, f7, f6
subf f30, f28, f29 ; |C|

; en caso de que la division sea entre 0 el programa acaba
eqf f28, f29
bfpt end

divf f31, f31, f30

multf f10, f9, f9 ;M22
subf f11, f21, f23 ;M23
multf f12, f11, f11 ;M24

; Segunda matriz sacada




multf f5, f3, f31
multf f6, f5, f3
subf f29, f20, f22 ;M13

multf f7, f29, f31 ;M14
multf f8, f7, f29


; Primera matriz sacada



; multiplicacion de las matrices

lw r1, M(r0)
multf f13, f5, f9 ;M41
multf f14, f5, f10 ;M42
sf 0(r1), f13
multf f15, f6, f9 ;M43
sf 4(r1), f14
multf f16, f6, f10 ;M44
sf 8(r1), f15
multf f17, f5, f11; M51
sf 12(r1), f16
multf f18, f5, f12 ;M52
sf 16(r1), f17
multf f19, f6, f11 ;M53
sf 20(r1), f18
multf f20, f6, f12 ;M54
sf 24(r1), f19
multf f21, f7, f9 ;M61
sf 28(r1), f20
multf f22, f7, f10 ;M62
sf 32(r1), f21
multf f23, f8, f9 ;M63
sf 36(r1), f22
multf f24, f8, f10 ;M64
sf 40(r1), f23
multf f25, f7, f11 ;M71
sf 44(r1), f24
multf f26, f7, f12 ;M72
sf 48(r1), f25
multf f27, f8, f11 ;M73
sf 52(r1), f26
multf f28, f8, f12 ;M74
sf 56(r1), f27
sf 60(r1), f28

end:
  trap 0

