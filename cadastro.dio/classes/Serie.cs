using System;
using System.Collections.Generic;
using System.Text;


namespace cadastro.dio
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        public string Titulo { get; set; }
        private string Descricao { get; set; }
        public int Ano { get; set; }
        private bool Excluido { get; set; }
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
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
            return "Gênero: "
                   + this.Genero
                   + Environment.NewLine
                   + "Titulo: "
                   + this.Titulo
                   + Environment.NewLine
                   + "Descricao: "
                   + this.Descricao
                   + Environment.NewLine
                   + "Ano de inicio: "
                   + this.Ano
                   + Environment.NewLine
                   + "Excluído: "
                   + this.Excluido;
        }
        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public int RetornaId()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }



    }
}