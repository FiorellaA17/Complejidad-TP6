
using System;
using System.Collections.Generic;

namespace Grafos
{
	class Program
	{
		public static void Main(string[] args)
		{
			Grafo<int> grafo=new Grafo<int>();
			
			Vertice<int> v1=new Vertice<int>(1);
			Vertice<int> v2=new Vertice<int>(2);
			Vertice<int> v3=new Vertice<int>(3);
			Vertice<int> v4=new Vertice<int>(4);
			Vertice<int> v5=new Vertice<int>(5);
			Vertice<int> v6=new Vertice<int>(6);
			
			grafo.agregarVertice(v1);
			grafo.agregarVertice(v2);
			grafo.agregarVertice(v3);
			grafo.agregarVertice(v4);
			grafo.agregarVertice(v5);
			grafo.agregarVertice(v6);
			
			grafo.conectar(v1,v2,3);
			grafo.conectar(v1,v3,4);
			grafo.conectar(v2,v4,1);
			grafo.conectar(v4,v6,4);
			grafo.conectar(v3,v5,3);
			grafo.conectar(v3,v6,5);
			grafo.conectar(v5,v4,2);
			
			Console.Write("DFS: ");
			grafo.DFS(v1);
			
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("BFS: ");
			grafo.BFS(v1);
			Console.WriteLine("");
			Console.WriteLine("");
			
			grafo.DFS_mejorCamino(v1,v6);
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}