using System;
using DIO.Series.Enum;
using DIO.Series.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class Series : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Series(int id, Genero genero, string titulo, string descricao, int ano )
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string stringRetorno = "";

            stringRetorno += "Gênero: " + this.Genero + Environment.NewLine;
            stringRetorno += "Titulo: " + this.Titulo + Environment.NewLine;
            stringRetorno += "Descrição: " + this.Descricao + Environment.NewLine;
            stringRetorno += "Ano de lançamento: " + this.Ano;
            stringRetorno += "Excluido? " + this.Excluido;
            return stringRetorno;
        }

        public bool RetornExcluido()
        {
            return this.Excluido;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }



}
