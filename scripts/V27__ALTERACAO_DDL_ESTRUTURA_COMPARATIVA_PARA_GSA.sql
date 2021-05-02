alter table  public.curso_comparativo add if not exists inserido_manualmente_google BOOLEAN NULL;
ALTER TABLE public.cursos ADD if not exists existe_google boolean null;
alter table  public.usuarios add if not exists existe_google BOOLEAN NULL;
alter table curso_comparativo alter id type varchar(50);
alter table curso_comparativo alter criador_id type varchar(50);
alter table curso_comparativo alter descricao drop not null;
alter table curso_comparativo drop constraint curso_comparativo_usuario_fk;

ALTER TABLE curso_comparativo RENAME TO cursos_gsa;
ALTER TABLE usuario_comparativo RENAME TO usuarios_gsa;
ALTER TABLE usuario_curso_comparativo RENAME TO cursos_usuarios_gsa;

alter table usuarios_gsa add if not exists inserido_manualmente_google BOOLEAN NULL;
alter table cursos_gsa alter nome drop not null;
alter table cursos_gsa alter secao drop not null;
alter table cursos_gsa alter data_inclusao drop not null;

alter table usuarios_gsa alter nome drop not null;
alter table usuarios_gsa alter data_inclusao drop not null;
alter table usuarios_gsa alter organization_path drop not null;
alter table usuarios_gsa add unique(email); 

alter table usuarios_gsa alter id type varchar(50);

alter table cursos_usuarios_gsa alter usuario_id type varchar(50);
alter table cursos_usuarios_gsa alter curso_id type varchar(50);
alter table cursos_usuarios_gsa add unique(usuario_id, curso_id);


