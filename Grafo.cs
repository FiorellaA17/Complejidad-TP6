
using System;
using System.Collections.Generic;

namespace Grafos
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		public Grafo()
		{
		}
		
		private List<Vertice<T>>vertices = new List<Vertice<T>>();
	
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}

	
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int posicion) {
			return this.vertices[posicion];
		}
	

		public void DFS(Vertice<T> origen) 
		{
			bool [] visitados= new bool[getVertices().Count];
			_DFS(origen,visitados);
		}
		
		private void _DFS(Vertice<T> origen, bool[] visitados)
		{
			visitados[origen.getPosicion()-1]=true;
			Console.Write(origen.getDato() + "|");
			foreach(var ady in origen.getAdyacentes())
			{
				if(!visitados[ady.getDestino().getPosicion()-1])
				{
					_DFS(ady.getDestino(),visitados);
				}
			}
		}
		
		public void BFS(Vertice<T> origen) 
		{
			Cola<Vertice<T>> c =new Cola<Vertice<T>>();
			Vertice<T> verticeAux;
			bool[] visitados=new bool[getVertices().Count];
			c.encolar(origen);
			visitados[origen.getPosicion()-1]=true;
			while(!c.esVacia())
			{
				verticeAux=c.desencolar();
				Console.Write(verticeAux.getDato()+"|");
				foreach(var ady in verticeAux.getAdyacentes())
				{
					if(!visitados[ady.getDestino().getPosicion()-1])
					{
						c.encolar(ady.getDestino());
						visitados[ady.getDestino().getPosicion()-1]=true;
					}
				}
			}
		}
		
		
		public void DFS_mejorCamino(Vertice<T> origen,Vertice<T> destino) 
		{
			bool [] visitados= new bool[getVertices().Count];
			List<Vertice<T>> camino=new List<Vertice<T>>();
			List<Vertice<T>> mejorCamino=new List<Vertice<T>>();
			
			_mejorCamino(origen,destino,camino,mejorCamino,visitados);
			foreach(var elem in mejorCamino)
			{
				Console.Write(elem.getDato() + "|");
			}
		}

		
		private void _mejorCamino(Vertice<T> origen,Vertice<T> destino,List<Vertice<T>> camino, List<Vertice<T>> mejorCamino, bool[] visitados)
		{
			camino.Add(origen); 
			visitados[origen.getPosicion()-1]=true; 
			
			if(origen.Equals(destino))
			{
				if(mejorCamino.Count==0)
				{
					mejorCamino.AddRange(camino);
				}
				
				if(camino.Count < mejorCamino.Count)
				{
					mejorCamino.Clear();
					mejorCamino.AddRange(camino);
					
				}
			}
			
			else
			{
				foreach(var ady in origen.getAdyacentes())
				{
					if(!visitados[ady.getDestino().getPosicion()-1])
					{
						_mejorCamino(ady.getDestino(),destino,camino,mejorCamino,visitados);
						visitados[ady.getDestino().getPosicion()-1]=false;
						camino.RemoveAt(camino.Count-1);
					}
				}
			}
			
		}
	}
}
