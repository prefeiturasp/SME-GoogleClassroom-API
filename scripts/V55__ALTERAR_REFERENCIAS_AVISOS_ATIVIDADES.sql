DO $$
BEGIN
	IF NOT EXISTS (
		SELECT column_name, *
		FROM information_schema.columns 
		WHERE table_name='cursos_gsa' and column_name='id' and data_type = 'bigint'		
	)
	THEN
		ALTER TABLE public.cursos_gsa 
		ALTER COLUMN id TYPE INT8 USING (TRIM(id)::INT8);
	END IF;

	IF EXISTS (
		SELECT column_name 
		FROM information_schema.columns 
		WHERE table_name='avisos' and column_name='curso_id'
	)
	THEN
		ALTER TABLE public.avisos 
		RENAME COLUMN curso_id TO curso_gsa_id;	
	END IF;


	IF EXISTS (
		SELECT column_name 
		FROM information_schema.columns 
		WHERE table_name='atividades' and column_name='curso_id'
	)
	THEN
		ALTER TABLE public.atividades 
		RENAME COLUMN curso_id TO curso_gsa_id;	
	END IF;


    IF EXISTS ( 
		SELECT 1
		FROM information_schema.table_constraints 
		WHERE constraint_name='avisos_curso_fk' AND table_name='avisos'
  	)
    THEN
        ALTER TABLE public.avisos 
		DROP CONSTRAINT avisos_curso_fk;
    END IF;
   
    IF EXISTS ( 
		SELECT 1
		FROM information_schema.table_constraints 
		WHERE constraint_name='atividades_curso_fk' AND table_name='atividades'
  	)
    THEN
        ALTER TABLE public.atividades 
		DROP CONSTRAINT atividades_curso_fk;
    END IF;
   
    IF NOT EXISTS ( 
		SELECT 1
		FROM information_schema.table_constraints 
		WHERE constraint_name='avisos_curso_gsa_fk' AND table_name='avisos'
  	)
    THEN
        ALTER TABLE public.avisos 
		ADD CONSTRAINT avisos_curso_gsa_fk
			FOREIGN KEY (curso_gsa_id)
		        REFERENCES cursos_gsa (id);
    END IF;
   
    IF NOT EXISTS ( 
		SELECT 1
		FROM information_schema.table_constraints 
		WHERE constraint_name='atividades_curso_gsa_fk' AND table_name='atividades'
  	)
    THEN
        ALTER TABLE public.atividades 
		ADD CONSTRAINT atividades_curso_gsa_fk
			FOREIGN KEY (curso_gsa_id)
		        REFERENCES cursos_gsa (id);
    END IF;
END $$;

