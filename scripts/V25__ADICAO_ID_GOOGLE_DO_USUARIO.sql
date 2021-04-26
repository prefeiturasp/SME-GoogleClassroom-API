ALTER TABLE public.usuarios ADD google_classroom_id int8 NULL;

CREATE INDEX usuarios_google_classroom_id_idx ON public.usuarios USING btree (google_classroom_id);

