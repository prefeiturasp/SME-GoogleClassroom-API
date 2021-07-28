drop table IF EXISTS public.cursos_arquivado;
create table public.cursos_arquivado
(
    id                INT8                 NOT NULL GENERATED ALWAYS AS IDENTITY,
    curso_id          INT8                 NOT NULL,
    data_arquivamento TIMESTAMP            NOT NULL,
    data_extincao 	  TIMESTAMP            NOT NULL,
    extinto           BOOLEAN DEFAULT FALSE NOT NULL
);


ALTER TABLE public.cursos_arquivado
    ADD CONSTRAINT cursos_arquivado_pk
        PRIMARY KEY (id);

ALTER TABLE public.cursos_arquivado
    ADD CONSTRAINT cursos_arquivado_curso_fk
        FOREIGN KEY (curso_id)
            REFERENCES cursos (id);

create index cursos_arquivado_curso_id_idx
    on cursos_arquivado (curso_id);
