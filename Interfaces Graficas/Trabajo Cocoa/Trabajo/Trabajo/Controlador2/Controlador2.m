//
//  Controlador2.m
//  Trabajo
//
//  Created by Lion on 21/01/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import "Controlador2.h"
#import "Datos.h"

@implementation Controlador2

- (void)awakeFromNib{
    [Max setStringValue:@"1"];
    [Min setIntValue:-1];
    [C setEnabled:false];
    [N setEnabled:false];
}

-(id) init{
    self= [super init];
    if(![super initWithWindowNibName:@"Controlador2"]){
        return nil;
    }
    lista1 = [[NSMutableArray alloc] init];
    listanombres = [[NSMutableArray alloc] init];
    lista2 = [[NSMutableArray alloc] init];
    return self;
}
- (id)initWithWindow:(NSWindow *)window
{
    self = [super initWithWindow:window];
    if (self) {
        // Initialization code here.
    }
    return self;
}
-(NSInteger)numberOfRowsInTableView:(NSTableView *)tableView{
    return [lista1 count];
}

-(id)tableView:(NSTableView *)tableView objectValueForTableColumn:(NSTableColumn *)tableColumn row:(NSInteger)row{
    Datos *dato= [lista1 objectAtIndex:row];
    NSString *identificador= [tableColumn identifier];
    return [dato valueForKey:identificador];
}

