+Aplicativo de quiz para Windows Forms (.NET Framework 4.7.2) que carrega perguntas e opções de resposta a partir de um banco MySQL e apresenta feedback imediato sobre a alternativa escolhida.
+
+## Funcionalidades
+- Carregamento das perguntas e respectivas opções via `QuizController`, que consulta os DAOs e vincula as alternativas a cada pergunta antes de iniciar o jogo.
+- Interface `Frmquiz` embaralha perguntas/opções, controla cliques dos botões, contabiliza a pontuação e avança automaticamente para a próxima questão após um intervalo de 1 segundo.
+- Persistência em MySQL por meio de classes DAO (`PerguntaDAO` e `OpcaoDAO`) que executam consultas parametrizadas utilizando a conexão singleton de `Conexao`.
+
+## Estrutura do projeto
+```
+QuizApp/
+├── Controller/      # Controlador principal do quiz
+├── Database/        # Gerenciamento da conexão MySQL
+├── Model/           # Modelos e DAOs das entidades do quiz
+├── View/            # Formulário Windows Forms e recursos associados
+├── QuizApp.csproj   # Projeto alvo .NET Framework 4.7.2
+└── packages/        # Dependências NuGet restauradas
+```
+
+## Pré-requisitos
+- Visual Studio 2019 ou superior com suporte ao .NET Framework 4.7.2.
+- Servidor MySQL 5.7+ ou MariaDB compatível.
+- Pacotes NuGet restaurados (serão baixados automaticamente ao abrir a solução se o `packages` não estiver presente).
+
+## Configuração do banco de dados
+1. Crie o banco de dados e tabelas esperadas pelo aplicativo:
+
+```sql
+CREATE DATABASE quizapp CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
+USE quizapp;
+
+CREATE TABLE perguntas (
+    id BIGINT AUTO_INCREMENT PRIMARY KEY,
+    texto VARCHAR(255) NOT NULL
+);
+
+CREATE TABLE opcoes (
+    id BIGINT AUTO_INCREMENT PRIMARY KEY,
+    texto VARCHAR(255) NOT NULL,
+    correta TINYINT(1) NOT NULL,
+    id_pergunta BIGINT NOT NULL,
+    CONSTRAINT fk_opcoes_perguntas FOREIGN KEY (id_pergunta) REFERENCES perguntas(id)
+);
+```
+
+2. Insira perguntas e quatro alternativas (apenas uma marcada como correta) para cada registro em `perguntas`.
+
+## App.config
+Crie um arquivo `App.config` na raiz do projeto (o `.csproj` já faz referência a ele) com a string de conexão `QuizDB` apontando para o banco criado. Ajuste `server`, `uid`, `pwd` e `database` conforme o seu ambiente:
+
+```xml
+<?xml version="1.0" encoding="utf-8"?>
+<configuration>
+  <connectionStrings>
+    <add name="QuizDB"
+         connectionString="server=localhost;uid=seu_usuario;pwd=sua_senha;database=quizapp;SslMode=None;Charset=utf8mb4" />
+  </connectionStrings>
+</configuration>
+```
+
+## Como executar
+1. Abra `QuizApp.sln` no Visual Studio.
+2. Garanta que o projeto `QuizApp` esteja como **Set as Startup Project**.
+3. Compile e execute (F5). A aplicação mostrará um alerta com o número de perguntas carregadas do banco e iniciará o quiz na tela principal.
+
+## Próximos passos sugeridos
+- Adicionar validações para lidar com perguntas com quantidade variável de opções e melhorar mensagens de erro na interface.
+- Versionar scripts SQL com dados de exemplo e considerar reduzir dependências NuGet não utilizadas no `.csproj`.
+- Implementar telas de administração para cadastro/edição de perguntas diretamente na aplicação. 
EOF
)
