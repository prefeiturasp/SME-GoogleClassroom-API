delete from public.parametro_sistema where tipo = 3;
insert into public.parametro_sistema (nome, tipo, descricao, valor, ano, ativo)
values('DiasRemocaoAluno', 3, 'Parametro de dias para remoção de aluno do curso', '10', 2021, true);

delete from public.parametro_sistema where tipo = 4;
insert into public.parametro_sistema (nome, tipo, descricao, valor, ano, ativo)
values('DiasRemocaoProfessor', 4, 'Parametro de dias para remoção de professor do curso', '10', 2021, true);