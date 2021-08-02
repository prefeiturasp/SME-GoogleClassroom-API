delete from execucao_controle where execucao_tipo = 17;
insert into execucao_controle (execucao_tipo, ultima_execucao)
select 17, '2021-01-01';