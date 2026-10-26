INSERT INTO public.parametro_sistema
    (nome, tipo, descricao, valor, ano, ativo)
SELECT 'TotalDiasImportacaoNotas', 6, 'Parametro que define a quantidade de dias a considerar para importação das notas', '15', cast(extract(year from current_date) as integer), true
WHERE NOT EXISTS (
    SELECT 1 FROM public.parametro_sistema WHERE tipo = 6 AND ano = cast(extract(year from current_date) as integer)
);
