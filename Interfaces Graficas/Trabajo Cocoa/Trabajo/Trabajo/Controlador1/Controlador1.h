//
//  Controlador1.h
//  Trabajo
//
//  Created by Lion on 21/01/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import <Cocoa/Cocoa.h>
@class Controlador2;

@interface Controlador1 : NSObject{
    NSMutableArray * lista;
    Controlador2 *controlador2;
    NSBezierPath *poly;
    IBOutlet NSTextField *etiqueta;
    IBOutlet NSView *view;
    int minimo;
    int maximo;
}
-(void) drawRect: (NSRect)b withGraphicsContext:(NSGraphicsContext *)ctx;

@end

