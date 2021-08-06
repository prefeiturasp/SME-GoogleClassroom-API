delete from public.parametro_sistema where tipo = 5;
insert into public.parametro_sistema (nome, tipo, descricao, valor, ano, ativo)
values('DiasInativacaoFuncionario', 5, 'Parametro de dias para inativação de funcionarios', '15', 2021, true); 