import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

// Retornar todas as aulas
Quando('envio uma requisição GET em aula', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/aulas/turma/${Cypress.env('TURMA_ID')}/componente-curricular/${Cypress.env('COMPONENTE_CURRICULAR_ID')}/data/${Cypress.env('DATA_AULA')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna as aulas existentes com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.eq('GoogleClassroom Worker!')
  })
})