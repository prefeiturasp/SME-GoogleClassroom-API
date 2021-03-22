ALTER TABLE public.usuarios ADD CONSTRAINT email_unique UNIQUE (email);

ALTER TABLE public.usuarios  ALTER column id DROP NOT NULL;    

CREATE INDEX usuarios_id_idx ON public.usuarios USING btree (id);

CREATE INDEX usuarios_usuario_tipo_idx ON public.usuarios USING btree (usuario_tipo);

ALTER TABLE public.cursos_usuarios_erro ADD email varchar(200) NOT NULL;