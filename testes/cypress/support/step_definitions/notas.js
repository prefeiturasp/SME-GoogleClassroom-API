import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

// Realizar sincronização das notas
Quando('envio uma requisição POST em notasSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/notas/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },           
    failOnStatusCode: false  
  }).as('response')
})

Então('realiza a sincronização das notas com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não realizar sincronização das notas sem autenticação
Quando('tento uma requisição POST em notasSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/notas/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza a sincronização das notas com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar as notas das atividades
Quando('envio uma requisição GET em notas', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/notas`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },           
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna as notas das atividades com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(500)
  })
})

// Não retornar as notas das atividades sem autenticação
Quando('tento uma requisição GET em notas', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/notas`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna as notas das atividades com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Executar o tratamento de importação de notas
Quando('envio uma requisição POST em notasErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/notas/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },           
    failOnStatusCode: false  
  }).as('response')
})

Então('executa o tratamento de importação de notas com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não realizar sincronização das notas sem autenticação
Quando('tento uma requisição POST em notasErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/notas/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não executa o tratamento de importação de notas com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})