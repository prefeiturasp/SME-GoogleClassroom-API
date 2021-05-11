ALTER TABLE cursos_usuarios_gsa ADD usuario_curso_tipo int4 NULL;

ALTER TABLE cursos_usuarios_gsa DROP CONSTRAINT if exists curso_usuario_comparativo_usuario_fk;

ALTER TABLE public.cursos_gsa ALTER COLUMN nome TYPE varchar(400) USING nome::varchar;
ALTER TABLE public.cursos_gsa ALTER COLUMN secao TYPE text USING secao::text;
ALTER TABLE public.cursos_gsa ALTER COLUMN descricao TYPE text USING descricao::text;

ALTER TABLE public.cursos ALTER COLUMN nome TYPE varchar(400) USING nome::varchar;
ALTER TABLE public.cursos ALTER COLUMN secao TYPE varchar(400) USING secao::varchar;

ALTER TABLE public.usuarios_gsa ALTER COLUMN id TYPE varchar(100) USING id::varchar;
ALTER TABLE public.usuarios ALTER COLUMN google_classroom_id TYPE varchar(100) USING google_classroom_id::varchar;

ALTER TABLE public.cursos_usuarios_gsa ALTER COLUMN usuario_id TYPE varchar(100) USING usuario_id::varchar;