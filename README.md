## Executa o Projeto

```bash
git clone https://github.com/GabrielLimaG3/AlunoAPI.git

cd AlunoAPI

docker compose up -d
sudo chmod 777 ./data
sudo chown 999:999 ./data

dotnet ef migrations add <Name_Migration>
dotnet ef database update
```

## Endpoints

<table align="center" border>
  <tr>
    <th>Method</th>
    <th>Endpoint</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>GET</td>
    <td>/api/v1/alunos</td>
    <td>Returns a list of all alunos</td>
  </tr>
  <tr>
    <td>Delete</td>
    <td>/api/v1/alunos/{nome}/nome</td>
    <td>delete of a specific alunos by nome</td>
  </tr>
  <tr>
    <td>POST</td>
    <td>/api/v1/alunos</td>
    <td>Endpoint to create a new aluno entry</td>
  </tr>
</table>

## Dependencies

<table align="center" border>
  <tr>
    <th>Package</th>
    <th>Version</th>
    <th>Link</th>
  </tr>
  <tr>
    <td>Microsoft.EntityFrameworkCore</td>
    <td>8.0.2</td>
    <td>
      <a
        href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/8.0.2"
        >NuGet</a
      >
    </td>
  </tr>
  <tr>
    <td>Microsoft.EntityFrameworkCore.Design</td>
    <td>8.0.2</td>
    <td>
      <a
        href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/3.1.8"
        >NuGet</a
      >
    </td>
  </tr>
  <tr>
    <td>Npgsql.EntityFrameworkCore.PostgreSQL</td>
    <td>8.0.2</td>
    <td>
      <a
        href="https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/8.0.2"
        >NuGet</a
      >
    </td>
  </tr>
  <tr>
    <td>Microsoft.EntityFrameworkCore.Tools</td>
    <td>8.0.2</td>
    <td>
      <a href="https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/8.0.2">NuGet</a>
    </td>
  </tr>
    <tr>
    <td>Swashbuckle.AspNetCore</td>
    <td>6.6.2</td>
    <td>
      <a href="https://www.nuget.org/packages/Newtonsoft.Json/12.0.2">NuGet</a>
    </td>
  </tr>
    <tr>
    <td>Microsoft.AspNetCore.OpenApi</td>
    <td>8.0.10</td>
    <td>
      <a href="https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/8.0.10">NuGet</a>
    </td>
  </tr>
</table>
