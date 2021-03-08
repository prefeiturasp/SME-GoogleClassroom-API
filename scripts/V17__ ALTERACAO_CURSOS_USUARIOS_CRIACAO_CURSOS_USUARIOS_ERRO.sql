ALTER TABLE public.cursos_usuarios 
	ADD column if not exists id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
    ADD column if not exists data_inclusao timestamp NOT NULL,
	ADD column if not exists data_atualizacao timestamp NULL,
    ADD column if not exists excluido boolean not null default false,
    ADD CONSTRAINT cursos_usuarios_pk PRIMARY KEY (id); 



-- public.cursos_usuarios_erro definition

-- Drop table

-- DROP TABLE cursos_usuarios_erro;

CREATE TABLE public.cursos_usuarios_erro (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	rf int8 NULL,
    turma_id int8 NULL,
	componenteCurricular_id Null,	
	mensagem text NOT NULL,
	erro_tipo int NOT NULL,
	execucao_tipo int NOT NULL,
	data_inclusao timestamp NOT NULL,
	CONSTRAINT cursos_usuarios_erro_pk PRIMARY KEY (id)
);

