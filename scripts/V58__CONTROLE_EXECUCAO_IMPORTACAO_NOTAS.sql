delete from execucao_controle where execucao_tipo = 19;

insert into execucao_controle (execucao_tipo, ultima_execucao)
select 19, '2021-01-01';