using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISCIPLINAS.P1
{
    internal class Program
    {
        public static readonly int _cargaHoraria = 80;
        public static Aluno _aluno = new Aluno();
        public static List<Disciplina> _disciplinas = new List<Disciplina>();
         
        static void Main(string[] args) => Menu();

        private static void Menu()
        {
            bool continuar = true;

            Console.Clear();
            Console.WriteLine(" \n SITUAÇÃO DO ALUNO ");
            Console.WriteLine(" BEM VINDO AO SISTEMA INTEGRADO");
            Console.WriteLine(" \n PARA CADASTRO DE ALUNO, DISCIPLINAS E CALCULO DE MÉDIA  ");
            Console.WriteLine("\n DIGITE QUALQUER TECLA PARA CONTINUAR");
            Console.ReadKey();
            Console.Clear();


            do
            {
                try
                {
                




                    Console.WriteLine(" [ 1 ] CADASTRO DO ALUNO ");
                    Console.WriteLine(" [ 2 ] ADICIONAR DADOS DE UMA DISCIPLINA ");
                    Console.WriteLine(" [ 3 ] DADOS DO ALUNO E DICIPLINAS CADASTRADAS ");
                    Console.WriteLine(" [ 4 ] SAIR");
                    Console.Write("\n ESCOLHA UMA OPÇÃO ");
                   
                    
                    int escolha = int.Parse(Console.ReadLine());

                    switch (escolha)
                    {
                        case 1:
                            Console.Clear();
                            if (_aluno.RA != null)
                            {
                                Console.WriteLine("\n O ALUNO INFORMADO JÁ ESTÁ CADASTRADO NO SISTEMA ");
                                MensagemParaContinuar();
                            }
                            else
                            {
                                CadastrarAluno();
                                Console.WriteLine("\n ALUNO CADASTRADO COM SUCESSO ");
                                MensagemParaContinuar();
                            }
                            break;

                        case 2:
                            Console.Clear();
                            if (_aluno.RA != null)
                            {
                                CadastrarDisciplina();
                                Console.WriteLine("\n DISCIPLINA CADASTRADA COM SUCESSO ");
                                MensagemParaContinuar();
                            }
                            else
                            {
                                Console.WriteLine("\n  CADASTRE UM ALUNO PARA ENTÃO CADASTRAR A DISCIPLINA ");
                                MensagemParaContinuar();
                            }
                            break;

                        case 3:
                            Console.Clear();
                            if (_aluno.RA != null)
                            {
                                Console.WriteLine(_aluno.ToString());

                                if (_disciplinas.Count > 0)
                                    foreach (var disciplina in _disciplinas)
                                        Console.WriteLine(disciplina.ToString());
                                else
                                {
                                    Console.WriteLine("\n NENHUMA DISCIPLINA CADASTRADA ");
                                    MensagemParaContinuar();
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n  NENHUM ALUNO CADASTRADO NO SISTEMA ");
                                MensagemParaContinuar();
                            }
                            MensagemParaContinuar();
                            break;

                        case 4:
                            continuar = false;
                            break;

                        default:
                            throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n DIGITO INVALIDO ");
                    Console.WriteLine("\n DIGITE UM NÚMERO QUE SEJA DE 1 A 5 ");
                    MensagemParaContinuar();
                }
            } while (continuar);
        }

        private static void CadastrarAluno()
        {
            Console.WriteLine(" CADASTRO DO ALUNO ");

            Console.Write(" \n DIGITE O NOME DO ALUNO: ");
            _aluno.Nome = Console.ReadLine();

            Console.Write("\n DIGITE O RA:  ");
            _aluno.RA = Console.ReadLine();
        }

        private static void CadastrarDisciplina()
        {
            Console.WriteLine(" ADICIONAR DISCIPLINA ");
            Console.Write("\n DIGITE O NOME DA DISCPLINA: ");
            string nome = Console.ReadLine();
            int codigo = LerValorInteiro ("\n DIGITE O CÓDIGO DA DISCPLINA: ");

            Console.WriteLine(" \n NOTAS ");

            double nota1 = LerValorDouble("\n INFORME A NOTA DA P1: ");
            double nota2 = LerValorDouble("\n INFORME A NOTA DA P2: ");

            Console.WriteLine(" \n SUBSTITUTIVA ");
            Console.WriteLine(" \n CASO O ALUNO NÃO TIVER FEITO, DIGITE ZERO ");
            double notaSubstitutiva = LerValorDouble("\n INFORME A NOTA TIRADA NA PROVA SUBSTITUTIVA: " );

            double mediaFinal = CalcularMediaFinal
            (
                nota1,
                nota2,
                notaSubstitutiva
            );

            Console.WriteLine(" \n FALTAS ");

            int faltas = LerValorInteiro("\n QUANTAS AUSÊNCIAS O ALUNO TEVE NESSA DISCIPLINA:  ");

            string situacaoFinal = DeterminarSituacaoFinalDoAluno(
                mediaFinal,
                faltas
            );

            _disciplinas.Add(
                new Disciplina(
                    codigo,
                    nome,
                    nota1,
                    nota2,
                    notaSubstitutiva,
                    mediaFinal,
                    faltas,
                    situacaoFinal
                )
            );
        }

        private static double CalcularMediaFinal
       
        (

            double nota1,
            double nota2,
            double notaSubstitutiva
        )
        {
            if (notaSubstitutiva > 0)
            {
                double maiorNota = 0;

                if (nota1 > nota2)
                    maiorNota = nota1;

                else if (nota2 > nota1)
                    maiorNota = nota2;

                else if (nota1 == nota2)
                    maiorNota = nota1;

                return (maiorNota + notaSubstitutiva) / 2;
            }
            else
                return (nota1 + nota2) / 2;
        }

        private static string DeterminarSituacaoFinalDoAluno(
            double mediaFinal,
            int faltas
        )
        {
            int limiteDeFaltas = (_cargaHoraria * 25) / 100;

            if (faltas > limiteDeFaltas && mediaFinal < 6)
                return " REPROVADO POR EXCESSO DE FALTAS E NOTA ABAIXO DA MÉDIA";

            else if (faltas > limiteDeFaltas)
                return "REPROVADO POR EXCESSO DE FALTAS";

            else if (mediaFinal >= 6)
                return "APROVADO";

            else
                return "REPROVADO POR NOTA ABAIXO DA MÉDIA";
        }

        private static int LerValorInteiro(string mensagem)
        {
            do
            {
                try
                {
                    Console.Write(mensagem);
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\n DIGITO INVALIDO " );
                    MensagemParaContinuar();
                }
            } while (true);
        }

        private static double LerValorDouble(string mensagem)
        {
            do
            {
                try
                {
                    Console.Write(mensagem);
                    double numero = double.Parse(Console.ReadLine());

                    if (numero >= 0 && numero <= 10)
                        return numero;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("\n DIGITO INVALIDO ");
                    MensagemParaContinuar();
                }
            } while (true);
        }

        private static void MensagemParaContinuar()
        {
            Console.WriteLine( " \n DIGITE QUALQUER TECLA PARA CONTINUAR" );
            Console.ReadKey();
            Console.Clear();
        }
    }
}

