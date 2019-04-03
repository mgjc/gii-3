//
//  Vista.m
//  Trabajo
//
//  Created by Lion on 05/02/2019.
//  Copyright © 2019 jcmg. All rights reserved.
//

#import "Vista.h"
#import "Controlador1.h"

@implementation Vista
- (id)initWithFrame:(NSRect)frame
{
    self = [super initWithFrame:frame];
    return self;
}
- (void)drawRect:(NSRect)dirtyRect {
    [super drawRect:dirtyRect];
    NSRect bounds = [self bounds];
    NSGraphicsContext * ctx = [NSGraphicsContext currentContext];
    
    [[NSColor whiteColor] set];
    [NSBezierPath fillRect:bounds];
    [controlador drawRect:bounds withGraphicsContext:ctx];
}

@end
