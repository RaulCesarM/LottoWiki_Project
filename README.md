# LottoWiki

Este é o README.md para o projeto LottoWiki.

## Instruções para Gerar Migrações e Atualizar o Banco de Dados

Para gerar migrações e atualizar o banco de dados, siga os passos abaixo:

## Gerar Migrações

1. Certifique-se de estar no diretório raiz da solução do seu projeto.

2. Execute o seguinte comando no terminal:

```bash
dotnet ef migrations add Name --project LottoWiki.Data/LottoWiki.Data.csproj --startup-project LottoWiki.Api/LottoWiki.Api.csproj
```


### Atualizar o Banco de Dados
1. Certifique-se de estar no diretório da API do seu projeto.

2. Execute o seguinte comando no terminal:

```bash
dotnet ef database update

```
