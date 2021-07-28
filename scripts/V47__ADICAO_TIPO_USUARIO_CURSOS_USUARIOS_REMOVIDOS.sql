ALTER TABLE public.curso_usuario_removido_gsa_erro ADD COLUMN usuario_tipo int NOT null default 0;
ALTER TABLE public.curso_usuario_removido_gsa_erro ADD COLUMN usuario_id_gsa varchar(50) NOT null default '0';
ALTER TABLE public.curso_usuario_removido_gsa_erro ADD COLUMN curso_id_gsa varchar(50) NOT null default '0';