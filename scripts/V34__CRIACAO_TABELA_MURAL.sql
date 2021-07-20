DROP TABLE IF EXISTS public.avisos;

CREATE TABLE public.avisos
(
    id            INT8 		   NOT NULL,
    texto         VARCHAR 	   NOT NULL,
    usuario_id    INT8         NOT NULL,
    curso_id      INT8         NOT NULL,
    data_inclusao TIMESTAMP    NOT NULL,
    data_alteracao TIMESTAMP   NULL
);

ALTER TABLE public.avisos
    ADD CONSTRAINT avisos_pk
        PRIMARY KEY (id);

ALTER TABLE public.avisos
    ADD CONSTRAINT avisos_curso_fk
        FOREIGN KEY (curso_id)
            REFERENCES cursos (id);

ALTER TABLE public.avisos
    ADD CONSTRAINT avisos_usuario_fk
        FOREIGN KEY (usuario_id)
            REFERENCES usuarios (indice);

create index avisos_curso_id_idx
    on avisos (curso_id);

create index avisos_usuario_id_idx
    on avisos (usuario_id);
