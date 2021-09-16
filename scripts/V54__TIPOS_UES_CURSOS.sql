alter table carga_inicial 
	drop column if exists tipos_ue_cursos;

alter table carga_inicial 
	add tipos_ue_cursos varchar null;

update carga_inicial 
	set tipos_ue = '1,2,3,4,10,11,12,13,16,17,18,23,28,31',
	  tipos_ue_cursos = '1,2,3,4,10,13,16,17,18,23,28,31';
