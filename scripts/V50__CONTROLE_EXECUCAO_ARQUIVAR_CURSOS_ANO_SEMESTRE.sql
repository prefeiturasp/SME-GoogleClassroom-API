delete from execucao_controle where execucao_tipo = 18;
insert into execucao_controle (execucao_tipo, ultima_execucao)
select 18, '2021-01-01';