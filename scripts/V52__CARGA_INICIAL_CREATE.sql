drop table IF EXISTS public.carga_inicial;
create table public.carga_inicial
(
    id          INT8        NOT NULL GENERATED ALWAYS AS IDENTITY,
    ano			INT4		NOT NULL,
    tipos_ue 	varchar		NULL,
    ues 		varchar		NULL,
    turmas 		varchar		NULL,
    criado_em 	TIMESTAMP	NOT NULL
);

create index carga_inicial_ano_idx
    on carga_inicial (ano);
