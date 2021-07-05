
pipeline {
    environment {
      branchname =  env.BRANCH_NAME.toLowerCase()
      registryCredential = 'regsme'
      imagename = "registry.sme.prefeitura.sp.gov.br/${env.branchname}/sme-sigpae-api"
      kubeconfig = "${env.branchname == 'main' ? 'config_dev' : 'config_hom'}"
      imagetag = "${env.branchname == 'main' ? 'latest' : 'release'}"
    }
  
    agent {
      node {
        label 'python-36-rc'
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

        stage('AmbienteTestes') {
            agent {
                label 'master'
            }
            steps {
                script {
                    CONTAINER_ID = sh (script: 'docker ps -q --filter "name=terceirizadas-db"',returnStdout: true).trim()
                    if (CONTAINER_ID) {
                        sh "echo nome é: ${CONTAINER_ID}"
                        sh "docker rm -f ${CONTAINER_ID}"
                        sh 'docker run -d --rm --cap-add SYS_TIME --name terceirizadas-db --network python-network -p 5432 -e TZ="America/Sao_Paulo" -e POSTGRES_DB=terceirizadas -e POSTGRES_PASSWORD=adminadmin -e POSTGRES_USER=postgres postgres:9-alpine'
                    } 
                    else {
                        sh 'docker run -d --rm --cap-add SYS_TIME --name terceirizadas-db --network python-network -p 5432 -e TZ="America/Sao_Paulo" -e POSTGRES_DB=terceirizadas -e POSTGRES_PASSWORD=adminadmin -e POSTGRES_USER=postgres postgres:9-alpine'
                    }
                }
            }
        }
        
        stage('Testes') {
          when { branch 'homolog' }
          steps {
             sh 'pip install --user pipenv'
             sh 'pipenv install --dev'
             sh 'pipenv run pytest'
             sh 'pipenv run flake8'
          }
          post {
            success{
              //  Publicando arquivo de cobertura
              publishCoverage adapters: [coberturaAdapter('coverage.xml')], sourceFileResolver: sourceFiles('NEVER_STORE')
            }
          }
        }

        stage('AnaliseCodigo') {
	      when { branch 'homolog' }
          steps {
            sh 'echo "[ INFO ] Iniciando analise Sonar..." && sonar-scanner \
              -Dsonar.projectKey=SME-Terceirizadas \
              -Dsonar.sources=. \
              -Dsonar.host.url=http://sonar.sme.prefeitura.sp.gov.br \
              -Dsonar.login=0d279825541065cf66a60cbdfe9b8a25ec357226'
          }
        }

        stage('Build') {
          when { anyOf { branch 'main'; branch "story/*"; branch 'development'; branch 'release';  } } 
          steps {
            sh 'echo build docker image desenvolvimento'
            script {
                dockerImage = docker.build imagename
                    docker.withRegistry( '', registryCredential ) {
                        dockerImage.push(imagetag)
                    }
            }
            sh "docker rmi $imagename:$imagetag"
          }
        }
	    
        stage('Deploy'){
            when { anyOf { branch 'main'; branch "story/*"; branch 'development'; branch 'release';  } }        
            steps {
                script{
	            withCredentials([file(credentialsId: "${kubeconfig}", variable: 'config')]){
                      sh('cp $config '+"$home"+'/.kube/config')
                      sh( 'kubectl get nodes')
                      sh('rm -f '+"$home"+'/.kube/config')
                    }
                }
            }           
        }    
    }

  post {
    always {
      echo 'One way or another, I have finished'
    }
    success {
      sendTelegram("${JOB_NAME}...O Build ${BUILD_DISPLAY_NAME} - Esta ok !!!\n Consulte o log para detalhes -> [Job logs](${env.BUILD_URL}console)\n\n Uma nova versão da aplicação esta disponivel!!!")
    }
    unstable {
      sendTelegram("O Build ${BUILD_DISPLAY_NAME} <${env.BUILD_URL}> - Esta instavel ...\nConsulte o log para detalhes -> [Job logs](${env.BUILD_URL}console)")
    }
    failure {
      sendTelegram("${JOB_NAME}...O Build ${BUILD_DISPLAY_NAME}  - Quebrou. \nConsulte o log para detalhes -> [Job logs](${env.BUILD_URL}console)")
    }
    changed {
      echo 'Things were different before...'
    }
    aborted {
      sendTelegram ("O Build ${BUILD_DISPLAY_NAME} - Foi abortado.\nConsulte o log para detalhes -> [Job logs](${env.BUILD_URL}console)")
    }
  }
}
    def sendTelegram(message) {
        def encodedMessage = URLEncoder.encode(message, "UTF-8")

        withCredentials([string(credentialsId: 'telegramToken', variable: 'TOKEN'),
        string(credentialsId: 'telegramChatId', variable: 'CHAT_ID')]) {

            response = httpRequest (consoleLogResponseBody: true,
                    contentType: 'APPLICATION_JSON',
                    httpMode: 'GET',
                    url: "https://api.telegram.org/bot$TOKEN/sendMessage?text=$encodedMessage&chat_id=$CHAT_ID&disable_web_page_preview=true",
                    validResponseCodes: '200')
            return response
        }
    }
