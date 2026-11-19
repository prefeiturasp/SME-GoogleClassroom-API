import { Given, When, Then, Before } from 'cypress-cucumber-preprocessor/steps'

const Dado = Given
const Quando = When
const Então = Then

Dado('que possuo um token de acesso', function () { 
})

// Retornar alunos do EOL que serão incluídos
Quando('envio uma requisição GET em alunosNovos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/novos?UltimaExecucao=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },
    timeout: 60000,      
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna alunos do EOL que serão incluídos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)

    expect(response.body).to.have.property('items')
    expect(response.body.items).to.be.an('array').and.not.be.empty

    expect(response.body.items[0]).to.have.property('codigo')
    expect(response.body.items[0]).to.have.property('nomePessoa')
    expect(response.body.items[0]).to.have.property('dataNascimento')
    expect(response.body.items[0]).to.have.property('email')
    expect(response.body.items[0]).to.have.property('organizationPath')
  })
})

// Não retornar alunos do EOL incluídos sem data
Quando('envio uma requisição GET em alunosNovos sem data de execução', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/novos?UltimaExecucao=&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna alunos do EOL que serão incluídos com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não retornar alunos do EOL incluídos sem autenticação
Quando('tento uma requisição GET em alunosNovos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/novos?UltimaExecucao=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna alunos do EOL incluídos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar alunos já incluídos
Quando('envio uma requisição GET em alunos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna alunos já incluídos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)

    expect(response.body).to.have.property('items')
    expect(response.body.items).to.be.an('array').and.not.be.empty

    expect(response.body.items[0]).to.have.property('codigo')
    expect(response.body.items[0]).to.have.property('usuarioTipo')
    expect(response.body.items[0]).to.have.property('nome')
    expect(response.body.items[0]).to.have.property('email')
    expect(response.body.items[0]).to.have.property('organizationPath')
  })
})

// Não retornar alunos do EOL incluídos sem página e quantidade
Quando('envio uma requisição GET em alunos sem página e quantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/novos?PaginaNumero=&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna alunos já incluídos com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não retornar alunos já incluídos sem autenticação
Quando('tento uma requisição GET em alunos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna alunos já incluídos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Inicia sincronização de alunos
Quando('envio uma requisição POST em alunosSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia sincronização de alunos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não inicia sincronização de alunos sem autenticação
Quando('tento uma requisição POST em alunosSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/sincronizacao`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia sincronização de alunos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Inicia tratamento da sincronização de alunos
Quando('envio uma requisição POST em alunosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('inicia tratamento da sincronização de alunos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não inicia tratamento da sincronização de alunos sem autenticação
Quando('tento uma requisição POST em alunosErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia tratamento da sincronização de alunos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar cursos do aluno que serão incluídos
Quando('envio uma requisição GET em alunosCursosNovos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/cursos/novos?codigoAluno=${Cypress.env('CODIGO_ALUNO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna cursos do aluno que serão incluídos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)

    expect(response.body).to.be.an('array').and.not.be.empty

    expect(response.body[0]).to.have.property('codigoAluno')
    expect(response.body[0]).to.have.property('turmaId')
    expect(response.body[0]).to.have.property('componenteCurricularId')
    expect(response.body[0]).to.have.property('cursoId')
    expect(response.body[0]).to.have.property('ueCodigo')
  })
})

// Não retornar cursos que serão incluídos sem aluno
Quando('envio uma requisição GET em alunosCursosNovos sem aluno', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/cursos/novos?codigoAluno=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos que serão incluídos sem aluno com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não retornar cursos do aluno que serão incluídos sem autenticação
Quando('tento uma requisição GET em alunosCursosNovos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/cursos/novos?codigoAluno=${Cypress.env('CODIGO_ALUNO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos do aluno que serão incluídos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})

// Retornar alunos com os cursos já incluídos
Quando('envio uma requisição GET em alunosCursos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/cursos?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna cursos do aluno já incluídos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)

    expect(response.body).to.have.property('items')
    expect(response.body.items).to.be.an('array').and.not.be.empty

    expect(response.body).to.have.property('totalPaginas')
    expect(response.body).to.have.property('totalRegistros')

    response.body.items.forEach((aluno) => {
      expect(aluno).to.have.property('codigoAluno')
      expect(aluno).to.have.property('nome')
      expect(aluno).to.have.property('email')
      expect(aluno.cursos).to.be.an('array')

      aluno.cursos.forEach((curso) => {
        expect(curso).to.have.property('cursoId')
        expect(curso).to.have.property('nome')
        expect(curso).to.have.property('secao')
        expect(curso).to.have.property('turmaId')
        expect(curso).to.have.property('componenteCurricularId')
      })
    })
  })
})

// Não retornar alunos com os cursos já incluídos sem página e quantidade
Quando('envio uma requisição GET em alunosCursos sem página e quantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/cursos?PaginaNumero=&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna alunos com os cursos já incluídos sem página e quantidade com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não retornar alunos com os cursos já incluídos sem autenticação
Quando('tento uma requisição GET em alunosCursos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/alunos/cursos?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos do aluno que serão incluídos com status 401', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(401)
  })
})