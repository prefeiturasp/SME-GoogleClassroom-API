delete from public.parametro_sistema where tipo = 2;
insert into public.parametro_sistema (nome, tipo, descricao, valor, ano, ativo)
values('DiasRemocaoFuncionario', 2, 'Parametro de dias para remoção de funcionario', '15', 2021, true);