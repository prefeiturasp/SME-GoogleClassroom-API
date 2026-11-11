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

  Cenário: Retornar cursos dos professores
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursos
    Então retorna cursos dos professores com status 200

  Cenário: Não retornar cursos dos professores sem página
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursos sem PaginaNumero
    Então não retorna cursos dos professores sem página com status 400

  Cenário: Não retornar cursos dos professores sem quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursos sem RegistrosQuantidade
    Então não retorna cursos dos professores sem quantidade com status 400

  Cenário: Não retornar cursos dos professores sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição GET em professoresCursos
    Então não retorna cursos dos professores com status 401

  Cenário: Atribuir um curso ao professor
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresCursos
    Então atribui curso ao professor com status 200

   Cenário: Não atribuir um curso ao professor sem dados
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresCursos sem dados
    Então não atribui atribui curso ao professor com status 400

  Cenário: Não atribuir um curso ao professor sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição POST em professoresCursos
    Então não atribui curso ao professor com status 401

  Cenário: Retornar professores atribuídos aos cursos
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoes
    Então retorna cursos dos professores atribuídos com status 200

  Cenário: Não retornar professores atribuídos aos cursos sem data
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoes sem DataReferencia
    Então não retorna cursos dos professores atribuídos sem data com status 400

  Cenário: Não retornar professores atribuídos aos cursos sem página
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoes sem PaginaNumero
    Então não retorna cursos dos professores atribuídos sem página com status 400

  Cenário: Não retornar professores atribuídos aos cursos sem quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoes sem RegistrosQuantidade
    Então não retorna cursos dos professores atribuídos sem quantidade com status 400

  Cenário: Não retornar professores atribuídos aos cursos sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição GET em professoresCursosAtribuicoes
    Então não retorna cursos dos professores atribuídos com status 401

  Cenário: Sincronizar atribuições de cursos dos professores
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresCursosAtribuicoesSincronizacao
    Então sincroniza atribuições de cursos dos professores com status 200

  Cenário: Não sincronizar atribuições de cursos dos professores sem ano letivo
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresCursosAtribuicoesSincronizacao sem ano letivo
    Então não sincroniza atribuições de cursos dos professores com status 400

  Cenário: Não sincronizar atribuições de cursos dos professores sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição POST em professoresCursosAtribuicoesSincronizacao
    Então não sincroniza atribuições de cursos dos professores com status 401

  Cenário: Retornar professores removidos atribuição dos cursos
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoesRemover
    Então retorna cursos dos professores removidos atribuição com status 200

  Cenário: Não retornar professores removidos atribuição aos cursos sem página
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoesRemover sem PaginaNumero
    Então não retorna cursos dos professores removidos atribuição sem página com status 400

  Cenário: Não retornar professores removidos atribuídos aos cursos sem quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em professoresCursosAtribuicoesRemover sem RegistrosQuantidade
    Então não retorna cursos dos professores removidos atribuição sem quantidade com status 400

  Cenário: Não retornar professores removidos atribuição aos cursos sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição GET em professoresCursosAtribuicoesRemover
    Então não retorna cursos dos professores removidos atribuição com status 401

  Cenário: Iniciar tratamento de erros de professores removidos a atribuição
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em professoresCursosAtribuicoesRemoverErrosTratamentos
    Então inicia tratamento de erros de professores removidos a atribuição com status 200

  Cenário: Não iniciar tratamento de erros de professores removidos a atribuição sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição POST em professoresCursosAtribuicoesRemoverErrosTratamentos
    Então não inicia tratamento de erros de professores removidos a atribuição com status 401