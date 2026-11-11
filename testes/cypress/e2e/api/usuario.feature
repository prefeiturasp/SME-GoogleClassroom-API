# language: pt

Funcionalidade: API - Usuario

  Cenário: Iniciar atualizações dos usuários
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em usuariosAtualizacoesGoogleId
    Então inicia a atualização dos usuários com status 200

  Cenário: Não iniciar atualizações dos usuários sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em usuariosAtualizacoesGoogleId
    Então não inicia a atualização dos usuários com status 401

  Cenário: Retornar os comparativos de usuários
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em usuariosComparativo
    Então retorna os comparativos de usuários com status 200

  Cenário: Não retornar os comparativos de usuários sem página
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em usuariosComparativo sem PaginaNumero
    Então não retorna os comparativos de usuários sem página com status 400

  Cenário: Não retornar os comparativos de usuários sem quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em usuariosComparativo sem RegistrosQuantidade
    Então não retorna os comparativos de usuários sem quantidade com status 400

  Cenário: Não retornar os comparativos de usuários sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em usuariosComparativo
    Então não retorna os comparativos de usuários com status 401

  Cenário: Iniciar carga de usuários
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em usuariosCarga
    Então inicia carga de usuários com status 200
 
  Cenário: Não iniciar carga de usuários sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em usuariosCarga
    Então não inicia carga de usuários com status 401

  Cenário: Iniciar tratamento de erro de usuários
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em usuariosErrosTratamentos
    Então inicia tratamento de erro de usuários com status 200
 
  Cenário: Não iniciar tratamento de erro de usuários sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em usuariosErrosTratamentos
    Então não inicia tratamento de erro de usuários com status 401

  Cenário: Iniciar tratamento de erro de usuários removidos
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em usuariosRemovidosErrosTratamentos
    Então inicia tratamento de erro de usuários removidos com status 200
 
  Cenário: Não iniciar tratamento de erro de usuários removidos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em usuariosRemovidosErrosTratamentos
    Então não inicia tratamento de erro de usuários removidos com status 401

  Cenário: Iniciar tratamento de erro de usuários GSA
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em usuariosGsaErrosTratamentos
    Então inicia tratamento de erro de usuários GSA com status 200
 
  Cenário: Não iniciar tratamento de erro de usuários GSA sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em usuariosGsaErrosTratamentos
    Então não inicia tratamento de erro de usuários GSA com status 401

  Cenário: Realizar carga tratamento de erro de usuários GSA
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em usuariosRealizarCargaGsaErrosTratamentos
    Então realiza carga tratamento de erro de usuários GSA com status 200
 
  Cenário: Não realizar carga tratamento de erro de usuários GSA sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em usuariosRealizarCargaGsaErrosTratamentos
    Então não realiza carga tratamento de erro de usuários GSA com status 401

  Cenário: Realizar carga de email
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em usuariosRealizarCargaEmail
    Então realiza carga email de usuários com status 200
 
  Cenário: Não realizar carga de email sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em usuariosRealizarCargaEmail
    Então não realiza carga email de usuários com status 401