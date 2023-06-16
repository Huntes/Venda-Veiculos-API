# Venda Veiculos

API para vitrine de venda de carros, desenvolvida em .NET 6 e SQL Server como database

<hr />
<h3>Como executar</h3>

Instale o banco SQL Server na máquina que será executado, em seguida pegue o usuário padrão e adicione em appsettings.json na <code>connectionString</code> em <code>Server</code>

Exemplo


<code>"ConnectionStrings": {
    "DefaultConnection": "Server=(SEU SERVIDOR);Database=SellCars;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"},</code>


OBS: Caso esteja utilizando um sistema operacional que não seja o Windows, pode-se utilizar desta connectionString


<code>Server=localhost;Initial Catalog=(SEU SERVIDOR);User Id=(SEU USUARIO);Password=(SUA SENHA);Encrypt=True;Trust Server Certificate=True;</code>
<hr />

<h3>Iniciando banco de dados</h3>

Execute o comando no terminal <code>dotnet ef database update</code> para atualizar o banco com as tabelas

<h3>Requisições API</h3>

Execute o projeto e acesse a rota <code>https://localhost:5000/swagger</code>
