//
//  Controlador2.h
//  Trabajo
//
//  Created by Lion on 21/01/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import <Cocoa/Cocoa.h>


@interface Controlador2 : NSWindowController <NSTableViewDataSource>{
    IBOutlet NSTextField *Nombre;
    IBOutlet NSPopUpButton *Funcion;
    IBOutlet NSPopUpButton *Color;
    IBOutlet NSTextField *A;
    IBOutlet NSTextField *B;
    IBOutlet NSTextField *C;
    IBOutlet NSTextField *N;
    IBOutlet NSTextField *Max;
    IBOutlet NSTextField *Min;
    IBOutlet NSTextField *Mensaje;
    IBOutlet NSTableView *tableview;
    NSMutableArray *lista1;
    NSMutableArray *listanombres;
    NSMutableArray *lista2;
}

- (IBAction)Agregar:(id)sender;
- (IBAction)Dibujar:(id)sender;
- (IBAction)Modificar:(id)sender;
- (IBAction)Eliminar:(id)sender;
- (IBAction)ActualizarFuncion:(id)sender;

@end
