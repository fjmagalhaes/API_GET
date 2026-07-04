# 📚 Chapter Web API

## 📖 Sobre o Projeto

O **Chapter Web API** é uma API REST desenvolvida em **ASP.NET Core 9** utilizando **Entity Framework Core** e **SQL Server** como banco de dados. O projeto foi desenvolvido como atividade prática com o objetivo de aplicar conceitos de:

- Desenvolvimento de APIs RESTful;
- Arquitetura em camadas;
- Injeção de Dependência (Dependency Injection);
- Entity Framework Core;
- Integração com SQL Server;
- Documentação automática utilizando Swagger/OpenAPI.

---

# 🏗 Arquitetura

O projeto foi organizado seguindo uma estrutura simples baseada no padrão Repository.

```
Chapter.WebApi
│
├── Controllers
│   └── LivrosController.cs
│
├── Contexts
│   └── ChapterContext.cs
│
├── Models
│   └── Livro.cs
│
├── Repositories
│   └── LivroRepository.cs
│
├── Program.cs
│
└── appsettings.json
```

---

# 🚀 Tecnologias Utilizadas

- ASP.NET Core 9
- .NET SDK 9
- Entity Framework Core 9
- SQL Server Express
- Swagger / OpenAPI
- Dependency Injection
- Git
- Visual Studio Code
- INSOMNIA

---

# 📦 Pacotes NuGet

Principais dependências utilizadas:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Swashbuckle.AspNetCore

---

# ⚙ Funcionalidades

Atualmente a API disponibiliza:

- Listagem de livros cadastrados
- Integração com banco SQL Server
- Documentação automática via Swagger

Endpoint disponível:

```
GET /api/livros
```

---

# ▶ Como executar

## Clone o projeto

```bash
git clone https://github.com/fjmagalhaes/API_GET.git
```

Entre na pasta

```bash
cd Chapter-WebApi
```

---

## Restaurar dependências

```bash
dotnet restore
```

---

## Compilar

```bash
dotnet build
```

---

## Executar

```bash
dotnet run
```

A aplicação iniciará em:

```
http://localhost:5062
```

Swagger:

```
http://localhost:5062/swagger
```

---

# Banco de Dados

O projeto utiliza SQL Server Express.

Exemplo de String de Conexão:

```csharp
Server=localhost\SQLEXPRESS;
Database=Chapter;
Trusted_Connection=True;
Encrypt=True;
TrustServerCertificate=True;
```

---

# Principais Desafios Encontrados

Durante o desenvolvimento surgiram incompatibilidades entre versões do SDK e das bibliotecas relacionadas ao Swagger/OpenAPI.

O projeto apresentava a exceção:

```
System.Reflection.ReflectionTypeLoadException

Could not load type
Microsoft.OpenApi.Models.OpenApiDocument
```

Essa exceção era causada por conflito entre versões de:

- Microsoft.OpenApi
- Swashbuckle.AspNetCore
- ASP.NET Core
- SDK .NET

Além disso, após a resolução dessa incompatibilidade, ocorreu um erro relacionado à conexão segura com o SQL Server:

```
A cadeia de certificação foi emitida por uma autoridade que não é de confiança.
```

Esse problema foi solucionado ajustando a string de conexão para aceitar certificados locais durante o ambiente de desenvolvimento.

---

# Soluções Aplicadas

Durante o processo foram realizadas as seguintes ações:

- Limpeza completa do cache NuGet
- Atualização das dependências incompatíveis
- Remoção de pacotes conflitantes
- Reinstalação do Swashbuckle
- Atualização do Microsoft.OpenApi
- Revisão do Program.cs
- Revisão das dependências transitivas
- Correção da string de conexão do SQL Server
- Ajuste do Swagger para compatibilidade com .NET 9

---

# Estrutura da API

## Model

```text
Livro
├── Id
├── Titulo
├── QuantidadePaginas
└── Disponivel
```

---

## Repository

Responsável pelo acesso aos dados utilizando Entity Framework.

```csharp
_context.Livros.ToList();
```

---

## Controller

Disponibiliza o endpoint REST:

```
GET /api/livros
```

---

# Injeção de Dependência

Registrada no Program.cs:

```csharp
builder.Services.AddScoped<ChapterContext>();
builder.Services.AddTransient<LivroRepository>();
```

---

# Documentação

Swagger habilitado automaticamente no ambiente Development.

```csharp
builder.Services.AddSwaggerGen();
```

---

# Aprendizados

Durante o desenvolvimento deste projeto foram consolidados conhecimentos sobre:

- APIs REST
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Injeção de Dependência
- Swagger/OpenAPI
- Gerenciamento de dependências NuGet
- Compatibilidade entre versões do SDK
- Resolução de conflitos entre bibliotecas
- Boas práticas na organização de projetos .NET
- INSOMNIA

---

# Autor

Desenvolvido por **Francisco Júnio** como atividade prática de desenvolvimento de APIs utilizando ASP.NET Core e Entity Framework Core.

---

# Licença

Projeto desenvolvido exclusivamente para fins acadêmicos e de aprendizado.