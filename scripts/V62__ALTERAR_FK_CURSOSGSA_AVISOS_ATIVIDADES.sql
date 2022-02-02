DO $$
BEGIN

DELETE FROM AVISOS;
DELETE FROM ATIVIDADES;

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