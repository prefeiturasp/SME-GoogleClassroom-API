insert into execucao_controle 
(execucao_tipo, ultima_execucao)
	select 13, '2021-01-01' 
	  where not exists(select 1 from execucao_controle where execucao_tipo = 13);
