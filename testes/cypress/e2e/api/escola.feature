# language: pt

Funcionalidade: API - Escola

  Cenário: Retornar todas escolas existentes
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em escolas
    Então retorna as escolas existentes com status 200

  Cenário: Buscar escolas por código DRE
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em escolas com CodigoDRE
    Então retorna as escolas por código DRE com status 200

  Cenário: Não buscar escolas por código inexistente
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em escolas com CodigoDRE incorreto
    Então não retorna as escolas no código DRE com status 204

  Cenário: Buscar escolas por tipo
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em escolas tipo
    Então retorna as escolas por sigla tipo com status 200

  Cenário: Não buscar escolas por tipo inexistente
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em escolas sem tipo
    Então não retorna as escolas por sigla tipo com status 204

  Cenário: Não retornar escolas existentes sem autenticação
    Dado que não possuo um token de acesso
    Quando tento uma requisição GET em escolas
    Então não retorna as escolas existentes com status 401