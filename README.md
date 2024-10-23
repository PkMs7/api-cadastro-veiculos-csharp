# Minimal API para Cadastro de Veículos com Autenticação de Usuário

Esta é uma Minimal API desenvolvida em C# que permite o cadastro de veículos com autenticação de usuário. A API oferece funcionalidades básicas para gerenciar veículos, garantindo que apenas usuários autenticados possam realizar operações de cadastro e gerenciamento.

## Stack

A API é construída utilizando as seguintes tecnologias:

- **C#**: Linguagem de programação principal.
- **PostgreSQL**: Sistema de gerenciamento de banco de dados utilizado para armazenar informações dos usuários e veículos.

## Instalação

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) - Certifique-se de ter o SDK instalado. (Este projeto utiliza a versão 6.0.4)
- [PostgreSQL](https://www.postgresql.org/download/) - Instale o PostgreSQL e configure um banco de dados.

### Passos para Executar

1. **Clone o repositório:**
   ```
   git clone https://github.com/PkMs7/api-cadastro-veiculos-csharp.git

   cd api-cadastro-veiculos-csharp
   ```

2. **Instale as dependências:**

   ```
    dotnet restore

   ```

3. **Configure a conexão com o banco de dados:**

- Abra o arquivo *appsettings.json* e modifique a string de conexão com as credenciais do seu banco

4. **Crie o banco de dados:**

    ```
    dotnet ef database update
    ```
5. **Inicie a aplicação:**

    ```
    dotnet watch run
    ```