ALTER TABLE public.cursos_usuarios 
    ADD column if not exists data_inclusao timestamp NOT NULL,
	ADD column if not exists data_atualizacao timestamp NULL,
    ADD column if not exists excluido boolean not null default false,
    ADD CONSTRAINT cursos_usuarios_pk PRIMARY KEY (id);

