ALTER TABLE public.usuarios ADD nome varchar(300) NOT NULL;

insert into execucao_controle 
(execucao_tipo, ultima_execucao)values(3, '2021-02-20');

insert into execucao_controle 
(execucao_tipo, ultima_execucao)values(4, '2021-02-20');