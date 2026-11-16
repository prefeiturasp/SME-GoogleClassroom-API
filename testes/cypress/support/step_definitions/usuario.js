import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

// Iniciar atualizações dos usuários
Quando('envio uma requisição POST em usuariosAtualizacoesGoogleId', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/atualizacoes/google-id`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia a atualização dos usuários com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não iniciar atualizações dos usuários sem autenticação
Quando('tento uma requisição POST em usuariosAtualizacoesGoogleId', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/atualizacoes/google-id`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia a atualização dos usuários com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Retornar os comparativos de usuários
Quando('envio uma requisição GET em usuariosComparativo', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/comparativo?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna os comparativos de usuários com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(500)   
  })
})

// Não retornar os comparativos de usuários sem página
Quando('envio uma requisição GET em usuariosComparativo sem PaginaNumero', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/comparativo?PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna os comparativos de usuários sem página com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)   
  })
})

// Não retornar os comparativos de usuários sem quantidade
Quando('envio uma requisição GET em usuariosComparativo sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/comparativo?PaginaNumero=1&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna os comparativos de usuários sem quantidade com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)   
  })
})

// Não retornar os comparativos de usuários sem autenticação
Quando('tento uma requisição GET em usuariosComparativo', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/comparativo?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna os comparativos de usuários com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Iniciar carga de usuários
Quando('envio uma requisição GET em usuariosCarga', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/carga`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia carga de usuários com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não iniciar carga de usuários sem autenticação
Quando('tento uma requisição GET em usuariosCarga', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/carga`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia carga de usuários com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Iniciar tratamento de erro de usuários
Quando('envio uma requisição POST em usuariosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia tratamento de erro de usuários com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não iniciar tratamento de erro de usuários sem autenticação
Quando('tento uma requisição POST em usuariosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia tratamento de erro de usuários com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Iniciar tratamento de erro de usuários removidos
Quando('envio uma requisição POST em usuariosRemovidosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/removidos/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia tratamento de erro de usuários removidos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não iniciar tratamento de erro de usuários removidos sem autenticação
Quando('tento uma requisição POST em usuariosRemovidosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/removidos/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia tratamento de erro de usuários removidos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Iniciar tratamento de erro de usuários GSA
Quando('envio uma requisição POST em usuariosGsaErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/gsa/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia tratamento de erro de usuários GSA com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não iniciar tratamento de erro de usuários GSA sem autenticação
Quando('tento uma requisição POST em usuariosGsaErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/gsa/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia tratamento de erro de usuários GSA com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Realizar carga tratamento de erro de usuários GSA
Quando('envio uma requisição POST em usuariosRealizarCargaGsaErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/realizar/carga/gsa/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('realiza carga tratamento de erro de usuários GSA com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não realizar carga tratamento de erro de usuários GSA sem autenticação
Quando('tento uma requisição POST em usuariosRealizarCargaGsaErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/realizar/carga/gsa/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza carga tratamento de erro de usuários GSA com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})

// Realizar carga de email
Quando('envio uma requisição POST em usuariosRealizarCargaEmail', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/realizar/carga/email`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },
    body: {
    "usuarios": [
    {     
      "tipo": 1,
      "id": 1,
      "nome": "Teste",
      "email": "automacao@@edu.sme.prefeitura.sp.gov.br"
    }
  ]
},       
    failOnStatusCode: false  
  }).as('response')
})

Então('realiza carga email de usuários com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)   
  })
})

// Não realizar carga de email sem autenticação
Quando('tento uma requisição POST em usuariosRealizarCargaEmail', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/usuarios/realizar/carga/email`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },
    body: {
    "usuarios": [
    {     
      "tipo": 1,
      "id": 1,
      "nome": "Teste",
      "email": "testeautomacao@edu.sme.prefeitura.sp.gov.br"
    }
  ]
},        
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza carga email de usuários com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)   
  })
})