create table if not exists public.usuario_comparativo(
    id varchar(20) not null,
    nome varchar(200) NOT NULL,
    email varchar(200) NOT NULL,
	data_inclusao timestamp NOT NULL,
	data_ultimo_login timestamp NULL,
	eh_admin boolean not null default false,
	organization_path varchar(200) NOT NULL,
	
	CONSTRAINT usuario_comparativo_pk PRIMARY KEY (id)
);

create table if not exists public.curso_comparativo(
    id varchar(20) not null,
    nome varchar(200) NOT NULL,
    secao varchar(200) NOT NULL,
    criador_id varchar(20) not null,
    descricao varchar(200) NOT NULL,
	data_inclusao timestamp NOT NULL,
	
	CONSTRAINT curso_comparativo_pk PRIMARY KEY (id)
);

ALTER TABLE public.curso_comparativo ADD constraint curso_comparativo_usuario_fk FOREIGN KEY (criador_id) REFERENCES usuario_comparativo(id);

create table if not exists public.usuario_curso_comparativo(
	usuario_id varchar(20) not null,
	curso_id varchar(20) not null
);

ALTER TABLE public.usuario_curso_comparativo ADD constraint curso_usuario_comparativo_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuario_comparativo(id);
ALTER TABLE public.usuario_curso_comparativo ADD constraint curso_usuario_comparativo_curso_fk FOREIGN KEY (curso_id) REFERENCES curso_comparativo(id);