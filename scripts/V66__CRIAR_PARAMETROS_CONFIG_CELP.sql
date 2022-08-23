INSERT INTO public.parametro_sistema
    (nome, tipo,descricao, valor,ano,ativo)
SELECT 'EmailCoordenadorCELP',7,'Parametro usado para indicar o e-mail do coordenador CELP','ana.katy@sme.prefeitura.sp.gov.br',2022,true
WHERE
    NOT EXISTS (
        SELECT ano FROM public.parametro_sistema WHERE ano = 2022 and tipo = 7
    );
	
INSERT INTO public.parametro_sistema
    (nome, tipo,descricao, valor,ano,ativo)
SELECT 'ComponentesCurricularesCELP',8,'Parametro usado para indicar os componentes curriculares que serão importados pelo CELP','1657,1658,1659,1660,1661,1662',2022,true
WHERE
    NOT EXISTS (
        SELECT ano FROM public.parametro_sistema WHERE ano = 2022 and tipo = 8
    );