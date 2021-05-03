ALTER TABLE usuarios DROP CONSTRAINT if exists usuarios_google_classroom_id_unique;
ALTER TABLE usuarios ADD CONSTRAINT usuarios_google_classroom_id_unique UNIQUE (google_classroom_id, usuario_tipo);

