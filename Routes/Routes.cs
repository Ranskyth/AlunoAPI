using AlunoAPI.controllers;

namespace AlunoAPI.Routes
{
    public static class Routes
    {
        public static void Route(this WebApplication app)
        {
            var groupRoutes = app.MapGroup("/api/v1");
            groupRoutes.MapPost("/aluno", AlunoController.PostAluno);
            groupRoutes.MapGet("/aluno", AlunoController.GetAluno);
            groupRoutes.MapGet("/aluno/{id}/id", AlunoController.GetAlunoId);
            groupRoutes.MapGet("/aluno/{nome}/nome",AlunoController.GetAlunoNome);
            groupRoutes.MapPut("/aluno/{id}/id",AlunoController.PutAlunoId);
            groupRoutes.MapDelete("/aluno/{id}/id", AlunoController.DeleteAlunoId);
        }
    }
}