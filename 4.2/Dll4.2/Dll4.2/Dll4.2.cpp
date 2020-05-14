// Dll4.2.cpp : Определяет экспортируемые функции для DLL.
//

#include "pch.h"
#include "framework.h"
#include "Dll4.2.h"

int Addition(int x, int y)
{
	return (x + y);
}
int Subtraction(int x, int y)
{
	return (x - y);
}
int Multiplication(int x, int y)
{
	return (x * y);
}
double Division(int x, int y)
{
	if (y == 0)
		return -666;
	return ((double)x / (double)y);
}
int Compare(int x, int y)
{
	if (x == y)
		return 0;
	if (x > y)
		return 1;
	if (x < y)
		return -1;
}
double Power(int x, int y)
{
	double rez = 1.0;

	if (y == 0)
		return 1;
	if (y > 0)
	{
		while (y != 0)
		{
			rez *= x;
			y--;
		}
		return rez;
	}
	else
	{
		while (y != 0)
		{
			rez *= x;
			y++;
		}
		return ((double)(1.0) / rez);
	}
}
int ABS(int x)
{
	if (x < 0)
		return (x * (-1));
	else return x;
}
