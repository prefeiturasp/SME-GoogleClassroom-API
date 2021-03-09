pipeline {
    agent {
      node { 
        label 'dotnet5-sdk'
	    }
    }
    
    options {
      buildDiscarder(logRotator(numToKeepStr: '5', artifactNumToKeepStr: '5'))
      disableConcurrentBuilds()
      skipDefaultCheckout()  
    }
           
    stages {
       stage('CheckOut') {
        steps {
          checkout scm	
        }
       }

       stage('Build projeto') {
        steps {
          sh "echo executando build de projeto"
          sh 'dotnet build sme.gclass.api.worker.rabbit/'
        }
      }

       stage('Analise Codigo') {
          when {
                branch 'release'
            }
         steps {
             sh 'echo Analise SonarQube API'
             sh 'dotnet-sonarscanner begin /k:"SME-GoogleClassroom-API" /d:sonar.host.url="http://sonar.sme.prefeitura.sp.gov.br" /d:sonar.login="5372148e28da7a141a6a553951a6cfd26ed8e9ee"'
             sh 'dotnet build sme.gclass.api.worker.rabbit/'
             sh 'dotnet-sonarscanner end /d:sonar.login="5372148e28da7a141a6a553951a6cfd26ed8e9ee"'
           
         }
       }

      stage('Docker build DEV') {
         when {
           branch 'development'
         }
        steps {
          sh 'echo build docker image desenvolvimento'
          // Start JOB para build das imagens Docker e push SME Registry
          script {
            step([$class: "RundeckNotifier",
              includeRundeckLogs: true,
              jobId: "e09dffde-f46f-454e-bbac-18d7d23c7f1c",
              nodeFilters: "",
              //options: """
              //     PARAM_1=value1
               //    PARAM_2=value2
              //     PARAM_3=
              //     """,
              rundeckInstance: "Rundeck-SME",
              shouldFailTheBuild: true,
              shouldWaitForRundeckJob: true,
              tags: "",
              tailLog: true])
           }
          }       
        } 
       
        stage('Deploy DEV') {
          when {
            branch 'development'
          }
        steps {
           //Start JOB de deploy Kubernetes 
          sh 'echo Deploy ambiente desenvolvimento'
          script {
            step([$class: "RundeckNotifier",
              includeRundeckLogs: true,
              jobId: "2692b141-52ba-4ab8-bc4f-47fc2d63f7bb",
              nodeFilters: "",
              //options: """
              //     PARAM_1=value1
               //    PARAM_2=value2
              //     PARAM_3=
              //     """,
              rundeckInstance: "Rundeck-SME",
              shouldFailTheBuild: true,
              shouldWaitForRundeckJob: true,
              tags: "",
              tailLog: true])
          }
        } 
       }
       
      stage('Docker build HOM') {
         when {
           branch 'release'
         }
        steps {
          sh 'echo Deploying ambiente homologacao'    
          // Start JOB para build das imagens Docker e push SME Registry
          script {
            step([$class: "RundeckNotifier",
              includeRundeckLogs: true,
                             
              //JOB DE BUILD
              jobId: "e32aa29a-2b26-4d00-9c0e-30dc42d1cde2",
              nodeFilters: "",
              //options: """
              //     PARAM_1=value1
               //    PARAM_2=value2
              //     PARAM_3=
              //     """,
              rundeckInstance: "Rundeck-SME",
              shouldFailTheBuild: true,
              shouldWaitForRundeckJob: true,
              tags: "",
              tailLog: true])
          }
        }
      }  

      stage('Deploy HOM') {
         when {
           branch 'release'
         }
        steps {
          //Start JOB deploy Kubernetes 
            timeout(time: 24, unit: "HOURS") {
            input message: 'Deseja realizar o deploy?', ok: 'SIM', submitter: 'marlon_goncalves, bruno_alevato, marcos_costa, rafael_losi, carlos_dias'
            }
          script {
            step([$class: "RundeckNotifier",
              includeRundeckLogs: true,
              jobId: "cda51939-84b0-4f7e-a11c-574c987b4896",
              nodeFilters: "",
              //options: """
              //     PARAM_1=value1
               //    PARAM_2=value2
              //     PARAM_3=
              //     """,
              rundeckInstance: "Rundeck-SME",
              shouldFailTheBuild: true,
              shouldWaitForRundeckJob: true,
              tags: "",
              tailLog: true])
          }
        }
       }

       stage('Docker build PROD') {
         when {
           branch 'master'
         }
        steps {
            sh 'echo Build image docker Produção'
            // Start JOB para build das imagens Docker e push SME Registry
      
          script {
            step([$class: "RundeckNotifier",
              includeRundeckLogs: true,
                             
              //JOB DE BUILD
              jobId: "b7035310-22e7-4ab5-93f7-acfa562d02f0",
              nodeFilters: "",
              //options: """
              //     PARAM_1=value1
               //    PARAM_2=value2
              //     PARAM_3=
              //     """,
              rundeckInstance: "Rundeck-SME",
              shouldFailTheBuild: true,
              shouldWaitForRundeckJob: true,
              tags: "",
              tailLog: true])
          }
        }
       }

       stage('Deploy PROD') {
         when {
           branch 'master'
         }
        steps {
            timeout(time: 24, unit: "HOURS") {
            input message: 'Deseja realizar o deploy?', ok: 'SIM', submitter: 'marlon_goncalves, bruno_alevato, marcos_costa, rafael_losi, carlos_dias'
          }    
          //Start JOB deploy kubernetes 
         
          script {
            step([$class: "RundeckNotifier",
              includeRundeckLogs: true,
              jobId: "907ea1f6-a4de-4669-ad12-cac567a34a42",
              nodeFilters: "",
              //options: """
              //     PARAM_1=value1
              //    PARAM_2=value2
              //     PARAM_3=
              //     """,
              rundeckInstance: "Rundeck-SME",
              shouldFailTheBuild: true,
              shouldWaitForRundeckJob: true,
              tags: "",
              tailLog: true])
          }
        }
       }
    } 
}
