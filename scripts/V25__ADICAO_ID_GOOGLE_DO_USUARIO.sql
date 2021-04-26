ALTER TABLE public.usuarios ADD if not exists google_classroom_id int8 NULL;

CREATE index if not exists usuarios_google_classroom_id_idx ON public.usuarios USING btree (google_classroom_id);

