DROP TABLE IF EXISTS public.notas;

CREATE TABLE public.notas
(
    id            INT8 		   NOT NULL,
    atividade_id  INT8		   NOT NULL,
    usuario_gsa_id VARCHAR 	   NOT NULL,
	situacao 	  VARCHAR 	   NOT NULL,
	nota		  NUMERIC(5,2) NULL,
    data_inclusao TIMESTAMP    NOT NULL,
    data_alteracao TIMESTAMP   NULL
);

ALTER TABLE public.notas
    ADD CONSTRAINT notas_pk
        PRIMARY KEY (id);

ALTER TABLE public.notas
    ADD CONSTRAINT notas_atividade_fk
        FOREIGN KEY (atividade_id)
            REFERENCES atividades (id);

create index notas_atividade_idx
    on notas (atividade_id);

