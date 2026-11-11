import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

Dado('que não possuo um token de acesso', function () { 
})

// Retornar formação por código da turma
Quando('envio uma requisição GET em formacao', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/turma/${Cypress.env('TURMA_ID')}/inscricoes`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna formação por turma com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.a('array')
    expect(response.body.length).to.be.greaterThan(0)
    expect(response.body[0]).to.have.property('codigoRf')
    expect(response.body[0]).to.have.property('cpf')
    expect(response.body[0]).to.have.property('nome')
    expect(response.body[0]).to.have.property('email')
    expect(response.body[0]).to.have.property('dreCodigo')
    expect(response.body[0]).to.have.property('ueCodigo')
    expect(response.body[0]).to.have.property('dreNome')
    expect(response.body[0]).to.have.property('ueNome')
    expect(response.body[0]).to.have.property('codigoCargo')
    expect(response.body[0]).to.have.property('descricaoCargo')
    expect(response.body[0]).to.have.property('tipoVinculo')
  })
})

// Não retornar dados de formação sem turma
Quando('envio uma requisição GET em formacao sem turma', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/turma//inscricoes`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna dados de formação e status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.eq('GoogleClassroom Worker!')
  })
})

// Não retornar formação sem autenticação
Quando('tento uma requisição GET em formacao', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/turma/${Cypress.env('TURMA_ID')}/inscricoes`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna formação e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar formação por detalhes do ano
Quando('envio uma requisição GET em formacao detalhes ano', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/detalhes/ano/${Cypress.env('ANO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna formação por ano com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.a('array')
    expect(response.body.length).to.be.greaterThan(0)
    expect(response.body[0]).to.have.property('codigoIE')
    expect(response.body[0]).to.have.property('nomeIE')
    expect(response.body[0]).to.have.property('codigoPL')
    expect(response.body[0]).to.have.property('nomePL')
    expect(response.body[0]).to.have.property('codigoCurso')
    expect(response.body[0]).to.have.property('nomeCurso')
    expect(response.body[0]).to.have.property('codigoSerie')
    expect(response.body[0]).to.have.property('nomeSerie')
    expect(response.body[0]).to.have.property('turmas')
  })
})

// Não retornar dados por detalhes sem ano
Quando('envio uma requisição GET em formacao detalhes sem ano', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/detalhes/ano/`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna dados de formação por ano e status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.eq('GoogleClassroom Worker!')
  })
})

// Não retornar formação detalhes do ano sem autenticação
Quando('tento uma requisição GET em formacao detalhes ano', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/detalhes/ano/${Cypress.env('ANO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('TOKEN_INVALIDO')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna formação por ano e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar formação por detalhes do ano
Quando('envio uma requisição GET em formacao detalhes ano', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/detalhes/ano/${Cypress.env('ANO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna formação por ano com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.a('array')
    expect(response.body.length).to.be.greaterThan(0)
    expect(response.body[0]).to.have.property('codigoIE')
    expect(response.body[0]).to.have.property('nomeIE')
    expect(response.body[0]).to.have.property('codigoPL')
    expect(response.body[0]).to.have.property('nomePL')
    expect(response.body[0]).to.have.property('codigoCurso')
    expect(response.body[0]).to.have.property('nomeCurso')
    expect(response.body[0]).to.have.property('codigoSerie')
    expect(response.body[0]).to.have.property('nomeSerie')
    expect(response.body[0]).to.have.property('turmas')
  })
})

// Não retornar formação detalhes do ano sem autenticação
Quando('tento uma requisição GET em formacao detalhes ano', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/detalhes/ano/${Cypress.env('ANO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('TOKEN_INVALIDO')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna formação por ano e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar instituição de ensino da formação
Quando('envio uma requisição GET em formacao instituicao ensino', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/instituicao-ensino`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna instituição de ensino da formação com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)  
    expect(response.body[0]).to.have.property('codigoIE')
    expect(response.body[0]).to.have.property('nomeIE')    
  })
})

// Não retornar instituição de ensino da formação sem autenticação
Quando('tento uma requisição GET em formacao instituicao ensino', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/formacao/instituicao-ensino`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna instituição de ensino da formação e status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})