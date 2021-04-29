alter table curso_comparativo alter id type varchar(50);
alter table curso_comparativo alter criador_id type varchar(50);
alter table curso_comparativo alter descricao drop not null;
alter table curso_comparativo drop constraint curso_comparativo_usuario_fk;