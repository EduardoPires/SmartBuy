# 🛒 SmartBuy - Aplicação de E-commerce com MVC e API RESTful

## 📌 Apresentação

Bem-vindo ao repositório do **SmartBuy**!  
Este projeto é uma entrega do **MBA DevXpert Full Stack .NET**, referente ao módulo **Introdução ao Desenvolvimento ASP.NET Core**.

O principal objetivo é desenvolver uma aplicação de e-commerce que permite aos usuários **criar, editar, visualizar e excluir categorias e produtos**, tanto por meio de uma **interface web (MVC)** quanto via **API RESTful**.

### 👤 Autor(a)
- Chayene Freitas

---

## 🎯 Proposta do Projeto

O projeto consiste em:

- 🔹 **Aplicação MVC**: Interface web para interação com o e-commerce.
- 🔹 **API RESTful**: Exposição dos recursos do sistema para integração com outras aplicações ou front-ends alternativos.
- 🔹 **Autenticação e Autorização**: Controle de acesso com diferenciação entre administradores e usuários comuns.
- 🔹 **Acesso a Dados**: Utilização de ORM para comunicação com o banco de dados.

---

## 💻 Tecnologias Utilizadas

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core MVC
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token)
- **Front-end:**
  - Razor Pages/Views
  - HTML/CSS
- **Documentação da API:** Swagger

---

## 📁 Estrutura do Projeto

```bash

src/SmartBuy/
├── SmartBuy.Gestao/            # Projeto MVC
├── SmartBuy.Api/               # Projeto da API RESTful
├── SmartBuy.Infrastructure/    # Camada de Dados
├── SmartBuy.Core/              # Camada compartilhada / Entities / Interfaces
├── README.md                   # Documentação do projeto
├── FEEDBACK.md                 # Feedbacks do instrutor
└── .gitignore                  # Padrões de exclusão do Git
```

---

## ✅ Funcionalidades Implementadas

- 📝 **CRUD de Posts e Comentários**
- 🔐 **Autenticação e Autorização com níveis de acesso**
- 🔗 **API RESTful para operações CRUD**
- 📄 **Documentação automática com Swagger**

---

## 🚀 Como Executar o Projeto

### 🔧 Pré-requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/)
- [SQL Server ou SQLite](https://www.microsoft.com/pt-br/sql-server/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [Git](https://git-scm.com/)

### 📥 Passos para Execução

1. **Clone o Repositório**

```bash
git clone https://github.com/chayenefreitas/SmartBuy.git
cd SmartBuy
```

2. **Configure o Banco de Dados**

- Edite o arquivo `appsettings.json` com a sua string de conexão do SQL Server.
- O projeto possui os arquivos do banco de dados SQLite pré-populado com as seguintes definição:
    - Usuarios:
      *email: usuario01@mail.com / senha: Usuario01*
      *email: usuario02@mail.com / senha: Usuario02*
    -Categorias e produtos.
      

3. **Execute a Aplicação MVC**

```bash
cd src/SmartBuy/SmartBuy.Gestao/
dotnet run
```
Acesse em: [http://localhost:7224](http://localhost:7224)

4. **Execute a API**

```bash
cd src/SmartBuy/SmartBuy.Api/
dotnet run
```
Acesse a documentação da API em: [http://localhost:7224/swagger/index.html](https://localhost:7224/swagger/index.html)

---

## ⚙️ Instruções de Configuração

- As chaves JWT estão configuradas no `appsettings.json`.
- As migrações são gerenciadas via Entity Framework Core.
  - **Obs.:** Não é necessário aplicar as migrações manualmente, pois a configuração inicial já faz isso via *Seed*.

---

## 📚 Documentação da API

A documentação da API está disponível via **Swagger**.  
Após iniciar a API, acesse:

📎 [http://localhost:7224/swagger/index.html](http://localhost:7224/swagger/index.html)

---

## 📌 Avaliação

- Este projeto é parte de um curso acadêmico e **não aceita contribuições externas**.
- Para dúvidas ou sugestões, utilize a aba de **Issues**.
- O arquivo `FEEDBACK.md` resume as avaliações do instrutor e **deve ser editado apenas por ele**.
