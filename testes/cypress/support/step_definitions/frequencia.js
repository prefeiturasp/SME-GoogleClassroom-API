import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

// Realizar o lançamento de frequência
Quando('envio uma requisição POST em frequencias', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/frequencias`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },
    body: {
      "aulaId": Cypress.env('AULA_ID'),
      "usuarioLogado": Cypress.env('NOME_USUARIO'),
      "perfilUsuario": Cypress.env('TIPO_USUARIO_ID'),
      "alunos":
    [
      {
        "codigoAluno": Cypress.env('CODIGO_ALUNO'),
        "frequencias":
      [{
        "tipoFrequencia": Cypress.env('TIPO_FREQUENCIA'),
        "numeroAula": Cypress.env('NUMERO_AULA')
      }]
    }]
  },        
    failOnStatusCode: false  
  }).as('response')
})

Então('realizar o lançamento de frequência com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não realizar o lançamento de frequência sem os dados
Quando('envio uma requisição POST em frequencias sem os dados', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/frequencias`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },
    body: {
      "aulaId": Cypress.env('AULA_ID'),      
      "alunos":
    [
      {
        "codigoAluno": Cypress.env('CODIGO_ALUNO'),
        "frequencias":
      [{
        "tipoFrequencia": Cypress.env('TIPO_FREQUENCIA'),
      }]
    }]
  },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza o lançamento de frequência com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não realizar o lançamento de frequência sem autenticação
Quando('tento uma requisição POST em frequencias', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/frequencias`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },
    body: {
      "aulaId": Cypress.env('AULA_ID'),
      "usuarioLogado": Cypress.env('NOME_USUARIO'),
      "perfilUsuario": Cypress.env('TIPO_USUARIO_ID'),
      "alunos":
    [
      {
        "codigoAluno": Cypress.env('CODIGO_ALUNO'),
        "frequencias":
      [{
        "tipoFrequencia": Cypress.env('TIPO_FREQUENCIA'),
        "numeroAula": Cypress.env('NUMERO_AULA')
      }]
    }]
  },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não realiza o lançamento de frequência com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})