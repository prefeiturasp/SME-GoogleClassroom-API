delete from public.parametro_sistema where tipo = 1;
insert into public.parametro_sistema (nome, tipo, descricao, valor, ano, ativo)
values('AnoLetivo', 1, 'Parametro de ano letivo', '2021-02-15', 2021, true);