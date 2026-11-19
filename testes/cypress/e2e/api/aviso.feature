# language: pt

Funcionalidade: API - Aviso

  Cenário: Realizar sincronização dos avisos
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em avisosSincronizacao
    Então realiza a sincronização dos avisos com status 200

  Cenário: Não realizar sincronização dos avisos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em avisosSincronizacao
    Então não realiza a sincronização dos avisos com status 401

  Cenário: Retorna os avisos do mural
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em avisos
    Então retorna os avisos do mural com status 200

  Cenário: Não retornar os avisos do mural sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em avisos
    Então não retorna os avisos do mural com status 401

  Cenário: Executar o tratamento de importação de avisos
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em avisosErrosTratamentos
    Então executa o tratamento de importação de avisos com status 200

  Cenário: Não realizar sincronização de avisos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em avisosErrosTratamentos
    Então não executa o tratamento de importação de avisos com status 401