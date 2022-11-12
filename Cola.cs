/*
 * Creado por SharpDevelop.
 * Usuario: Windows
 * Fecha: 7/11/2022
 * Hora: 16:54
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Grafos
{
	
	public class Cola<T>
	{
		private List<T> datos = new List<T>();
	
		public void encolar(T elem) 
		{
			this.datos.Add(elem);
		}
	
		public T desencolar() 
		{
			T temp = this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}
		
		public T tope() 
		{
			return this.datos[0]; 
		}
		
		public bool esVacia() 
		{
			return this.datos.Count == 0;
		}
		
	}
}
