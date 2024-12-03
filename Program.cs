using AlunoAPI.context;
using AlunoAPI.models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppContextDB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Aluno", (AppContextDB context, AlunoModel aluno) => {
    context.Alunos.Add(aluno);
    context.SaveChanges();
    return Results.Created($"/Aluno/{aluno.Id}", aluno);
});

app.MapGet("/Alunos", async (AppContextDB context)=>{
    List<AlunoModel> Alunos = await context.Alunos.ToListAsync();
    return Results.Ok(Alunos);
});

app.MapDelete("/Aluno/{nome}/Nome", async (AppContextDB context, string nome) => {
    var alunodelete = await context.Alunos.Where(x => x.Nome == nome).FirstOrDefaultAsync();
    if(alunodelete == null){
        return Results.NotFound();
    }
    context.Alunos.Remove(alunodelete);
    context.SaveChanges();
    return Results.NoContent();
});

app.Run();