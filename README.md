# LottoWiki

### Instruções Gerais.

### Gerar Migrações (ja possui as migrações)

1. Certifique-se de estar no diretório raiz da solução do seu projeto.
2. Execute o seguinte comando no terminal:
```bash
dotnet ef migrations add Name --project LottoWiki.Data/LottoWiki.Data.csproj --startup-project LottoWiki.Api/LottoWiki.Api.csproj
```

### Atualizar o Banco de Dados (sera necessario)
1. Certifique-se de estar no diretório da API do seu projeto.
2. Execute o seguinte comando no terminal:
```bash
dotnet ef database update
```

### Requerimentos(em breve será contido em imagem docker)
1. version 15.2.10.
2. version Node.js 16.20.2
3. version .NET SDK 8.0
4. SQL SERVER

 Para verificar as versões do angular instaladas, execute o comando:
   ```bash
   ng version
   ```
 Para verificar as versões do node instaladas, execute o comando:
   ```bash
  node -v
   ```
 Para verificar as versões do .net core instaladas, execute o comando:
   ```bash
   dotnet --list-sdks
   ```

### Iniciando o Back-end(em breve sera script)

Navegue até o diretório do projeto.
1. Restaure os pacotes NuGet:
 ```bash
   dotnet restore
   ```
2. Compile o projeto:
 ```bash
  dotnet build
   ```
3. Rode o projeto:
 ```bash
   dotnet run
   ```
### Iniciando o Front-end( sera adicionado a solution)
1. Navege ate a pasta Presentation.
2. Atualize node_modules
 ```bash
   npm install
   ```
3. O front-end pode ser startado pelos seguintes comandos:
 ```bash
  npm start
   ```
ou 
 ```bash
  ng serve-o
   ```














