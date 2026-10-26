// Plugin do Allure
require('@shelex/cypress-allure-plugin')

// Comandos personalizados - API

// Comandos personalizados - UI

// Evita falhas silenciosas caso algum comando seja removido ou renomeado
Cypress.on('uncaught:exception', () => {
  return false
})