-- public.tipo_execucao definition

-- Drop table

-- DROP TABLE public.tipo_execucao;

CREATE TABLE public.tipo_execucao (
	id int8 NOT NULL,
	descricao varchar(30) NOT NULL,
	CONSTRAINT tipo_execucao_pk PRIMARY KEY (id),
	CONSTRAINT tipo_execucao_un UNIQUE (descricao)
);

insert into tipo_execucao values (1, 'Usuários Adicionar');
insert into tipo_execucao values (2, 'Usuários Arquivar');
insert into tipo_execucao values (3, 'Cursos Adicionar');
insert into tipo_execucao values (4, 'Cursos Arquivar');

-- public.controle_execucao definition

-- Drop table

-- DROP TABLE public.controle_execucao;

CREATE TABLE public.controle_execucao (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	tipo_execucao_id int8 NOT NULL,
	ultima_execucao date NOT NULL,
	CONSTRAINT controle_execucao_pk PRIMARY KEY (id)
);


-- public.controle_execucao foreign keys

ALTER TABLE public.controle_execucao ADD constraint controle_execucao_tipo_execucao_fk FOREIGN KEY (tipo_execucao_id) REFERENCES tipo_execucao(id);

-- public.tipo_usuario definition

-- Drop table

-- DROP TABLE public.tipo_usuario;

CREATE TABLE public.tipo_usuario (
	id int8 NOT NULL,
	descricao varchar(30) NOT NULL,
	CONSTRAINT tipo_usuario_pk PRIMARY KEY (id),
	CONSTRAINT tipo_usuario_un UNIQUE (descricao)
);

insert into tipo_usuario values (1, 'Professor');
insert into tipo_usuario values (2, 'Aluno');
insert into tipo_usuario values (3, 'Funcionário');

-- public.usuario definition

-- Drop table

-- DROP TABLE public.usuario;

CREATE TABLE public.usuario (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	tipo_usuario_id int8 NOT NULL,
	email varchar(200) NOT NULL,
	organization_path varchar(200) NOT NULL,
	CONSTRAINT usuario_pk PRIMARY KEY (id)
);


-- public.usuario foreign keys

ALTER TABLE public.usuario ADD constraint usuario_tipo_fk FOREIGN KEY (tipo_usuario_id) REFERENCES tipo_usuario(id);

-- public.cargo definition

-- Drop table

-- DROP TABLE public.cargo;

CREATE TABLE public.cargo (
	usuario_id int8 NOT NULL,
	cargo_base int NOT NULL,
	cargo_sobreposto int NULL,
	funcao_atividade int NULL
);

-- public.cargo foreign keys

ALTER TABLE public.cargo ADD constraint cargo_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- public.curso definition

-- Drop table

-- DROP TABLE public.curso;

CREATE TABLE public.curso (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	id_google int8 NOT NULL,
	email varchar(200) NOT NULL,
	nome varchar(200) NOT NULL,
	secao varchar(200) NOT NULL,
	turma_id int NOT NULL,
	componente_curricular_id int8 NOT NULL,
	CONSTRAINT curso_pk PRIMARY KEY (id)
);

-- public.curso_usuario definition

-- Drop table

-- DROP TABLE public.curso_usuario;

CREATE TABLE public.curso_usuario (
	curso_id int8 NOT NULL,
	usuario_id int8 NOT NULL
);

ALTER TABLE public.curso_usuario ADD constraint curso_usuario_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuario(id);
ALTER TABLE public.curso_usuario ADD constraint curso_usuario_curso_fk FOREIGN KEY (curso_id) REFERENCES curso(id);