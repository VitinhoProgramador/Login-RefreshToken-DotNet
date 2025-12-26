# APIrest: Sistema de Autenticação e Perfil de Usuário em ASP.NET Core

## 🚀 Visão Geral do Projeto

O **APIrest** é uma robusta API RESTful desenvolvida em **ASP.NET Core** (C#) focada em fornecer um sistema completo de **autenticação** e **gestão de perfis de usuário**. Utilizando o padrão JWT (JSON Web Tokens) para segurança e PostgreSQL como banco de dados, esta API é a base ideal para qualquer aplicação que necessite de um controle de acesso seguro e um modelo de usuário rico em detalhes.

## ✨ Funcionalidades Principais

- **Autenticação Segura (JWT):** Implementação de JSON Web Tokens para proteger os endpoints da API.

- **Registro e Login de Usuários:** Endpoints dedicados para criação de novas contas e autenticação.

- **Refresh Token:** Suporte a *refresh tokens* para manter sessões de usuário ativas de forma segura.

- **Gestão de Perfis:** Modelo de usuário detalhado, incluindo campos para `TrusScore`, `XpTotal`, `NivelAtual` e `Cargo` (Enum: `Usuario`, `Administrador`, `SuperAdministrador`).

- **Persistência de Dados:** Utiliza **PostgreSQL** como banco de dados, gerenciado pelo Entity Framework Core.

- **Documentação Interativa:** Configuração com Swagger/OpenAPI para testar e visualizar os endpoints facilmente.

## 🛠️ Tecnologias Utilizadas

| Categoria | Tecnologia | Descrição |
| --- | --- | --- |
| **Backend** | ASP.NET Core Web API (C#) | Framework principal para construção da API. |
| **Banco de Dados** | PostgreSQL | Sistema de gerenciamento de banco de dados relacional. |
| **ORM** | Entity Framework Core (EF Core) | Mapeamento Objeto-Relacional para interagir com o PostgreSQL. |
| **Segurança** | JWT Bearer Authentication | Padrão de token para autenticação sem estado. |
| **Documentação** | Swagger/OpenAPI | Geração de documentação interativa para a API. |

## ⚙️ Pré-requisitos

Para rodar este projeto localmente, você precisará ter instalado:

- [.NET SDK](https://dotnet.microsoft.com/download) (Versão 8.0 ou superior)

- [PostgreSQL](https://www.postgresql.org/download/)

- Um cliente de banco de dados (ex: pgAdmin, DBeaver)

## 🚀 Configuração e Instalação

Siga os passos abaixo para configurar e executar a API em sua máquina local.

### 1. Clonar o Repositório

```bash
git clone <URL_DO_SEU_REPOSITORIO>
cd APIrest
```

### 2. Configurar o Banco de Dados

1. Certifique-se de que o seu servidor PostgreSQL está em execução.

1. Crie um banco de dados com o nome `APIrest`.

1. Atualize a *connection string* no arquivo `appsettings.json` se necessário. A configuração padrão é:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=APIrest;Username=postgres;Password=9476;"
   }
   ```

### 3. Aplicar Migrations

Utilize o Entity Framework Core para aplicar as migrações e criar o esquema do banco de dados:

```bash
dotnet ef database update
```

### 4. Configurar o Token JWT

Altere a chave secreta do JWT no arquivo `appsettings.json` para uma string mais segura e complexa:

```json
"AppSettings": {
  "Token": "SUA_CHAVE_SECRETA_MUITO_FORTE_AQUI"
}
```

### 5. Executar a Aplicação

Execute o projeto a partir da linha de comando:

```bash
dotnet run
```

A API estará acessível em `https://localhost:<PORTA_DO_PROJETO>` (a porta padrão é configurada no `launchSettings.json` ).

## 🔑 Endpoints da API

A documentação completa dos endpoints está disponível no Swagger após a execução da aplicação.

| Método | Endpoint | Descrição | Requer Autenticação |
| --- | --- | --- | --- |
| `POST` | `/api/Auth/register` | Cria um novo usuário no sistema. | Não |
| `POST` | `/api/Auth/login` | Autentica o usuário e retorna um JWT. | Não |
| `GET` | `/api/Usuario` | Exemplo de endpoint protegido que retorna uma mensagem de sucesso. | Sim |



