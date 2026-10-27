import { defineConfig } from 'cypress'
import allureWriter from '@shelex/cypress-allure-plugin/writer.js'
import { cloudPlugin } from 'cypress-cloud/plugin'
import dotenv from 'dotenv'
import cucumber from 'cypress-cucumber-preprocessor'
import babelify from 'babelify'
import fs from 'fs'
import FormData from 'form-data'
import axios from 'axios'

dotenv.config()

export default defineConfig({
  e2e: {
    watchForFileChanges: true,
    baseUrl: 'https://hom-gcasync.sme.prefeitura.sp.gov.br',
    usuario: process.env.USUARIO,   
    senha: process.env.SENHA,
    token: process.env.TOKEN,
    token_invalido: process.env.TOKEN_INVALIDO,
    supportFile: 'cypress/support/e2e.js',
    viewportWidth: 1920,
    viewportHeight: 1080,
    video: false,
    retries: { runMode: 2, openMode: 0 },
    screenshotOnRunFailure: false,
    chromeWebSecurity: false,
    experimentalRunAllSpecs: true,
    failOnStatusCode: false,

    specPattern: ['cypress/e2e/**/*.feature'],

    defaultCommandTimeout: 60000,
    requestTimeout: 60000,
    execTimeout: 60000,
    pageLoadTimeout: 60000,
    waitForAnimations: true,
    animationDistanceThreshold: 5,

    async setupNodeEvents(on, config) {
      allureWriter(on, config)

      on('file:preprocessor', cucumber.default({
        browserifyOptions: {
          transform: [[babelify.configure({
            sourceType: 'module',
            plugins: ['@babel/plugin-transform-modules-commonjs'],
          }), { global: true }]],
        },
      }))

      on('task', {
        async uploadFile({ method = 'POST', url, headers = {}, filePath }) {
          const form = new FormData()

          if (filePath && filePath.trim() !== '') {
            form.append('file', fs.createReadStream(filePath))
          }

          const response = await axios({
            method,
            url,
            headers: { ...headers, ...form.getHeaders() },
            data: form,
            maxBodyLength: Infinity,
            validateStatus: () => true,
          })

          return { status: response.status, body: response.data }
        },
      })

      const envKeys = [
        'TOKEN',
        'TOKEN_INVALIDO',
        'CODIGO_DRE',
        'SIGLA_TIPO_ESCOLA',
      ]

      const customVariable = Object.fromEntries(
        envKeys.map((key) => [key, process.env[key] ?? ''])
      )

      config.env = { ...config.env, ...customVariable }

      const enhancedConfig = await cloudPlugin(on, config)

      return enhancedConfig
    },
  },
})