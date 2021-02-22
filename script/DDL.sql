-- public.controle_execucao definition

-- Drop table

-- DROP TABLE public.controle_execucao;

CREATE TABLE public.controle_execucao (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	tipo_execucao_id int NOT NULL,
	ultima_execucao date NOT NULL,
	CONSTRAINT controle_execucao_pk PRIMARY KEY (id)
);

-- public.usuario definition

-- Drop table

-- DROP TABLE public.usuario;

CREATE TABLE public.usuario (
	documento varchar(30) NOT NULL,
	tipo_usuario_id int NOT NULL,
	email varchar(200) NOT NULL,
	organization_path varchar(200) NOT NULL,
	CONSTRAINT usuario_pk PRIMARY KEY (documento)
);

-- public.usuario_cargo definition

-- Drop table

-- DROP TABLE public.usuario_cargo;

CREATE TABLE public.usuario_cargo (
	usuario_id int8 NOT NULL,
	cargo_base int NOT NULL,
	cargo_sobreposto int NULL,
	funcao_atividade int NULL
);

-- public.usuario_cargo foreign keys

ALTER TABLE public.usuario_cargo ADD constraint usuario_cargo_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuario(id);

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
	CONSTRAINT curso_pk PRIMARY KEY (id),
	CONSTRAINT curso_unique UNIQUE (turma_id, componente_curricular_id)
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