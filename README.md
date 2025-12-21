# 🛡️ API Auth Boilerplate - .NET 8/9

Este projeto é um modelo (boilerplate) profissional de **Autenticação e Autorização** desenvolvido em ASP.NET Core. Ele foi extraído do ecossistema do projeto "Cidade Alerta" para servir como uma base sólida e reutilizável para qualquer API que necessite de segurança robusta.

## 🚀 Funcionalidades

- **Registro de Usuários:** Com validação de duplicidade e armazenamento seguro.
- **Segurança de Senhas:** Implementação de `HMACSHA512` com geração de **Salt** e **Hash** únicos por usuário.
- **Autenticação JWT:** Emissão de tokens seguros para acesso a rotas protegidas.
- **Refresh Token:** Sistema de renovação de acesso para melhor experiência do usuário (UX) e segurança.


## 🏗️ Arquitetura

O projeto utiliza o padrão de **Camadas (Service Pattern)** para promover o baixo acoplamento:

1. **Controllers:** Gerenciam as rotas e entradas da API.
2. **Services:** Onde reside a lógica de negócio e as regras de segurança/criptografia.
3. **Models & DTOs:** Definição da estrutura de dados e objetos de transferência seguros.
4. **Data (EF Core):** Camada de persistência utilizando PostgreSQL.



## 🛠️ Tecnologias Utilizadas

- ASP.NET Core API
- Entity Framework Core
- PostgreSQL
- JWT (JSON Web Tokens)
- Swagger (Documentação)

## 📖 Como Rodar o Projeto

1. **Configurar o Banco:** Altere a `DefaultConnection` no arquivo `appsettings.json`.
2. **Migrations:** No terminal, execute:
   ```bash
   dotnet ef database update
