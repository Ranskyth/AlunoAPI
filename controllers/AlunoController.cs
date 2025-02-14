using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunoAPI.context;
using AlunoAPI.models;
using Microsoft.EntityFrameworkCore;

namespace AlunoAPI.controllers
{
    public class AlunoController
    {
        public static IResult PostAluno(AppContextDB context, AlunoModel aluno)
        {
            aluno.Id = Guid.NewGuid();
            context.Alunos.Add(aluno);
            context.SaveChanges();
            return Results.Created($"/Aluno/{aluno.Id}", aluno);
        }
        
        public static async Task<IResult> GetAluno(AppContextDB context)
        {
            List<AlunoModel> Alunos = await context.Alunos.ToListAsync();
            if (Alunos.Count == 0)
            {
                return Results.NotFound(new { message = "Nenhum aluno encontrado" });
            }
            return Results.Ok(Alunos);
        }
        public static IResult GetAlunoId(AppContextDB context, Guid id)
        {
            var idAluno = context.Alunos.Where(x => x.Id == id);
            if (idAluno == null)
            {
                return Results.NotFound(new { message = $"Nenhum Aluno encontrado Com O id {id}" });
            }
            return Results.Ok(idAluno);
        }
        public static IResult GetAlunoNome(AppContextDB context, string nome)
        {
            var aluno = context.Alunos.Where(x => x.Nome == nome);
            if (aluno == null)
            {
                return Results.NotFound(new { message = $"Nenhum Aluno encontrado Com O Nome {nome}" });
            }

            return Results.Ok(aluno);
        }
        public static IResult PutAlunoId(AppContextDB context, Guid id, AlunoModel aluno){
                var alunoUpdate = context.Alunos.Where(x => x.Id == id).FirstOrDefault();
                alunoUpdate.Nome = aluno.Nome;
                alunoUpdate.Email = aluno.Email;
                alunoUpdate.DataNascimento = aluno.DataNascimento;
                alunoUpdate.Telefone = aluno.Telefone;
                alunoUpdate.DataInicioCurso = aluno.DataInicioCurso;
                alunoUpdate.DataFimCurso = aluno.DataFimCurso;
                context.SaveChanges();
                return Results.Json(alunoUpdate);
            }

            public async static Task<IResult> DeleteAlunoId(AppContextDB context, Guid id){
                var alunodelete = await context.Alunos.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (alunodelete == null)
                {
                    return Results.NotFound(new { message = $"Nenhum Aluno com id {id} foi Encontrado Para Deletar"});
                }
                context.Alunos.Remove(alunodelete);
                context.SaveChanges();
                return Results.NoContent();
            }
    }
}