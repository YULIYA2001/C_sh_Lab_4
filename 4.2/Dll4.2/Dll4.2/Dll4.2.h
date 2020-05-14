#pragma once

// Приведенный ниже блок ifdef — это стандартный метод создания макросов, упрощающий процедуру
// экспорта из библиотек DLL. Все файлы данной DLL скомпилированы с использованием символа DLL42_EXPORTS
// Символ, определенный в командной строке. Этот символ не должен быть определен в каком-либо проекте,
// использующем данную DLL. Благодаря этому любой другой проект, исходные файлы которого включают данный файл, видит
// функции DLL42_API как импортированные из DLL, тогда как данная DLL видит символы,
// определяемые данным макросом, как экспортированные.
#ifdef DLL42_EXPORTS
#define DLL42_API __declspec(dllexport)
#else
#define DLL42_API __declspec(dllimport)
#endif

extern "C" DLL42_API int Addition(int x, int y);
extern "C" DLL42_API int Subtraction(int x, int y);
extern "C" DLL42_API int Multiplication(int x, int y);
extern "C" DLL42_API double Division(int x, int y);
extern "C" DLL42_API int Compare(int x, int y);
extern "C" DLL42_API double Power(int x, int y);
extern "C" DLL42_API int ABS(int x);