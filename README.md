# RestauRank - Challenge #2

Stack: 

- **Backend:** .NET Code (com EF Core) com SOLID design
- **Frontend:** ReactJS com Material UI

Solicitante: DB Server

Andamento:

- [x]  DB
- [x]  Design Pattern ([https://whimsical.com/UbAWJi6t3AL5QQWuHiK3C7#7YNFXnKbYihZJPEcj5zeK](https://whimsical.com/UbAWJi6t3AL5QQWuHiK3C7#7YNFXnKbYihZJPEcj5zeK))
- [x]  Backend ([https://github.com/atreib/restaurank.api](https://github.com/atreib/restaurank.api))
    - Ver mais
        - [x]  SOLID structure
        - [x]  AuthController
        - [x]  VoteController
        - [x]  RestaurantController
- [x]  Logo
- [x]  Esquema de cores (Cor base: #FF2B2B)
- [x]  Frontend ([https://github.com/atreib/restaurank.app](https://github.com/atreib/restaurank.app))
    - Ver mais
        - [x]  Layout
        - [x]  Login
        - [x]  Resultado
        - [x]  Votar
- [x]  Readme
    - Ver mais
        - [x]  Requisitos de ambiente necessários para compilar e rodar o software
        - [x]  Instruções de como utilizar o sistema.
        - [x]  O que vale destacar no código implementado?
        - [x]  O que poderia ser feito para melhorar o sistema?

## Stories:

> **Estória 1**
Eu como profissional faminto
Quero votar no meu restaurante favorito
Para que eu consiga democraticamente levar meus colegas a comer onde eu
gosto.
*Critério de Aceitação: Um profissional só pode votar em um restaurante por dia.*

> **Estória 2**
Eu como facilitador do processo de votação
Quero que um restaurante não possa ser repetido durante a semana
Para que não precise ouvir reclamações infinitas!
*Critério de Aceitação: O mesmo restaurante não pode ser escolhido mais de uma vez durante a semana.*

> **Estória 3**
Eu como profissional faminto
Quero saber antes do meio dia qual foi o restaurante escolhido
Para que eu possa me despir de preconceitos e preparar o psicológico.
*Critério de Aceitação: Mostrar de alguma forma o resultado da votação.*

# Design pattern do Backend:

![RestauRank%20Challenge%202%20e923b736428e41a4a8142141e96c9a88/DBServer_-_Desafio2x_(4).png](RestauRank%20Challenge%202%20e923b736428e41a4a8142141e96c9a88/DBServer_-_Desafio2x_(4).png)

## Rodando o projeto:

- *Se for desenvolver/codar:* Instalar o VS Code ([https://code.visualstudio.com/download](https://code.visualstudio.com/download))
- Instalar o Git ([https://git-scm.com/downloads](https://git-scm.com/downloads))
- Instalar o .NET Core SDK 2.2 ([https://dotnet.microsoft.com/download/dotnet-core/2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2))
- Dar um `git clone` no projeto da API
- Acessar a pasta do projeto da API
- Rodar `dotnet build` e `dotnet run` para iniciar a API (como o banco está em memória, não precisamos instalar o banco de dados)
- Instalar o NPM ([https://www.npmjs.com/](https://www.npmjs.com/))
- Instalar o Yarn ([https://yarnpkg.com/](https://yarnpkg.com/))
- Dar um `git clone` no projeto do front
- Acessar a pasta do projeto do front
- Rodar `npm install` e `yarn start` para iniciar a aplicação
- Usuário da API: `andre` e `teste`
- Senha dos usuários da API: `123456`
- **ATENÇÃO:** Como o banco está em memória, a cada execução da API, se perderá todos os dados. Para testar diferentes cenários, basta modificar as informações inseridas no banco através do código da API.

## Extensões:

• BCrypt.Net-Core 1.6.0: [https://www.nuget.org/packages/BCrypt.Net-Core/](https://www.nuget.org/packages/BCrypt.Net-Core/)

> `dotnet add package BCrypt.Net-Core --version 1.6.0`

• Swashbuckle.AspNetCore 5.4.1: [https://www.nuget.org/packages/Swashbuckle.AspNetCore/](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)

> `dotnet add package Swashbuckle.AspNetCore --version 5.4.1`

• Swashbuckle.AspNetCore.Newtonsoft 5.4.1: [https://www.nuget.org/packages/Swash](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)

> `dotnet add package Swashbuckle.AspNetCore.Newtonsoft --version 5.4.1`

# O que vale destacar no código implementado?

1. Injeção de dependência e independência dos módulos/serviços: Com o SOLID pattern, temos independência nos módulos, logo, facilidade na manutenção e melhorias dos módulos, diminuindo o impacto na integração entre os serviços do projeto. O mesmo vale para a injeção de dependência, que facilita a possibilidade de ter upgrade ou downgrade de versão, além de mudança de módulos externos.
2. Código padronizado em inglês: Com a padronização do código, em inglês, temos uma facilidade no aprendizado de manutenção no projeto.
3. Baixo uso de bibliotecas externas: Dentro do backend, temos apenas 3 bibliotecas externas sendo utilizadas (*BCrypt*, usado para *hashear* a senha, e 2 para o *Swashbuckle*, sendo o Swagger para a documentação da nossa API e a implementação de suporte à biblioteca *Newtonsoft JSON*).

**Regras:**

- Votação sempre para o restaurante de amanhã ✅
- Consigo ver o resultado do restaurante de HOJE ✅
- Na hora de buscar o restaurante escolhido pro dia, verificar se ele já não foi "essa semana" (Se foi pega o segundo lugar) ✅

# O que poderia ser feito para melhorar o sistema?

O primeiro passo que eu faria seria transformar o sistema em um produto. Isto é, criar uma estrutura para que cada empresa possua os seus funcionários e as suas votações.

Uma segunda melhoria seria apresentar o número de votos por restaurante (porém, me agrada a proposta da aplicação ser básica e simples de usar).
