using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCWebAPI.Models;

namespace PoCWebAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private EscolaContext escola = new EscolaContext();
        

        [HttpGet]
        public Aluno[] AcessarAluno()
        {
            return escola.Alunos.ToArray();
        }

        [HttpGet("{Id}")]
        public Aluno AcessarAlunoId(int Id)
        {
            Aluno Resultado = new Aluno();
            foreach (Aluno aluno in escola.Alunos)
            {
                if (aluno.Id == Id)
                {
                    Resultado = aluno;
                }
            }
            return Resultado;
        }

        [HttpPost]
        public Aluno AdicionarAlunoId(Aluno novoAluno)
        {
            escola.Alunos.Add(novoAluno);
            escola.SaveChanges();
            return novoAluno;
        }


        [HttpDelete("{Id}")]
        public Aluno DeletarAlunoId(int Id)
        {
            Aluno AlunoDeletado = new Aluno();

            foreach(Aluno aluno in escola.Alunos)
            {
                if(aluno.Id == Id)
                {
                    AlunoDeletado = aluno;
                    escola.Alunos.Remove(AlunoDeletado);
                    escola.SaveChanges();
                }

            }
            return AlunoDeletado;
        }

        
        

    }

}
