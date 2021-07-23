delete from execucao_controle where execucao_tipo = 15;

insert into execucao_controle (execucao_tipo, ultima_execucao)
select 15, '2021-01-01';