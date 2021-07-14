CREATE TABLE if not exists public.curso_usuario_removido_gsa (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	curso_id int8 NULL,
	usuario_tipo int NOT NULL,
	removido_em timestamp NOT NULL,
	CONSTRAINT curso_usuario_removido_gsa_pk PRIMARY KEY (id)
);

ALTER TABLE public.curso_usuario_removido_gsa ADD constraint curso_usuario_removido_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);
ALTER TABLE public.curso_usuario_removido_gsa ADD constraint curso_usuario_removido_cursos_fk FOREIGN KEY (curso_id) REFERENCES cursos(id);

CREATE TABLE if not exists  public.curso_usuario_removido_gsa_erro (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	curso_id int8 NULL,
	mensagem text NOT NULL,
	execucao_tipo int NOT NULL,
	data_inclusao timestamp NOT NULL,
	CONSTRAINT curso_usuario_removido_gsa_erro_pk PRIMARY KEY (id)
);

ALTER TABLE public.curso_usuario_removido_gsa_erro ADD constraint curso_usuario_removido_gsa_erro_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);
ALTER TABLE public.curso_usuario_removido_gsa_erro ADD constraint curso_usuario_removido_gsa_erro_cursos_fk FOREIGN KEY (curso_id) REFERENCES cursos(id);
