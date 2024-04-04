# Sistema de Hotelaria

## Descrição Geral

Este sistema de hotelaria é uma aplicação console C# que gerencia hospedes, suítes, reservas e cadastros dentro de um contexto de hotel, operando inteiramente em memória. Ao encerrar a execução, todos os dados se perdem.

## Classes e Funcionalidades

### `Menu`

Classe responsável por exibir o menu principal do sistema e direcionar para as funções específicas de acordo com a escolha do usuário.

- `public static void ExibirMenu()`: Exibe o menu principal e processa a escolha do usuário.

### `Suite`

Representa uma suíte dentro do hotel.

- Propriedades: `Id`, `Tipo` (enum `TipoSuite`), `Capacidade` (enum `Capacidade`), `ValorDiaria`, `Ocupado`.

### `Reserva`

Representa uma reserva no hotel.

- Propriedades: `Id`, `List<Pessoa> Hospedes`, `Suite suite`, `DiasReservados`.

### `Pessoa`

Representa uma pessoa, seja um hospede ou um funcionário do hotel.

- Propriedades: `Id`, `Nome`, `Sobrenome`, `Hospedado`.

### `ListarSuites`

Fornece funcionalidade para listar todas as suítes cadastradas.

- `public static void ExibirSuites()`: Lista as suítes cadastradas.

### `ListarReservas`

Permite listar todas as reservas cadastradas.

- `public static void ExibirReservas()`: Exibe todas as reservas.

### `ListarHospedes`

Permite listar todos os hospedes cadastrados.

- `public static void ExibirHospedes()`: Lista todos os hospedes cadastrados.

### `FecharReserva`

Fornece funcionalidade para encerrar uma reserva existente.

- `public static void EncerrarReserva()`: Encerra uma reserva especificada pelo usuário.

### `GerenciadorReservas`

Gerencia as operações relacionadas às reservas.

- `public static List<Reserva> Reservas`: Mantém uma lista das reservas.
- `public static void RealizarReserva()`: Realiza uma nova reserva.

### `ConsoleUI`

Fornece métodos auxiliares para a interface de usuário no console.

- Forma responsiva de melhorar a experiência do usuário para melhor visualização em Console.
- Métodos para exibir mensagens, cabeçalhos, ler entradas do usuário, entre outros.

### `CadastrarSuite`

Permite o cadastro de novas suítes.

- `public static List<Suite> Suites`: Mantém uma lista de suítes cadastradas.
- `public static void Cadastrar()`: Cadastra uma nova suíte.

### `ConsoleManager`

Oferece funcionalidades para manipulação do console, como desabilitar o redimensionamento.

- `public static void DisableResize()`: Desabilita a capacidade de redimensionar o console.

### `GerenciadorHospedes`

Gerencia as operações relacionadas aos hospedes.

- `public static List<Pessoa> Hospedes`: Mantém uma lista dos hospedes.
- `public static Pessoa CadastrarHospede()`: Realiza o cadastro de um novo hospede.

## Observações

- A aplicação não utiliza banco de dados, e todos os dados são armazenados em tempo de execução.
- Ao reiniciar a aplicação, todos os dados são perdidos.
