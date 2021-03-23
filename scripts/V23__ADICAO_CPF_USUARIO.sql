ALTER TABLE public.usuarios ADD cpf varchar(11) NULL;

CREATE INDEX usuarios_cpf_usuario_tipo_idx ON public.usuarios USING btree (cpf, usuario_tipo);