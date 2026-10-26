import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

Dado('que não possuo um token de acesso', function () { 
})

// Retornar todas escolas existentes
Quando('envio uma requisição GET em escolas', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + '/api/v1/escolas',
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna as escolas existentes com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.a('array')
    expect(response.body.length).to.be.greaterThan(0)
    expect(response.body[0]).to.have.property('codigo')
    expect(response.body[0]).to.have.property('nome')
    expect(response.body[0]).to.have.property('codigoDRE')
    expect(response.body[0]).to.have.property('siglaTipoEscola')
  })
})

// Buscar escolas por código DRE
Quando('envio uma requisição GET em escolas com CodigoDRE', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/escolas??CodigoDRE=${Cypress.env('CODIGO_DRE')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna as escolas por código DRE com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.a('array')
    expect(response.body.length).to.be.greaterThan(0)
    expect(response.body[0]).to.have.property('codigo')
    expect(response.body[0]).to.have.property('nome')
    expect(response.body[0]).to.have.property('codigoDRE')
    expect(response.body[0]).to.have.property('siglaTipoEscola')
  })
})

// Não buscar escolas por código inexistente
Quando('envio uma requisição GET em escolas com CodigoDRE incorreto', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/escolas?CodigoDRE=0`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false,
  }).as('response')
})

Então('não retorna as escolas no código DRE com status 204', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(204)
  })
})

// Buscar escolas por tipo
Quando('envio uma requisição GET em escolas tipo', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/escolas?SiglaTipoEscola=${Cypress.env('SIGLA_TIPO_ESCOLA')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna as escolas por sigla tipo com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.a('array')
    expect(response.body.length).to.be.greaterThan(0)
    expect(response.body[0]).to.have.property('codigo')
    expect(response.body[0]).to.have.property('nome')
    expect(response.body[0]).to.have.property('codigoDRE')
    expect(response.body[0]).to.have.property('siglaTipoEscola')
  })
})

// Não buscar escolas por tipo inexistente
Quando('envio uma requisição GET em escolas sem tipo', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/escolas?SiglaTipoEscola=teste`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna as escolas por sigla tipo com status 204', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(204)
  })
})

// Não retornar escolas existentes sem autenticação
Quando('tento uma requisição GET em escolas', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + '/api/v1/escolas',
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna as escolas existentes com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})