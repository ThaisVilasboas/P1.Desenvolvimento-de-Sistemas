using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISCIPLINAS.P1
{
    internal class Disciplina

    {
        public Disciplina()
        { }
        public Disciplina
        (

            int codigo,
            string nome,
            double nota1,
            double nota2,
            double notaSubstitutiva,
            double media,
            int ausencia,
            string situacaoFinal
        )

        {
            Codigo = codigo;
            Nome = nome;
            Nota1 = nota1;
            Nota2 = nota2;
            NotaSubstitutiva = notaSubstitutiva;
            Media = media;
            Ausencia = ausencia;
            SituacaoFinal = situacaoFinal;
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double NotaSubstitutiva { get; set; }
        public double Media { get; set; }
        public int Ausencia { get; set; }
        public string SituacaoFinal { get; set; }
        public override string ToString()

        {

            {
                return

                       $"\n DADOS DA DISCIPLINAS {Nome} | CÓDIGO: {Codigo}:" +
                       $"\n PRIMEIRA NOTA: {Nota1}" +
                       $"\n SEGUNDA NOTA: {Nota2}" +
                       $"\n NOTA DA SUB: {NotaSubstitutiva}" +
                       $"\n MEDIA: {Media}" +
                       $"\n NÚMERO DE FALTAS: {Ausencia}" +
                       $"\n SITUAÇÃO DA DISCIPLINA: {SituacaoFinal}";

            }
                       


        }

    }
}
