using System;
using System.Collections.Generic;
using APIs.Interfaces;

namespace APIs.Classes
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaPorId(int id)
		{
			if (!RegistroExiste(id))
			{
				throw new Exception("Série não encontrada");
			}
			return listaSerie[id];
		}

		public bool RegistroExiste(int id)
		{
			bool existe = false;
			foreach (var item in listaSerie)
			{
				if (item.Id == id)
					existe = true;
			}
			return existe;
		}
	}
}