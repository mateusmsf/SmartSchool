using System.Collections.Generic;

namespace SchoolAPIcode.Models
{
    public class Curso
    {
        public Curso()
        {
            
        }

        public Curso(int id, string nome) 
        {
            this.id = id;
            this.nome = nome;
               
        }
        public int id { get; set; }
        public string nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; } 
    }
}