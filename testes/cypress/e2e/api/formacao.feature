# language: pt

Funcionalidade: API - Formação

  Cenário: Retornar formação por código da turma
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em formacao
    Então retorna formação por turma com status 200

  Cenário: Não retornar dados de formação sem turma
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em formacao sem turma
    Então não retorna dados de formação e status 200

  Cenário: Não retornar formação sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em formacao
    Então não retorna formação e status 401

  Cenário: Retornar formação por detalhes do ano
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em formacao detalhes ano
    Então retorna formação por ano com status 200

  Cenário: Não retornar dados por detalhes sem ano
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em formacao detalhes sem ano
    Então não retorna dados de formação por ano e status 200

  Cenário: Não retornar formação detalhes do ano sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em formacao detalhes ano
    Então não retorna formação por ano e status 401

  Cenário: Retornar instituição de ensino da formação
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em formacao instituicao ensino
    Então retorna instituição de ensino da formação com status 200

  Cenário: Não retornar instituição de ensino da formação sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em formacao instituicao ensino
    Então não retorna instituição de ensino da formação e status 401