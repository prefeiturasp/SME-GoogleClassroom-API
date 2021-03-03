delete from public.cursos_usuarios;
alter table public.cursos_usuarios drop constraint if exists cursos_usuarios_usuario_fk;

drop table public.usuarios_cargos;

delete from public.usuarios_erro;
alter table public.usuarios_erro drop constraint if exists usuarios_erro_usuario_fk;

drop table public.usuarios;

CREATE TABLE public.usuarios (
	indice int8 NOT NULL GENERATED ALWAYS AS identity,
	id int8 NOT NULL,
	usuario_tipo int NOT NULL,
	email varchar(200) NOT NULL,
	organization_path varchar(200) NOT NULL,
	data_inclusao timestamp NOT NULL,
	data_atualizacao timestamp NULL,
	CONSTRAINT usuario_pk PRIMARY KEY (indice),
	CONSTRAINT usuario_uk UNIQUE (id,usuario_tipo)
);


ALTER TABLE public.usuarios_erro ADD constraint usuarios_erro_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);
ALTER TABLE public.cursos_usuarios ADD constraint cursos_usuarios_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuarios(indice);

