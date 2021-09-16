CREATE TABLE if not exists public.usuario_inativo(
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	usuario_id int8 NULL,
	usuario_tipo int NOT NULL,
	inativado_em timestamp NOT NULL,
	CONSTRAINT usuario_inativo_pk PRIMARY KEY (id)
);

ALTER TABLE public.usuario_inativo ADD constraint usuario_inativo_usuarios_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);

CREATE INDEX usuario_inativo_idx ON public.usuario_inativo USING btree (usuario_id);