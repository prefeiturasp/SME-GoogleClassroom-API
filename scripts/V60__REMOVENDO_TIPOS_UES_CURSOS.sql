ALTER TABLE PUBLIC.CARGA_INICIAL DROP COLUMN IF EXISTS TIPOS_UE_CURSOS;
    
UPDATE CARGA_INICIAL SET TIPOS_UE = '1,2,3,4,10,13,16,17,18,23,28,31';
