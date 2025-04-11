# DIO.Series - Gerenciador de Séries

Este projeto é uma aplicação de console desenvolvida em C# como parte do **bootcamp da Digital Innovation One (DIO)**. Ele permite gerenciar um catálogo de séries, incluindo funcionalidades como listar, inserir, atualizar, excluir e visualizar séries. O código foi evoluído para seguir boas práticas de programação, como separação de responsabilidades, uso de serviços e utilitários, e implementação de um sistema de logging.

---

## 🚀 Funcionalidades

- **Listar Séries**: Exibe todas as séries cadastradas no sistema.
- **Inserir Série**: Permite adicionar uma nova série ao catálogo.
- **Atualizar Série**: Atualiza os dados de uma série existente.
- **Excluir Série**: Marca uma série como excluída.
- **Visualizar Série**: Exibe os detalhes de uma série específica.
- **Sistema de Logs**: Registra eventos e erros em um arquivo de log para facilitar a depuração.

---

## 🛠️ Melhorias Implementadas

### 1. **Separação de Responsabilidades**

- O código foi refatorado para seguir o princípio de **responsabilidade única**:
  - A lógica de interação com o usuário foi movida para a classe `Menu`.
  - A lógica de manipulação de séries foi centralizada na classe `SerieService`.
  - Métodos auxiliares, como leitura de entradas do usuário, foram movidos para a classe `ConsoleHelper`.

### 2. **Sistema de Logging**

- Foi implementada a classe `Logger`, que registra eventos e erros em um arquivo de log localizado em:

  ```
  %AppData%\DIO.Series\logs.txt
  ```

- O sistema de logs utiliza níveis como `INFO`, `WARNING` e `ERROR` para categorizar as mensagens.

### 3. **Validação de Dados**

- Adicionadas validações para evitar erros ao acessar índices inválidos ou ao inserir dados incorretos.
- Exemplo: O método `ReturnById` na classe `SerieRepository` lança uma exceção caso o ID seja inválido.

### 4. **Boas Práticas no Program.cs**

- O arquivo `Program.cs` foi simplificado para delegar responsabilidades à classe `Menu`, mantendo o ponto de entrada da aplicação limpo e organizado.

### 5. **Estrutura do Projeto**

- O projeto foi reorganizado em pastas para melhorar a legibilidade:
  - **Classes**: Contém as classes principais, como `Serie` e `SerieRepository`.
  - **Enum**: Contém o enum `Genre`, que define os gêneros das séries.
  - **Interfaces**: Contém a interface `IRepository`, que define o contrato para o repositório.
  - **Services**: Contém a lógica de negócios na classe `SerieService`.
  - **Utils**: Contém utilitários como `ConsoleHelper` e `Menu`.

---

## 📂 Estrutura do Projeto

```
DIO.Series/
├── Classes/
│   ├── BaseEntity.cs
│   ├── Logger.cs
│   ├── Serie.cs
│   ├── SerieRepository.cs
├── Enum/
│   ├── Genre.cs
├── Interfaces/
│   ├── IRepository.cs
├── Services/
│   ├── SerieService.cs
├── Utils/
│   ├── ConsoleHelper.cs
│   ├── Menu.cs
├── Program.cs
├── DIO.Series.csproj
```

---

## 🖥️ Como Executar o Projeto

### Pré-requisitos

- .NET 9.0 ou superior instalado na máquina.

### Passos

1. Clone o repositório:

   ```bash
   git clone https://github.com/fellipedoprado/dio-dotnet-poo-lab-2.git
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd dio-dotnet-poo-lab-2/DIO.Series
   ```

3. Restaure as dependências (se necessário):

   ```bash
   dotnet restore
   ```

4. Execute o projeto:

   ```bash
   dotnet run
   ```

---

## 📝 Exemplos de Uso

### Inserir uma Nova Série

1. Escolha a opção `2` no menu principal.
2. Insira os dados solicitados, como gênero, título, ano e descrição.
3. A série será adicionada ao catálogo.

### Listar Séries

1. Escolha a opção `1` no menu principal.
2. Todas as séries cadastradas serão exibidas, incluindo as marcadas como excluídas.

### Excluir uma Série

1. Escolha a opção `4` no menu principal.
2. Insira o ID da série que deseja excluir.
3. A série será marcada como excluída.

---

## 📄 Logs

Os logs são gerados automaticamente e podem ser encontrados no seguinte caminho:

- **Windows**: `%AppData%\DIO.Series\logs.txt`
- **Linux/Mac**: `~/.DIO.Series/logs.txt`

Exemplo de log:

```
2025-04-10 14:30:00 [INFO] Aplicação iniciada.
2025-04-10 14:31:00 [INFO] Série inserida com sucesso: Título Breaking Bad
2025-04-10 14:32:00 [ERROR] Erro ao atualizar série: ID inválido.
```

---

## 📚 Tecnologias Utilizadas

- **C#**
- **.NET 9.0**

---

## 📦 Próximos Passos

- Implementar testes unitários para validar as funcionalidades.
- Adicionar suporte a persistência de dados (ex.: salvar séries em um banco de dados ou arquivo).
- Melhorar a interface do usuário com menus mais interativos.

---

## 🧑‍💻 Autor

- **Fellipe Prado**  
  [GitHub](https://github.com/fellipedoprado)

---

Com este README, o projeto está bem documentado e reflete as melhorias implementadas, além de fornecer instruções claras para uso e contribuição.
