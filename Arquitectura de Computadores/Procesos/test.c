// http://stackoverflow.com/questions/2550281/floating-point-vs-integer-calculations-on-modern-hardware

#include <stdio.h>
#include <sys/time.h>
#include <time.h>
#include <limits.h>
#include <float.h>

double mygettime(void) {
  struct timeval tv;
  if(gettimeofday(&tv, 0) < 0) {
    perror("oops");
  }
  return (double)tv.tv_sec + (0.000001 * (double)tv.tv_usec);
}

double test_long_add_sub(unsigned long iMax, long * vSal )
{
  unsigned long long i;




  long v  = 1;

  long v0 = 1;
  long v1 = 2;
  long v2 = 3;
  long v3 = 4;
  long v4 = 5;
  long v5 = 5;
  long v6 = 4;
  long v7 = 3;
  long v8 = 2;
  long v9 = 1;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
  }
 
  double t2 = mygettime();
  *vSal=v+iMax; 

  return t2 - t1;
}



double test_long_mul_div(unsigned long iMax, long * vSal)
{
  unsigned long i;

  long  v0 = 1;
  long  v1 = 1;
  long  v2 = 2;
  long  v3 = 2;
  long  v4 = 3;
  long  v5 = 3;
  long  v6 = 4;
  long  v7 = 4;
  long  v8 = 5;
  long  v9 = 5;
  long  v=0;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v=1;
    v *= v0;
    v /= v1;
    v *= v2;
    v /= v3;
    v *= v4;
    v /= v5;
    v *= v6;
    v /= v7;
    v *= v8;
    v /= v9;
    v *= v0;
    v /= v1;
    v *= v2;
    v /= v3;
    v *= v4;
    v /= v5;
    v *= v6;
    v /= v7;
    v *= v8;
    v /= v9;
  }
  
  double t2 = mygettime();
  *vSal=v+iMax;

  return t2 - t1;
}

double test_long_long_add_sub(unsigned long iMax, long long * vSal)
{
  unsigned long long i;

  long long  v  = 1;

  long long  v0 = 1;
  long long  v1 = 2;
  long long  v2 = 3;
  long long  v3 = 4;
  long long  v4 = 5;
  long long  v5 = 5;
  long long  v6 = 4;
  long long  v7 = 3;
  long long  v8 = 2;
  long long  v9 = 1;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
  }
  double t2 = mygettime();
  *vSal=v+iMax;

  return t2 - t1;
}



double test_long_long_mul_div(unsigned long iMax, long long * vSal)
{
  unsigned long long i;

  long long v0 = 1;
  long long v1 = 1;
  long long v2 = 2;
  long long v3 = 2;
  long long v4 = 3;
  long long v5 = 3;
  long long v6 = 4;
  long long v7 = 4;
  long long v8 = 5;
  long long v9 = 5;
  long long v=0;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v=1;
    v *= v0;
    v /= v1;
    v *= v2;
    v /= v3;
    v *= v4;
    v /= v5;
    v *= v6;
    v /= v7;
    v *= v8;
    v /= v9;
    v *= v0;
    v /= v1;
    v *= v2;
    v /= v3;
    v *= v4;
    v /= v5;
    v *= v6;
    v /= v7;
    v *= v8;
    v /= v9;
  }
  double t2 = mygettime();
  *vSal=v+iMax;
  
return t2 - t1;
}



double test_double_add_sub(unsigned long iMax, double *vSal )
{
  unsigned long long i;
  double v  = 1;

  double v0 = 1;
  double v1 = 2;
  double v2 = 3;
  double v3 = 4;
  double v4 = 5;
  double v5 = 5;
  double v6 = 4;
  double v7 = 3;
  double v8 = 2;
  double v9 = 1;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
  }
  double t2 = mygettime();
  *vSal=v+iMax;

  return t2 - t1;
}


double test_double_mul_div(unsigned long iMax, double *vSal)
{
  unsigned long long i;

  double v0 = 1.1;
  double v1 = 1.1;
  double v2 = 2.2;
  double v3 = 2.2;
  double v4 = 3.3;
  double v5 = 3.3;
  double v6 = 4.4;
  double v7 = 4.4;
  double v8 = 5.5;
  double v9 = 5.5;
  double v=0;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v=1;
    v /= v0;
    v *= v1;
    v /= v2;
    v *= v3;
    v /= v4;
    v *= v5;
    v /= v6;
    v *= v7;
    v /= v8;
    v *= v9;
    v /= v0;
    v *= v1;
    v /= v2;
    v *= v3;
    v /= v4;
    v *= v5;
    v /= v6;
    v *= v7;
    v /= v8;
    v *= v9;
  }
  double t2 = mygettime();
  *vSal=v+iMax;

  return t2 - t1;
}


double test_long_double_add_sub(unsigned long iMax, long double * vSal)
{
 unsigned long long i;
  long double v  = 1;

  long double v0 = 1;
  long double v1 = 2;
  long double v2 = 3;
  long double v3 = 4;
  long double v4 = 5;
  long double v5 = 5;
  long double v6 = 4;
  long double v7 = 3;
  long double v8 = 2;
  long double v9 = 1;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
    v += v0;
    v += v1;
    v += v2;
    v += v3;
    v += v4;
    v -= v5;
    v -= v6;
    v -= v7;
    v -= v8;
    v -= v9;
  }
  double t2 = mygettime();
  *vSal=v+iMax;  

  return t2 - t1;
}


double test_long_double_mul_div(unsigned long iMax, long double *vSal)
{
  unsigned long long i;

  long double v0 = 1.1;
  long double v1 = 1.1;
  long double v2 = 2.2;
  long double v3 = 2.2;
  long double v4 = 3.3;
  long double v5 = 3.3;
  long double v6 = 4.4;
  long double v7 = 4.4;
  long double v8 = 5.5;
  long double v9 = 5.5;
  long double v=0;
  *vSal=0;
  double t1 = mygettime();
  for (i = 0; i < iMax; ++i) {
    v=1;
    v /= v0;
    v *= v1;
    v /= v2;
    v *= v3;
    v /= v4;
    v *= v5;
    v /= v6;
    v *= v7;
    v /= v8;
    v *= v9;
    v /= v0;
    v *= v1;
    v /= v2;
    v *= v3;
    v /= v4;
    v *= v5;
    v /= v6;
    v *= v7;
    v /= v8;
    v *= v9;
  }
  double t2 = mygettime();
  *vSal=v+iMax;

  return t2 - t1;
}


void print_limits(void)
{
	printf("CHAR    (min, max, umax): %d,%d,%u\n", SCHAR_MIN, SCHAR_MAX, UCHAR_MAX);
	printf("SHORT   (min, max, umax): %d,%d,%u\n", SHRT_MIN, SHRT_MAX, USHRT_MAX);
	printf("INT     (min, max, umax): %d,%d,%u\n", INT_MIN, INT_MAX, UINT_MAX);  
	printf("LONG    (min, max, umax): %ld,%ld,%lu\n", LONG_MIN, LONG_MAX, ULONG_MAX);
	printf("LLONG   (min, max, umax): %lld,%lld,%llu\n", LLONG_MIN, LLONG_MAX, ULLONG_MAX);   
	printf("FLOAT   (min, max)      : %e,%e\n", FLT_MIN, FLT_MAX);
	printf("DOUBLE  (min, max)      : %e,%e\n", DBL_MIN, DBL_MAX);
	printf("LDOUBLE (min, max)      : %Le,%Le\n", LDBL_MIN, LDBL_MAX);  
    
}

