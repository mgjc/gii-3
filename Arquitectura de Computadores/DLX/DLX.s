.data 0x200

; Input matrix 1

M1:
M10:
  .float 0.0
M11:
  .float 0.0
M12:
  .float 0.0
M13:
  .float 0.0



; Input matrix 2

M2:
M20:
  .float 0.0
M21:
  .float 0.0
M22:
  .float 0.0
M23:
  .float 0.0



; Input matrix 3

M3:
M30:
  .float 0.0
M31:
  .float 0.0
M32:
  .float 0.0
M33:
  .float 0.0


; datos de entrada

a1: 
  .float 1.1254
a2: 
  .float 4.5268
a3: 
  .float 2.3654
a4: 
  .float 15.2487



; Output matrix

M: 
  .float 0.0,0.0,0.0,0.0
  .float 0.0,0.0,0.0,0.0
  .float 0.0,0.0,0.0,0.0
  .float 0.0,0.0,0.0,0.0 

ONE:
  .float 1.0

.text
.global main

main:


; carga datos

lf f1, a1
lf f2, a2
lf f3, a3
lf f4, a4

; guarda en registros las tres matrices

addf f5, f2, f1 ;M10
addf f6, f4, f3 ;M20
addf f7, f3, f1 ;M30

subf f8, f1, f2 ;M12
subf f9, f3, f4 ;M22
subf f10, f1, f3 ;M32


multf f11, f5, f5 ;M11
multf f12, f6, f6 ;M21
multf f13, f7, f7 ;M31

multf f14, f8, f8 ;M13
multf f15, f9, f9 ;M23
multf f16, f10, f10 ;M33


; multiplicacion de las matrices

multf f1, f6, f5 ;M40
multf f2, f12, f5 ;M41
multf f3, f6, f11 ;M42
multf f4, f12, f11 ;M43

multf f17, f9, f5; M50
multf f18, f15, f5 ;M51
multf f19, f9, f11 ;M52
multf f20, f15, f11 ;M53

multf f21, f6, f8 ;M60
multf f22, f12, f8 ;M61
multf f23, f6, f14 ;M62
multf f24, f12, f14 ;M63

multf f25, f9, f8 ;M70
multf f26, f15, f8 ;M71
multf f27, f9, f14 ;M72
multf f28, f15, f14 ;M73


; determinante de la tercera matriz
multf f29, f16, f7
multf f30, f13, f10

subf f31, f29, f30 ; |C|

; en caso de que la division sea entre 0 el programa acaba
eqf f31, f0
bfpt end

; división de todos los elementos de la matriz grande entre el determinante
; De esta forma en vez de dividir 1/|C| y multiplicar el resultado por cada elemento de la matriz, dividimos directamente cada elemento entre el determinante y nos ahorramos una instrucción
; en vez de guardarlo en registros lo guardamos directamente en las variables
; probar que funciona más rápido, guardar en variables directamente o guardar en registro y luego meterlo en variables

divf f1, f1, f31
divf f2, f2, f31
divf f3, f3, f31
divf f4, f4, f31
divf f17, f17, f31
divf f18, f18, f31
divf f 19,f 19, f31
divf f20, f20, f31
divf f21, f21, f31
divf f22, f22, f31
divf f23, f23, f31
divf f24, f24, f31
divf f25, f25, f31
divf f26, f26, f31
divf f27, f27, f31
divf f28, f28, f31

lw r1, M(r0)
sf 0(r1), f1
sf 4(r1), f2
sf 8(r1), f3
sf 12(r1), f4
sf 16(r1), f17
sf 20(r1), f18
sf 24(r1), f19
sf 28(r1), f20
sf 32(r1), f21
sf 36(r1), f22
sf 40(r1), f23
sf 44(r1), f24
sf 48(r1), f25
sf 52(r1), f26
sf 56(r1), f27
sf 60(r1), f28



end:
  trap 0
