using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISCIPLINAS.P1
{
 
    
        internal class Aluno
        {
            public string RA { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
            return

                   $"\n REGISTRO DO ALUNO:" +
                   $"\n Nome: {Nome} | RA: {RA}";
                       
            }
        }
    }




