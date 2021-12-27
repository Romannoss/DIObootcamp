using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appcadastro.Enum;
using Appcadastro.interfaces;

namespace Appcadastro.classes
{
    class SerieRepositorio : irepositorio<serie>
    {
        private List<serie> ListaSerie = new List<serie>();

        public SerieRepositorio()
        {
        }

        public SerieRepositorio(int id, Genero genero, string titulo, int ano, string descricao)
        {
        }

        public void Atualiza(int id, serie objeto)
        {
            ListaSerie[id] = objeto;
        }

        public void Atualiza(int id, Task entidade)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(serie objeto)
        {
            ListaSerie.Add(objeto);
        }

        public List<serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public serie RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}