- (IBAction)Agregar:(id)sender{
    NSString *convertidor;
    BOOL x=true;
    
    [Mensaje setStringValue:@""];
    
    int valorA=[A intValue];
    convertidor=[NSString stringWithFormat:@"%d", valorA ];
    valorA=[convertidor intValue];
    
    int valorXMAX=[Max intValue];
    convertidor=[NSString stringWithFormat:@"%d", valorXMAX ];
    valorXMAX=[convertidor intValue];
    
    int valorXMIN=[Min intValue];
    convertidor=[NSString stringWithFormat:@"%d", valorXMIN ];
    valorXMIN=[convertidor intValue];
    
    if([@"a*sen(b*x)" isEqualToString:[Funcion titleOfSelectedItem]] || [@"a*cos(b*x)" isEqualToString:[Funcion titleOfSelectedItem]] || [@"a*x+b" isEqualToString:[Funcion titleOfSelectedItem]] || [@"a/(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
        int valorB=[B intValue];
        convertidor=[NSString stringWithFormat:@"%d", valorB ];
        valorB=[convertidor intValue];
        if([@"a/(b*x)" isEqualToString:[Funcion titleOfSelectedItem]] && valorB == 0){
            [Mensaje setStringValue:@"Valor inválido para B"];
            return;
        }
        NSInteger filas=[listanombres count];
        for(int i=0;i<filas;i++){
            NSString *name= [listanombres objectAtIndex:i];
            if([name isEqualToString:[Nombre stringValue]]){
                x=false;
            }
        }
        if(x){
            [lista1 addObject:[[Datos alloc] CargarValores:[Nombre stringValue] Funcion:[Funcion titleOfSelectedItem] A:valorA B:valorB C:0 N:0 Color:[Color titleOfSelectedItem] XMAX:valorXMAX XMIN:valorXMIN]];
        }
    }
    if([@"a*x^n" isEqualToString:[Funcion titleOfSelectedItem]]){
        int valorN=[N intValue];
        convertidor=[NSString stringWithFormat:@"%d", valorN ];
        valorN=[convertidor intValue];
        NSInteger filas=[listanombres count];
        for(int i=0;i<filas;i++){
            NSString *name= [listanombres objectAtIndex:i];
            if([name isEqualToString:[Nombre stringValue]]){
                x=false;
            }
        }
        if(x){
            [lista1 addObject:[[Datos alloc] CargarValores:[Nombre stringValue] Funcion:[Funcion titleOfSelectedItem] A:valorA B:0 C:0 N:valorN Color:[Color titleOfSelectedItem] XMAX:valorXMAX XMIN:valorXMIN]];
        }
    }
    if([@"a*x^2+b*x+c" isEqualToString:[Funcion titleOfSelectedItem]]){
        int valorB=[B intValue];
        convertidor=[NSString stringWithFormat:@"%d", valorB ];
        valorB=[convertidor intValue];
        int valorC=[C intValue];
        convertidor=[NSString stringWithFormat:@"%d", valorC ];
        valorC=[convertidor intValue];
        NSInteger filas=[listanombres count];
        for(int i=0;i<filas;i++){
            NSString *name= [listanombres objectAtIndex:i];
            if([name isEqualToString:[Nombre stringValue]]){
                x=false;
            }
        }
        if(x){
            [lista1 addObject:[[Datos alloc] CargarValores:[Nombre stringValue] Funcion:[Funcion titleOfSelectedItem] A:valorA B:valorB C:valorC N:0 Color:[Color titleOfSelectedItem] XMAX:valorXMAX XMIN:valorXMIN]];
        }
        
    }
    if(x){
        [listanombres addObject:[Nombre stringValue]];
    }else{
        [Mensaje setStringValue:@"Nombre ya usado, utiliza otro"];
    }
    [Nombre setStringValue:@""];
    [A setStringValue:@""];
    [B setStringValue:@""];
    [C setStringValue:@""];
    [N setStringValue:@""];
    [Min setStringValue:@"-1"];
    [Max setStringValue:@"1"];
    [tableview reloadData];
    return;
}
- (IBAction)Dibujar:(id)sender{
    NSInteger fila=[tableview selectedRow];
    
    if(fila!=-1){
        Datos *d=[lista1 objectAtIndex:fila];
        NSString *nombre=[d nombre];
        for(int i=0;i<[lista2 count];i++){
            Datos *x=[lista2 objectAtIndex:i];
            if([nombre isEqualToString:[x nombre]]){
                return;
            }
        }
        [lista2 addObject:[lista1 objectAtIndex:fila]];
        NSDictionary *pr=[NSDictionary dictionaryWithObject:lista2 forKey:@"lista2"];
        [[NSNotificationCenter defaultCenter] postNotificationName:@"Transferencia" object:self userInfo:pr];
    }
}
- (IBAction)Modificar:(id)sender{
    NSInteger fila=[tableview selectedRow];
    NSString *convertidor;
    NSString *name;
    [Mensaje setStringValue:@""];
    if(fila!=-1){
        Datos *d=[lista1 objectAtIndex:fila];
        [lista1 removeObjectAtIndex:fila];
        name= [listanombres objectAtIndex:fila];
        [listanombres removeObjectAtIndex:fila];
        for(int i=0;i<[lista2 count];i++){
            Datos *x=[lista2 objectAtIndex:i];
            if([name isEqualToString:[x nombre]]){
                [lista2 removeObjectAtIndex:i];
            }
        }
        [Nombre setStringValue:[d nombre]];
        [Funcion selectItemWithTitle:[d funcion]];
        [Color selectItemWithTitle:[d color]];
        convertidor=[NSString stringWithFormat:@"%d", [d a] ];
        [A setStringValue:convertidor];
        convertidor=[NSString stringWithFormat:@"%d", [d b] ];
        [B setStringValue:convertidor];
        convertidor=[NSString stringWithFormat:@"%d", [d c] ];
        [C setStringValue:convertidor];
        convertidor=[NSString stringWithFormat:@"%d", [d n] ];
        [N setStringValue:convertidor];
        convertidor=[NSString stringWithFormat:@"%d", [d xmax] ];
        [Max setStringValue:convertidor];
        convertidor=[NSString stringWithFormat:@"%d", [d xmin] ];
        [Min setStringValue:convertidor];
        
        if([@"a*sen(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
            [C setStringValue:@""];
            [N setStringValue:@""];
            [B setEnabled:true];
            [C setEnabled:false];
            [N setEnabled:false];
        }
        if([@"a*cos(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
            [C setStringValue:@""];
            [N setStringValue:@""];
            [B setEnabled:true];
            [C setEnabled:false];
            [N setEnabled:false];
        }
        if([@"a*x^n" isEqualToString:[Funcion titleOfSelectedItem]]){
            [B setStringValue:@""];
            [C setStringValue:@""];
            [B setEnabled:false];
            [C setEnabled:false];
            [N setEnabled:true];
        }
        if([@"a*x+b" isEqualToString:[Funcion titleOfSelectedItem]]){
            [C setStringValue:@""];
            [N setStringValue:@""];
            [B setEnabled:true];
            [C setEnabled:false];
            [N setEnabled:false];
        }
        if([@"a*x^2+b*x+c" isEqualToString:[Funcion titleOfSelectedItem]]){
            [N setStringValue:@""];
            [B setEnabled:true];
            [C setEnabled:true];
            [N setEnabled:false];
        }
        if([@"a/(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
            [C setStringValue:@""];
            [N setStringValue:@""];
            [B setEnabled:true];
            [C setEnabled:false];
            [N setEnabled:false];
        }
        [Mensaje setStringValue:@"Recuerda guardar los datos, sino los perderás"];
        if([lista2 count]>0){
            NSDictionary *pr=[NSDictionary dictionaryWithObject:lista2 forKey:@"lista2"];
            [[NSNotificationCenter defaultCenter] postNotificationName:@"Transferencia" object:self userInfo:pr];
        }else{
            [[NSNotificationCenter defaultCenter] postNotificationName:@"Transferencia" object:self userInfo:nil];
        }
    }
    [tableview reloadData];
}

- (IBAction)Eliminar:(id)sender{
    NSInteger fila=[tableview selectedRow];
    if(fila!=-1){
        [lista1 removeObjectAtIndex:fila];
        NSString *name= [listanombres objectAtIndex:fila];
        [listanombres removeObjectAtIndex:fila];
        for(int i=0;i<[lista2 count];i++){
            Datos *x=[lista2 objectAtIndex:i];
            if([name isEqualToString:[x nombre]]){
                [lista2 removeObjectAtIndex:i];
            }
        }
        if([lista2 count]>0){
            NSDictionary *pr=[NSDictionary dictionaryWithObject:lista2 forKey:@"lista2"];
            [[NSNotificationCenter defaultCenter] postNotificationName:@"Transferencia" object:self userInfo:pr];
        }else{
            [[NSNotificationCenter defaultCenter] postNotificationName:@"Transferencia" object:self userInfo:nil];
        }
    }
    [tableview reloadData];
}

- (IBAction)ActualizarFuncion:(id)sender {
    if([@"a*sen(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
        [A setStringValue:@""];
        [B setStringValue:@""];
        [B setEnabled:true];
        [C setEnabled:false];
        [N setEnabled:false];
    }
    if([@"a*cos(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
        [A setStringValue:@""];
        [B setStringValue:@""];
        [B setEnabled:true];
        [C setEnabled:false];
        [N setEnabled:false];
    }
    if([@"a*x^n" isEqualToString:[Funcion titleOfSelectedItem]]){
        [A setStringValue:@""];
        [N setStringValue:@""];
        [B setEnabled:false];
        [C setEnabled:false];
        [N setEnabled:true];
    }
    if([@"a*x+b" isEqualToString:[Funcion titleOfSelectedItem]]){
        [A setStringValue:@""];
        [B setStringValue:@""];
        [B setEnabled:true];
        [C setEnabled:false];
        [N setEnabled:false];
    }
    if([@"a*x^2+b*x+c" isEqualToString:[Funcion titleOfSelectedItem]]){
        [A setStringValue:@""];
        [B setStringValue:@""];
        [C setStringValue:@""];
        [B setEnabled:true];
        [C setEnabled:true];
        [N setEnabled:false];
    }
    if([@"a/(b*x)" isEqualToString:[Funcion titleOfSelectedItem]]){
        [A setStringValue:@""];
        [B setStringValue:@""];
        [B setEnabled:true];
        [C setEnabled:false];
        [N setEnabled:false];
    }
    
}

@end
