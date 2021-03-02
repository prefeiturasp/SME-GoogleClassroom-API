
-- public.execucao_controle definition

-- Drop table

-- DROP TABLE public.execucao_controle;

CREATE TABLE public.execucao_controle (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	execucao_tipo int NOT NULL,
	ultima_execucao timestamp NOT NULL,
	CONSTRAINT execucao_controle_pk PRIMARY KEY (id)
);

-- public.usuarios definition

-- Drop table

-- DROP TABLE public.usuarios;

CREATE TABLE public.usuarios (
	id int8 NOT NULL,
	usuario_tipo int NOT NULL,
	email varchar(200) NOT NULL,
	organization_path varchar(200) NOT NULL,
	data_inclusao timestamp NOT NULL,
	data_atualizacao timestamp NULL,
	CONSTRAINT usuario_pk PRIMARY KEY (id)
);

-- public.usuarios_erro definition

-- Drop table

-- DROP TABLE public.usuarios_erro;

CREATE TABLE public.usuarios_erro (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	email varchar(200) NOT NULL,
	mensagem text NOT NULL,
	usuario_tipo int NOT NULL,
	execucao_tipo int NOT NULL,
	data_inclusao timestamp NOT NULL,
	CONSTRAINT usuarios_erro_pk PRIMARY KEY (id)
);

ALTER TABLE public.usuarios_erro ADD constraint usuarios_erro_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(id);

-- public.usuarios_cargos definition

-- Drop table

-- DROP TABLE public.usuarios_cargos;

CREATE TABLE public.usuarios_cargos (
	usuario_id int8 NOT NULL,
	cargo_base int NOT NULL,
	cargo_sobreposto int NULL,
	funcao_atividade int NULL
);

-- public.usuarios_cargos foreign keys

ALTER TABLE public.usuarios_cargos ADD constraint usuarios_cargos_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(id);

-- public.cursos definition

-- Drop table

-- DROP TABLE public.cursos;

CREATE TABLE public.cursos (
	id int8 NOT NULL,
	email varchar(200) NOT NULL,
	nome varchar(200) NOT NULL,
	secao varchar(200) NOT NULL,
	turma_id int NOT NULL,
	componente_curricular_id int NOT NULL,
	data_inclusao timestamp NOT NULL,
	data_atualizacao timestamp NULL,
	CONSTRAINT cursos_pk PRIMARY KEY (id),
	CONSTRAINT cursos_unique UNIQUE (turma_id, componente_curricular_id)
);

-- public.cursos_usuarios definition

-- Drop table

-- DROP TABLE public.cursos_usuarios;

CREATE TABLE public.cursos_usuarios (
	curso_id int8 NOT NULL,
	usuario_id int8 NOT NULL
);

ALTER TABLE public.cursos_usuarios ADD constraint cursos_usuarios_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(id);
ALTER TABLE public.cursos_usuarios ADD constraint cursos_usuarios_curso_fk FOREIGN KEY (curso_id) REFERENCES cursos(id);

-- public.cursos_erro definition

-- Drop table

-- DROP TABLE public.cursos_erro;

CREATE TABLE public.cursos_erro (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	turma_id int NOT NULL,
	componente_curricular_id int NOT NULL,
	mensagem text NOT NULL,
	execucao_tipo int NOT NULL,
	curso_id int8 NULL,
	data_inclusao timestamp NOT NULL,
	tipo int not null,
	CONSTRAINT cursos_erro_pk PRIMARY KEY (id)
);

ALTER TABLE public.cursos_erro ADD constraint cursos_erro_curso_fk FOREIGN KEY (curso_id) REFERENCES cursos(id);

-- public.acessos_google definition

-- Drop table

-- DROP TABLE public.acessos_google;

CREATE TABLE public.acessos_google (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	aplicacao_nome varchar(100) NOT NULL,
	email_conta_servico varchar(200) NOT NULL,
	email_admin varchar(200) NOT NULL,
	private_key varchar(2000) NOT NULL,
	CONSTRAINT acessos_google_pk PRIMARY KEY (id)
);



insert into execucao_controle 
(execucao_tipo, ultima_execucao)values(1, '2021-02-20');

insert into execucao_controle 
(execucao_tipo, ultima_execucao)values(2, '2021-02-20');