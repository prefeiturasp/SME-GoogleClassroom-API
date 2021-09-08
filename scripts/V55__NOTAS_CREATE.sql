DROP TABLE IF EXISTS public.notas;

CREATE TABLE public.notas
(
    id            varchar(50)  NOT NULL,
    atividade_id  INT8         NOT NULL,
    usuario_id    INT8         NOT NULL,
	nota 		  NUMERIC(5,2) NULL,
	status		  INT4		   NOT NULL,
    data_importacao TIMESTAMP  NOT NULL,
    data_inclusao TIMESTAMP    NOT NULL,
    data_alteracao TIMESTAMP   NULL,
	CONSTRAINT 	  notas_pk PRIMARY KEY (id)
);

ALTER TABLE public.notas ADD CONSTRAINT notas_atividades_fk FOREIGN KEY (atividade_id) REFERENCES atividades (id);

ALTER TABLE public.notas ADD CONSTRAINT notas_usuario_fk FOREIGN KEY (usuario_id) REFERENCES usuarios (indice);
			
create index notas_atividade_id_idx on notas (atividade_id);	

create index notas_usuario_id_idx on notas (usuario_id);
