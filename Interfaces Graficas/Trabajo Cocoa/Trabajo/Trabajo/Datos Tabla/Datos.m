//
//  Datos.m
//  Trabajo
//
//  Created by Lion on 25/01/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import "Datos.h"

@implementation Datos

@synthesize nombre;
@synthesize funcion;
@synthesize a;
@synthesize b;
@synthesize c;
@synthesize n;
@synthesize color;
@synthesize xmax;
@synthesize xmin;
@synthesize colorNS;
-(id)init{
    self=[super init];
    if(self){
    }
    return self;
}
-(id)CargarValores:(NSString *)vNombre Funcion:(NSString *)vFuncion A:(int)vA B:(int)vB C:(int)vC N:(int)vConst Color:(NSString *)vColor XMAX:(int)vXMAX XMIN:(int)vXMIN{
    nombre=vNombre;
    funcion=vFuncion;
    color=vColor;
    a=vA;
    b=vB;
    c=vC;
    n=vConst;
    xmax=vXMAX;
    xmin=vXMIN;
    [self ConvertirColor];
    return self;
}
-(void)ConvertirColor{
    if([@"Rojo" isEqualToString:color]){
        colorNS=[NSColor redColor];
    }
    if([@"Verde" isEqualToString:color]){
        colorNS=[NSColor greenColor];
    }
    if([@"Amarillo" isEqualToString:color]){
        colorNS=[NSColor yellowColor];
    }
    if([@"Azul" isEqualToString:color]){
        colorNS=[NSColor blueColor];
    }
    if([@"Rosa" isEqualToString:color]){
        colorNS=[NSColor systemPinkColor];
    }
    if([@"Negro" isEqualToString:color]){
        colorNS=[NSColor blackColor];
    }
}
-(float)CalcularYInicial:(float)x{
    if([@"a*sen(b*x)" isEqualToString:funcion]){
        return a*sin(b*x);
    }
    if([@"a*cos(b*x)" isEqualToString:funcion]){
        return a*cos(b*x);
    }
    if([@"a*x^n" isEqualToString:funcion]){
        return a*pow(x,n);
    }
    if([@"a*x+b" isEqualToString:funcion]){
        return a*x+b;
    }
    if([@"a*x^2+b*x+c" isEqualToString:funcion]){
        return a*pow(x,2)+b*x+c;
    }
    if([@"a/(b*x)" isEqualToString:funcion]){
        return a/(b*x);
    }
    return 0;
}
-(float)CalcularY:(float)x Distacia:(float)distance Poligono:(NSBezierPath *)poly{
    if([@"a*sen(b*x)" isEqualToString:funcion]){
        return a*sin(b*x);
    }
    if([@"a*cos(b*x)" isEqualToString:funcion]){
        return a*cos(b*x);
    }
    if([@"a*x^n" isEqualToString:funcion]){
        return a*pow(x,n);
    }
    if([@"a*x+b" isEqualToString:funcion]){
        return a*x+b;
    }
    if([@"a*x^2+b*x+c" isEqualToString:funcion]){
        return a*pow(x,2)+b*x+c;
    }
    if([@"a/(b*x)" isEqualToString:funcion]){
        if((x- distance < 0 && x+distance>0) || x ==0){
            int y;
            NSPoint punto;
            x += distance;
            y =a/(b*x);
            punto.x=x;
            punto.y=y;
            [poly moveToPoint:punto];
            x += distance;
        }
        return a/(b*x);
    }
    return 0;
}
@end
