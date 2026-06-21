# Exercicio SOLID - Refatoracao de Sistema de Logistica

Este repositorio contem a refatoracao de um sistema ficticio de gerenciamento de entregas, criado para simular o cenario de uma startup de logistica. O objetivo do projeto e demonstrar a aplicacao pratica dos 5 principios SOLID para transformar um codigo legado, acoplado e de dificil manutencao em uma arquitetura limpa e escalavel.

## Visao Geral do Projeto

O codigo base utilizado para este exercicio apresentava serios problemas de design de software. A refatoracao reescreveu a estrutura do sistema isolando responsabilidades e criando abstracoes. O projeto ataca cinco violacoes principais:

* SRP (Responsabilidade Unica): Isolamento de entidades, persistencia no banco de dados e geracao de relatorios.
* OCP (Aberto/Fechado): Implementacao de interfaces para adicionar novos tipos de frete sem modificar o calculo base.
* LSP (Substituicao de Liskov): Correcao da hierarquia de veiculos, separando logicas de combustao e eletricidade.
* ISP (Segregacao de Interfaces): Fatiamento de interfaces globais em contratos especificos por funcao do funcionario.
* DIP (Inversao de Dependencia): Desacoplamento do servico de notificacoes (Email, SMS, WhatsApp) utilizando injecao de dependencia.

## Estrutura do Codigo

```text
exerciciosolid/
├── src/
│   └── Logistica.App/
│       ├── Program.cs          # Motor de testes comprovando OCP e DIP na prática
│       ├── SRP/                # Classes com responsabilidade única
│       ├── OCP/                # Estratégias de cálculo de frete
│       ├── LSP/                # Hierarquia de veículos corrigida
│       ├── ISP/                # Interfaces segregadas por função
│       └── DIP/                # Abstrações de serviços de notificação

## Como Executar

1. Clone o repositorio.
2. Abra a pasta `src/Logistica.App` na sua IDE (Visual Studio ou VS Code).
3. Execute o `Program.cs` para visualizar no console a orquestracao dos servicos refatorados.

---
