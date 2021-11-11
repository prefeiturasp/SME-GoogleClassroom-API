drop index if exists atividades_curso_id_idx;
drop index if exists atividades_usuario_id_idx;
drop index if exists atividades_inclusao_idx;
drop index if exists atividades_entrega_idx;

create index atividades_curso_id_idx
    on atividades (curso_id);
create index atividades_usuario_id_idx
    on atividades (usuario_id);
create index atividades_inclusao_idx
    on atividades (data_inclusao);
create index atividades_entrega_idx
    on atividades (data_entrega);

ALTER TABLE notas
	drop column if exists usuario_id;
ALTER TABLE notas
	drop column if exists usuario_classroom_id;

ALTER TABLE notas
	add column usuario_classroom_id varchar(100) not null;

drop index if exists notas_usuario_idx;
create index notas_usuario_idx
    on notas (usuario_classroom_id);
drop index if exists notas_data_importacao_idx;
CREATE INDEX notas_data_importacao_idx 
	ON public.notas (data_importacao);
