using System;
using System.IO;
using System.Threading;
using static System.Console;

namespace Proyecto_3er_Parcial_Test
{
    static class MatrixCalc
{
    private static int _i, _j;

//Suma
    private static void AddMatrix(int[,] a, int[,] b, int m, int n)
{
int[,] c = new int[10, 10];
if (c == null) throw new ArgumentNullException(nameof(c));
for (_i = 0; _i < m; _i++)
{
    for (_j = 0; _j < n; _j++)
        c[_i, _j] = a[_i, _j] + b[_i, _j];
}
Display(c, m, n);
}
//Resta
    private static void SubMatrix(int[,] a, int[,] b, int m, int n)
{
int[,] c = new int[10, 10];
if (c == null) throw new ArgumentNullException(nameof(c));
for (_i = 0; _i < m; _i++)
{
    for (_j = 0; _j < n; _j++)
        c[_i, _j] = a[_i, _j] - b[_i, _j];
}
Display(c, m, n);
}

static void Display(int[,] a, int m, int n)
{
for (_i = 0; _i < m; _i++)
{
    for (_j = 0; _j < n; _j++)
        Write(a[_i, _j] + "\t");
    WriteLine();
}
}

//Multiplicación
static void MulMatrix(int[,]a,int [,]b,int m,int n)
{
int [,]c = new int[10,10];
if (c == null) throw new ArgumentNullException(nameof(c));
for(_i=0;_i< m;_i++)
{
    for(_j=0;_j< n;_j++)
    {
        c[_i,_j] = 0;
        for(int k=0;k< n;k++)
        {
            c[_i,_j] = c[_i,_j] + a[_i,k] * b[k,_j];
        }
    }
}
Display(c, m, n);
}

public static void Main(string[] args)
{
    //Bienvenida
    WriteLine("···················································································");
    WriteLine("                     Bienvenido a mi calculadora de matrices                       ");
    WriteLine("···················································································");  
    //Menú y lectura de eleccion del usuario
    int choice;
    WriteLine("1 · Suma");
    WriteLine("2 · Resta");
    WriteLine("3 · Multiplicacion");
    WriteLine("4 · Salir");
    Write("Elija una opcion: ");
    while (Int32.TryParse(Console.ReadLine(), out choice) == false)
    {
        Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
    }
// La primera matriz de entrada es llamada A
int m, n;
Write("Introduzca el número de filas de la matriz A: ");
while (Int32.TryParse(Console.ReadLine(), out m) == false)
{
    Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
}Write("Introduzca el número de columnas de la matriz A: ");
while (Int32.TryParse(Console.ReadLine(), out n) == false)
{
    Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
}
int[,] a = new int[10, 10];
if (a == null) throw new ArgumentNullException(nameof(a));
Write("\nIngrese los valores de la primer matriz (Ingrese el número y presione Enter): \n");
for (_i = 0; _i < m; _i++)
{
    for (_j = 0; _j < n; _j++)
        while (Int32.TryParse(Console.ReadLine(), out a[_i, _j]) == false)
        {
            Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
        }
}
// La primera matriz de entrada es llamada B
int p,q;
Write("Introduzca el número de filas de la matriz B:");
while (Int32.TryParse(Console.ReadLine(), out p) == false)
{
    Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
}
Write("Introduzca el número de columnas de la matriz B: ");
while (Int32.TryParse(Console.ReadLine(), out q) == false)
{
    Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
}
int[,] b = new int[10, 10];
if (b == null) throw new ArgumentNullException(nameof(b));
Write("\nIngrese los valores de la segunda matriz (Ingrese el número y presione Enter): \n");
for (_i = 0; _i < p; _i++)
{
    for (_j = 0; _j < q; _j++)
        while (Int32.TryParse(Console.ReadLine(), out b[_i, _j]) == false)
        {
            Console.WriteLine("ERROR !!!!!! Ingrese un numero por favor");
        }
}
Clear();

// Muestra las dos matrices

WriteLine("\nMatriz A : ");
Display(a, m, n);

WriteLine("\nMatriz B: ");
Display(b, p, q);

//Se selecciona una operación a realizar
    switch (choice)
{
case 1:
    if (m != p || n != q) //Se verifica que las filas y columas sean iguales antes de llamar a función de la operación
        WriteLine("ERROR !!!!!! Filas y columnas de ambas matrices deben ser iguales");
    else
    {
        WriteLine("El resultado de la suma de matrices es: ");
        AddMatrix(a, b, m, n);
        Console.WriteLine ("La Matriz Resultante del Calculo Elegido fue almacenada en el archivo Resultados_de_Operacion_Matrices.txt");
        Console.WriteLine("¿Desea capturar otros datos?");
        var response = (Console.ReadLine());
        switch (response)
        {
            case "si":
                string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
                System.Diagnostics.Process.Start(myApp);
                Environment.Exit(0);
                break;
            case "no":
                Console.WriteLine("Gracias por usar mi programa, bye");
                Thread.Sleep(2000);
                break;
        }
        FileStream filestream = new FileStream("Resultados_de_Operacion_Matrices.txt", FileMode.Create);
        var streamwriter = new StreamWriter(filestream);
        streamwriter.AutoFlush = true;
        Console.SetOut(streamwriter);
        Console.SetError(streamwriter);
        WriteLine("El resultado de la suma de matrices es: ");
        AddMatrix(a, b, m, n);
    }

    break;

case 2:
if (m == p && n == q)
{
    WriteLine("El resultado de la resta de matrices es: ");
    SubMatrix(a, b, m, n);
    Console.WriteLine ("La Matriz Resultante del Calculo Elegido fue almacenada en el archivo Resultados_de_Operacion_Matrices.txt");
    Console.WriteLine("¿Desea capturar otros datos?");
    var response = (Console.ReadLine());
    switch (response)
    {
        case "si":
            string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            System.Diagnostics.Process.Start(myApp);
            Environment.Exit(0);
            break;
        case "no":
            Console.WriteLine("Gracias por usar mi programa, bye");
            Thread.Sleep(2000);
            break;
    }
    FileStream filestream = new FileStream("Resultados_de_Operacion_Matrices.txt", FileMode.Create);
    var streamwriter = new StreamWriter(filestream);
    streamwriter.AutoFlush = true;
    Console.SetOut(streamwriter);
    Console.SetError(streamwriter);
    WriteLine("El resultado de la resta de matrices es: ");
    SubMatrix(a, b, m, n);
}
else
    WriteLine("ERROR !!!!!! Filas y columnas de ambas martrices deben ser iguales");
break;

case 3:
if (n == p)
{
    WriteLine("El resultado de la multiplicacion de matrices es: ");
    MulMatrix(a, b, m, q);
    Console.WriteLine ("La Matriz Resultante del Calculo Elegido fue almacenada en el archivo Resultados_de_Operacion_Matrices.txt");
    Console.WriteLine("¿Desea capturar otros datos?");
    var response = (Console.ReadLine());
    switch (response)
    {
        case "si":
            string myApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            System.Diagnostics.Process.Start(myApp);
            Environment.Exit(0);
            break;
        case "no":
            Console.WriteLine("Gracias por usar mi programa, bye");
            Thread.Sleep(2000);
            break;
    }
    FileStream filestream = new FileStream("Resultados_de_Operacion_Matrices.txt", FileMode.Create);
    var streamwriter = new StreamWriter(filestream);
    streamwriter.AutoFlush = true;
    Console.SetOut(streamwriter);
    Console.SetError(streamwriter);
    WriteLine("El resultado de la multiplicacion de matrices es: ");
    MulMatrix(a, b, m, q);
}
else
    WriteLine("ERROR !!!!!! Filas y columnas de ambas martrices deben ser iguales");
break;

case 4:
    Console.WriteLine("Gracias por usar mi programa, bye");
    Thread.Sleep(1000);
break;
}
}
}
}