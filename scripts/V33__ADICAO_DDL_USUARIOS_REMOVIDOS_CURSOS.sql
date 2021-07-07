--DROP TABLE public.usuario_curso_removido_gsa;

CREATE TABLE if not exists public.usuario_curso_removido_gsa (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	curso_id int8 NULL,
	usuario_tipo int NOT NULL,
	removido_em timestamp NOT NULL,
	CONSTRAINT usuario_curso_removido_gsa_pk PRIMARY KEY (id)
);

ALTER TABLE public.usuario_curso_removido_gsa ADD constraint usuario_curso_removido_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);
ALTER TABLE public.usuario_curso_removido_gsa ADD constraint usuario_curso_removido_cursos_fk FOREIGN KEY (curso_id) REFERENCES cursos(id);


-- DROP TABLE public.usuario_curso_removido_gsa_erro;

CREATE TABLE if not exists  public.usuario_curso_removido_gsa_erro (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	curso_id int8 NULL,
	mensagem text NOT NULL,
	execucao_tipo int NOT NULL,
	data_inclusao timestamp NOT NULL,
	CONSTRAINT usuario_curso_removido_gsa_erro_pk PRIMARY KEY (id)
);

ALTER TABLE public.usuario_curso_removido_gsa_erro ADD constraint usuario_curso_removido_gsa_erro_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);
ALTER TABLE public.usuario_curso_removido_gsa_erro ADD constraint usuario_curso_removido_gsa_erro_cursos_fk FOREIGN KEY (curso_id) REFERENCES cursos(id);
