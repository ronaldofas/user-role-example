# User Access Control

Este projeto é uma aplicação web ASP.NET Core destinada a gerenciar o acesso de usuários com base em roles (perfis) utilizando o Identity Framework da Microsoft. A aplicação permite que diferentes usuários acessem páginas específicas com base nas suas roles, como Admin, User e EspecialUser. Os dados são persistidos em um banco de dados SQLite usando o Entity Framework Core.

## Propósito do Projeto

O objetivo deste projeto é demonstrar como configurar e utilizar o ASP.NET Core Identity para gerenciar autenticação e autorização de usuários em uma aplicação web. Os usuários podem ser atribuídos a diferentes roles, e a aplicação redireciona os usuários para páginas específicas com base em suas roles após o login.

## Ferramentas Utilizadas

- **ASP.NET Core 8**: Framework para construir a aplicação web.
- **Entity Framework Core**: ORM (Object-Relational Mapping) para acesso ao banco de dados.
- **SQLite**: Banco de dados relacional leve usado para persistência de dados.
- **ASP.NET Core Identity**: Sistema de autenticação e autorização.
- **Razor Pages**: Para construção das páginas web.
- **Visual Studio / Visual Studio Code**: IDE recomendada para desenvolvimento.

## Como Executar o Projeto

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html)
- Um editor de código como Visual Studio ou Visual Studio Code

### Passos para Execução

1. Clone o repositório do GitHub:
    ```sh
    git clone https://github.com/seu-usuario/user-access-control.git
    cd user-access-control
    ```

2. Restaure as dependências do projeto:
    ```sh
    dotnet restore
    ```

3. Execute as migrações para criar o banco de dados:
    ```sh
    dotnet ef database update
    ```

4. Execute a aplicação:
    ```sh
    dotnet run
    ```

5. Abra o navegador e acesse `https://localhost:5001` (ou o endereço indicado no console).

## Bibliotecas Necessárias

As seguintes bibliotecas são utilizadas no projeto e estão listadas no arquivo `.csproj`:

- `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Sqlite`
- `Microsoft.EntityFrameworkCore.Tools`

### Instalando as Bibliotecas

Estas bibliotecas são restauradas automaticamente ao executar o comando `dotnet restore`. No entanto, você pode instalá-las manualmente usando o seguinte comando:

```sh
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

## Conceito de Acesso Vinculado a Roles

O conceito de acesso vinculado a roles é uma prática comum de segurança em aplicações web onde os usuários são categorizados em diferentes roles (perfis) de acordo com suas permissões. Cada role tem acesso a diferentes partes da aplicação. Neste projeto, três roles são utilizadas:

- **Admin**: Tem acesso total à aplicação e pode gerenciar outros usuários e configurações.
- **User**: Tem acesso a funcionalidades básicas da aplicação.
- **EspecialUser**: Tem acesso a funcionalidades especiais além das disponíveis para um usuário comum.

### Funcionamento

1. **Registro e Login**: Usuários se registram e fazem login na aplicação.
2. **Atribuição de Roles**: Um administrador pode atribuir diferentes roles a usuários.
3. **Autorização**: Com base na role, o usuário é redirecionado para páginas específicas após o login.

A configuração de roles é feita no `Startup.cs` (ou `Program.cs` em ASP.NET Core 8) e a verificação de roles é realizada nos controladores e páginas usando atributos como `[Authorize(Roles = "Admin")]`.

## Estrutura do Projeto

- **Areas**: Contém páginas da aplicação geradas automaticamente pelo aspnet-codegenerator.
- **Controllers**: Contém os controladores para gerenciar as requisições HTTP.
- **Data**: Contém o contexto do banco de dados e inicialização.
- **Migrations**: Classes de migration geradas pelo Entity Framework Core para geração do banco de dados.
- **Models**: Contém as classes de modelo utilizadas pelo Entity Framework.
- **Pages**: Contém as páginas Razor que definem a interface do usuário.

## Contribuição

Se você deseja contribuir com este projeto, por favor, abra um pull request ou reporte um problema na página de issues do repositório.

## Licença

Este projeto é licenciado sob os termos da licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
