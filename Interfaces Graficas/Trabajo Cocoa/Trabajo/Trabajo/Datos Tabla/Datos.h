//
//  Datos.h
//  Trabajo
//
//  Created by Lion on 25/01/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface Datos : NSObject{
    NSString *nombre;
    NSString *funcion;
    NSString *color;
    int a, b, c, n, xmax, xmin;
    NSColor *colorNS;
}
@property (copy) NSString *nombre;
@property (copy) NSString *funcion;
@property (copy) NSString *color;
@property int a;
@property int b;
@property int c;
@property int n;
@property int xmax;
@property int xmin;
@property (copy) NSColor *colorNS;

-(id)CargarValores:(NSString *)vNombre Funcion:(NSString *)vFuncion A:(int)vA B:(int)vB C:(int)vC N:(int)vConst Color:(NSString *)vColor XMAX:(int)vXMAX XMIN:(int)vXMIN;
-(void)ConvertirColor;
-(float)CalcularYInicial:(float)x;
-(float)CalcularY:(float)x Distacia:(float)distance Poligono:(NSBezierPath *)poly;
@end
