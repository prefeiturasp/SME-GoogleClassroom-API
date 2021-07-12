DROP TABLE IF EXISTS public.atividades;

CREATE TABLE public.atividades
(
    id            INT8 		   NOT NULL,
    titulo        VARCHAR 	   NOT NULL,
    descricao     VARCHAR 	   NOT NULL,
    usuario_id    INT8         NOT NULL,
    curso_id      INT8         NOT NULL,
    data_inclusao TIMESTAMP    NOT NULL,
    data_alteracao TIMESTAMP   NULL
);

ALTER TABLE public.atividades
    ADD CONSTRAINT atividades_pk
        PRIMARY KEY (id);

ALTER TABLE public.atividades
    ADD CONSTRAINT atividades_curso_fk
        FOREIGN KEY (curso_id)
            REFERENCES cursos (id);

ALTER TABLE public.avisos
    ADD CONSTRAINT atividades_usuario_fk
        FOREIGN KEY (usuario_id)
            REFERENCES usuarios (indice);

create index atividades_curso_id_idx
    on avisos (curso_id);

create index atividades_usuario_id_idx
    on avisos (usuario_id);