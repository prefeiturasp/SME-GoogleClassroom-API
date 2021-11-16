DO $$
begin

IF NOT EXISTS (
	SELECT column_name, *
	FROM information_schema.columns 
	WHERE table_name='cursos_gsa' and column_name='id' and data_type = 'bigint'		
)
THEN
	ALTER TABLE public.cursos_gsa
	ALTER COLUMN id TYPE INT8 USING (TRIM(id)::INT8);
END IF;


-- AVISOS - CURSO
IF EXISTS (
	SELECT column_name, *
	FROM information_schema.columns 
	WHERE table_name='avisos' and column_name='curso_id'		
)
then
	ALTER TABLE public.avisos 
		RENAME COLUMN curso_id TO curso_gsa_id;	
end if;

-- AVISOS - USUARIO
IF EXISTS (
	SELECT column_name, *
	FROM information_schema.columns 
	WHERE table_name='avisos' and column_name='usuario_id'		
)
then
	ALTER TABLE public.avisos 
	DROP COLUMN if exists usuario_gsa_id;
		
	ALTER TABLE public.avisos 
	ADD COLUMN usuario_gsa_id varchar(100);

	update avisos a 
		set usuario_gsa_id = u.google_classroom_id
	from usuarios u
	where u.indice = a.usuario_id;

	ALTER TABLE public.avisos 
	DROP COLUMN usuario_id;

	-- AVISOS INDEXES
	CREATE INDEX avisos_usuario_gsa_id_idx ON public.avisos (usuario_gsa_id);
end if;


-- ATIVIDADES - CURSO
IF EXISTS (
	SELECT column_name, *
	FROM information_schema.columns 
	WHERE table_name='atividades' and column_name='curso_id'		
)
then
	ALTER TABLE public.atividades 
		RENAME COLUMN curso_id TO curso_gsa_id;	
end if;
   
-- ATIVIDADES - USUARIO
IF EXISTS (
	SELECT column_name, *
	FROM information_schema.columns 
	WHERE table_name='atividades' and column_name='usuario_id'		
)
then
	ALTER TABLE public.atividades 
	DROP COLUMN if exists usuario_gsa_id;
	
	ALTER TABLE public.atividades 
	ADD COLUMN usuario_gsa_id varchar(100);

	update atividades a 
		set usuario_gsa_id = u.google_classroom_id
	from usuarios u
	where u.indice = a.usuario_id;

	ALTER TABLE public.atividades 
	DROP COLUMN usuario_id;

	-- ATIVIDADES INDEXES
	CREATE INDEX atividades_usuario_gsa_id_idx ON public.atividades (usuario_gsa_id);
end if;
       
end $$