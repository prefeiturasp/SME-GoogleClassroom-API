# language: pt

Funcionalidade: API - Frequência

  Cenário: Realizar o lançamento de frequência
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em frequencias
    Então realiza o lançamento de frequência com status 200

  Cenário: Não realizar o lançamento de frequência sem os dados
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em frequencias sem os dados
    Então não realiza o lançamento de frequência com status 400

  Cenário: Não realizar o lançamento de frequência sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em frequencias
    Então não realiza o lançamento de frequência com status 401