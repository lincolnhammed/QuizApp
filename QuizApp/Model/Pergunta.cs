using System;
using System.Collections.Generic;


namespace QuizApp.Model
{
    public class Pergunta
    {

        public long Id { get; set; }
        public String texto { get; set; }
        public List<Opcao> opcoes { get; set; }
       

        public Pergunta()
        {
            opcoes = new List<Opcao>();
        }
    }
}
