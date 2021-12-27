using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcadastro.classes
{
    public class serie : Entidadebase
    {

        // atributos

        private Enum.Genero Genero { get; set; }

        private String titulo { get; set; }

        private String descricao { get; set; }

        private int ano { get; set; }

        private bool Excluido { get; set; }

        // metodos

        public serie(int id, Enum.Genero genero, string titulo, string descricao, int ano) { 

            this.id = id;
            this.Genero = Genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
           

            string retorno = "";

            retorno += "Genero " + this.Genero + Environment.NewLine;
            retorno += "Titulo " + this.titulo + Environment.NewLine;
            retorno += "descrição " + this.descricao + Environment.NewLine;
            retorno += "Ano " + this.ano;
            retorno += "Excluido " + this.Excluido;

            return retorno;
        }

        public string retornatitulo()
        {
            return this.titulo;
        }

        public int retornaid()
        {
            return this.id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
