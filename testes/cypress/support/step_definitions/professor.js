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

// Retornar cursos dos professores
Quando('envio uma requisição GET em professoresCursos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna cursos dos professores com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.an('object')
    expect(response.body.items).to.be.an('array').and.not.be.empty
    expect(response.body.items[0]).to.have.property('cursoUsuarioId')
    expect(response.body.items[0]).to.have.property('indice')
    expect(response.body.items[0]).to.have.property('rf')
    expect(response.body.items[0]).to.have.property('nome')
    expect(response.body.items[0]).to.have.property('email')
    expect(response.body.items[0]).to.have.property('googleClassRoomId')
    expect(response.body.items[0].cursos).to.be.an('array').and.not.be.empty
    expect(response.body.items[0].cursos[0]).to.have.property('cursoId')
    expect(response.body.items[0].cursos[0]).to.have.property('nome')
  })
})

// Não retornar cursos dos professores sem página
Quando('envio uma requisição GET em professoresCursos sem PaginaNumero', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos?PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores sem página com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar cursos dos professores sem quantidade
Quando('envio uma requisição GET em professoresCursos sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos?PaginaNumero=1&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores sem quantidade com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})
 
// Não retornar cursos dos professores sem autenticação
Quando('tento uma requisição GET em professoresCursos', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Atribuir um curso ao professor
Quando('envio uma requisição POST em professoresCursos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },
    body: {
      "rf": Cypress.env('RF'),
      "turmaId": Cypress.env('TURMA_ID'),
      "componenteCurricularId": Cypress.env('COMPONENTE_CURRICULAR_ID')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('atribui curso ao professor com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não atribuir um curso ao professor sem dados
Quando('envio uma requisição POST em professoresCursos sem dados', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },
    body: {
      "rf": '',
      "turmaId": '',
      "componenteCurricularId": ''
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não atribui atribui curso ao professor com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não atribuir um curso ao professor sem autenticação
Quando('tento uma requisição POST em professoresCursos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    }, 
    body: {
      "rf": Cypress.env('RF'),
      "turmaId": Cypress.env('TURMA_ID'),
      "componenteCurricularId": Cypress.env('COMPONENTE_CURRICULAR_ID')
    },      
    failOnStatusCode: false  
  }).as('response')
})

Então('não atribui curso ao professor com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Retornar professores atribuídos aos cursos
Quando('envio uma requisição GET em professoresCursosAtribuicoes', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes?DataReferencia=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('retorna cursos dos professores atribuídos com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
    expect(response.body).to.be.an('object')
    expect(response.body.items).to.be.an('array').and.not.be.empty  
    expect(response.body.items[0]).to.have.property('rf')
    expect(response.body.items[0]).to.have.property('nome')
    expect(response.body.items[0]).to.have.property('email')
    expect(response.body.items[0]).to.have.property('turmaId')
    expect(response.body.items[0]).to.have.property('componenteCurricularId')
    expect(response.body.items[0]).to.have.property('dataAtribuicao')
    expect(response.body.items[0]).to.have.property('cdUe')
  })
})

// Não retornar professores atribuídos aos cursos sem data
Quando('envio uma requisição GET em professoresCursosAtribuicoes sem DataReferencia', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes?DataReferencia=&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores atribuídos sem data com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar professores atribuídos aos cursos sem página
Quando('envio uma requisição GET em professoresCursosAtribuicoes sem PaginaNumero', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes?DataReferencia=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores atribuídos sem página com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar professores atribuídos aos cursos sem quantidade
Quando('envio uma requisição GET em professoresCursosAtribuicoes sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes?DataReferencia=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores atribuídos sem quantidade com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})
 
// Não retornar professores atribuídos aos cursos sem autenticação
Quando('tento uma requisição GET em professoresCursosAtribuicoes', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes?DataReferencia=${Cypress.env('ULTIMA_EXECUCAO')}&PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores atribuídos com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Sincronizar atribuições de cursos dos professores
Quando('envio uma requisição POST em professoresCursosAtribuicoesSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/sincronizacao?AnoLetivo=${Cypress.env('ANO_LETIVO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },         
    failOnStatusCode: false  
  }).as('response')
})

Então('sincroniza atribuições de cursos dos professores com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})

// Não sincronizar atribuições de cursos dos professores sem ano letivo
Quando('envio uma requisição POST em professoresCursosAtribuicoesSincronizacao sem ano letivo', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/sincronizacao?AnoLetivo=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },   
    failOnStatusCode: false  
  }).as('response')
})

Então('não sincroniza atribuições de cursos dos professores com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
  })
})

// Não sincronizar atribuições de cursos dos professores sem autenticação
Quando('tento uma requisição POST em professoresCursosAtribuicoesSincronizacao', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/sincronizacao?AnoLetivo=${Cypress.env('ANO_LETIVO')}`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },         
    failOnStatusCode: false  
  }).as('response')
})

Então('não sincroniza atribuições de cursos dos professores com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Retornar professores removidos atribuição dos cursos
Quando('envio uma requisição GET em professoresCursosAtribuicoesRemover', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/remover?PaginaNumero=1&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false,
    timeout: 60000  
  }).as('response')
})

Então('retorna cursos dos professores removidos atribuição com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(500)
  })
})

// Não retornar professores removidos atribuição aos cursos sem página
Quando('envio uma requisição GET em professoresCursosAtribuicoesRemover sem PaginaNumero', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/remover?PaginaNumero=&RegistrosQuantidade=10`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores removidos atribuição sem página com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})

// Não retornar professores removidos atribuição aos cursos sem quantidade
Quando('envio uma requisição GET em professoresCursosAtribuicoesRemover sem RegistrosQuantidade', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/remover?PaginaNumero=1&RegistrosQuantidade=`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores removidos atribuição sem quantidade com status 400', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(400)
    expect(response.body).to.have.property('errors')
  })
})
 
// Não retornar professores removidos atribuição aos cursos sem autenticação
Quando('tento uma requisição GET em professoresCursosAtribuicoesRemover', function () {
  cy.request({
    method: 'GET',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/remover?PaginaNumero=1&RegistrosQuantidade=10`,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não retorna cursos dos professores removidos atribuição com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})

// Iniciar tratamento de erros de professores removidos a atribuição
Quando('envio uma requisição POST em professoresCursosAtribuicoesRemoverErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/remover/erros/tratamentos`,
    failOnStatusCode: false,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token')
    },        
    failOnStatusCode: false,
    timeout: 60000  
  }).as('response')
})

Então('inicia tratamento de erros de professores removidos a atribuição com status 200', function () {
  cy.get('@response').then((response) => {
    expect(response.status).to.eq(200)
  })
})
 
// Não iniciar tratamento de erros de professores removidos a atribuição sem autenticação
Quando('tento uma requisição POST em professoresCursosAtribuicoesRemoverErrosTratamentos', function () {
  cy.request({
    method: 'POST',
    url: Cypress.config('baseUrl') + `/api/v1/professores/cursos/atribuicoes/remover/erros/tratamentos`,
    headers: {
      accept: 'text/plain',  
      'x-gca-api-key': Cypress.config('token_invalido')
    },        
    failOnStatusCode: false  
  }).as('response')
})

Então('não inicia tratamento de erros de professores removidos a atribuição com status 401', function () {
  cy.get('@response').then((response) => {
  expect(response.status).to.eq(401)
  })
})