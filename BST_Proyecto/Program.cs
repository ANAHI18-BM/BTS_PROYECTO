using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBST
{
    public Nodo Raiz;

    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        return nodo;
    }

    public bool Buscar(int valor)
    {
        return BuscarRec(Raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;

        if (valor == nodo.Valor)
            return true;

        if (valor < nodo.Valor)
            return BuscarRec(nodo.Izquierdo, valor);

        return BuscarRec(nodo.Derecho, valor);
    }

    public void Eliminar(int valor)
    {
        Raiz = EliminarRec(Raiz, valor);
    }

    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            nodo.Valor = MinValor(nodo.Derecho);
            nodo.Derecho = EliminarRec(nodo.Derecho, nodo.Valor);
        }

        return nodo;
    }

    private int MinValor(Nodo nodo)
    {
        int min = nodo.Valor;
        while (nodo.Izquierdo != null)
        {
            min = nodo.Izquierdo.Valor;
            nodo = nodo.Izquierdo;
        }
        return min;
    }

    public int Min()
    {
        return MinValor(Raiz);
    }

    public int Max()
    {
        Nodo actual = Raiz;
        while (actual.Derecho != null)
            actual = actual.Derecho;

        return actual.Valor;
    }

    public int Altura()
    {
        return AlturaRec(Raiz);
    }

    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null)
            return -1;

        return 1 + Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho));
    }

    public void Inorden()
    {
        InordenRec(Raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InordenRec(nodo.Derecho);
        }
    }

    public void Preorden()
    {
        PreordenRec(Raiz);
        Console.WriteLine();
    }

    private void PreordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRec(nodo.Izquierdo);
            PreordenRec(nodo.Derecho);
        }
    }

    public void Postorden()
    {
        PostordenRec(Raiz);
        Console.WriteLine();
    }

    private void PostordenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRec(nodo.Izquierdo);
            PostordenRec(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENU BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Inorden");
            Console.WriteLine("5. Preorden");
            Console.WriteLine("6. Postorden");
            Console.WriteLine("7. Minimo");
            Console.WriteLine("8. Maximo");
            Console.WriteLine("9. Altura");
            Console.WriteLine("10. Limpiar");
            Console.WriteLine("0. Salir");

            Console.Write("Opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor: ");
                    arbol.Insertar(int.Parse(Console.ReadLine()));
                    break;

                case 2:
                    Console.Write("Valor: ");
                    Console.WriteLine(arbol.Buscar(int.Parse(Console.ReadLine())) ? "Encontrado" : "No encontrado");
                    break;

                case 3:
                    Console.Write("Valor: ");
                    arbol.Eliminar(int.Parse(Console.ReadLine()));
                    break;

                case 4:
                    arbol.Inorden();
                    break;

                case 5:
                    arbol.Preorden();
                    break;

                case 6:
                    arbol.Postorden();
                    break;

                case 7:
                    Console.WriteLine("Minimo: " + arbol.Min());
                    break;

                case 8:
                    Console.WriteLine("Maximo: " + arbol.Max());
                    break;

                case 9:
                    Console.WriteLine("Altura: " + arbol.Altura());
                    break;

                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Arbol limpiado");
                    break;
            }

        } while (opcion != 0);
    }
}
