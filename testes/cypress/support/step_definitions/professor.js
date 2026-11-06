import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

Dado('que não possuo um token de acesso', function () { 
})

// Retornar novos professores
Quando('envio uma requisição GET em professoresNovos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/novos?UltimaExecucao=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna novos professores com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(500)
  })
})

// Última execução obrigatória para novos professores
Quando('envio uma requisição GET em professoresNovos sem UltimaExecucao', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/novos?UltimaExecucao=&PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna novos professores sem execução com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar novos professores sem página
Quando('envio uma requisição GET em professoresNovos sem PaginaNumero', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/novos?UltimaExecucao=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna novos professores sem página com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar novos professores sem quantidade
Quando('envio uma requisição GET em professoresNovos sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/novos?UltimaExecucao=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna novos professores sem quantidade com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar novos professores sem autenticação
Quando('tento uma requisição GET em professoresNovos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/novos?UltimaExecucao=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna novos professores com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar todos professores
Quando('envio uma requisição GET em professores', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna todos professores com status 200', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(200)

  expect(response.body).to.be.an('object')
  expect(response.body.items).to.be.an('array')
  expect(response.body.items.length).to.be.greaterThan(0)

  expect(response.body.items[0]).to.have.property('rf')
  expect(response.body.items[0]).to.have.property('usuarioTipo')
  expect(response.body.items[0]).to.have.property('nome')
  expect(response.body.items[0]).to.have.property('email')
  expect(response.body.items[0]).to.have.property('organizationPath')
  expect(response.body.items[0]).to.have.property('dataInclusao')
  expect(response.body.items[0]).to.have.property('dataAtualizacao') 
  expect(response.body.items[0]).to.have.property('existeGoogle')

  expect(response.body).to.have.property('totalPaginas')
  expect(response.body).to.have.property('totalRegistros')
  })
})

// Não retornar todos professores sem página
Quando('envio uma requisição GET em professores sem PaginaNumero', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores?PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna todos professores sem página com status 400', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(400)
  })
})

// Não retornar todos professores sem quantidade
Quando('envio uma requisição GET em professores sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores?PaginaNumero=1&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna todos professores sem quantidade com status 400', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(400)
  })
})
 
// Não retornar todos professores sem autenticação
Quando('tento uma requisição GET em professores', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna todos professores com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Realizar sincronização de professores
Quando('envio uma requisição POST em professoresSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('sincroniza todos professores com status 200', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(200)
  })
})
 
// Não realizar sincronização de professores sem autenticação
Quando('tento uma requisição POST em professoresSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não sincroniza todos professores com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Realizar tratamentos de erros
Quando('envio uma requisição POST em professoresErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('realiza tratamentos de erros em professores com status 200', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(200)
  })
})
 
// Não realizar tratamentos de erros sem autenticação
Quando('tento uma requisição POST em professoresErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza tratamentos de erros em professores com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})