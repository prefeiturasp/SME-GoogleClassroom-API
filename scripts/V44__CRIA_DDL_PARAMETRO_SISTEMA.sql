DROP TABLE IF EXISTS parametro_sistema;
create table parametro_sistema
(
    id           bigint generated always as identity,
    nome         varchar(50)          not null,
    tipo         integer              not null,
    descricao    varchar(200)         not null,
    valor        varchar(100)         not null,
    ano          integer              not null,
    ativo        boolean default true not null   
);


ALTER TABLE parametro_sistema
    ADD CONSTRAINT parametros_sistema_pk
        PRIMARY KEY (id);

create index parametro_sistema_tipo_id_idx
    on public.parametro_sistema (tipo);

create index parametro_sistema_ano_idx
    on public.parametro_sistema (ano);