# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Camada MVC e API implementadas corretamente com rotas para autenticação, produtos e categorias.
    - Navegação funcional e bem estruturada.

  * Pontos negativos:
    - Nenhum.

### Design
  - Layout administrativo coerente com o propósito. Simples, claro e objetivo.

### Funcionalidade
  * Pontos positivos:
    - CRUD completo implementado nas camadas MVC e API.
    - Registro do vendedor junto com o usuário do Identity está implementado corretamente.
    - Autenticação com ASP.NET Identity funcionando nas duas camadas (JWT e cookie).
    - Migrations automáticas e seed de dados com SQLite corretamente configurados.
    - Modelagem de entidades atende aos requisitos do domínio.

  * Pontos negativos:
    - Seed de dados presente apenas no MVC, o que prejudica a API em cenários de testes independentes.

## Back End

### Arquitetura
  * Pontos positivos:
    - Arquitetura em camadas bem definida com divisão entre API, Core, Infrastructure e MVC.
    - Camada `Core` centraliza a lógica de domínio compartilhada.

  * Pontos negativos:
    - Duplicação de lógica entre MVC e API poderia ser evitada com implementação de repositórios compartilhados.
    - Camada de infraestrutura (`Infrastructure`) poderia estar dentro da camada `Core` para simplificação, conforme o escopo do desafio.
    - Mistura de modelos de domínio com objetos de mapeamento e configuração (ex: JWTSettings) na mesma estrutura/pasta, o que pode dificultar a manutenção.

### Funcionalidade
  * Pontos positivos:
    - Funcionalidades entregues conforme os requisitos.
    - Proteção por autenticação e autorização está bem implementada.

  * Pontos negativos:
    - Nenhum.

### Modelagem
  * Pontos positivos:
    - Entidades modeladas corretamente e com validações apropriadas.
    - Uso coerente de atributos e controle de integridade.

  * Pontos negativos:
    - Organização de objetos (entidades vs. configurações) poderia ser mais clara com separação em pastas distintas.

## Projeto

### Organização
  * Pontos positivos:
    - Projeto bem estruturado, uso de `src`, `.sln` na raiz e documentação presente.
    - Separação clara entre camadas.

  * Pontos negativos:
    - Presença de algumas pastas e arquivos da IDE (.vs) e outros desnecessários na raiz.

### Documentação
  * Pontos positivos:
    - `README.md` e `FEEDBACK.md` presentes.
    - Swagger implementado na API.

### Instalação
  * Pontos positivos:
    - SQLite configurado corretamente.
    - Execução de migrations e seed de dados automatizada na inicialização.

  * Pontos negativos:
    - Seed está apenas no MVC, prejudicando testes via API standalone.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 10       | 3,0                                      |
| **Qualidade do Código**       | 20%      | 9        | 1,8                                      |
| **Eficiência e Desempenho**   | 20%      | 8        | 1,6                                      |
| **Inovação e Diferenciais**   | 10%      | 10       | 1,0                                      |
| **Documentação e Organização**| 10%      | 9        | 0,9                                      |
| **Resolução de Feedbacks**    | 10%      | 7        | 0,7                                      |
| **Total**                     | 100%     | -        | **9,0**                                  |

## 🎯 **Nota Final: 9 / 10**
