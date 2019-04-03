//
//  Controlador1.m
//  Trabajo
//
//  Created by Lion on 21/01/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import "Controlador1.h"
#import "../Controlador2/Controlador2.h"
#import "../Datos Tabla/Datos.h"
#define HOPS (500)

@implementation Controlador1

- (id)init
{
    self= [super init];
    if(self){
        lista=[[NSMutableArray alloc]init];
        [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(RecibirDatos:) name:@"Transferencia"
                                                   object:nil];
        poly=[[NSBezierPath alloc]init];
        controlador2=[[Controlador2 alloc]init];
        [controlador2 showWindow:self];
    }
    return self;
}

-(void)RecibirDatos:(NSNotification *) notificacicion{

    NSDictionary *dic=[notificacicion userInfo];
    lista=dic[@"lista2"];
    Datos *d=[lista objectAtIndex:0];
    minimo=[d xmin];
    maximo=[d xmax];
    for (int i=0;i<[lista count];i++){
        Datos *d=[lista objectAtIndex:i];
        if(minimo>[d xmin]){
            minimo=[d xmin];
        }
        if(maximo<[d xmax]){
            maximo=[d xmax];
        }
    }
    [etiqueta setIntValue:(int)[lista count]];
    [view setNeedsDisplay:YES];
}

- (void)drawRect:(NSRect)bounds withGraphicsContext:(NSGraphicsContext *)ctx
{
    int temp=minimo;
    if(minimo<0){
        temp*=-1;
    }
    int ancho=maximo+temp;
    NSRect funcRect={minimo,-5,ancho,10};
    
    for (int i=0;i<[lista count];i++){
        NSPoint aPoint;
        
        Datos *d=[lista objectAtIndex:i];
        funcRect.origin.x=[d xmin];
        
        float distance = funcRect.size.width/HOPS;
        [poly removeAllPoints];
        [ctx saveGraphicsState];
        NSAffineTransform *tf = [NSAffineTransform transform];
        [tf translateXBy:bounds.size.width/2 yBy:bounds.size.height/2];
        [tf scaleXBy:bounds.size.width/funcRect.size.width
                 yBy:bounds.size.height/funcRect.size.height];
        [tf concat];
        [poly setLineWidth:0.1];
        
         if(!i){
            [[NSColor blackColor] setStroke];
            [poly setLineWidth:0.1];
            aPoint.x=funcRect.origin.x;
            aPoint.y=0;
            [poly moveToPoint:aPoint];
            aPoint.x=funcRect.size.width;
            aPoint.y=0;
            [poly lineToPoint:aPoint];
            [poly stroke];
            [poly setLineWidth:0.1];
            aPoint.x=0;
            aPoint.y=funcRect.size.height;
            [poly moveToPoint:aPoint];
            aPoint.x=0;
            aPoint.y=funcRect.origin.y;;
            [poly lineToPoint:aPoint];
            [poly stroke];
            [poly removeAllPoints];
        }
        [[d colorNS] setStroke];
        
        aPoint.x = funcRect.origin.x;
        aPoint.y=[d CalcularYInicial:aPoint.x];
        [poly moveToPoint:aPoint];

        while (aPoint.x <= [d xmax])
        {
            aPoint.y=[d CalcularY:aPoint.x Distacia:distance Poligono:poly];
            [poly lineToPoint:aPoint];
            aPoint.x += distance;
        }
        [poly stroke];
        [ctx restoreGraphicsState];
    }
    
}
@end
