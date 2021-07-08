-- DROP TABLE public.aluno_inativo_erro;

CREATE TABLE if not exists  public.aluno_inativo_erro (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	mensagem text NOT NULL,
	execucao_tipo int NOT NULL,
	data_inclusao timestamp NOT NULL,
	CONSTRAINT aluno_inativo_erro_pk PRIMARY KEY (id)
);

ALTER TABLE public.aluno_inativo_erro ADD constraint aluno_inativo_erro_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);