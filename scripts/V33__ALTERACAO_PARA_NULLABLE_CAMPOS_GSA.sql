alter table cursos_gsa alter nome drop not null;
alter table cursos_gsa alter secao drop not null;
alter table cursos_gsa alter data_inclusao drop not null;

alter table usuarios_gsa alter nome drop not null;
alter table usuarios_gsa alter data_inclusao drop not null;
alter table usuarios_gsa alter organization_path drop not null;

alter table usuarios_gsa alter id type varchar(50);

alter table cursos_usuarios_gsa alter usuario_id type varchar(50);
alter table cursos_usuarios_gsa alter curso_id type varchar(50);
alter table cursos_usuarios_gsa add unique(usuario_id, curso_id);