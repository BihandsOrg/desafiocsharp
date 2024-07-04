## Desafio para Back-end Developer na DoroTech - C# .NET

#### Requisitos Gerais:

Uma livraria da cidade teve um aumento no número de seus exemplares e está com um problema para identificar todos os livros que possui em estoque. 
Para ajudar a livraria foi solicitado a você desenvolver uma aplicação web para gerenciar estes exemplares. Requisitos:


* O sistema deverá mostrar todos os livros cadastrados ordenados de forma ascendente pelo nome.
* Ao persistir, validar se o livro já foi cadastrado.
* O sistema deverá permitir consultar, criar, editar e excluir um livro.
* Os livros devem ser persistidos em um banco de dados.
* Criar algum mecanismo de log de registro e de erro.

#### Requisitos Técnicos:

* Configurar o Swagger na aplicação (fundamental), pois será usado para testes.
* Incluir mecanismo de autenticação no Swagger, usando Token JWT (Bearer).
* Para a persistência dos dados deve ser utilizado o Entity Framework.
* Como banco de dados, pode ser usado MySQL, PostgreSQL ou SQL Server.
* Utilizar migrations ou Gerar Scripts e disponibilizá-los um uma pasta.
* Incluir git.ignore no repositório para não subir arquivos de compilação.


#### Observações:
* O sistema deverá ser desenvolvido na plataforma .NET com C#.
	(preferêncialmente 5.0+, caso for usado outra versão, informar no pull-request)
* Deve conter autenticação com dois níveis de acesso, um administrador e um público, o usuário de nível 
	público não terá autenticação, ou seja, terá acesso livre a consulta de livros
* Atenção aos princípio do SOLID.
* Não é necessária a criação de front-end, o teste será feito pelo Swagger UI.

#### Diferenciais do desafio:
* Aplicação das boas práticas do DDD, TDD, Design Patterns, SOLID e Clean Code.
* A modelagem dos dados não será fornecida, de propósito. Desejamos avaliar a sua capacidade de abstração.
* A API deverá realizar tratamento de entrada de dados e retornar códigos de erro quando aplicáveis.
* Criar massa de dados para que seja possível verificar o funcionamento das lógicas propostas.
* Incluir parâmetros de paginação e campos de filtro nos métodos de consulta (GET).
* Documentar, via código-fonte, os campos, parâmetros e dados de retorno da API para exibição no Swagger.


## Como deverá ser entregue:

    1. Faça um fork deste repositório;
    2. Realize o teste;
    3. Adicione seu currículo na raiz do repositório;
    4. Envie-nos o PULL-REQUEST para que seja avaliado.

