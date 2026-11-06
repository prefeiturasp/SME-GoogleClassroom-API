import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

Dado('que não possuo um token de acesso', function () { 
})

// Retornar todas as atividades
Quando('envio uma requisição GET em atividades', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/atividades?DataReferencia=${Cypress.env('DATA_AULA')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna todas as atividades com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)    
    expect(response.body).to.have.property('items')
    expect(response.body).to.have.property('totalPaginas')
    expect(response.body).to.have.property('totalRegistros')
  })
})

// Quantidade de registros obrigatória
Quando('envio uma requisição GET em atividades sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/atividades?DataReferencia=${Cypress.env('DATA_AULA')}&PaginaNumero=1`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna dados de atividades e status 500', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(500)
  })
})

// Não retornar atividades sem autenticação
Quando('tento uma requisição GET em atividades', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/atividades?DataReferencia=${Cypress.env('DATA_AULA')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna atividades e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Executa o tratamento de importação das atividades
Quando('envio uma requisição POST em atividades tratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/atividades/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: '*/*',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('executa o tratamento dos erros de importação com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não executar o tratamento de importação de atividades sem autenticação
Quando('tento uma requisição POST em atividades tratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/atividades/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: '*/*',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não executa o tratamento dos erros de importação e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Executar a sincronização das atividades
Quando('envio uma requisição POST em atividades sincronização', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/atividades/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: '*/*',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('executa a sincronização de atividades com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Executar por página a sincronização das atividades
Quando('envio uma requisição POST em atividades sincronização totalPaginas', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/atividades/sincronizacao?pagina=1&totalPaginas=10`,
    failOnStatusCode: false,
    headers: {
      accept: '*/*',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('executa a sincronização de atividades por página com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não executar a sincronização de atividades sem autenticação
Quando('tento uma requisição POST em atividades sincronização', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/atividades/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: '*/*',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não executa a sincronização de atividades e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})