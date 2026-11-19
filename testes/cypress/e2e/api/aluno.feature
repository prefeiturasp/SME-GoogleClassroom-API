# language: pt

Funcionalidade: API - Aluno

  Cenário: Retornar alunos do EOL que serão incluídos
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunosNovos
    Então retorna alunos do EOL que serão incluídos com status 200

  Cenário: Não retornar alunos do EOL incluídos sem data
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunosNovos sem data de execução
    Então não retorna alunos do EOL que serão incluídos com status 400

  Cenário: Não retornar alunos do EOL incluídos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em alunosNovos
    Então não retorna alunos do EOL incluídos com status 401

  Cenário: Retornar alunos já incluídos
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunos
    Então retorna alunos já incluídos com status 200

  Cenário: Não retornar alunos do EOL incluídos sem página e quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunos sem página e quantidade
    Então não retorna alunos já incluídos com status 400

  Cenário: Não retornar alunos já incluídos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em alunos
    Então não retorna alunos já incluídos com status 401

  Cenário: Inicia sincronização de alunos
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em alunosSincronizacao
    Então inicia sincronização de alunos com status 200

  Cenário: Não inicia sincronização de alunos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em alunosSincronizacao
    Então não inicia sincronização de alunos com status 401

  Cenário: Inicia tratamento da sincronização de alunos
    Dado que possuo um token de acesso
    Quando envio uma requisição POST em alunosErrosTratamentos
    Então inicia tratamento da sincronização de alunos com status 200

  Cenário: Não inicia tratamento da sincronização de alunos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição POST em alunosErrosTratamentos
    Então não inicia tratamento da sincronização de alunos com status 401

  Cenário: Retornar cursos do aluno que serão incluídos
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunosCursosNovos
    Então retorna cursos do aluno que serão incluídos com status 200

  Cenário: Não retornar cursos que serão incluídos sem aluno
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunosCursosNovos sem aluno
    Então não retorna cursos que serão incluídos sem aluno com status 400

  Cenário: Não retornar cursos do aluno que serão incluídos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em alunosCursosNovos
    Então não retorna cursos do aluno que serão incluídos com status 401

  Cenário: Retornar alunos com os cursos já incluídos
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunosCursos
    Então retorna cursos do aluno já incluídos com status 200

  Cenário: Não retornar alunos com os cursos já incluídos sem página e quantidade
    Dado que possuo um token de acesso
    Quando envio uma requisição GET em alunosCursos sem página e quantidade
    Então não retorna alunos com os cursos já incluídos sem página e quantidade com status 400

  Cenário: Não retornar alunos com os cursos já incluídos sem autenticação
    Dado que possuo um token de acesso
    Quando tento uma requisição GET em alunosCursos
    Então não retorna cursos do aluno que serão incluídos com status 401