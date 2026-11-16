# language: pt

Funcionalidade: API - Aula

  Cenário: Retornar todas as aulas
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em aula
    Então retorna as aulas existentes com status 200