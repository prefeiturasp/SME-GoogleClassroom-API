delete from public.parametro_sistema where tipo = 6;
insert into public.parametro_sistema (nome, tipo, descricao, valor, ano, ativo)
values('TotalDiasImportacaoNotas', 6, 'Parametro que define a quantidade de dias a considerar para importação das notas', '15', 2021, true);