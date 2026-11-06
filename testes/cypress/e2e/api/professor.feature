# language: pt

Funcionalidade: API - Professor

  Cenário: Retornar novos professores
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresNovos
    Então retorna novos professores com status 200

  Cenário: Última execução obrigatória para novos professores
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresNovos sem UltimaExecucao
    Então não retorna novos professores sem execução com status 400

  Cenário: Não retornar novos professores sem página
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresNovos sem PaginaNumero
    Então não retorna novos professores sem página com status 400

  Cenário: Não retornar novos professores sem quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresNovos sem RegistrosQuantidade
    Então não retorna novos professores sem quantidade com status 400
  
  Cenário: Não retornar novos professores sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição GET em professoresNovos
    Então não retorna novos professores com status 401

  Cenário: Retornar todos professores
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professores
    Então retorna todos professores com status 200

  Cenário: Não retornar todos professores sem página
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professores sem PaginaNumero
    Então não retorna todos professores sem página com status 400

  Cenário: Não retornar todos professores sem quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professores sem RegistrosQuantidade
    Então não retorna todos professores sem quantidade com status 400

  Cenário: Não retornar todos professores sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição GET em professores
    Então não retorna todos professores com status 401

  Cenário: Realizar sincronização de professores
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresSincronizacao
    Então sincroniza todos professores com status 200

  Cenário: Não realizar sincronização de professores sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição POST em professoresSincronizacao
    Então não sincroniza todos professores com status 401

  Cenário: Realizar tratamentos de erros
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresErrosTratamentos
    Então realiza tratamentos de erros em professores com status 200

  Cenário: Não realizar tratamentos de erros sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição POST em professoresErrosTratamentos
    Então não realiza tratamentos de erros em professores com status 401