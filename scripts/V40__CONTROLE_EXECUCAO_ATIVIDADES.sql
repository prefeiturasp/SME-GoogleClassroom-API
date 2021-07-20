delete from execucao_controle where execucao_tipo = 14;

insert into execucao_controle (execucao_tipo, ultima_execucao)
select 14, '2021-01-01';