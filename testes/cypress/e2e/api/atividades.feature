# language: pt

Funcionalidade: API - Atividades

  Cenário: Retornar todas as atividades
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em atividades
    Então retorna todas as atividades com status 200

  Cenário: Quantidade de registros obrigatória
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em atividades sem RegistrosQuantidade
    Então não retorna dados de atividades e status 500

  Cenário: Não retornar atividades sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em atividades
    Então não retorna atividades e status 401

  Cenário: Executar o tratamento de importação das atividades
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em atividades tratamentos
    Então executa o tratamento dos erros de importação com status 200

  Cenário: Não executar o tratamento de importação de atividades sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em atividades tratamentos
    Então não executa o tratamento dos erros de importação e status 401

  Cenário: Executar a sincronização das atividades
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em atividades sincronização
    Então executa a sincronização de atividades com status 200

  Cenário: Executar por página a sincronização das atividades
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em atividades sincronização totalPaginas
    Então executa a sincronização de atividades por página com status 200

  Cenário: Não executar a sincronização de atividades sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em atividades sincronização
    Então não executa a sincronização de atividades e status 401