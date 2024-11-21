# Countries Memory Cache Api

https://countrylayer.com/

* `appsettings.json` (configurações padrão)
* `appsettings.Development.json` (configurações específicas para desenvolvimento)
* `appsettings.Production.json` (configurações específicas para produção)

## Pacotes do Projeto

- `Microsoft.Extensions.Caching.Memory`
- `Microsoft.Extensions.Configuration`
- `RestSharp`
- `System.Text.Json`

## Variáveis de Ambiente

CMD para setar variável de ambiente

```bash
set API_KEY=suachave
```

```json
{
  "ApiSettings": {
    "ApiKey": "${API_KEY}"
  }
}
```

Usar um Gerenciador de Segredos (Alternativa)

```bash
dotnet user-secrets init
dotnet user-secrets set "ApiSettings
```

## Configuração

```csharp
builder.Configuration.AddUserSecrets<Program>();
string apiKey = builder.Configuration["ApiSettings:ApiKey"];
Console.WriteLine($"API Key: {apiKey}");
```

## Alternativas para Produção
Gerenciadores de Segredos: Use ferramentas como AWS Secrets Manager, Azure Key Vault ou HashiCorp Vault.
Variáveis de Ambiente no Docker ou CI/CD: Configure segredos diretamente no ambiente de execução.


## Vou usar o Secret do Github

* No menu lateral, selecione Secrets and variables > Actions.
* Clique em New repository secret.
* Adicione o nome e o valor do segredo. Exemplo:
Name: API_KEY
Value: sua-chave-super-secreta

Comando onde você vai usar a variável de ambiente

```yaml
- API_KEY: ${{ secrets.API_KEY }}
```


