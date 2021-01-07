# ApiParticipacaoLucros

Para essa solução, utilizei o [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1), apliquei também o [Swagger](https://swagger.io/) para facilitar a utilização e documentação.

Abaixo coloquei o passo a passo para teste, aproveite:
- Verifique se o banco está vazio, executando o GET ObterTodos
- Fique a vontade, pode deletar todos executando o DELETE DeletarTodos
- Pronto, banco zerado ;)
- Realize o insert, para isso basta copiar os dados do txt "ApiParticipacaoLucros/jsonDados.txt", cole essas infos no POST InserirInformacoes
- Agora a base já está alimentada!
- Execute GET por matricula através do ObterPorMatricula, coloque qualquer uma que tenha inserido. Exemplo: 0005253
- Execute PUT para atualizar o funcionário AtualizarFuncionario, altere o funcionário que desejar
- Execute o DELETE para retirar um funcionário da base DeletarFuncionarioPorMatricula

Pronto, agora você já testou tudo sobre os funcionários!

Hora de calcular a PLR $$
- Execute o GET Distribuicao/ObterDistribuicaoLucros, e passe um valor (seja generoso haha)

Para rodar os testes, troque a conexão no FirebaseContext.

- [x] Código no GitHub
- [x] .Net Core
- [x] RestFull API
- [x] Testes com XUnit
- [x] Firebase
