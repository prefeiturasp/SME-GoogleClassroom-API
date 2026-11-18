import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

// Realizar sincronização dos avisos
Quando('envio uma requisição POST em avisosSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/avisos/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },           
    failOnStatusCode: false
  }).as('response')
})

Então('realiza a sincronização dos avisos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não realizar sincronização dos avisos sem autenticação
Quando('tento uma requisição POST em avisosSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/avisos/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza a sincronização dos avisos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retorna os avisos do mural
Quando('envio uma requisição GET em avisos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/avisos?DataReferencia=${Cypress.env('DATA_AULA')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },           
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna os avisos do mural com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não retornar os avisos do mural sem autenticação
Quando('tento uma requisição GET em avisos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/avisos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna os avisos do mural com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Executar o tratamento de importação de avisos
Quando('envio uma requisição POST em avisosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/avisos/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },           
    failOnStatusCode: false  
  }).as('response')
})

Então('executa o tratamento de importação de avisos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não realizar sincronização de avisos sem autenticação
Quando('tento uma requisição POST em avisosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/avisos/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não executa o tratamento de importação de avisos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})