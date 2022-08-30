CREATE TABLE public.config_celp (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,	
	dre_id varchar(15) NOT NULL,	
	email varchar(400) NOT NULL,
	ativo bool NULL,
	data_inclusao timestamp NOT NULL,
	data_atualizacao timestamp NULL,	
	CONSTRAINT config_celp_pk PRIMARY KEY (id)
);
