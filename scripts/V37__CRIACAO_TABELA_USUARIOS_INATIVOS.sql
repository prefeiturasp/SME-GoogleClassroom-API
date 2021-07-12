CREATE TABLE if not exists public.usuario_inativado_gsa (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	usuario_tipo int NOT NULL,
	removido_em timestamp NOT NULL,
	CONSTRAINT usuario_inativado_pk PRIMARY KEY (id)
);

ALTER TABLE public.usuario_inativado_gsa ADD constraint usuario_inativado_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);