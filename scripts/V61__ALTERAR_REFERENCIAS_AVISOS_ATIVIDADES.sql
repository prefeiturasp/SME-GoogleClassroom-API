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
ALTER TABLE public.avisos 
DROP COLUMN if exists curso_id; 
ALTER TABLE public.avisos 
DROP COLUMN if exists curso_gsa_id; 

ALTER TABLE public.avisos 
ADD COLUMN curso_gsa_id int8 not null;	

-- AVISOS - USUARIO
ALTER TABLE public.avisos 
DROP COLUMN if exists usuario_id;
ALTER TABLE public.avisos 
DROP COLUMN if exists usuario_gsa_id;
	
ALTER TABLE public.avisos 
ADD COLUMN usuario_gsa_id varchar(100) not null;

-- AVISOS INDEXES
CREATE INDEX avisos_usuario_gsa_id_idx ON public.avisos (usuario_gsa_id);
CREATE INDEX avisos_curso_gsa_id_idx ON public.avisos (curso_gsa_id);
   
ALTER TABLE public.avisos 
ADD CONSTRAINT avisos_curso_gsa_fk
	FOREIGN KEY (curso_gsa_id)
        REFERENCES cursos_gsa (id);

-- ATIVIDADES - CURSO
ALTER TABLE public.atividades 
DROP COLUMN if exists curso_id;
ALTER TABLE public.atividades 
DROP COLUMN if exists curso_gsa_id;

ALTER TABLE public.atividades 
ADD COLUMN curso_gsa_id int8 not null;
   
-- ATIVIDADES - USUARIO
ALTER TABLE public.atividades 
DROP COLUMN if exists usuario_id;
ALTER TABLE public.atividades 
DROP COLUMN if exists usuario_gsa_id;

ALTER TABLE public.atividades 
ADD COLUMN usuario_gsa_id varchar(100);

-- ATIVIDADES INDEXES
CREATE INDEX atividades_usuario_gsa_id_idx ON public.atividades (usuario_gsa_id);
CREATE INDEX atividades_curso_gsa_id_idx ON public.atividades (curso_gsa_id);
       
ALTER TABLE public.atividades 
ADD CONSTRAINT atividades_curso_gsa_fk
	FOREIGN KEY (curso_gsa_id)
        REFERENCES cursos_gsa (id);

end $$