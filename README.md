
# AlunoAPI

AlunoAPI é uma API para cadastro e gerenciamento de informações de alunos.


## Funcionalidades

- [x]   Cadastro de Aluno
- [x]   Consulta de Aluno Por ID e Nome
- [x]   Atualizar Aluno Pelo ID
- [x]   Deleta Por ID do aluno


## Documentação da API

#### Rota Padrão do Swagger
```
  GET /swagger/index.html
```

#### Retorna todos os Alunos
```
  GET /api/v1/aluno/
```

#### Retorna um Aluno pelo id
```
  GET /api/v1/aluno/{id}/id
```

#### Retorna um Aluno pelo Nome
```
  GET /api/v1/aluno/{nome}/nome
```
#### Criar Um Aluno
```
  POST /api/v1/aluno/
```
#### Atualizar Aluno Pelo id
```
  PUT /api/v1/aluno/{id}/id
```

#### Deleta Aluno Pelo id
```
  DELETE /api/v1/aluno/{id}/id
```

## Rodando localmente

#### Clone o projeto

```bash
  git clone https://github.com/Ranskyth/AlunoAPI
```

#### Entre no diretório do projeto

```bash
  cd AlunoAPI
```

#### Instale as dependências

```bash
  dotnet restore
```

#### Inicia a Aplicação

```bash
  dotnet watch run
```

## Stack utilizada

- Asp.Net Core
- Docker
- Postgres
- Entity Framework Core
- Swagger

