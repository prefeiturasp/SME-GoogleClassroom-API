# language: pt

Funcionalidade: API - Notas

  Cenário: Realizar sincronização das notas
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em notasSincronizacao
    Então realiza a sincronização das notas com status 200

  Cenário: Não realizar sincronização das notas sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em notasSincronizacao
    Então não realiza a sincronização das notas com status 401

  Cenário: Retornar as notas das atividades
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em notas
    Então retorna as notas das atividades com status 200

  Cenário: Não retornar as notas das atividades sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em notas
    Então não retorna as notas das atividades com status 401

  Cenário: Executar o tratamento de importação de notas
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em notasErrosTratamentos
    Então executa o tratamento de importação de notas com status 200

  Cenário: Não realizar sincronização das notas sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em notasErrosTratamentos
    Então não executa o tratamento de importação de notas com status 401