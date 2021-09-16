CREATE INDEX IF NOT EXISTS curso_usuario_removido_gsa_usuario ON public.curso_usuario_removido_gsa USING btree (usuario_id);
CREATE INDEX IF NOT EXISTS curso_usuario_removido_gsa_curso ON public.curso_usuario_removido_gsa USING btree (curso_id);
CREATE INDEX IF NOT EXISTS curso_usuario_removido_gsa_erro_usuario ON public.curso_usuario_removido_gsa_erro USING btree (usuario_id);
CREATE INDEX IF NOT EXISTS curso_usuario_removido_gsa_erro_curso ON public.curso_usuario_removido_gsa_erro USING btree (curso_id);