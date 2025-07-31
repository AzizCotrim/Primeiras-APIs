
# Primeiras APIs

Este repositório contém um projeto de estudo com a criação de APIs REST utilizando **ASP.NET Core**. O projeto simula um sistema de cadastro de Pokémons, onde é possível realizar operações básicas como listar, adicionar, atualizar e excluir Pokémons do banco de dados.

## 📚 Tecnologias Utilizadas

- [.NET 6](https://dotnet.microsoft.com/en-us/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core/web-api/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server/)
- [Visual Studio](https://visualstudio.microsoft.com/)

## 🚀 Como executar o projeto

1. Clone o repositório:
   ````
   git clone https://github.com/AzizCotrim/Primeiras-APIs.git
    ````

2. Abra o projeto no Visual Studio.

3. Restaure os pacotes NuGet (caso necessário):

   * Clique com o botão direito na solução > Restaurar Pacotes

4. Configure a string de conexão no arquivo `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=PokemonDB;Trusted_Connection=True;"
   }
   ```

5. Execute as migrações para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```

6. Inicie a aplicação (F5 ou `dotnet run`)

7. Acesse a documentação Swagger:

   ```
   https://localhost:{porta}/swagger
   ```

## 📌 Funcionalidades

* `GET /api/pokemon` – Lista todos os Pokémons
* `GET /api/pokemon/{id}` – Busca um Pokémon pelo ID
* `POST /api/pokemon` – Adiciona um novo Pokémon
* `PUT /api/pokemon/{id}` – Atualiza um Pokémon existente
* `DELETE /api/pokemon/{id}` – Remove um Pokémon

## 🧠 Objetivo do Projeto

Este projeto tem como objetivo **praticar a criação de APIs RESTful com ASP.NET Core** e entender conceitos como:

* Injeção de dependência
* Padrão REST
* Uso do Entity Framework para persistência de dados
* Boas práticas com controllers e rotas

## 📂 Estrutura do Projeto

```text
├── Controllers/
│   └── PokemonController.cs
├── Data/
│   └── PokemonContext.cs
├── Model/
│   └── Pokemon.cs
├── appsettings.json
└── Program.cs
```

### Desenvolvido por [Aziz Cotrim](https://github.com/AzizCotrim) 👨‍💻
