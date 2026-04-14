# Site da Escola - School Website

## Descrição do Projeto

Website institucional desenvolvido em ASP.NET Core (MVC) para gestão e apresentação de conteúdo de uma escola. O sistema permite a publicação de notícias, eventos, galeria de imagens, sistema de feedback e gestão completa de usuários com diferentes níveis de acesso.

## Tecnologias Utilizadas

| Categoria | Tecnologia |
|-----------|------------|
| **Framework** | ASP.NET Core 8.0 (MVC) |
| **Banco de Dados** | MySQL (via Entity Framework Core + Pomelo) |
| **ORM** | Entity Framework Core 9.0 |
| **Frontend** | Razor Views + HTML/CSS/JS |
| **Autenticação** | Session-based com criptografia JSON |
| **Bibliotecas** | Newtonsoft.Json, Microsoft.AspNet.Mvc |

## Arquitetura do Projeto

### Padrões de Projeto
- **Repository Pattern**: Interfaces e implementações para acesso a dados (`IPostarNoticia`, `IPostarEvento`, `IUsuario`, `IFeedback`)
- **Dependency Injection**: Injeção de dependência nativa do ASP.NET Core
- **MVC (Model-View-Controller)**: Separação clara entre camadas

### Estrutura de Diretórios
```
site_da_escola/
├── Controllers/          # Controladores MVC (7 endpoints)
├── Models/              # Entity Models (6 modelos)
├── Data/                # Contexto do Entity Framework
├── Repositorio/         # Camada de acesso a dados
├── Helper/              # Gerenciamento de sessão
├── filter/              # Filtros de autorização
├── enum/                # Enumerações
├── Views/               # Razor Views (22 páginas)
└── Migrations/          # Migrações do banco de dados
```

## Funcionalidades Principais

### 1. Gestão de Notícias
- Postagem de notícias com imagens
- Listagem de todas as notícias
- Fixação de notícias no topo (máximo 3)
- Exclusão de notícias

### 2. Gestão de Eventos
- Criação de eventos com imagens
- Listagem de eventos
- Sistema de fixação de eventos (máximo 3)
- Exclusão de eventos

### 3. Sistema de Autenticação
- Registro de novos usuários
- Login com validação de email/senha
- Sessão persistente com Session-based auth
- Logout

### 4. Sistema de Feedback
- Usuários logados podem enviar feedback
- Sistema de avaliação por estrelas (1-5)
- Admin pode visualizar e excluir feedbacks

### 5. Painel Admin
- Dashboard com estatísticas (total de eventos, notícias, usuários)
- Gerenciamento completo de usuários (CRUD)
- Postagem de notícias e eventos
- Visualização de todos os feedbacks
- Permissões de acesso restritas

### 6. Páginas Públicas
- Home (com notícias/eventos fixados)
- Galeria de imagens
- Sobre a escola

## Controle de Acesso

| Recurso | Visitante | Usuário | Admin |
|---------|-----------|---------|-------|
| Visualizar Home | ✅ | ✅ | ✅ |
| Login/Registro | ✅ | ❌ | ❌ |
| Enviar Feedback | ❌ | ✅ | ✅ |
| Ver Noticias/Eventos | ✅ | ✅ | ✅ |
| Criar Postagens | ❌ | ❌ | ✅ |
| Gerenciar Usuários | ❌ | ❌ | ✅ |
| Dashboard Admin | ❌ | ❌ | ✅ |

## Modelos de Dados

- **UsuariosModel**: id, nome, email, senha, isAdmin
- **NoticiasModel**: id, titulo, descricao, imagem, dataPostagem
- **EventosModel**: id, titulo, descricao, imagem, dataPostagem
- **FeedbackModel**: id, nome, estrelas, descricao
- **FixadosModel**: id, idEstrangeiro, tipo, titulo, descricao, imagem

## Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- MySQL Server (configurar connectionString em `appsettings.json`)

### Executando o Projeto
```bash
cd site_da_escola
dotnet restore
dotnet build
dotnet run
```

### Configuração do Banco
No arquivo `appsettings.json`, configurar a string de conexão:
```json
"connectionStrings": {
  "DataBase": "Server=localhost;Database=nome_banco;User=usuario;Password=senha;"
}
```

## Autor

Desenvolvido como projeto acadêmico/institucional para apresentar informações da escola de forma dinâmica e moderna.