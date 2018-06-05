// http://stackoverflow.com/questions/2550281/floating-point-vs-integer-calculations-on-modern-hardware

#include <stdio.h>
#include <sys/time.h>
#include <time.h>
#include <limits.h>
#include <float.h>

#define ADD_SUB_PER_ITER 20

#define MUL_DIV_PER_ITER 20

double mygettime(void);
double test_long_add_sub	(unsigned long  iMax, 	long *vSal);
double test_long_mul_div	(unsigned long  iMax, 	long *vSal);
double test_long_long_add_sub	(unsigned long  iMax, 	long long *vSal);
double test_long_long_mul_div	(unsigned long  iMax, 	long long *vSal);
double test_double_add_sub	(unsigned long  iMax, 	double *vSal);
double test_double_mul_div	(unsigned long  iMax, 	double *vSal);
double test_long_double_add_sub	(unsigned long  iMax, 	long double *vSal);
double test_long_double_mul_div	(unsigned long  iMax, 	long double *vSal);

void print_limits(void);
