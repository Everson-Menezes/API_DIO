using System;
using System.Collections.Generic;
using APIs.Interfaces;

namespace APIs.Classes
{
	public class FilmeRepositorio : IRepositorio<Filme>
	{
        private List<Filme> listaFilme = new List<Filme>();
		public void Atualiza(int id, Filme objeto)
		{
			listaFilme[id] = objeto;
		}

		public void Exclui(int id)
		{
			if (!RegistroExiste(id))
			{
				throw new Exception("Filme não encontrado");
            }
            else
            {

				listaFilme[id].Excluir();
			}
		}

		public void Insere(Filme objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filme RetornaPorId(int id)
		{
            if (!RegistroExiste(id))
            {
				throw new Exception("Filme não encontrado");
            }
			return listaFilme[id];
		}

        public bool RegistroExiste(int id)
        {
			bool existe = false;
            foreach (var item in listaFilme)
            {
				if (item.Id == id)
					existe = true;
            }
			return existe;
        }
    }
}