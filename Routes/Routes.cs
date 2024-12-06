using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunoAPI.context;
using AlunoAPI.models;
using Microsoft.EntityFrameworkCore;

namespace AlunoAPI.Routes
{
    public static class Routes
    {
        public static void Route(this WebApplication app)
        {
            var groupRoutes = app.MapGroup("/api/v1");

            groupRoutes.MapPost("/aluno", (AppContextDB context, AlunoModel aluno) =>
            {
                aluno.Id = Guid.NewGuid();
                context.Alunos.Add(aluno);
                context.SaveChanges();
                return Results.Created($"/Aluno/{aluno.Id}", aluno);
            });

            groupRoutes.MapGet("/aluno", async (AppContextDB context) =>
            {
                List<AlunoModel> Alunos = await context.Alunos.ToListAsync();
                if (Alunos.Count == 0)
                {
                    return Results.NotFound(new {message = "Nenhum aluno encontrado"});
                }
                return Results.Ok(Alunos);
            });

            groupRoutes.MapGet("/aluno/{id}/id",async (AppContextDB context, Guid id)=>{
                var idAluno = context.Alunos.Where(x => x.Id == id);
                if (idAluno == null)
                {
                    return Results.NotFound(new {message = $"Nenhum Aluno encontrado Com O id {id}"});
                }
                return Results.Ok(idAluno);
            });
            groupRoutes.MapGet("/aluno/{nome}/nome",(AppContextDB context, string nome) => {
                var aluno = context.Alunos.Where(x => x.Nome == nome);
                if (aluno == null)
                {
                    return Results.NotFound(new {message = $"Nenhum Aluno encontrado Com O Nome {nome}"});
                }

                return Results.Ok(aluno);
            });

            groupRoutes.MapPut("/aluno/{id}/id",(AppContextDB context, Guid id, AlunoModel aluno) => {
                var alunoUpdate = context.Alunos.Where(x => x.Id == id).FirstOrDefault();
                alunoUpdate.Nome = aluno.Nome;
                alunoUpdate.Email = aluno.Email;
                alunoUpdate.DataNascimento = aluno.DataNascimento;
                alunoUpdate.Telefone = aluno.Telefone;
                alunoUpdate.DataInicioCurso = aluno.DataInicioCurso;
                alunoUpdate.DataFimCurso = aluno.DataFimCurso;
                context.SaveChanges();
                return Results.Json(alunoUpdate);
                

            });

            groupRoutes.MapDelete("/aluno/{id}/id", async (AppContextDB context, Guid id) =>
            {
                var alunodelete = await context.Alunos.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (alunodelete == null)
                {
                    return Results.NotFound(new { message = $"Nenhum Aluno com id {id} foi Encontrado Para Deletar"});
                }
                context.Alunos.Remove(alunodelete);
                context.SaveChanges();
                return Results.NoContent();
            });

            groupRoutes.MapDelete("/aluno/all",async (AppContextDB context)=>{
                context.Alunos.RemoveRange(context.Alunos);

                context.SaveChanges();
                return Results.Json(new { message = "Todos os Alunos foram Deletados" });
            });
        }
    }
}