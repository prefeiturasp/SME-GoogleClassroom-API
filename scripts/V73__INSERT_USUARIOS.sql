DO 
$do$ 
BEGIN 
IF EXISTS (SELECT * from usuarios where cpf = '35591539807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DIAS SABINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianisabino.35591539807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DIAS SABINO'),
 '35591539807', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DIAS SABINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9153314  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DIAS SANDOVAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9153314, 
 3,'vivianesandoval.9153314@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DIAS SANDOVAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DIAS SANDOVAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '05305797667'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DO CARMO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.e05305797667@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DO CARMO SILVA'),
 '05305797667', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DO CARMO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 2982210398  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DO NASCIMENTO BORGES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 2982210398, 
 3,'vivianeborges.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DO NASCIMENTO BORGES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DO NASCIMENTO BORGES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9177582  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DO NASCIMENTO LIRA RIBEIRO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9177582, 
 3,'vivianeribeiro.9177582@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DO NASCIMENTO LIRA RIBEIRO '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DO NASCIMENTO LIRA RIBEIRO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7455003  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOMINGUES DA ROCHA LORIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7455003, 
 3,'vivianeloria.7455003@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOMINGUES DA ROCHA LORIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOMINGUES DA ROCHA LORIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36838308835'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS REIS FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeferreira.e36838308835@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS REIS FERREIRA'),
 '36838308835', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS REIS FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8197521  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8197521, 
 3,'vivianesantos.8197521@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8447276  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS CACCIATORE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8447276, 
 3,'vivianecacciatore.8447276@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS CACCIATORE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS CACCIATORE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8010722  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS FORGE FREO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8010722, 
 3,'vivianefreo.8010722@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS FORGE FREO '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS FORGE FREO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36104458823'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS MARANHÃO BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianebarbosa.36104458823@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS MARANHÃO BARBOSA'),
 '36104458823', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS MARANHÃO BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8795690  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS RASQUINHO ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8795690, 
 3,'vivianerasquinho.8795690@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS RASQUINHO ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS RASQUINHO ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8789738  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8789738, 
 3,'vivianerodrigues.8789738@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32640359878'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.32640359878@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS SILVA'),
 '32640359878', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8420424  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOS SANTOS VALE DE NOGUEIRA FREIRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8420424, 
 3,'vivianefreire.8420424@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOS SANTOS VALE DE NOGUEIRA FREIRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOS SANTOS VALE DE NOGUEIRA FREIRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33965258842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE DOURADO DE JESUS RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianerodrigues.33965258842@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE DOURADO DE JESUS RODRIGUES'),
 '33965258842', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE DOURADO DE JESUS RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7254695  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE EDUARDA FONSECA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7254695, 
 3,'vivianefonseca.7254695@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE EDUARDA FONSECA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE EDUARDA FONSECA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8453012  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ELIZEU DA SILVA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8453012, 
 3,'vivianesantos.8453012@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ELIZEU DA SILVA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ELIZEU DA SILVA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30030308844'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ESTERINA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.30030308844@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ESTERINA DA SILVA'),
 '30030308844', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ESTERINA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7561474  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FARIA DE MIRANDA NEGRETTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7561474, 
 3,'vivianenegrette.7561474@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FARIA DE MIRANDA NEGRETTE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FARIA DE MIRANDA NEGRETTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7448643  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FATIMA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7448643, 
 3,'vivianesilva.7448643@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FATIMA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FATIMA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34462987896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERNANDA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.34462987896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERNANDA DA SILVA'),
 '34462987896', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERNANDA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7115903  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERREIRA DA SILVA MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7115903, 
 3,'vivianemendes.7115903@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERREIRA DA SILVA MENDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERREIRA DA SILVA MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34810975819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERREIRA DOS REIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianereis.e34810975819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERREIRA DOS REIS'),
 '34810975819', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERREIRA DOS REIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31139588818'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERREIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.e31139588818@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERREIRA DOS SANTOS'),
 '31139588818', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERREIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15704313884'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERREIRA DOS SANTOS GONÇALVES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianegoncalves.15704313884@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERREIRA DOS SANTOS GONÇALVES '),
 '15704313884', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERREIRA DOS SANTOS GONÇALVES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8118752  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERREIRA ESPINDOLA DE MACEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8118752, 
 3,'vivianemacedo.8118752@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERREIRA ESPINDOLA DE MACEDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERREIRA ESPINDOLA DE MACEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22821725825'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERREIRA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianepereira.22821725825@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERREIRA PEREIRA'),
 '22821725825', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERREIRA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7540191  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FIDELIS FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7540191, 
 3,'vivianeferreira.7540191@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FIDELIS FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FIDELIS FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8211540  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FONSECA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8211540, 
 3,'vivianesilva.8211540@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FONSECA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FONSECA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33885535807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FRANKLIM  DO  NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianenascimento.33885535807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FRANKLIM  DO  NASCIMENTO'),
 '33885535807', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FRANKLIM  DO  NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8789231  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GARCIA LEONARDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8789231, 
 3,'vivianeleonardo.8789231@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GARCIA LEONARDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GARCIA LEONARDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22653437813'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.22653437813@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GOMES'),
 '22653437813', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8018405  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GOMES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8018405, 
 3,'vivianesilva.8018405@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GOMES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GOMES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7232187  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GOMES MACEDO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7232187, 
 3,'vivianesilva.7232187@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GOMES MACEDO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GOMES MACEDO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8193681  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GOMES RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8193681, 
 3,'vivianerodrigues.8193681@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GOMES RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GOMES RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42791845852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GONÇALVES JULIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianegjulio.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GONÇALVES JULIO'),
 '42791845852', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GONÇALVES JULIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36102564863'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GONÇALVES MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemartins.36102564863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GONÇALVES MARTINS'),
 '36102564863', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GONÇALVES MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9128565  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GONÇALVES SOARES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9128565, 
 3,'vivianegssantos.9128565@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GONÇALVES SOARES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GONÇALVES SOARES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7940106  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE GUEIROS RAMOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7940106, 
 3,'vivianeramos.7940106@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE GUEIROS RAMOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE GUEIROS RAMOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8141410  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE HONORIO DA COSTA PAIVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8141410, 
 3,'vivianepaiva.8141410@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE HONORIO DA COSTA PAIVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE HONORIO DA COSTA PAIVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8031771  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ISIDORO DE FRANCA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8031771, 
 3,'vivianefranca.8031771@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ISIDORO DE FRANCA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ISIDORO DE FRANCA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8453985  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE JACOB FRANZIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8453985, 
 3,'vivianefranzin.8453985@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE JACOB FRANZIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE JACOB FRANZIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31968907869'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE JESUS DE CARVALHO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.e31968907869@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE JESUS DE CARVALHO SILVA'),
 '31968907869', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE JESUS DE CARVALHO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8816603  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE KELLY ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8816603, 
 3,'vivianealves.8816603@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE KELLY ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE KELLY ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26666866800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE KELLY DE LIMA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianelima.26666866800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE KELLY DE LIMA '),
 '26666866800', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE KELLY DE LIMA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32496829850'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE L G DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.32496829850@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE L G DA SILVA'),
 '32496829850', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE L G DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38291093857'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LAURINDO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.38291093857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LAURINDO DA SILVA'),
 '38291093857', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LAURINDO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '29697066876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LEAL AZEVEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeazevedo.29697066876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LEAL AZEVEDO'),
 '29697066876', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LEAL AZEVEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7767340  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LEITE DE ASSIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7767340, 
 3,'vivianeassis.7767340@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LEITE DE ASSIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LEITE DE ASSIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7754337  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LEOPOLDINO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7754337, 
 3,'vivianesilva.7754337@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LEOPOLDINO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LEOPOLDINO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39438035893'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LIMA DANTAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianedantas.39438035893@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LIMA DANTAS'),
 '39438035893', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LIMA DANTAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8244782  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LIMA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8244782, 
 3,'vivianesilva.8244782@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LIMA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LIMA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7726007  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LIZI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7726007, 
 3,'vivianebarbosa.7726007@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LIZI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LIZI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25242620811'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LOPES CARDOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianecardoso.25242620811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LOPES CARDOSO'),
 '25242620811', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LOPES CARDOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7443901  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LOPES DE OLIVEIRA BATISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7443901, 
 3,'vivianebatista.7443901@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LOPES DE OLIVEIRA BATISTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LOPES DE OLIVEIRA BATISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35425774800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE LUCIO NUNES VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianevieira.35425774800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE LUCIO NUNES VIEIRA'),
 '35425774800', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE LUCIO NUNES VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31331201829'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MACHADO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.31331201829@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MACHADO DA SILVA'),
 '31331201829', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MACHADO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6776833  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MACHADO FURLAN '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6776833, 
 3,'vivianefurlan.6776833@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MACHADO FURLAN '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MACHADO FURLAN '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8214000  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MACHADO SABADIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8214000, 
 3,'vivianesabadin.8214000@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MACHADO SABADIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MACHADO SABADIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8572895  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MAIA TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8572895, 
 3,'vivianeteixeira.8572895@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MAIA TEIXEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MAIA TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6950205  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6950205, 
 3,'vivianebarbosa.6950205@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA BARBOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8023778  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8023778, 
 3,'vivianecampos.8023778@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8065918  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA DA SILVA MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8065918, 
 3,'vivianemendes.8065918@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA DA SILVA MENDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA DA SILVA MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25862916890'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA DA SILVA MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemoura.25862916890@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA DA SILVA MOURA'),
 '25862916890', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA DA SILVA MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8895473  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA DE OLIVEIRA BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8895473, 
 3,'vivianebrito.8895473@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA DE OLIVEIRA BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA DE OLIVEIRA BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6800751  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6800751, 
 3,'vivianesantos.6800751@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28816027894'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA MARTINS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.28816027894@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA MARTINS DA SILVA'),
 '28816027894', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA MARTINS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7218168  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA MILAN KONDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7218168, 
 3,'vivianekondo.7218168@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA MILAN KONDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA MILAN KONDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28342326870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA SANTOS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemssilva.28342326870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA SANTOS DA SILVA'),
 '28342326870', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA SANTOS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26453809800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA SATELES DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianearaujo.26453809800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA SATELES DE ARAUJO'),
 '26453809800', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA SATELES DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28691885874'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA SILVA PORTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeporto.28691885874@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA SILVA PORTO'),
 '28691885874', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA SILVA PORTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27279520820'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA TORZILLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianetorzillo.27279520820@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA TORZILLO'),
 '27279520820', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA TORZILLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34575862843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARINHO DE MACEDO RODRIGUES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianerodrigues.34575862843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARINHO DE MACEDO RODRIGUES '),
 '34575862843', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARINHO DE MACEDO RODRIGUES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '19222622855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARQUES CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianecruz.19222622855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARQUES CRUZ'),
 '19222622855', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARQUES CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8572747  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARQUES DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8572747, 
 3,'vivianelima.8572747@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARQUES DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARQUES DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7992467  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARQUES MIRANDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7992467, 
 3,'vivianemiranda.7992467@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARQUES MIRANDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARQUES MIRANDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7849575  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARQUES MOURA SIMÃO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7849575, 
 3,'vivianesimao.7849575@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARQUES MOURA SIMÃO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARQUES MOURA SIMÃO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35703876826'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARQUES SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesouza.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARQUES SOUZA'),
 '35703876826', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARQUES SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8228612  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARSAL SATURNINO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8228612, 
 3,'vivianesantos.8228612@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARSAL SATURNINO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARSAL SATURNINO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7274611  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARTARELLI BIZ TENÓRIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7274611, 
 3,'vivianetenorio.7274611@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARTARELLI BIZ TENÓRIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARTARELLI BIZ TENÓRIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28519699863'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARTINS CONRADO LARA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianelara.28519699863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARTINS CONRADO LARA '),
 '28519699863', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARTINS CONRADO LARA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36911831822'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARTINS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemsilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARTINS DA SILVA'),
 '36911831822', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARTINS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8453748  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARTINS DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8453748, 
 3,'vivianesouza.8453748@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARTINS DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARTINS DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8239983  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARTINS DOS SANTOS RODRIGUES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8239983, 
 3,'vivianerodrigues.8239983@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARTINS DOS SANTOS RODRIGUES '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARTINS DOS SANTOS RODRIGUES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8362297  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARTINS PALHARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8362297, 
 3,'vivianepalhares.8362297@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARTINS PALHARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARTINS PALHARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7243723  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MEKITARIAN GRANDE DE REZENDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7243723, 
 3,'vivianerezende.7243723@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MEKITARIAN GRANDE DE REZENDE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MEKITARIAN GRANDE DE REZENDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33312473837'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MELLO FERREIRA DA CRUZ '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianecruz.33312473837@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MELLO FERREIRA DA CRUZ '),
 '33312473837', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MELLO FERREIRA DA CRUZ '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31851447830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MENECK MOURA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianecosta.31851447830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MENECK MOURA COSTA'),
 '31851447830', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MENECK MOURA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8406821  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MENEZES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8406821, 
 3,'vivianesouza.8406821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MENEZES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MENEZES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8212970  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MENEZES DE SOUZA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8212970, 
 3,'vivianerodrigues.8212970@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MENEZES DE SOUZA RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MENEZES DE SOUZA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8221651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MESSIAS DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8221651, 
 3,'vivianesouza.8221651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MESSIAS DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MESSIAS DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32671996896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MIRANDA SILVA BALULA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianebalula.32671996896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MIRANDA SILVA BALULA'),
 '32671996896', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MIRANDA SILVA BALULA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7279469  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MIWA FUKUI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7279469, 
 3,'vivianefukui.7279469@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MIWA FUKUI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MIWA FUKUI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8271020  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MONTECELI CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8271020, 
 3,'vivianesilva.8271020@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MONTECELI CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MONTECELI CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8118493  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MORAIS COSTA E SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8118493, 
 3,'vivianesilva.8118493@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MORAIS COSTA E SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MORAIS COSTA E SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42250276862'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MOREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.e42250276862@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MOREIRA DA SILVA'),
 '42250276862', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MOREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6380018  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MORENO ANTONIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6380018, 
 3,'vivianeantonio.6380018@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MORENO ANTONIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MORENO ANTONIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32768011835'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MORETI STRINGARI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianestringari.32768011835@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MORETI STRINGARI'),
 '32768011835', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MORETI STRINGARI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8968071  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MORGADO SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8968071, 
 3,'vivianesoares.8968071@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MORGADO SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MORGADO SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7801718  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MOTA DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7801718, 
 3,'vivianealmeida.7801718@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MOTA DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MOTA DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7805659  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MUNOZ PEREZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7805659, 
 3,'vivianeperez.7805659@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MUNOZ PEREZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MUNOZ PEREZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7820925  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NASCIMENTO DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7820925, 
 3,'vivianealmeida.7820925@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NASCIMENTO DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NASCIMENTO DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22305883897'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NASCIMENTO SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantana.22305883897@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NASCIMENTO SANTANA'),
 '22305883897', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NASCIMENTO SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33159634876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NAZARETH SASSI TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeteixeira.33159634876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NAZARETH SASSI TEIXEIRA'),
 '33159634876', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NAZARETH SASSI TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 322675318  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NEVES DE SOUZA PINHEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 322675318, 
 3,'vivivane.pinheiro322675318@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NEVES DE SOUZA PINHEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NEVES DE SOUZA PINHEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35997741885'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NICOLAU VALENTIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianevalentim.35997741885@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NICOLAU VALENTIM'),
 '35997741885', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NICOLAU VALENTIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8193380  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NOGUEIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8193380, 
 3,'vivianesilva.8193380@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NOGUEIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NOGUEIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '21897188803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NOVAES MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemendes.21897188803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NOVAES MENDES'),
 '21897188803', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NOVAES MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8212601  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NOVAIS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8212601, 
 3,'vivianesilva.8212601@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NOVAIS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NOVAIS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8240434  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NOVAKOSKI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8240434, 
 3,'vivianenovakoski.8240434@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NOVAKOSKI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NOVAKOSKI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8549184  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NUNES CAMILO ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8549184, 
 3,'vivianearaujo.8549184@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NUNES CAMILO ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NUNES CAMILO ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32906460842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE NUNES GARCIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.32906460842@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE NUNES GARCIA DOS SANTOS'),
 '32906460842', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE NUNES GARCIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 367  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ODO VALENTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 367, 
 3,'vivianevalente.367.341.948@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ODO VALENTE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ODO VALENTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34965266889'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA ARAÚJO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.34965266889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA ARAÚJO PEREIRA'),
 '34965266889', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA ARAÚJO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '29697071870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA CARDOSO CHAGAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianechagas.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA CARDOSO CHAGAS'),
 '29697071870', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA CARDOSO CHAGAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33776364807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianelima.33776364807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA DE LIMA'),
 '33776364807', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22841889823'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA DE MATOS ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeomandrade.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA DE MATOS ANDRADE'),
 '22841889823', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA DE MATOS ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8243085  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8243085, 
 3,'vivianesantos.8243085@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51630057827'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA MATIAS SANTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeomsanto.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA MATIAS SANTO'),
 '51630057827', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA MATIAS SANTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36928848855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianerodrigues.36928848855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA RODRIGUES'),
 '36928848855', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28471072823'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE OLIVEIRA TELES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeotsantos.28471072823@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE OLIVEIRA TELES DOS SANTOS'),
 '28471072823', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE OLIVEIRA TELES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7111584  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PACHECO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7111584, 
 3,'vivianepereira.7111584@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PACHECO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PACHECO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7491158  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PAGANINI DADAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7491158, 
 3,'vivianedadas.7491158@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PAGANINI DADAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PAGANINI DADAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6774482  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PANNI RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6774482, 
 3,'vivianerodrigues.6774482@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PANNI RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PANNI RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8858900  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PASTREELO CORREA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8858900, 
 3,'vivianecorrea.8858900@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PASTREELO CORREA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PASTREELO CORREA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43523415845'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PATRICIA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PATRICIA DA SILVA'),
 '43523415845', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PATRICIA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8362840  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PAULA MOREIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8362840, 
 3,'vivianesantos.8362840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PAULA MOREIRA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PAULA MOREIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33662651831'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.e33662651831@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA DA SILVA'),
 '33662651831', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40293170819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA DA SILVA BALDASSIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianebaldassim.40293170819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA DA SILVA BALDASSIM'),
 '40293170819', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA DA SILVA BALDASSIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36088468831'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA DE ABREU'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeabreu.36088468831@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA DE ABREU'),
 '36088468831', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA DE ABREU'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7292368  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA DE SOUSA	'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7292368, 
 3,'vivianesousa.7292368@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA DE SOUSA	'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA DE SOUSA	'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35390186893'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA DO CARMO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianecarmo.35390186893@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA DO CARMO '),
 '35390186893', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA DO CARMO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7991738  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7991738, 
 3,'vivianenascimento.7991738@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA DO NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7517581  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PEREIRA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7517581, 
 3,'vivianevieira.7517581@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PEREIRA VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PEREIRA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8080623  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PICAGLIE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8080623, 
 3,'vivianepicaglie.8080623@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PICAGLIE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PICAGLIE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 1516468562  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PINHEIRO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 1516468562, 
 3,'vivianesantos.1516468562@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PINHEIRO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PINHEIRO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8381437  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PINHEIRO GOMES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8381437, 
 3,'vivianerocha.8381437@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PINHEIRO GOMES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PINHEIRO GOMES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36999379840'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PINHEIRO MOTA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianepsilva.36999379840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PINHEIRO MOTA DA SILVA'),
 '36999379840', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PINHEIRO MOTA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7824700  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PINHEIRO PERLIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7824700, 
 3,'vivianeperlin.7824700@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PINHEIRO PERLIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PINHEIRO PERLIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7741758  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE PINTO PINHEIRO DE SOUZA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7741758, 
 3,'vivianelima.7741758@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE PINTO PINHEIRO DE SOUZA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE PINTO PINHEIRO DE SOUZA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '06882320519'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE QUEIROZ DA SILVA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeqsferreira.06882320519@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE QUEIROZ DA SILVA FERREIRA'),
 '06882320519', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE QUEIROZ DA SILVA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8012288  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RAIA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8012288, 
 3,'vivianesilva.8012288@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RAIA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RAIA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7826931  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RANSATO FIGUEIREDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7826931, 
 3,'vivianefigueiredo.7826931@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RANSATO FIGUEIREDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RANSATO FIGUEIREDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7750404  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RAQUEL DA SILVA SIMAO DUARTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7750404, 
 3,'vivianeduarte.7750404@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RAQUEL DA SILVA SIMAO DUARTE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RAQUEL DA SILVA SIMAO DUARTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7247281  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE REGINA DA SILVA ROSOSTOLATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7247281, 
 3,'vivianerosostolato.7247281@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE REGINA DA SILVA ROSOSTOLATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE REGINA DA SILVA ROSOSTOLATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7372205  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE REGINA RAMOS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7372205, 
 3,'vivianesantos.7372205@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE REGINA RAMOS DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE REGINA RAMOS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34335611846'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RENATA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianerocha.34335611846@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RENATA ROCHA'),
 '34335611846', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RENATA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8195013  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RIBEIRO DOS SANTOS GODOI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8195013, 
 3,'vivianegodoi.8195013@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RIBEIRO DOS SANTOS GODOI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RIBEIRO DOS SANTOS GODOI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8131741  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RIBEIRO MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8131741, 
 3,'vivianemendes.8131741@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RIBEIRO MENDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RIBEIRO MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26252812862'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RIBEIRO MENDES MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemelo.26252812862@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RIBEIRO MENDES MELO'),
 '26252812862', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RIBEIRO MENDES MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8040681  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ROBERTA DOS REIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8040681, 
 3,'vivianereis.8040681@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ROBERTA DOS REIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ROBERTA DOS REIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6155529  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ROCHA CIAMBELLIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6155529, 
 3,'vivianeciambellis.6155529@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ROCHA CIAMBELLIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ROCHA CIAMBELLIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28744143877'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RODRIGUES DA LUZ SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.28744143877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RODRIGUES DA LUZ SANTOS'),
 '28744143877', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RODRIGUES DA LUZ SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9112651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RODRIGUES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9112651, 
 3,'vivianesantos.9112651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RODRIGUES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RODRIGUES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7769245  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RODRIGUES FERNANDEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7769245, 
 3,'vivianefernandez.7769245@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RODRIGUES FERNANDEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RODRIGUES FERNANDEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8448671  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RODRIGUES LIMA ORDELINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8448671, 
 3,'vivianeordelino.8448671@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RODRIGUES LIMA ORDELINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RODRIGUES LIMA ORDELINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30562644806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RODRIGUES SABINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesabino.30562644806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RODRIGUES SABINO'),
 '30562644806', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RODRIGUES SABINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34134503876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RODRIGUES SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.e34134503876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RODRIGUES SANTOS'),
 '34134503876', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RODRIGUES SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7111592  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ROSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7111592, 
 3,'vivianerosa.7111592@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ROSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ROSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33585068863'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ROSA DOS SANTOS IRENO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeireno.e33585068863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ROSA DOS SANTOS IRENO'),
 '33585068863', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ROSA DOS SANTOS IRENO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8597642  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ROSA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8597642, 
 3,'vivianepereira.8597642@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ROSA PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ROSA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27139416866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RUFATO DE MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemoura.27139416866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RUFATO DE MOURA'),
 '27139416866', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RUFATO DE MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7730624  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SABINO CALAÇA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7730624, 
 3,'vivianesilva.7730624@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SABINO CALAÇA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SABINO CALAÇA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7268289  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SACCHI COURA ALCAIDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7268289, 
 3,'vivianealcaide.7268289@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SACCHI COURA ALCAIDE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SACCHI COURA ALCAIDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26073572840'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SACRAMENTO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.26073572840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SACRAMENTO DA SILVA'),
 '26073572840', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SACRAMENTO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33463585855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SACRAMENTO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianessantos.33463585855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SACRAMENTO DOS SANTOS'),
 '33463585855', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SACRAMENTO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8173141  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SANCHES RAMALDES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8173141, 
 3,'vivianeramaldes.8173141@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SANCHES RAMALDES '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SANCHES RAMALDES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '49112297801'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SANTOS BEZERRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianebezerra.e49112297801@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SANTOS BEZERRA'),
 '49112297801', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SANTOS BEZERRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38475681832'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SANTOS DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeoliveira.38475681832@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SANTOS DE OLIVEIRA'),
 '38475681832', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SANTOS DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '41109357842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SANTOS DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianenascimento.e41109357842@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SANTOS DO NASCIMENTO'),
 '41109357842', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SANTOS DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8180521  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SEGATTO BATTAIOLA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8180521, 
 3,'vivianebattaiola.8180521@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SEGATTO BATTAIOLA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SEGATTO BATTAIOLA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7399651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVA ACRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7399651, 
 3,'vivianeacre.7399651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVA ACRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVA ACRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '16309647865'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVA BELINELLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianebelinello.e16309647865@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVA BELINELLO'),
 '16309647865', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVA BELINELLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22346951803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeoliveira.22346951803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVA DE OLIVEIRA'),
 '22346951803', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '46747352890'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.e46747352890@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVA DOS SANTOS'),
 '46747352890', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38377811863'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVA ROCHA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.38377811863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVA ROCHA DOS SANTOS'),
 '38377811863', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVA ROCHA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8167249  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVA VILARONGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8167249, 
 3,'vivianevilaronga.8167249@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVA VILARONGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVA VILARONGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34731868807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVEIRA NUNES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianenunes.34731868807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVEIRA NUNES'),
 '34731868807', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVEIRA NUNES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22324509881'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SILVESTRE DUARTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeduarte.e22324509881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SILVESTRE DUARTE'),
 '22324509881', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SILVESTRE DUARTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8361681  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SIMONE DOS SANTOS RODRIGUES REIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8361681, 
 3,'vivianeporto.8361681@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SIMONE DOS SANTOS RODRIGUES REIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SIMONE DOS SANTOS RODRIGUES REIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7936273  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOARES DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7936273, 
 3,'vivianenascimento.7936273@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOARES DO NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOARES DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32727669879'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOARES FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeferreira.32727669879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOARES FERREIRA'),
 '32727669879', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOARES FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '18464182830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SORROCHE DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.18464182830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SORROCHE DA SILVA'),
 '18464182830', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SORROCHE DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48824389848'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOUSA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianeoliveira.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOUSA DE OLIVEIRA'),
 '48824389848', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOUSA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40674145879'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOUSA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianevieira.e40674145879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOUSA VIEIRA'),
 '40674145879', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOUSA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36782392852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOUTO MAGALHAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemagalhes.36782392852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOUTO MAGALHAES'),
 '36782392852', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOUTO MAGALHAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7997744  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOUZA ATHU'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7997744, 
 3,'vivianeathu.7997744@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOUZA ATHU'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOUZA ATHU'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45209452832'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SOUZA DE JESUS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.e45209452832@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SOUZA DE JESUS SANTOS'),
 '45209452832', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SOUZA DE JESUS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7704330  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SPLUGUES ALENCAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7704330, 
 3,'vivianealencar.7704330@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SPLUGUES ALENCAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SPLUGUES ALENCAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35069313851'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SULLIVAN DO VALLE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianevalle.35069313851@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SULLIVAN DO VALLE'),
 '35069313851', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SULLIVAN DO VALLE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8098735  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE SUSANA DE BRITO FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8098735, 
 3,'vivianeferreira.8098735@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE SUSANA DE BRITO FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE SUSANA DE BRITO FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31060874806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE TALITA DO NASCIMENTO MACARIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianemacario.31060874806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE TALITA DO NASCIMENTO MACARIO'),
 '31060874806', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE TALITA DO NASCIMENTO MACARIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33829700822'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE TOMAZ DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.33829700822@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE TOMAZ DA SILVA'),
 '33829700822', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE TOMAZ DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8193266  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE VASCONCELOS DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8193266, 
 3,'vivianesouza.8193266@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE VASCONCELOS DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE VASCONCELOS DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9117695  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE VIEIRA DA CONCEIÇÃO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9117695, 
 3,'vivianeconceicao.9117695@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE VIEIRA DA CONCEIÇÃO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE VIEIRA DA CONCEIÇÃO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31084646803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE VIEIRA LORANDI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianelorandi.31084646803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE VIEIRA LORANDI'),
 '31084646803', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE VIEIRA LORANDI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8394156  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE VITOR MELO FIRMINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8394156, 
 3,'vivianefirmino.8394156@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE VITOR MELO FIRMINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE VITOR MELO FIRMINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8398941  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE XAVIER MATIAS DA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8398941, 
 3,'vivianerocha.8398941@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE XAVIER MATIAS DA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE XAVIER MATIAS DA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8205477  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE YOSHINAGA FUJIHARA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8205477, 
 3,'vivianefujihara.8205477@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE YOSHINAGA FUJIHARA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE YOSHINAGA FUJIHARA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6999735  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ZANONI DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6999735, 
 3,'vivianeoliveira.6999735@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ZANONI DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ZANONI DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39168907869'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI JESUS CARVALHO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianisilva.e39168907869@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI JESUS CARVALHO DA SILVA'),
 '39168907869', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI JESUS CARVALHO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7447612  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI KARINA GERMANO TONI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7447612, 
 3,'vivianitoni.7447612@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI KARINA GERMANO TONI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI KARINA GERMANO TONI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '87212587168'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI LEAL DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianicarvalho.e87212587168@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI LEAL DE CARVALHO'),
 '87212587168', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI LEAL DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8146454  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI LILIAN PEREIRA DA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8146454, 
 3,'vivianicosta.8146454@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI LILIAN PEREIRA DA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI LILIAN PEREIRA DA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8041911  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI MARIA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8041911, 
 3,'vivianirocha.8041911@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI MARIA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI MARIA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27243387829'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI MOREIRA LEAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianileao.27243387829@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI MOREIRA LEAO'),
 '27243387829', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI MOREIRA LEAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8245550  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANI ZIANTONI PASCUI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8245550, 
 3,'vivianipascui.8245550@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANI ZIANTONI PASCUI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANI ZIANTONI PASCUI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '14414886856'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANLEIDE DIAS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianleidesilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANLEIDE DIAS DA SILVA'),
 '14414886856', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANLEIDE DIAS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '18718393861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANNE MARIA GONÇALVES MENDONÇA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesantos.18718393861@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANNE MARIA GONÇALVES MENDONÇA'),
 '18718393861', NULL, true); 
 raise notice 'Adicionado o usuario VIVIANNE MARIA GONÇALVES MENDONÇA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8062421  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANY DA SILVA MARISA ROGERIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8062421, 
 3,'vivianyrogerio.8062421@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANY DA SILVA MARISA ROGERIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANY DA SILVA MARISA ROGERIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39400493878'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIELLEN BARBOSA DA SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'viviellensilva.39400493878@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIELLEN BARBOSA DA SILVA '),
 '39400493878', NULL, true); 
 raise notice 'Adicionado o usuario VIVIELLEN BARBOSA DA SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30258156805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVJANE FEITOZA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianesilva.30258156805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVJANE FEITOZA SILVA'),
 '30258156805', NULL, true); 
 raise notice 'Adicionado o usuario VIVJANE FEITOZA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30838349854'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVVIAN CRISTINA AVANZI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianavanzi.30838349854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVVIAN CRISTINA AVANZI'),
 '30838349854', NULL, true); 
 raise notice 'Adicionado o usuario VIVVIAN CRISTINA AVANZI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 863923363  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLADIA MARIA LEMOS RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 863923363, 
 3,'vladiaribeiro.863923363@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLADIA MARIA LEMOS RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VLADIA MARIA LEMOS RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33322804810'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLADIANA SOUSA OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vladianaoliveira.33322804810@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLADIANA SOUSA OLIVEIRA'),
 '33322804810', NULL, true); 
 raise notice 'Adicionado o usuario VLADIANA SOUSA OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6780555  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLADIMIR CONGO DA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6780555, 
 3,'vladimircosta.6780555@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLADIMIR CONGO DA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VLADIMIR CONGO DA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7507941  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLADIMIR GONCALVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7507941, 
 3,'vladimirsilva.7507941@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLADIMIR GONCALVES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VLADIMIR GONCALVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8791970  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLADIMIR ROBERTOVITCH MATIOLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8791970, 
 3,'vladimirmatioli.8791970@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLADIMIR ROBERTOVITCH MATIOLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VLADIMIR ROBERTOVITCH MATIOLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37496356840'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLANIELE FRANÇA SOUSA NUNES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vlanielenunes.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLANIELE FRANÇA SOUSA NUNES'),
 '37496356840', NULL, true); 
 raise notice 'Adicionado o usuario VLANIELE FRANÇA SOUSA NUNES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8428751  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VOLEIDE APARECIDA DE ALMEIDA ASTOLPHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8428751, 
 3,'voleideastolpho.8428751@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VOLEIDE APARECIDA DE ALMEIDA ASTOLPHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VOLEIDE APARECIDA DE ALMEIDA ASTOLPHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '23519802805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VONETE DOS SANTOS XAVIER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vonetexavier.23519802805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VONETE DOS SANTOS XAVIER'),
 '23519802805', NULL, true); 
 raise notice 'Adicionado o usuario VONETE DOS SANTOS XAVIER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42237417806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VYCTORIA APARECIDA AZEVEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vyctoriaazevedo.e42237417806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VYCTORIA APARECIDA AZEVEDO'),
 '42237417806', NULL, true); 
 raise notice 'Adicionado o usuario VYCTORIA APARECIDA AZEVEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40484510819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNGELA CERQUEIRA FERNANDES SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vangelasantana.40484510819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNGELA CERQUEIRA FERNANDES SANTANA'),
 '40484510819', NULL, true); 
 raise notice 'Adicionado o usuario VÂNGELA CERQUEIRA FERNANDES SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '98550349534'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA  DE CARVALHO  SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasouza.98550349534@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA  DE CARVALHO  SOUZA'),
 '98550349534', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA  DE CARVALHO  SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8954607  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA ALMEIDA ALVES DE MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8954607, 
 3,'vaniamoura.8954607@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA ALMEIDA ALVES DE MOURA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA ALMEIDA ALVES DE MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34767697808'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA ALVES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasantos.34767697808@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA ALVES DOS SANTOS'),
 '34767697808', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA ALVES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '16702430876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA ALVES NUNES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasantos.16702430876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA ALVES NUNES DOS SANTOS'),
 '16702430876', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA ALVES NUNES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34162716889'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA APARECIDA BEDNARSKI SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasantos.34162716889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA APARECIDA BEDNARSKI SANTOS'),
 '34162716889', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA APARECIDA BEDNARSKI SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8209022  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA APARECIDA ZANGRANDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8209022, 
 3,'vaniazangrande.8209022@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA APARECIDA ZANGRANDE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA APARECIDA ZANGRANDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8390177  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA ARRUDA SILVESTRE PESSOA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8390177, 
 3,'vaniapessoa.8390177@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA ARRUDA SILVESTRE PESSOA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA ARRUDA SILVESTRE PESSOA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15259739833'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA BATISTA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasilva.15259739833@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA BATISTA DA SILVA'),
 '15259739833', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA BATISTA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8572178  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CARMO DE QUEIROZ LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8572178, 
 3,'vanialima.8572178@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CARMO DE QUEIROZ LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CARMO DE QUEIROZ LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '03008664539'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CERQUEIRA DA SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasilva.03008664539@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CERQUEIRA DA SILVA '),
 '03008664539', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CERQUEIRA DA SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7747667  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CRISTINA DE SOUZA RODRIGUES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7747667, 
 3,'vaniarodrigues.7747667@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CRISTINA DE SOUZA RODRIGUES '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CRISTINA DE SOUZA RODRIGUES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '14291482841'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CRISTINA DO CARMO JACINTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniajacinto.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CRISTINA DO CARMO JACINTO'),
 '14291482841', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CRISTINA DO CARMO JACINTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8206872  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CRISTINA GAGLIERA AFFONSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8206872, 
 3,'vaniaaffonso.8206872@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CRISTINA GAGLIERA AFFONSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CRISTINA GAGLIERA AFFONSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7400446  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CRISTINA MAJORAL '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7400446, 
 3,'vaniamajoral.7400446@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CRISTINA MAJORAL '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CRISTINA MAJORAL '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8142912  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA CRISTINA NUNES DOS SANTOS '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8142912, 
 3,'vaniasantos.8142912@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA CRISTINA NUNES DOS SANTOS '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA CRISTINA NUNES DOS SANTOS '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32560918811'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA DE FRANÇA MACENA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniamacena.32560918811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA DE FRANÇA MACENA '),
 '32560918811', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA DE FRANÇA MACENA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30530125889'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA DIAS SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasoares.30530125889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA DIAS SOARES'),
 '30530125889', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA DIAS SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8373442  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA DOS SANTOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8373442, 
 3,'vaniasilva.8373442@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA DOS SANTOS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA DOS SANTOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02576230350'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA DUTRA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vanialima.02576230350@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA DUTRA LIMA'),
 '02576230350', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA DUTRA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5974712  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA ELAINE TIEPKE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5974712, 
 3,'vaniatiepke.5974712@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA ELAINE TIEPKE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA ELAINE TIEPKE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '19180835848'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA FERREIRA DE AZEVEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniaazevedo.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA FERREIRA DE AZEVEDO'),
 '19180835848', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA FERREIRA DE AZEVEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7857594  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA IMPERIAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7857594, 
 3,'vaniaimperial.7857594@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA IMPERIAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA IMPERIAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '01431559547'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA LÚCIA MARQUES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasouza.01431559547@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA LÚCIA MARQUES DE SOUZA'),
 '01431559547', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA LÚCIA MARQUES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8005141  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MARIA CARNEIRO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8005141, 
 3,'vaniasilva.8005141@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MARIA CARNEIRO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MARIA CARNEIRO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31827840803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MARIA DA COSTA JEPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniajepes.31827840803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MARIA DA COSTA JEPES'),
 '31827840803', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MARIA DA COSTA JEPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8205400  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MARIA DA SILVA BRITES MUNARIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8205400, 
 3,'vaniamunarin.8205400@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MARIA DA SILVA BRITES MUNARIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MARIA DA SILVA BRITES MUNARIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32658394861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MARIA DE ALENCAR SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniamasousa.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MARIA DE ALENCAR SOUSA'),
 '32658394861', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MARIA DE ALENCAR SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26823007826'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MARIA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniasouza.26823007826@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MARIA DE SOUZA'),
 '26823007826', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MARIA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7369883  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MARTINEZ DOTTA DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7369883, 
 3,'vaniaalmeida.7369883@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MARTINEZ DOTTA DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MARTINEZ DOTTA DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8557471  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA MELO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8557471, 
 3,'vaniasilva.8557471@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA MELO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA MELO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7847289  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA REGINA DIAS DOS REIS SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7847289, 
 3,'vaniasilva.7847289@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA REGINA DIAS DOS REIS SILVA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA REGINA DIAS DOS REIS SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8215111  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA REIS DE LIMA BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8215111, 
 3,'vaniabarbosa.8215111@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA REIS DE LIMA BARBOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA REIS DE LIMA BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33052542893'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA RIBEIRO LEITE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vanialeite.33052542893@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA RIBEIRO LEITE'),
 '33052542893', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA RIBEIRO LEITE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8795908  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA RODRIGUES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8795908, 
 3,'vaniasouza.8795908@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA RODRIGUES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA RODRIGUES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8971081  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA RODRIGUES SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8971081, 
 3,'vaniarsousa.8971081@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA RODRIGUES SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA RODRIGUES SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8381348  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA SANTANA SÃO JOSÉ MARIANNO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8381348, 
 3,'vaniamarianno.8381348@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA SANTANA SÃO JOSÉ MARIANNO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA SANTANA SÃO JOSÉ MARIANNO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '11674684819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÂNIA SILVA REIS COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vaniacosta.11674684819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÂNIA SILVA REIS COSTA'),
 '11674684819', NULL, true); 
 raise notice 'Adicionado o usuario VÂNIA SILVA REIS COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '94462429591'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÍVIA DIAS TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'viviateixeira.94462429591@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÍVIA DIAS TEIXEIRA'),
 '94462429591', NULL, true); 
 raise notice 'Adicionado o usuario VÍVIA DIAS TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8430748  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÍVIAN CRISTINA DA COSTA MENEZES SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8430748, 
 3,'viviansantos.8430748@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÍVIAN CRISTINA DA COSTA MENEZES SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VÍVIAN CRISTINA DA COSTA MENEZES SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45189209881'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÍVIAN FONTES SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'viviansilva.45189209881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÍVIAN FONTES SILVA '),
 '45189209881', NULL, true); 
 raise notice 'Adicionado o usuario VÍVIAN FONTES SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27916004852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÍVIAN NASCIMENTO VIEIRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'vivianvieira.27916004852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÍVIAN NASCIMENTO VIEIRA '),
 '27916004852', NULL, true); 
 raise notice 'Adicionado o usuario VÍVIAN NASCIMENTO VIEIRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51554215862'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VÍVIAN VIANA KAC'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'viviankac.51554215862@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VÍVIAN VIANA KAC'),
 '51554215862', NULL, true); 
 raise notice 'Adicionado o usuario VÍVIAN VIANA KAC'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8243867  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WADAMES PROCOPIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8243867, 
 3,'wadamesprocopio.8243867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WADAMES PROCOPIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WADAMES PROCOPIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35058053861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WADJA STEPHANE MENDES CONCEIÇÃO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wadjaconceicao.35058053861@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WADJA STEPHANE MENDES CONCEIÇÃO'),
 '35058053861', NULL, true); 
 raise notice 'Adicionado o usuario WADJA STEPHANE MENDES CONCEIÇÃO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7537514  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WADSON ROGERIO MENEGILDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7537514, 
 3,'wadsonmenegildo.7537514@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WADSON ROGERIO MENEGILDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WADSON ROGERIO MENEGILDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43347332806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNA ALVES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wagnasouza.43347332806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNA ALVES DE SOUZA'),
 '43347332806', NULL, true); 
 raise notice 'Adicionado o usuario WAGNA ALVES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32375216806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNA DA SILVA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wagnacruz.32375216806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNA DA SILVA CRUZ'),
 '32375216806', NULL, true); 
 raise notice 'Adicionado o usuario WAGNA DA SILVA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8047073  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER ALEXANDRE PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8047073, 
 3,'wagnerpereira.8047073@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER ALEXANDRE PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER ALEXANDRE PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7780885  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER ALVES NEGREIROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7780885, 
 3,'wagnernegreiros.7780885@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER ALVES NEGREIROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER ALVES NEGREIROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8481407  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER AMERICO ISIDORO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8481407, 
 3,'wagnerisidoro.8481407@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER AMERICO ISIDORO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER AMERICO ISIDORO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7347618  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER ANTONIO DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7347618, 
 3,'wagnercarvalho.7347618@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER ANTONIO DE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER ANTONIO DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7229879  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER ARNONI DE ASSUNCAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7229879, 
 3,'wagnerassuncao.7229879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER ARNONI DE ASSUNCAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER ARNONI DE ASSUNCAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7251335  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER BARBOSA DE LIMA PALANCH'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7251335, 
 3,'wagnerpalanch.7251335@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER BARBOSA DE LIMA PALANCH'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER BARBOSA DE LIMA PALANCH'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6766684  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER CUSTODIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6766684, 
 3,'wagnercustodio.6766684@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER CUSTODIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER CUSTODIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7930593  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER DA SILVA ROSCHEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7930593, 
 3,'wagnerroschel.7930593@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER DA SILVA ROSCHEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER DA SILVA ROSCHEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5899770  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER DE FREITAS MAIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5899770, 
 3,'wagnermaia.5899770@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER DE FREITAS MAIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER DE FREITAS MAIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7905858  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER DE LORENCE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7905858, 
 3,'wagnerlima.7905858@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER DE LORENCE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER DE LORENCE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8427879  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER DOS SANTOS SALES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8427879, 
 3,'wagnersales.8427879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER DOS SANTOS SALES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER DOS SANTOS SALES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8548684  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER FERREIRA NEVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8548684, 
 3,'wagnerneves.8548684@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER FERREIRA NEVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER FERREIRA NEVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6668682  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER FREITAS MOTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6668682, 
 3,'wagnermota.6668682@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER FREITAS MOTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER FREITAS MOTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7781024  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER GOMES ALVES JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7781024, 
 3,'wagnerjunior.7781024@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER GOMES ALVES JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER GOMES ALVES JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8023930  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER GONCALVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8023930, 
 3,'wagnersilva.8023930@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER GONCALVES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER GONCALVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7250380  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER LIMA FEITOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7250380, 
 3,'wagnerfeitosa.7250380@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER LIMA FEITOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER LIMA FEITOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6915264  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER MARCEL SANCHES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6915264, 
 3,'wagnersanches.6915264@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER MARCEL SANCHES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER MARCEL SANCHES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8502226  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER MARCELO LAMBERT JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8502226, 
 3,'wagnerjunior.8502226@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER MARCELO LAMBERT JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER MARCELO LAMBERT JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8083371  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER MARTINS ARNOLD'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8083371, 
 3,'wagnerarnold.8083371@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER MARTINS ARNOLD'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER MARTINS ARNOLD'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7826290  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER MORELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7826290, 
 3,'wagnermorelli.7826290@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER MORELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER MORELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8003190  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER MOTA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8003190, 
 3,'wagneroliveira.8003190@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER MOTA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER MOTA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6777295  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6777295, 
 3,'wagnerpereira.6777295@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7866674  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER PEREIRA DA SILVA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7866674, 
 3,'wagnervieira.7866674@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER PEREIRA DA SILVA VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER PEREIRA DA SILVA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8418101  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER PEREIRA GARDUZI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8418101, 
 3,'wagnergarduzi.8418101@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER PEREIRA GARDUZI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER PEREIRA GARDUZI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8853215  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER PEREIRA SAMPAIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8853215, 
 3,'wagnersampaio.8853215@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER PEREIRA SAMPAIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER PEREIRA SAMPAIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5658560  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER RODRIGUES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5658560, 
 3,'wagneroliveira.5658560@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER RODRIGUES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER RODRIGUES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8026637  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER RODRIGUES FLORIANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8026637, 
 3,'wagner.floriano@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER RODRIGUES FLORIANO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER RODRIGUES FLORIANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7755112  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER RODRIGUES TAVARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7755112, 
 3,'wagnertavares.7755112@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER RODRIGUES TAVARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER RODRIGUES TAVARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7209363  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER ROGERIO MANTOVANI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7209363, 
 3,'wagnermantovani.7209363@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER ROGERIO MANTOVANI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER ROGERIO MANTOVANI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8467391  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER TAVARES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8467391, 
 3,'wagnersilva.8467391@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER TAVARES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER TAVARES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39882363814'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER YAGO SERGIO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wagnersantos.e39882363814@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER YAGO SERGIO DOS SANTOS'),
 '39882363814', NULL, true); 
 raise notice 'Adicionado o usuario WAGNER YAGO SERGIO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '00877765375'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDARIA MARACIELLA LEAL DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waldariasilva.00877765375@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDARIA MARACIELLA LEAL DA SILVA'),
 '00877765375', NULL, true); 
 raise notice 'Adicionado o usuario WALDARIA MARACIELLA LEAL DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8402451  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDECK SILVA SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8402451, 
 3,'waldecksouza.8402451@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDECK SILVA SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDECK SILVA SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7872259  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDEMAR MAZZA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7872259, 
 3,'waldemarsilva.7872259@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDEMAR MAZZA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDEMAR MAZZA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8965781  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDEMIRIAN CUSTODIO GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8965781, 
 3,'waldemiriangomes.8965781@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDEMIRIAN CUSTODIO GOMES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDEMIRIAN CUSTODIO GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35612293879'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDENISE DE ARAUJO FILGUEIRA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waldenisepereira.35612293879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDENISE DE ARAUJO FILGUEIRA PEREIRA'),
 '35612293879', NULL, true); 
 raise notice 'Adicionado o usuario WALDENISE DE ARAUJO FILGUEIRA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5547288  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDERES CASTILHO MARQUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5547288, 
 3,'walderesmarques.5547288@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDERES CASTILHO MARQUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDERES CASTILHO MARQUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47991950425'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDERES COSTA ADRIANO ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walderesaraujo.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDERES COSTA ADRIANO ARAUJO'),
 '47991950425', NULL, true); 
 raise notice 'Adicionado o usuario WALDERES COSTA ADRIANO ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6052681  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDETE DOS SANTOS CARLETTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6052681, 
 3,'waldetecarletti.6052681@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDETE DOS SANTOS CARLETTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDETE DOS SANTOS CARLETTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6425577  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDILEIDE PEREIRA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6425577, 
 3,'waldileidelima.6425577@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDILEIDE PEREIRA DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDILEIDE PEREIRA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '60578378515'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDILÉSIA SOUZA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waldilesiasantos.60578378515@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDILÉSIA SOUZA SANTOS'),
 '60578378515', NULL, true); 
 raise notice 'Adicionado o usuario WALDILÉSIA SOUZA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6847846  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDINEIA LUZIA BATISTA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6847846, 
 3,'waldineiavieira.6847846@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDINEIA LUZIA BATISTA VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDINEIA LUZIA BATISTA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7890877  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIR GODOI MARTES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7890877, 
 3,'waldirmartes.7890877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIR GODOI MARTES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDIR GODOI MARTES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6768270  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIR MARREIRO GODOY'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6768270, 
 3,'waldirgodoy.6768270@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIR MARREIRO GODOY'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDIR MARREIRO GODOY'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8100250  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIR SILVA JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8100250, 
 3,'waldirjunior.8100250@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIR SILVA JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDIR SILVA JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8591415  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIRENE ALVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8591415, 
 3,'waldirenesilva.8591415@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIRENE ALVES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDIRENE ALVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '21917098855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIRENE ALVES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waldirenesantos.21917098855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIRENE ALVES DOS SANTOS'),
 '21917098855', NULL, true); 
 raise notice 'Adicionado o usuario WALDIRENE ALVES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8415471  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIRENE ANDRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8415471, 
 3,'waldireneandre.8415471@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIRENE ANDRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDIRENE ANDRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15371548858'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDIRENES WANIA COSTA BELA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waldirenesbela.15371548858@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDIRENES WANIA COSTA BELA'),
 '15371548858', NULL, true); 
 raise notice 'Adicionado o usuario WALDIRENES WANIA COSTA BELA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26934856813'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDNÉA CONCEIÇÃO DA SILVA OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waldneaoliveira.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDNÉA CONCEIÇÃO DA SILVA OLIVEIRA'),
 '26934856813', NULL, true); 
 raise notice 'Adicionado o usuario WALDNÉA CONCEIÇÃO DA SILVA OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8027293  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDO FELIPE GONZALEZ YANEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8027293, 
 3,'waldoyanez.8027293@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDO FELIPE GONZALEZ YANEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDO FELIPE GONZALEZ YANEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5678501  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALDOMIRO DIAS MACHADO JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5678501, 
 3,'waldomirojunior.5678501@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALDOMIRO DIAS MACHADO JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALDOMIRO DIAS MACHADO JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6604358  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALERIA MAGALHÃES FIGLIOLINO DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6604358, 
 3,'waleriaalmeida.6604358@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALERIA MAGALHÃES FIGLIOLINO DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALERIA MAGALHÃES FIGLIOLINO DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8208565  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALERIA ROMERO SCARINCI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8208565, 
 3,'waleriascarinci.8208565@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALERIA ROMERO SCARINCI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALERIA ROMERO SCARINCI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40335742807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALESKA MORAIS DOS ANJOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waleskamorais.40335742807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALESKA MORAIS DOS ANJOS'),
 '40335742807', NULL, true); 
 raise notice 'Adicionado o usuario WALESKA MORAIS DOS ANJOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '16889334841'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALESKA TEREZA VILAR  DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waleskasantos.16889334841@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALESKA TEREZA VILAR  DOS SANTOS'),
 '16889334841', NULL, true); 
 raise notice 'Adicionado o usuario WALESKA TEREZA VILAR  DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44981687800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALISSON GONÇALVES BEZERRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walissonbezerra.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALISSON GONÇALVES BEZERRA '),
 '44981687800', NULL, true); 
 raise notice 'Adicionado o usuario WALISSON GONÇALVES BEZERRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7524552  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA BARBOSA LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7524552, 
 3,'walkirialopes.7524552@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA BARBOSA LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA BARBOSA LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8205451  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA CLAUDINO DE OLIVEIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8205451, 
 3,'walkiriasilva.8205451@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA CLAUDINO DE OLIVEIRA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA CLAUDINO DE OLIVEIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8198543  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA DE ANDRADE ULIANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8198543, 
 3,'walkiriauliana.8198543@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA DE ANDRADE ULIANA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA DE ANDRADE ULIANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '14216925898'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walkiriasantos.14216925898@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA DE LIMA'),
 '14216925898', NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8799067  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA RAMOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8799067, 
 3,'walkiriaramos.8799067@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA RAMOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA RAMOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6770797  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA ROSA SANTILLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6770797, 
 3,'walkiriasantilli.6770797@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA ROSA SANTILLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA ROSA SANTILLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8591326  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA SALES DA SILVA MORAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8591326, 
 3,'walkiriamoraes.8591326@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA SALES DA SILVA MORAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA SALES DA SILVA MORAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31219141895'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA SILVA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walkiriasouza.31219141895@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA SILVA DE SOUZA'),
 '31219141895', NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA SILVA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6848915  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA TELLES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6848915, 
 3,'walkiriasilva.6848915@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA TELLES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA TELLES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5466334  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKYRIA DA COSTA BOMBONATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5466334, 
 3,'walkyriabombonato.5466334@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKYRIA DA COSTA BOMBONATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKYRIA DA COSTA BOMBONATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26425709839'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKYRIA DE MELO BORGES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walkyriaborges.26425709839@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKYRIA DE MELO BORGES'),
 '26425709839', NULL, true); 
 raise notice 'Adicionado o usuario WALKYRIA DE MELO BORGES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7539533  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKYRIA MARIA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7539533, 
 3,'walkyriaoliveira.7539533@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKYRIA MARIA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKYRIA MARIA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8095531  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKYRIA SFORZIN BORGES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8095531, 
 3,'walkyriaborges.8095531@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKYRIA SFORZIN BORGES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKYRIA SFORZIN BORGES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8493782  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKÍRIA IRMA VIEIRA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8493782, 
 3,'walkiriaoliveira.8493782@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKÍRIA IRMA VIEIRA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKÍRIA IRMA VIEIRA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40942226852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALLACE YAGO LEITE SANTANA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wallacesilva.e40942226852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALLACE YAGO LEITE SANTANA DA SILVA'),
 '40942226852', NULL, true); 
 raise notice 'Adicionado o usuario WALLACE YAGO LEITE SANTANA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50905327888'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALLERY CRISTINA DOS SANTOS MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wallerymatos.e50905327888@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALLERY CRISTINA DOS SANTOS MATOS'),
 '50905327888', NULL, true); 
 raise notice 'Adicionado o usuario WALLERY CRISTINA DOS SANTOS MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8129771  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALLESKA DE ASSIS OLIVEIRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8129771, 
 3,'walleskaoliveira.8129771@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALLESKA DE ASSIS OLIVEIRA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALLESKA DE ASSIS OLIVEIRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9191119  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALLISON BEZERRA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9191119, 
 3,'wallisonjesus.9191119@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALLISON BEZERRA DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALLISON BEZERRA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6719643  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALMIR SIQUEIRA RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6719643, 
 3,'walmirribeiro.6719643@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALMIR SIQUEIRA RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALMIR SIQUEIRA RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8890889  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALMIRA SANTOS PIMENTA DE SOUZA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8890889, 
 3,'walmraspsouza.8890889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALMIRA SANTOS PIMENTA DE SOUZA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALMIRA SANTOS PIMENTA DE SOUZA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6908462  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUILANIA SILVEIRA PAULINO NOGUEIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6908462, 
 3,'walquilaniasilva.6908462@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUILANIA SILVEIRA PAULINO NOGUEIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUILANIA SILVEIRA PAULINO NOGUEIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26358803875'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA ALESSANDRA PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walquiriapereira.26358803875@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA ALESSANDRA PEREIRA DA SILVA'),
 '26358803875', NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA ALESSANDRA PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6957307  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA ALVES PEREIRA DA LUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6957307, 
 3,'walquirialuz.6957307@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA ALVES PEREIRA DA LUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA ALVES PEREIRA DA LUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7530064  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA APARECIDA DE MORAES DE CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7530064, 
 3,'walquiriacastro.7530064@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA APARECIDA DE MORAES DE CASTRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA APARECIDA DE MORAES DE CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5535999  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA BITENCOURT RAMOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5535999, 
 3,'walquiriaramos.5535999@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA BITENCOURT RAMOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA BITENCOURT RAMOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8212082  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA BRITO CUNHA DE MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8212082, 
 3,'walquiriamoura.8212082@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA BRITO CUNHA DE MOURA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA BRITO CUNHA DE MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33842173814'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA DA SILVA MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walquiriamoreira.33842173814@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA DA SILVA MOREIRA'),
 '33842173814', NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA DA SILVA MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7790881  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA GOMES DE SANTANA GONCALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7790881, 
 3,'walquiriagoncalves.7790881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA GOMES DE SANTANA GONCALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA GOMES DE SANTANA GONCALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37037301884'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA JACINTA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walquiriaferreira.37037301884@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA JACINTA FERREIRA'),
 '37037301884', NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA JACINTA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35589004802'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA MAGALHAES AZEVEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walquiriaazevedo.35589004802@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA MAGALHAES AZEVEDO'),
 '35589004802', NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA MAGALHAES AZEVEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8288321  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA SANTOS NOGUEIRA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8288321, 
 3,'walquiriasouza.8288321@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA SANTOS NOGUEIRA DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA SANTOS NOGUEIRA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7767293  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALQUIRIA SIMOES MESQUITA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7767293, 
 3,'walquiriamesquita.7767293@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALQUIRIA SIMOES MESQUITA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALQUIRIA SIMOES MESQUITA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8424691  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER APARECIDO BORGES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8424691, 
 3,'walterborges.8424691@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER APARECIDO BORGES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER APARECIDO BORGES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8361908  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER DE SOUZA DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8361908, 
 3,'walterdias.8361908@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER DE SOUZA DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER DE SOUZA DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8482641  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER FÁVARO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8482641, 
 3,'waltersantos.8482641@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER FÁVARO SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER FÁVARO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33816227813'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER JEFFERSON  FABRIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walterfabris.33816227813@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER JEFFERSON  FABRIS'),
 '33816227813', NULL, true); 
 raise notice 'Adicionado o usuario WALTER JEFFERSON  FABRIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5789079  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER JESUS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5789079, 
 3,'waltersantos.5789079@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER JESUS DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER JESUS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6861709  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER LUIZ MARIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6861709, 
 3,'waltermaria.6861709@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER LUIZ MARIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER LUIZ MARIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6800271  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER MARINHO DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6800271, 
 3,'walteraraujo.6800271@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER MARINHO DE ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER MARINHO DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6363369  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALTER ZENIO GOMES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6363369, 
 3,'walteroliveira.6363369@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALTER ZENIO GOMES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALTER ZENIO GOMES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7503610  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALVENARCK RAMOS SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7503610, 
 3,'walvenarcksouza.7503610@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALVENARCK RAMOS SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALVENARCK RAMOS SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37432399816'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALÉRIA APARECIDA CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waleriacarvalho.37432399816@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALÉRIA APARECIDA CARVALHO'),
 '37432399816', NULL, true); 
 raise notice 'Adicionado o usuario WALÉRIA APARECIDA CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33928876848'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDA BOLDRINI VIDAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wandavidal.33928876848@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDA BOLDRINI VIDAL'),
 '33928876848', NULL, true); 
 raise notice 'Adicionado o usuario WANDA BOLDRINI VIDAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6749518  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDA CATARINA BAUNGARTNER GALVAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6749518, 
 3,'wandagalvao.6749518@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDA CATARINA BAUNGARTNER GALVAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDA CATARINA BAUNGARTNER GALVAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32851428802'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDA DE JESUS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wandasantos.32851428802@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDA DE JESUS DOS SANTOS'),
 '32851428802', NULL, true); 
 raise notice 'Adicionado o usuario WANDA DE JESUS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8200882  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDA DE OLIVEIRA MORAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8200882, 
 3,'wandamorais.8200882@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDA DE OLIVEIRA MORAIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDA DE OLIVEIRA MORAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33663131882'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDA MARIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wandasantos.33663131882@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDA MARIA DOS SANTOS'),
 '33663131882', NULL, true); 
 raise notice 'Adicionado o usuario WANDA MARIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31589352874'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDA REGINA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wandacosta.31589352874@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDA REGINA COSTA'),
 '31589352874', NULL, true); 
 raise notice 'Adicionado o usuario WANDA REGINA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8024138  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDEIR MARIA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8024138, 
 3,'wandeirsilva.8024138@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDEIR MARIA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDEIR MARIA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7213263  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDELSON PEREIRA MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7213263, 
 3,'wandelsonmoura.7213263@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDELSON PEREIRA MOURA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDELSON PEREIRA MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '41810030862'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDER DOS SANTOS TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanderteixeira.e41810030862@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDER DOS SANTOS TEIXEIRA'),
 '41810030862', NULL, true); 
 raise notice 'Adicionado o usuario WANDER DOS SANTOS TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7222530  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDER MARQUES VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7222530, 
 3,'wandervieira.7222530@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDER MARQUES VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDER MARQUES VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8417822  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDER ONORIO PACHECO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8417822, 
 3,'wanderpacheco.8417822@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDER ONORIO PACHECO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDER ONORIO PACHECO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6810365  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERBERG ALVES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6810365, 
 3,'wanderbergsouza.6810365@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERBERG ALVES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERBERG ALVES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42594846805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLANDYA MORAIS PEIXOTO DOLCI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanderlandyampdolci.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLANDYA MORAIS PEIXOTO DOLCI'),
 '42594846805', NULL, true); 
 raise notice 'Adicionado o usuario WANDERLANDYA MORAIS PEIXOTO DOLCI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8462232  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEI EVARISTO DE MATTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8462232, 
 3,'wanderleimattos.8462232@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEI EVARISTO DE MATTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEI EVARISTO DE MATTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6947964  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEI SILVA AVERALDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6947964, 
 3,'wanderleiaveraldo.6947964@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEI SILVA AVERALDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEI SILVA AVERALDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8916560  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEIA DE SOUSA MORAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8916560, 
 3,'wanderleiamorais.8916560@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEIA DE SOUSA MORAIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEIA DE SOUSA MORAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7728719  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEIA GOMES DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7728719, 
 3,'wanderleiajesus.7728719@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEIA GOMES DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEIA GOMES DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '86057103300'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEIA VANA BATISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanderleiabatista.86057103300@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEIA VANA BATISTA'),
 '86057103300', NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEIA VANA BATISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7550081  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEY ANTONIO CARRER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7550081, 
 3,'wanderleycarrer.7550081@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEY ANTONIO CARRER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEY ANTONIO CARRER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6897321  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEY FRANCISCO VIRGILIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6897321, 
 3,'wanderleyvirgilio.6897321@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEY FRANCISCO VIRGILIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEY FRANCISCO VIRGILIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7250622  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEY MACHADO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7250622, 
 3,'wanderleysouza.7250622@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEY MACHADO DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEY MACHADO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8598711  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEY PELLICCI BIGHETTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8598711, 
 3,'wanderleybighetti.8598711@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEY PELLICCI BIGHETTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEY PELLICCI BIGHETTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6689051  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLEY SOARES MACIEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6689051, 
 3,'wanderleymaciel.6689051@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLEY SOARES MACIEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLEY SOARES MACIEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '24588785800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLI APARECIDA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanderlisantos.24588785800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLI APARECIDA DOS SANTOS'),
 '24588785800', NULL, true); 
 raise notice 'Adicionado o usuario WANDERLI APARECIDA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8233594  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLY GARCIA BARUEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8233594, 
 3,'wanderlybaruel.8233594@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLY GARCIA BARUEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLY GARCIA BARUEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6015433  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDERLY PASTOR DE OLIVEIRA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6015433, 
 3,'wanderlylima.6015433@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDERLY PASTOR DE OLIVEIRA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDERLY PASTOR DE OLIVEIRA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8481628  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANDREILLA MOREIRA GARCIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8481628, 
 3,'wandreillagarcia.8481628@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANDREILLA MOREIRA GARCIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANDREILLA MOREIRA GARCIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28506950848'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA APARECIDA SANTANA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanessapereira.28506950848@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA APARECIDA SANTANA PEREIRA'),
 '28506950848', NULL, true); 
 raise notice 'Adicionado o usuario WANESSA APARECIDA SANTANA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30115887830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA DE OLIVEIRA SEVERINO ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanessaalmeida.30115887830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA DE OLIVEIRA SEVERINO ALMEIDA'),
 '30115887830', NULL, true); 
 raise notice 'Adicionado o usuario WANESSA DE OLIVEIRA SEVERINO ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8403007  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA FELIPE DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8403007, 
 3,'wanessasilva.8403007@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA FELIPE DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSA FELIPE DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36579493801'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA GONÇALVES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanessadeoliveira.36579493801@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA GONÇALVES DE OLIVEIRA'),
 '36579493801', NULL, true); 
 raise notice 'Adicionado o usuario WANESSA GONÇALVES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7531214  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA JANUÁRIO REZENDE LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7531214, 
 3,'wanessalopes.7531214@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA JANUÁRIO REZENDE LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSA JANUÁRIO REZENDE LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8462160  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA JULIA SALES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8462160, 
 3,'wanessaoliveira.8462160@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA JULIA SALES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSA JULIA SALES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36923128811'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA LIMA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanessasilva.36923128811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA LIMA SILVA'),
 '36923128811', NULL, true); 
 raise notice 'Adicionado o usuario WANESSA LIMA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31425471827'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA MARIA CASTRO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wnanessamaria.31425471827@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA MARIA CASTRO SILVA'),
 '31425471827', NULL, true); 
 raise notice 'Adicionado o usuario WANESSA MARIA CASTRO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34125471827'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA MARIA CASTRO SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanessasilva.34125471827@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA MARIA CASTRO SILVA '),
 '34125471827', NULL, true); 
 raise notice 'Adicionado o usuario WANESSA MARIA CASTRO SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8203687  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA PETRAGLIA MIGUEL MASSARI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8203687, 
 3,'wanessamassari.8203687@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA PETRAGLIA MIGUEL MASSARI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSA PETRAGLIA MIGUEL MASSARI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7388012  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7388012, 
 3,'wanessarodrigues.7388012@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8271984  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSA RODRIGUES DE SOUZA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8271984, 
 3,'wanessasouza.8271984@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSA RODRIGUES DE SOUZA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSA RODRIGUES DE SOUZA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8774072  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANESSSA ANDRADE DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8774072, 
 3,'wanessasantos.8774072@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANESSSA ANDRADE DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANESSSA ANDRADE DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27354836818'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANGLEY DOS SANTOS LEME'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wangleyleme27354836818@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANGLEY DOS SANTOS LEME'),
 '27354836818', NULL, true); 
 raise notice 'Adicionado o usuario WANGLEY DOS SANTOS LEME'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7906277  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA APARECIDA GUEDES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7906277, 
 3,'waniasilva.7906277@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA APARECIDA GUEDES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIA APARECIDA GUEDES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9335678805  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA CRISTINA GOMES DE ONOFRIO MARQUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9335678805, 
 3,'waniamarques.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA CRISTINA GOMES DE ONOFRIO MARQUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIA CRISTINA GOMES DE ONOFRIO MARQUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5910935  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA CRISTINA MANOEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5910935, 
 3,'waniamanoel.5910935@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA CRISTINA MANOEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIA CRISTINA MANOEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22491391805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA DA COSTA SEBASTIÃO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waniasebastiao.22491391805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA DA COSTA SEBASTIÃO'),
 '22491391805', NULL, true); 
 raise notice 'Adicionado o usuario WANIA DA COSTA SEBASTIÃO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6466419  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA MAGALHAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6466419, 
 3,'waniamagalhaes.6466419@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA MAGALHAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIA MAGALHAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '06440522604'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA MARIA ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'waniaalves.06440522604@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA MARIA ALVES'),
 '06440522604', NULL, true); 
 raise notice 'Adicionado o usuario WANIA MARIA ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8064229  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA MERBOLD RAMALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8064229, 
 3,'waniaramalho.8064229@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA MERBOLD RAMALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIA MERBOLD RAMALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7445482  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIA TONIN DE MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7445482, 
 3,'waniamelo.7445482@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIA TONIN DE MELO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIA TONIN DE MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6911633  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANIL POLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6911633, 
 3,'wanilpoli.6911633@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANIL POLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANIL POLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34149423806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANISE DA SILVA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wanisesantos.34149423806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANISE DA SILVA SANTOS'),
 '34149423806', NULL, true); 
 raise notice 'Adicionado o usuario WANISE DA SILVA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8389381  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANKEILA PEREIRA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8389381, 
 3,'wankeilasantos.8389381@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANKEILA PEREIRA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANKEILA PEREIRA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8029407  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANTUIR DOS REIS MARIANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8029407, 
 3,'wantuirmariano.8029407@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANTUIR DOS REIS MARIANO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANTUIR DOS REIS MARIANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7444273  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WANUSA RODRIGUES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7444273, 
 3,'wanusasilva.7444273@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WANUSA RODRIGUES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WANUSA RODRIGUES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6931588  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON ALMEIDA SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6931588, 
 3,'washingtonsouza.6931588@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON ALMEIDA SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON ALMEIDA SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8250430  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON BARROS GONZAGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8250430, 
 3,'washingtongonzaga.8250430@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON BARROS GONZAGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON BARROS GONZAGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8482624  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON BEZERRA FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8482624, 
 3,'washingtonfernandes.8482624@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON BEZERRA FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON BEZERRA FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8244065  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON GIBSON PINHEIRO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8244065, 
 3,'washingtonsilva.8244065@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON GIBSON PINHEIRO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON GIBSON PINHEIRO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7439431  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON JOSE OLIVEIRA DA FONSECA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7439431, 
 3,'washingtonfonseca.7439431@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON JOSE OLIVEIRA DA FONSECA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON JOSE OLIVEIRA DA FONSECA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5642621  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON LUIS CORDEIRO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5642621, 
 3,'washingtonsantos.5642621@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON LUIS CORDEIRO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON LUIS CORDEIRO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37393221870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON LUIZ DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'washingtonsilva.37393221870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON LUIZ DA SILVA'),
 '37393221870', NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON LUIZ DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6941087  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON ROBERTO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6941087, 
 3,'washingtonsilva.6941087@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON ROBERTO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON ROBERTO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8420033  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WASHINGTON SOARES SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8420033, 
 3,'washingtonsilva.8420033@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WASHINGTON SOARES SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WASHINGTON SOARES SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7424302  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WATSON DOS SANTOS MESSIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7424302, 
 3,'watsonmessias.7424302@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WATSON DOS SANTOS MESSIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WATSON DOS SANTOS MESSIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8548811  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEBER FERREIRA CANDIDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8548811, 
 3,'webercandido.8548811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEBER FERREIRA CANDIDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WEBER FERREIRA CANDIDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42283952875'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEDINA KELI  GALDINO DOS ANJOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wedinaanjos.42283952875@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEDINA KELI  GALDINO DOS ANJOS'),
 '42283952875', NULL, true); 
 raise notice 'Adicionado o usuario WEDINA KELI  GALDINO DOS ANJOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36017561880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEDJA CARLA DA SILVA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wedjacosta.36017561880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEDJA CARLA DA SILVA COSTA'),
 '36017561880', NULL, true); 
 raise notice 'Adicionado o usuario WEDJA CARLA DA SILVA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '14204536883'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEDJA CRISTIANA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wedjasilva.14204536883@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEDJA CRISTIANA DA SILVA'),
 '14204536883', NULL, true); 
 raise notice 'Adicionado o usuario WEDJA CRISTIANA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26216075861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEDJA SILVA DE LIMA SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wedjalima.26216075861@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEDJA SILVA DE LIMA SANTANA'),
 '26216075861', NULL, true); 
 raise notice 'Adicionado o usuario WEDJA SILVA DE LIMA SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27028018890'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEDJA TAVARES DA SILVA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wedjaoliveira.27028018890@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEDJA TAVARES DA SILVA DE OLIVEIRA'),
 '27028018890', NULL, true); 
 raise notice 'Adicionado o usuario WEDJA TAVARES DA SILVA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32291174843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEIDA FADIA BARROS MANCINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'weidamancini.32291174843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEIDA FADIA BARROS MANCINI'),
 '32291174843', NULL, true); 
 raise notice 'Adicionado o usuario WEIDA FADIA BARROS MANCINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33831995842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEIDY KARLA FONSECA MACEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'weidymacedo.33831995842@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEIDY KARLA FONSECA MACEDO'),
 '33831995842', NULL, true); 
 raise notice 'Adicionado o usuario WEIDY KARLA FONSECA MACEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34803438803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELBERT NERE SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'welbertsilva.e34803438803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELBERT NERE SILVA'),
 '34803438803', NULL, true); 
 raise notice 'Adicionado o usuario WELBERT NERE SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8597863  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELDER LOPES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8597863, 
 3,'weldersantos.8597863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELDER LOPES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELDER LOPES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8041687  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELHENTON FREIRE DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8041687, 
 3,'welhentonsilva.8041687@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELHENTON FREIRE DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELHENTON FREIRE DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8481636  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELINGTON DOS ANJOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8481636, 
 3,'welingtonsilva.8481636@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELINGTON DOS ANJOS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELINGTON DOS ANJOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8004005  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELINGTON MARIANO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8004005, 
 3,'welingtonsilva.8004005@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELINGTON MARIANO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELINGTON MARIANO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36555840838'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELINGTON RALF LOPES OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'welingtonoliveira.e36555840838@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELINGTON RALF LOPES OLIVEIRA'),
 '36555840838', NULL, true); 
 raise notice 'Adicionado o usuario WELINGTON RALF LOPES OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33539606866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELITON ALEXANDRE DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'welitonsilva.e33539606866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELITON ALEXANDRE DA SILVA'),
 '33539606866', NULL, true); 
 raise notice 'Adicionado o usuario WELITON ALEXANDRE DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37279222811'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLEN BATISTA DE MENEZES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wellenmenezes.37279222811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLEN BATISTA DE MENEZES'),
 '37279222811', NULL, true); 
 raise notice 'Adicionado o usuario WELLEN BATISTA DE MENEZES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44503455842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLEN LARISSA SILVA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wellenferreira.44503455842@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLEN LARISSA SILVA FERREIRA'),
 '44503455842', NULL, true); 
 raise notice 'Adicionado o usuario WELLEN LARISSA SILVA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7905483  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLIGTON DOS SANTOS FARIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7905483, 
 3,'welligtonfarias.7905483@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLIGTON DOS SANTOS FARIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLIGTON DOS SANTOS FARIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8019746  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGHTON SA TELES CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8019746, 
 3,'wellinghtoncarvalho.8019746@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGHTON SA TELES CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGHTON SA TELES CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7934521  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON CAMARGO FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7934521, 
 3,'wellingtonfernandes.7934521@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON CAMARGO FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON CAMARGO FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31577694805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON COELHO GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wellingtongomes.31577694805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON COELHO GOMES'),
 '31577694805', NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON COELHO GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7928190  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON DA SILVA MACIEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7928190, 
 3,'wellingtonmaciel.7928190@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON DA SILVA MACIEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON DA SILVA MACIEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8230463  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON FERREIRA LEITE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8230463, 
 3,'wellingtonleite.8230463@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON FERREIRA LEITE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON FERREIRA LEITE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7831234  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON GABRIEL DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7831234, 
 3,'wellingtonalmeida.7831234@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON GABRIEL DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON GABRIEL DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7749708  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON GOMES DE ASSIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7749708, 
 3,'wellingtonassis.7749708@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON GOMES DE ASSIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON GOMES DE ASSIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7538413  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON GUSTAVO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7538413, 
 3,'wellingtonpereira.7538413@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON GUSTAVO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON GUSTAVO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8440638  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON JOSE DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8440638, 
 3,'wellingtonsilva.8440638@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON JOSE DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON JOSE DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8420271  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON JOSÉ DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8420271, 
 3,'wellingtonsilva.8420271@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON JOSÉ DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON JOSÉ DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8416664  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON MARTINS MATEUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8416664, 
 3,'wellingtonmateus.8416664@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON MARTINS MATEUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON MARTINS MATEUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7943075  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON RENAN RODRIGUES LANDIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7943075, 
 3,'wellingtonlandim.7943075@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON RENAN RODRIGUES LANDIM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON RENAN RODRIGUES LANDIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8438811  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON ROBERTO PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8438811, 
 3,'wellingtonsilva.8438811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON ROBERTO PEREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON ROBERTO PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8022038  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON RODRIGUES DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8022038, 
 3,'wellingtonlima.8022038@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON RODRIGUES DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON RODRIGUES DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8024014  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON ROGERIO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8024014, 
 3,'wellingtonpereira.8024014@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON ROGERIO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON ROGERIO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8201749  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON SANTANA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8201749, 
 3,'wellingtonsantos.8201749@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON SANTANA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON SANTANA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8034427  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON SANTOS DE ASSIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8034427, 
 3,'wellingtonassis.8034427@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON SANTOS DE ASSIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON SANTOS DE ASSIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38866613851'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON SANTOS PAES LANDIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wellingtonlandin.38866613851@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON SANTOS PAES LANDIM'),
 '38866613851', NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON SANTOS PAES LANDIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7427204  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON SOARES DA CUNHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7427204, 
 3,'wellingtoncunha.7427204@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON SOARES DA CUNHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON SOARES DA CUNHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8271313  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON VIEIRA FREIRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8271313, 
 3,'wellingtonfreire.8271313@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON VIEIRA FREIRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON VIEIRA FREIRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35563288870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLITNIA MARIA DOS SANTOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wellitniasilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLITNIA MARIA DOS SANTOS SILVA'),
 '35563288870', NULL, true); 
 raise notice 'Adicionado o usuario WELLITNIA MARIA DOS SANTOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8469261  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELTON RODRIGUES DA MATA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8469261, 
 3,'weltonmata.8469261@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELTON RODRIGUES DA MATA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELTON RODRIGUES DA MATA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45260154827'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDE ALÍCIA SOIER SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendesouza.45260154827@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDE ALÍCIA SOIER SOUZA'),
 '45260154827', NULL, true); 
 raise notice 'Adicionado o usuario WENDE ALÍCIA SOIER SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8499179  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDEL CAMARGO MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8499179, 
 3,'wendelmendes.8499179@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDEL CAMARGO MENDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDEL CAMARGO MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8466769  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDEL DOS SANTOS DE MENEZES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8466769, 
 3,'wendelmenezes.8466769@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDEL DOS SANTOS DE MENEZES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDEL DOS SANTOS DE MENEZES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7478895  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDEL MOREIRA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7478895, 
 3,'wendeloliveira.7478895@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDEL MOREIRA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDEL MOREIRA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7302673  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDELL AUGUSTO GUIMARAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7302673, 
 3,'wendellguimaraes.7302673@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDELL AUGUSTO GUIMARAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDELL AUGUSTO GUIMARAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8191034  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDELL GOMES MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8191034, 
 3,'wendellmatos.8191034@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDELL GOMES MATOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDELL GOMES MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8023409  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDERSON DE ARAUJO FARIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8023409, 
 3,'wendersonfaria.8023409@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDERSON DE ARAUJO FARIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDERSON DE ARAUJO FARIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38906851880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDEVANIA TAVARES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendevaniasilva.e38906851880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDEVANIA TAVARES DA SILVA'),
 '38906851880', NULL, true); 
 raise notice 'Adicionado o usuario WENDEVANIA TAVARES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '54199923888'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDHY STHEPHANY PINTO BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendhybarbosa.e54199923888@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDHY STHEPHANY PINTO BARBOSA'),
 '54199923888', NULL, true); 
 raise notice 'Adicionado o usuario WENDHY STHEPHANY PINTO BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '06511164306'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDY CORLATE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendycorlate.06511164306@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDY CORLATE'),
 '06511164306', NULL, true); 
 raise notice 'Adicionado o usuario WENDY CORLATE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42653516896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDY MACHADO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendysantos.e42653516896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDY MACHADO DOS SANTOS'),
 '42653516896', NULL, true); 
 raise notice 'Adicionado o usuario WENDY MACHADO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '29395548894'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDY SOUSA DA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendyrocha.29395548894@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDY SOUSA DA ROCHA'),
 '29395548894', NULL, true); 
 raise notice 'Adicionado o usuario WENDY SOUSA DA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28471239892'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDY VIEIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wendysantos.28471239892@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDY VIEIRA DOS SANTOS'),
 '28471239892', NULL, true); 
 raise notice 'Adicionado o usuario WENDY VIEIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9190716  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WERLON DA PAIXÃO COSTA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9190716, 
 3,'werlonsilva.9190716@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WERLON DA PAIXÃO COSTA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WERLON DA PAIXÃO COSTA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8496781  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WERNER ROBERTO VIANA LUCIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8496781, 
 3,'wernerlucio.8496781@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WERNER ROBERTO VIANA LUCIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WERNER ROBERTO VIANA LUCIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8161321  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WERNER ROGERIO GALHARDO ALEN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8161321, 
 3,'werneralen.8161321@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WERNER ROGERIO GALHARDO ALEN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WERNER ROGERIO GALHARDO ALEN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8514186  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WERTON CALLENDER VARJAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8514186, 
 3,'wertonvarjao.8514186@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WERTON CALLENDER VARJAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WERTON CALLENDER VARJAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7493762  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESICLECYA DA SILVA BARROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7493762, 
 3,'wesiclecyabarros.7493762@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESICLECYA DA SILVA BARROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESICLECYA DA SILVA BARROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8398577  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY BATISTA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8398577, 
 3,'wesleysantos.8398577@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY BATISTA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY BATISTA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8221626  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY BISPO ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8221626, 
 3,'wesleyalves.8221626@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY BISPO ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY BISPO ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8424926  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY CRISTIANO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8424926, 
 3,'wesleysouza.8424926@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY CRISTIANO DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY CRISTIANO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8424985  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY DA SILVA MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8424985, 
 3,'wesleymartins.8424985@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY DA SILVA MARTINS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY DA SILVA MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8482403  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY DE LIMA GONCALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8482403, 
 3,'wesleygoncalves.8482403@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY DE LIMA GONCALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY DE LIMA GONCALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8085854  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY DE SOUSA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8085854, 
 3,'wesleyvieira.8085854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY DE SOUSA VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY DE SOUSA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44824278880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY DE SOUZA GAMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wesleygama.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY DE SOUZA GAMA'),
 '44824278880', NULL, true); 
 raise notice 'Adicionado o usuario WESLEY DE SOUZA GAMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '46882259895'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY DOS REIS VIANA ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wesleyaraujo.e46882259895@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY DOS REIS VIANA ARAUJO'),
 '46882259895', NULL, true); 
 raise notice 'Adicionado o usuario WESLEY DOS REIS VIANA ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34437289870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY DOS SANTOS CAMARGO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wesleycamargo.34437289870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY DOS SANTOS CAMARGO'),
 '34437289870', NULL, true); 
 raise notice 'Adicionado o usuario WESLEY DOS SANTOS CAMARGO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8511934  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY GONCALVES SIMOES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8511934, 
 3,'wesleysimoes.8511934@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY GONCALVES SIMOES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY GONCALVES SIMOES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '52802733842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY PEREIRA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wesleylima.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY PEREIRA DE LIMA'),
 '52802733842', NULL, true); 
 raise notice 'Adicionado o usuario WESLEY PEREIRA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50939353873'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY ROCHA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wesleysilva.e50939353873@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY ROCHA SILVA'),
 '50939353873', NULL, true); 
 raise notice 'Adicionado o usuario WESLEY ROCHA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9117709  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLEY SELES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9117709, 
 3,'wesleysoliveira.9117709@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLEY SELES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLEY SELES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8416826  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WESLLEY ALEGRETTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8416826, 
 3,'weslleyalegretti.8416826@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WESLLEY ALEGRETTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WESLLEY ALEGRETTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44374981861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WEVWETON FELIPH DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wevertonsilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WEVWETON FELIPH DA SILVA'),
 '44374981861', NULL, true); 
 raise notice 'Adicionado o usuario WEVWETON FELIPH DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43292754810'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WHAGATA APARECIDA PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'whagatasilva.43292754810@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WHAGATA APARECIDA PEREIRA DA SILVA'),
 '43292754810', NULL, true); 
 raise notice 'Adicionado o usuario WHAGATA APARECIDA PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '24056241848'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WHALYSSON WILLIAN AMARO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'whalyssonsouza.e24056241848@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WHALYSSON WILLIAN AMARO DE SOUZA'),
 '24056241848', NULL, true); 
 raise notice 'Adicionado o usuario WHALYSSON WILLIAN AMARO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8422982  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WIDER APARECIDO RODRIGUES DE SOUA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8422982, 
 3,'widersouza.8422982@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WIDER APARECIDO RODRIGUES DE SOUA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WIDER APARECIDO RODRIGUES DE SOUA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50424298830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WIGNER LOURRAN FERREIRA DA SILVA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wignersantos.e50424298830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WIGNER LOURRAN FERREIRA DA SILVA SANTOS'),
 '50424298830', NULL, true); 
 raise notice 'Adicionado o usuario WIGNER LOURRAN FERREIRA DA SILVA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8148457  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILCEA DOS SANTOS COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8148457, 
 3,'wilceacosta.8148457@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILCEA DOS SANTOS COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILCEA DOS SANTOS COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8194335  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILDIANE SOUSA BRAGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8194335, 
 3,'wildianebraga.8194335@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILDIANE SOUSA BRAGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILDIANE SOUSA BRAGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36645339844'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILDMA FERNANDES COSTA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wildmarocha.36645339844@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILDMA FERNANDES COSTA ROCHA'),
 '36645339844', NULL, true); 
 raise notice 'Adicionado o usuario WILDMA FERNANDES COSTA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8450633  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILHAERTE ANTONIO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8450633, 
 3,'wilhaertesilva.8450633@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILHAERTE ANTONIO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILHAERTE ANTONIO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7435282  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIAM JOSE DA SILVA MATHIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7435282, 
 3,'wiliammathias.7435282@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIAM JOSE DA SILVA MATHIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILIAM JOSE DA SILVA MATHIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7209533  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIAM PEREIRA FROTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7209533, 
 3,'wiliamfrota.7209533@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIAM PEREIRA FROTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILIAM PEREIRA FROTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8026947  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIAN ANTONIO GUIMARAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8026947, 
 3,'wilianguimaraes.8026947@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIAN ANTONIO GUIMARAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILIAN ANTONIO GUIMARAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8468427  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIAN FAIAS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8468427, 
 3,'wiliansilva.8468427@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIAN FAIAS DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILIAN FAIAS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '41674416830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIANE GALDINO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilianesilva.41674416830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIANE GALDINO SILVA'),
 '41674416830', NULL, true); 
 raise notice 'Adicionado o usuario WILIANE GALDINO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6603386  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIBALDO LEAL PERES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6603386, 
 3,'wilibaldoperes.6603386@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIBALDO LEAL PERES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILIBALDO LEAL PERES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34912727857'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILKA DOS SANTOS MOTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilkamota.34912727857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILKA DOS SANTOS MOTA'),
 '34912727857', NULL, true); 
 raise notice 'Adicionado o usuario WILKA DOS SANTOS MOTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8463131  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLAN CHARLES PEREIRA AMANCIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8463131, 
 3,'willanamancio.8463131@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLAN CHARLES PEREIRA AMANCIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLAN CHARLES PEREIRA AMANCIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8432295  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLANY VASCONCELOS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8432295, 
 3,'willanysantos.8432295@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLANY VASCONCELOS DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLANY VASCONCELOS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8027048  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLEM MARCIO PEREIRA PRATES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8027048, 
 3,'willemprates.8027048@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLEM MARCIO PEREIRA PRATES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLEM MARCIO PEREIRA PRATES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8017531  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM AGNALDO STEVANATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8017531, 
 3,'williamstevanato.8017531@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM AGNALDO STEVANATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM AGNALDO STEVANATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35846986854'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM APARECIDO RODRIGUES PAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'williampais.e35846986854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM APARECIDO RODRIGUES PAIS'),
 '35846986854', NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM APARECIDO RODRIGUES PAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7750340  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM BATISTA CANDIDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7750340, 
 3,'williamcandido.7750340@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM BATISTA CANDIDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM BATISTA CANDIDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33062354828'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM DE MELO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'williamsantos.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM DE MELO SANTOS'),
 '33062354828', NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM DE MELO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8598029  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM DE SOUSA POIATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8598029, 
 3,'williampoiato.8598029@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM DE SOUSA POIATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM DE SOUSA POIATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8419469  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM DE SOUZA NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8419469, 
 3,'williamnascimento.8419469@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM DE SOUZA NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM DE SOUZA NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36577559856'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM DIAS DE MORAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'williammoraes.e36577559856@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM DIAS DE MORAES'),
 '36577559856', NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM DIAS DE MORAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8419035  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM DOS SANTOS COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8419035, 
 3,'williamcosta.8419035@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM DOS SANTOS COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM DOS SANTOS COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7725493  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM GONCALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7725493, 
 3,'williamgoncalves.7725493@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM GONCALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM GONCALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8464880  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM JACOBISON DA SILVA MENDONCA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8464880, 
 3,'williammendonca.8464880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM JACOBISON DA SILVA MENDONCA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM JACOBISON DA SILVA MENDONCA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8016267  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM JOSE DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8016267, 
 3,'williamsantos.8016267@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM JOSE DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM JOSE DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8499381  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM LUIS CAETANO DE SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8499381, 
 3,'williamsousa.8499381@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM LUIS CAETANO DE SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM LUIS CAETANO DE SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7265191  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM MIGUEL DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7265191, 
 3,'williamsilva.7265191@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM MIGUEL DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM MIGUEL DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6971776  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM PEDRO DA CUNHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6971776, 
 3,'williamcunha.6971776@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM PEDRO DA CUNHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM PEDRO DA CUNHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8459321  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM PEREIRA FLORENTINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8459321, 
 3,'williamflorentino.8459321@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM PEREIRA FLORENTINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM PEREIRA FLORENTINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8555761  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM ROCHA DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8555761, 
 3,'williamdias.8555761@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM ROCHA DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM ROCHA DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50713026839'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM SANTOS DA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'williamcosta.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM SANTOS DA COSTA'),
 '50713026839', NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM SANTOS DA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6543588  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM SEBASTIÃO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6543588, 
 3,'williamsilva.6543588@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM SEBASTIÃO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM SEBASTIÃO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7233825  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM SERPA BOETA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7233825, 
 3,'williamboeta.7233825@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM SERPA BOETA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM SERPA BOETA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7918089  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAM VERAS CORDEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7918089, 
 3,'williamcordeiro.7918089@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAM VERAS CORDEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAM VERAS CORDEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8092168  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN DE SOUZA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8092168, 
 3,'williansantos.8092168@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN DE SOUZA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN DE SOUZA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50079188818'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN DOS SANTOS LARINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'willianlarini.e50079188818@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN DOS SANTOS LARINI'),
 '50079188818', NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN DOS SANTOS LARINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7908946  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN NUNES DE CERQUEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7908946, 
 3,'williancerqueira.7908946@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN NUNES DE CERQUEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN NUNES DE CERQUEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8424616  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN PEREIRA BARRETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8424616, 
 3,'willianbarreto.8424616@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN PEREIRA BARRETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN PEREIRA BARRETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7921756  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN PEREIRA CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7921756, 
 3,'williancastro.7921756@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN PEREIRA CASTRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN PEREIRA CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8027072  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8027072, 
 3,'williansilva.8027072@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN PEREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7923597  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN ROBSON SOARES LUCINDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7923597, 
 3,'willianlucindo.7923597@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN ROBSON SOARES LUCINDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN ROBSON SOARES LUCINDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8085773  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN RODRIGUES MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8085773, 
 3,'willianmoreira.8085773@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN RODRIGUES MOREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN RODRIGUES MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8098034  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN SEVERINO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8098034, 
 3,'willianoliveira.8098034@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN SEVERINO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN SEVERINO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8417211  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN TEOFILO VIANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8417211, 
 3,'willianviana.8417211@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN TEOFILO VIANA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN TEOFILO VIANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38532903886'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIANA PEREIRA MARQUES TAVARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'willianatavares.38532903886@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIANA PEREIRA MARQUES TAVARES'),
 '38532903886', NULL, true); 
 raise notice 'Adicionado o usuario WILLIANA PEREIRA MARQUES TAVARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38605639806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIANA TAINA DE SOUZA MARQUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'willianamarques.38605639806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIANA TAINA DE SOUZA MARQUES'),
 '38605639806', NULL, true); 
 raise notice 'Adicionado o usuario WILLIANA TAINA DE SOUZA MARQUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37621754893'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIANS DE SOUZA GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'williansgomes.e37621754893@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIANS DE SOUZA GOMES'),
 '37621754893', NULL, true); 
 raise notice 'Adicionado o usuario WILLIANS DE SOUZA GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8501394  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIANS PASCHOAL DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8501394, 
 3,'willianssouza.8501394@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIANS PASCHOAL DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIANS PASCHOAL DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38367213840'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIANY CARLA PINHEIRO DA SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'willianysilva.38367213840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIANY CARLA PINHEIRO DA SILVA '),
 '38367213840', NULL, true); 
 raise notice 'Adicionado o usuario WILLIANY CARLA PINHEIRO DA SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '61945161353'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA APARECIDA LIMA DE QUEIROZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmaqueiroz61945161353@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA APARECIDA LIMA DE QUEIROZ'),
 '61945161353', NULL, true); 
 raise notice 'Adicionado o usuario WILMA APARECIDA LIMA DE QUEIROZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6755208  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA CECILIA CARREIRA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6755208, 
 3,'wilmapereira.6755208@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA CECILIA CARREIRA PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILMA CECILIA CARREIRA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32902653824'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA CUSINATO CARDOSO DE PAIVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmapaiva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA CUSINATO CARDOSO DE PAIVA'),
 '32902653824', NULL, true); 
 raise notice 'Adicionado o usuario WILMA CUSINATO CARDOSO DE PAIVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '03811413490'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA DE MOURA OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmaoliveira.03811413490@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA DE MOURA OLIVEIRA'),
 '03811413490', NULL, true); 
 raise notice 'Adicionado o usuario WILMA DE MOURA OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '19860913846'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA DE OLIVEIRA BARROS RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmarodrigues.19860913846@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA DE OLIVEIRA BARROS RODRIGUES'),
 '19860913846', NULL, true); 
 raise notice 'Adicionado o usuario WILMA DE OLIVEIRA BARROS RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40614919894'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA DOS SANTOS FRANCISCO BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmabarbosa.40614919894@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA DOS SANTOS FRANCISCO BARBOSA'),
 '40614919894', NULL, true); 
 raise notice 'Adicionado o usuario WILMA DOS SANTOS FRANCISCO BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8399131  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA FELICIANO DE BARROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8399131, 
 3,'wilmabarros.8399131@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA FELICIANO DE BARROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILMA FELICIANO DE BARROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6760104  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA MUER MINDICELLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6760104, 
 3,'wilmamindicello.6760104@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA MUER MINDICELLO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILMA MUER MINDICELLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35122395870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA REGIA ALVES NEVES GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmaneves.35122395870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA REGIA ALVES NEVES GOMES'),
 '35122395870', NULL, true); 
 raise notice 'Adicionado o usuario WILMA REGIA ALVES NEVES GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7949944  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA RUGGERI CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7949944, 
 3,'wilmacampos.7949944@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA RUGGERI CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILMA RUGGERI CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31407384805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILMA SANTOS DA SILVA FIGUEIREDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilmafigueiredo.31407384805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILMA SANTOS DA SILVA FIGUEIREDO'),
 '31407384805', NULL, true); 
 raise notice 'Adicionado o usuario WILMA SANTOS DA SILVA FIGUEIREDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7116314  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON ALBUQUERQUE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7116314, 
 3,'wilsonoliveira.7116314@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON ALBUQUERQUE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON ALBUQUERQUE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6604811  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON ALMEIDA AMARAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6604811, 
 3,'wilsonamaral.6604811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON ALMEIDA AMARAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON ALMEIDA AMARAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8226253  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON ALVES DE BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8226253, 
 3,'wilsonbrito.8226253@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON ALVES DE BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON ALVES DE BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6681247  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON APARECIDO SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6681247, 
 3,'wilsonsouza.6681247@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON APARECIDO SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON APARECIDO SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5741220  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON BATISTA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5741220, 
 3,'wilsonsantos.5741220@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON BATISTA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON BATISTA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7925212  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON CALIXTO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7925212, 
 3,'wilsonsilva.7925212@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON CALIXTO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON CALIXTO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7925239  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON DA CONCEICAO DO SACRAMENTO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7925239, 
 3,'wilsonsantos.7925239@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON DA CONCEICAO DO SACRAMENTO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON DA CONCEICAO DO SACRAMENTO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7703007  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON DA SILVA JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7703007, 
 3,'wilsonjunior.7703007@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON DA SILVA JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON DA SILVA JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8459428  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON DE OLIVEIRA LEAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8459428, 
 3,'wilsonleal.8459428@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON DE OLIVEIRA LEAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON DE OLIVEIRA LEAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7224613  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON DE SOUZA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7224613, 
 3,'wilsonpereira.7224613@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON DE SOUZA PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON DE SOUZA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7964021  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7964021, 
 3,'wilsonsantos.7964021@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9155538  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON FELIX DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9155538, 
 3,'wilsonoliveira.9155538@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON FELIX DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON FELIX DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8022909  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON GONCALVES LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8022909, 
 3,'wilsonlopes.8022909@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON GONCALVES LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON GONCALVES LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7922272  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON KRACIUNAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7922272, 
 3,'wilsonkraciunas.7922272@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON KRACIUNAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON KRACIUNAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7251904  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON MANOEL DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7251904, 
 3,'wilsonlima.7251904@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON MANOEL DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON MANOEL DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7905891  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON MONTEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7905891, 
 3,'wilsonmonteiro.7905891@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON MONTEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON MONTEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6932975  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON MOREIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6932975, 
 3,'wilsonsantos.6932975@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON MOREIRA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON MOREIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6679480  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON OKUMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6679480, 
 3,'wilsonokuma.6679480@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON OKUMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON OKUMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5519748  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON PEREIRA BORGES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5519748, 
 3,'wilsonborges.5519748@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON PEREIRA BORGES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON PEREIRA BORGES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7211546  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON PEREIRA PARENTE FILHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7211546, 
 3,'wilsonfilho.7211546@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON PEREIRA PARENTE FILHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON PEREIRA PARENTE FILHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8022054  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON ROBERTO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8022054, 
 3,'wilsonoliveira.8022054@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON ROBERTO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON ROBERTO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8024189  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON RODRIGUES MOTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8024189, 
 3,'wilsonmota.8024189@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON RODRIGUES MOTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON RODRIGUES MOTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8540128  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON SANTOS DE MIRANDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8540128, 
 3,'wilsonmiranda.8540128@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON SANTOS DE MIRANDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON SANTOS DE MIRANDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '00754222390'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTA FERREIRA LIMA FILHA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wiltafilha.00754222390@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTA FERREIRA LIMA FILHA '),
 '00754222390', NULL, true); 
 raise notice 'Adicionado o usuario WILTA FERREIRA LIMA FILHA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7416822  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON CARLOS AMORIM REZENDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7416822, 
 3,'wiltonrezende.7416822@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON CARLOS AMORIM REZENDE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON CARLOS AMORIM REZENDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6863051  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON CASSIANO DE GOUVEIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6863051, 
 3,'wiltongouveia.6863051@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON CASSIANO DE GOUVEIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON CASSIANO DE GOUVEIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7929986  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON DE MORAES BATISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7929986, 
 3,'Wilton.batista.7929986@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON DE MORAES BATISTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON DE MORAES BATISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8030235  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON FERNANDO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8030235, 
 3,'wiltonsilva.8030235@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON FERNANDO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON FERNANDO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6603815  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON LUIZ DUQUE LYRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6603815, 
 3,'wiltonlyra.6603815@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON LUIZ DUQUE LYRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON LUIZ DUQUE LYRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7785500  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7785500, 
 3,'wiltonsilva.7785500@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON PEREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8017310  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILTON PUNKO GALDINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8017310, 
 3,'wiltongaldino.8017310@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILTON PUNKO GALDINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILTON PUNKO GALDINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6761801  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILZA DE JESUS CONCEICAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6761801, 
 3,'wilzaconceicao.6761801@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILZA DE JESUS CONCEICAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILZA DE JESUS CONCEICAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '29244760894'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILZA LAURA CAMPOS AGUIAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wilzaaguiar.29244760894@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILZA LAURA CAMPOS AGUIAR'),
 '29244760894', NULL, true); 
 raise notice 'Adicionado o usuario WILZA LAURA CAMPOS AGUIAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7437986  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WINSTYA PEIXOTO DE MESQUITA EUFRÁSIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7437986, 
 3,'winstyaeufrasio.7437986@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WINSTYA PEIXOTO DE MESQUITA EUFRÁSIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WINSTYA PEIXOTO DE MESQUITA EUFRÁSIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15771889857'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WIRLENE SOUZA BROCHADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wirlenebrochado.15771889857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WIRLENE SOUZA BROCHADO'),
 '15771889857', NULL, true); 
 raise notice 'Adicionado o usuario WIRLENE SOUZA BROCHADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8388091  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WIVIAN LINARES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8388091, 
 3,'wiviansouza.8388091@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WIVIAN LINARES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WIVIAN LINARES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8468877  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLADEMIR CALDERONI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8468877, 
 3,'wlademircalderoni.8468877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLADEMIR CALDERONI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WLADEMIR CALDERONI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8251223  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLADIMIR AGUIAR DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8251223, 
 3,'wladimirsouza.8251223@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLADIMIR AGUIAR DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WLADIMIR AGUIAR DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '16988801898'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLADIMIR GIMENES NARANJOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wladimirgnaranjos@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLADIMIR GIMENES NARANJOS'),
 '16988801898', NULL, true); 
 raise notice 'Adicionado o usuario WLADIMIR GIMENES NARANJOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8018561  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLADIMIR JANSEN FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8018561, 
 3,'wladimirferreira.8018561@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLADIMIR JANSEN FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WLADIMIR JANSEN FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6749089  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLADIMIR SANCHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6749089, 
 3,'wladimirsancho.6749089@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLADIMIR SANCHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WLADIMIR SANCHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '09234532880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLAKIRIA CÉLIA FIGUEIREDO DE ARAÚJO SIQUEIRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'walkiriasiqueira.09234532880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLAKIRIA CÉLIA FIGUEIREDO DE ARAÚJO SIQUEIRA '),
 '09234532880', NULL, true); 
 raise notice 'Adicionado o usuario WLAKIRIA CÉLIA FIGUEIREDO DE ARAÚJO SIQUEIRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25988004865'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLAUDIMARA HELENA BORGES OLIVEIRA AFFONSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wlaudimaraaffonso.25988004865@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLAUDIMARA HELENA BORGES OLIVEIRA AFFONSO'),
 '25988004865', NULL, true); 
 raise notice 'Adicionado o usuario WLAUDIMARA HELENA BORGES OLIVEIRA AFFONSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35516014883'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLISSES OLIVEIRA AQUINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wlissesoaquino.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLISSES OLIVEIRA AQUINO'),
 '35516014883', NULL, true); 
 raise notice 'Adicionado o usuario WLISSES OLIVEIRA AQUINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25262723861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLLTANIA FEITOSA SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wlltaniasantana.25262723861@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLLTANIA FEITOSA SANTANA'),
 '25262723861', NULL, true); 
 raise notice 'Adicionado o usuario WLLTANIA FEITOSA SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7242654  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WLMA DOS SANTOS '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7242654, 
 3,'wilmasantos.7242654@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WLMA DOS SANTOS '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WLMA DOS SANTOS '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8469229  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WOOLHEMBERG FERREIRA DE MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8469229, 
 3,'woolhembergmelo.8469229@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WOOLHEMBERG FERREIRA DE MELO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WOOLHEMBERG FERREIRA DE MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8471541  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WYANK DOUGLLAS DE ALMEIDA XAVIER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8471541, 
 3,'wyankxavier.8471541@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WYANK DOUGLLAS DE ALMEIDA XAVIER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WYANK DOUGLLAS DE ALMEIDA XAVIER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '05195007411'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WYARA DUARTE DO NASCIMENTO BISPO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wyarabispo.05195007411@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WYARA DUARTE DO NASCIMENTO BISPO'),
 '05195007411', NULL, true); 
 raise notice 'Adicionado o usuario WYARA DUARTE DO NASCIMENTO BISPO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8464774  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WYLIANA NASCIMENTO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8464774, 
 3,'wylianasilva.8464774@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WYLIANA NASCIMENTO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WYLIANA NASCIMENTO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51467838888'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WYVELLYN JOSYHELLEN SOUZA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'wyvellynsilva.e51467838888@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WYVELLYN JOSYHELLEN SOUZA DA SILVA'),
 '51467838888', NULL, true); 
 raise notice 'Adicionado o usuario WYVELLYN JOSYHELLEN SOUZA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7947658  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario XIRLAINE DOS ANJOS SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7947658, 
 3,'xirlainesousa.7947658@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('XIRLAINE DOS ANJOS SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario XIRLAINE DOS ANJOS SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8418501  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario XIRLENE SANTOS SALGUEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8418501, 
 3,'xirlenesalgueiro.8418501@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('XIRLENE SANTOS SALGUEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario XIRLENE SANTOS SALGUEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8450412  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario XÊNIA MARA SILVA DE ARAÚJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8450412, 
 3,'xeniaaraujo.8450412@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('XÊNIA MARA SILVA DE ARAÚJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario XÊNIA MARA SILVA DE ARAÚJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48052451825'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANCA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yancasilva.48052451825@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANCA'),
 '48052451825', NULL, true); 
 raise notice 'Adicionado o usuario YANCA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44100141882'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANCA MENEZES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yancamenezes.44100141882@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANCA MENEZES'),
 '44100141882', NULL, true); 
 raise notice 'Adicionado o usuario YANCA MENEZES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47246579877'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANDRA DA SILVA SANTIAGO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yandrasantiago.e47246579877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANDRA DA SILVA SANTIAGO'),
 '47246579877', NULL, true); 
 raise notice 'Adicionado o usuario YANDRA DA SILVA SANTIAGO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8211655  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANDRA DIAS DE FREITAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8211655, 
 3,'yandrafreitas.8211655@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANDRA DIAS DE FREITAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YANDRA DIAS DE FREITAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45654095854'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANDRA LALLESKA LIMA DE PAIVA BONFIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yandrabonfim.45654095854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANDRA LALLESKA LIMA DE PAIVA BONFIM'),
 '45654095854', NULL, true); 
 raise notice 'Adicionado o usuario YANDRA LALLESKA LIMA DE PAIVA BONFIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42485276854'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANDRA OLIVEIRA LIMA FERREIRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yandraferreira.42485276854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANDRA OLIVEIRA LIMA FERREIRA '),
 '42485276854', NULL, true); 
 raise notice 'Adicionado o usuario YANDRA OLIVEIRA LIMA FERREIRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31865041807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANE K DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yanesantos.31865041807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANE K DOS SANTOS'),
 '31865041807', NULL, true); 
 raise notice 'Adicionado o usuario YANE K DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7383738  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANE PINHEIRO NOGUEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7383738, 
 3,'yanenogueira.7383738@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANE PINHEIRO NOGUEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YANE PINHEIRO NOGUEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45263668899'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANKA DA SILVA DE PAULA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yankapaula.45263668899@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANKA DA SILVA DE PAULA'),
 '45263668899', NULL, true); 
 raise notice 'Adicionado o usuario YANKA DA SILVA DE PAULA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8206678  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YANNA TAHIS SOUSA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8206678, 
 3,'yannasilva.8206678@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YANNA TAHIS SOUSA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YANNA TAHIS SOUSA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48996398802'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA ALVES AMORIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaraamorim.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA ALVES AMORIM'),
 '48996398802', NULL, true); 
 raise notice 'Adicionado o usuario YARA ALVES AMORIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8482055  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA AMANDA DE JESUS ABREU'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8482055, 
 3,'yaraabreu.8482055@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA AMANDA DE JESUS ABREU'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA AMANDA DE JESUS ABREU'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7970498  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA APARECIDA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7970498, 
 3,'yarasilva.7970498@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA APARECIDA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA APARECIDA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '11644528860'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA BARROS DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaraoliveira.11644528860@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA BARROS DE ARAUJO'),
 '11644528860', NULL, true); 
 raise notice 'Adicionado o usuario YARA BARROS DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8430381  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA BATISTA FREITAS NERYS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8430381, 
 3,'yaranerys.8430381@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA BATISTA FREITAS NERYS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA BATISTA FREITAS NERYS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8278873  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA CABRAL AVELINO MOTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8278873, 
 3,'yaramota.8278873@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA CABRAL AVELINO MOTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA CABRAL AVELINO MOTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45746566896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA CABRAL DA SILVA PASSOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yarapassos.45746566896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA CABRAL DA SILVA PASSOS'),
 '45746566896', NULL, true); 
 raise notice 'Adicionado o usuario YARA CABRAL DA SILVA PASSOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 2724153324  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA CARLA DA SILVA ALBUQUERQUE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 2724153324, 
 3,'yaraalbuquerque.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA CARLA DA SILVA ALBUQUERQUE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA CARLA DA SILVA ALBUQUERQUE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7209673  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA CRISTINA BADOLATO DUARTE HELENO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7209673, 
 3,'yaraheleno.7209673@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA CRISTINA BADOLATO DUARTE HELENO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA CRISTINA BADOLATO DUARTE HELENO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8436207  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DA SILVA FARIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8436207, 
 3,'yarafaria.8436207@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DA SILVA FARIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA DA SILVA FARIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8213828  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DA SILVA SOUSA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8213828, 
 3,'yarapereira.8213828@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DA SILVA SOUSA PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA DA SILVA SOUSA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40281089850'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DAS GRAÇAS LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaralima.40281089850@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DAS GRAÇAS LIMA'),
 '40281089850', NULL, true); 
 raise notice 'Adicionado o usuario YARA DAS GRAÇAS LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32562505808'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DE CAMARGO MARCHI '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaracmarchi.32562505808@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DE CAMARGO MARCHI '),
 '32562505808', NULL, true); 
 raise notice 'Adicionado o usuario YARA DE CAMARGO MARCHI '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7756933  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DE FATIMA GARCIA OLIVEIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7756933, 
 3,'yarasilva.7756933@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DE FATIMA GARCIA OLIVEIRA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA DE FATIMA GARCIA OLIVEIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7756933  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DE FÁTIMA GARCIA OLIVEIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7756933, 
 3,'yarasilva.7756933@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DE FÁTIMA GARCIA OLIVEIRA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA DE FÁTIMA GARCIA OLIVEIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44032012881'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA DIAS DE MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaramoura.e44032012881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA DIAS DE MOURA'),
 '44032012881', NULL, true); 
 raise notice 'Adicionado o usuario YARA DIAS DE MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28368114802'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA EMANOELA DORAZIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaradorazio.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA EMANOELA DORAZIO'),
 '28368114802', NULL, true); 
 raise notice 'Adicionado o usuario YARA EMANOELA DORAZIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33678878890'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA FERREIRA CAMPOS GERALDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yarageraldo.33678878890@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA FERREIRA CAMPOS GERALDO'),
 '33678878890', NULL, true); 
 raise notice 'Adicionado o usuario YARA FERREIRA CAMPOS GERALDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33673970836'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA GOMES RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yararodrigues.33673970836@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA GOMES RODRIGUES'),
 '33673970836', NULL, true); 
 raise notice 'Adicionado o usuario YARA GOMES RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '10189275731'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA GONÇALVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yarasilva.10189275731@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA GONÇALVES DA SILVA'),
 '10189275731', NULL, true); 
 raise notice 'Adicionado o usuario YARA GONÇALVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8483272  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA JOYCE RODRIGUES DE FIGUEIREDO LIGEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8483272, 
 3,'yaraligeiro.8483272@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA JOYCE RODRIGUES DE FIGUEIREDO LIGEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA JOYCE RODRIGUES DE FIGUEIREDO LIGEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8195374  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA KRUGEL DE MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8195374, 
 3,'yaramelo.8195374@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA KRUGEL DE MELO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA KRUGEL DE MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7914601  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA LACERDA DE OLIVEIRA GOEGAN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7914601, 
 3,'yaragoegan.7914601@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA LACERDA DE OLIVEIRA GOEGAN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA LACERDA DE OLIVEIRA GOEGAN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8241155  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA LIMA PEREIRA MAGALHÃES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8241155, 
 3,'yaramagalhaes.8241155@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA LIMA PEREIRA MAGALHÃES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA LIMA PEREIRA MAGALHÃES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '49092136867'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA LUCENA DE MORAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaramoraes.49092136867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA LUCENA DE MORAES'),
 '49092136867', NULL, true); 
 raise notice 'Adicionado o usuario YARA LUCENA DE MORAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '41080107878'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA MARIANO CIRINO LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaralima.41080107878@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA MARIANO CIRINO LIMA'),
 '41080107878', NULL, true); 
 raise notice 'Adicionado o usuario YARA MARIANO CIRINO LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8034079  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA MARQUES SANCHEZ RAMOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8034079, 
 3,'yararamos.8034079@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA MARQUES SANCHEZ RAMOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA MARQUES SANCHEZ RAMOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38204734832'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA MARTINS DE MIRANDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaramiranda.38204734832@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA MARTINS DE MIRANDA'),
 '38204734832', NULL, true); 
 raise notice 'Adicionado o usuario YARA MARTINS DE MIRANDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8269122  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA MIZOKAMI LEAO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8269122, 
 3,'yarasilva.8269122@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA MIZOKAMI LEAO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA MIZOKAMI LEAO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48429853804'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA PEREIRA COSTA SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yarapcsouza.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA PEREIRA COSTA SOUZA'),
 '48429853804', NULL, true); 
 raise notice 'Adicionado o usuario YARA PEREIRA COSTA SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45758878898'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA REGINA DE SOUZA VIRGINIO LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaralima.e45758878898@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA REGINA DE SOUZA VIRGINIO LIMA'),
 '45758878898', NULL, true); 
 raise notice 'Adicionado o usuario YARA REGINA DE SOUZA VIRGINIO LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8131996  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA ROBERTA MOREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8131996, 
 3,'yarasilva.8131996@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA ROBERTA MOREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA ROBERTA MOREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7223501  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YARA RODRIGUES CUNHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7223501, 
 3,'yaracunha.7223501@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YARA RODRIGUES CUNHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YARA RODRIGUES CUNHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31925315843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASKARA REJANE CAMURÇA RICIERI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yaskararicieri.31925315843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASKARA REJANE CAMURÇA RICIERI'),
 '31925315843', NULL, true); 
 raise notice 'Adicionado o usuario YASKARA REJANE CAMURÇA RICIERI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '49955119896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimsilva.49955119896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM FERREIRA DA SILVA'),
 '49955119896', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '24100165889'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM FERREIRA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimpereira.e24100165889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM FERREIRA PEREIRA'),
 '24100165889', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM FERREIRA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47713028803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM FRANCA MONTEZANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimmontezano.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM FRANCA MONTEZANO'),
 '47713028803', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM FRANCA MONTEZANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '46232064836'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM FURTUNATO MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimmoreira.46232064836@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM FURTUNATO MOREIRA'),
 '46232064836', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM FURTUNATO MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '49898343800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM GUIMARÃES DE CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimcastro.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM GUIMARÃES DE CASTRO'),
 '49898343800', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM GUIMARÃES DE CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43319379844'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM LISBOA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimsilva.43319379844@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM LISBOA SILVA'),
 '43319379844', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM LISBOA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32760563804'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM OLTRAMARI NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimnascimento.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM OLTRAMARI NASCIMENTO'),
 '32760563804', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM OLTRAMARI NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '59055779865'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmimsilva.e59055779865@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM PEREIRA DA SILVA'),
 '59055779865', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '49780684876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIM SILVA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsantos.49780684876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIM SILVA DOS SANTOS'),
 '49780684876', NULL, true); 
 raise notice 'Adicionado o usuario YASMIM SILVA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42942145897'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN ARAGÃO SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminaasouza.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN ARAGÃO SOUZA'),
 '42942145897', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN ARAGÃO SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 08102019  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN CARVALHO DE MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 08102019, 
 3,'yasmincmelo.08102019@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN CARVALHO DE MELO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YASMIN CARVALHO DE MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44534098855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN CAVALCANTI DE SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsantana.44534098855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN CAVALCANTI DE SANTANA'),
 '44534098855', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN CAVALCANTI DE SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '23958056881'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN DA SILVA FREITAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminfreitas.e23958056881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN DA SILVA FREITAS'),
 '23958056881', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN DA SILVA FREITAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40185833896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN DA SILVA REIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminreis.e40185833896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN DA SILVA REIS'),
 '40185833896', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN DA SILVA REIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '52007450801'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN DE FRANÇA MORAES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminmoraes.e52007450801@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN DE FRANÇA MORAES '),
 '52007450801', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN DE FRANÇA MORAES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15559083739'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN DE OLIVEIRA TOLEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmintoledo.15559083739@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN DE OLIVEIRA TOLEDO'),
 '15559083739', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN DE OLIVEIRA TOLEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38554303814'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN DISSELLI GOMES RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminrodrigues.38554303814@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN DISSELLI GOMES RODRIGUES'),
 '38554303814', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN DISSELLI GOMES RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8513121  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN ERNANDES ABDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8513121, 
 3,'yasminabdo.8513121@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN ERNANDES ABDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YASMIN ERNANDES ABDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47834442856'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN FELIX BRANCO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminbranco.47834442856@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN FELIX BRANCO'),
 '47834442856', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN FELIX BRANCO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35880728889'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN FRANÇA OLIVEIRA SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsilva.35880728889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN FRANÇA OLIVEIRA SILVA '),
 '35880728889', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN FRANÇA OLIVEIRA SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48073134870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN FRANÇA SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsoares.e48073134870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN FRANÇA SOARES'),
 '48073134870', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN FRANÇA SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48765869850'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN FREIRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminfreire.48765869850@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN FREIRE'),
 '48765869850', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN FREIRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '46232064836'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN FURTUNATO MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminmoreira.46232064836@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN FURTUNATO MOREIRA'),
 '46232064836', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN FURTUNATO MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '52865700895'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN GUEDES ROMA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminroma.e52865700895@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN GUEDES ROMA '),
 '52865700895', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN GUEDES ROMA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '52354749880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN JAMILLY SILVA LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminlopes.e52354749880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN JAMILLY SILVA LOPES'),
 '52354749880', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN JAMILLY SILVA LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 4786255387  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN LIMA ESMERIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 4786255387, 
 3,'yasminesmeria.4786255387@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN LIMA ESMERIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YASMIN LIMA ESMERIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40339812842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN LUCIANO BISPO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminbispo.e40339812842@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN LUCIANO BISPO'),
 '40339812842', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN LUCIANO BISPO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50244529841'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN MARIA AMANCIO LEONDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminleonde.e50244529841@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN MARIA AMANCIO LEONDE'),
 '50244529841', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN MARIA AMANCIO LEONDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22782186892'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN MARIANE DOS SANTOS RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminribeiro.e22782186892@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN MARIANE DOS SANTOS RIBEIRO'),
 '22782186892', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN MARIANE DOS SANTOS RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8387991  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN MATHIAS CANTARINOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8387991, 
 3,'yasmincantarino.8387991@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN MATHIAS CANTARINOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YASMIN MATHIAS CANTARINOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '08135013930'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN MATHIAS MEDEIROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminmathias.08135013930@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN MATHIAS MEDEIROS'),
 '08135013930', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN MATHIAS MEDEIROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38558168830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN MILENA MIRANDA SALAZAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsalazar.e38558168830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN MILENA MIRANDA SALAZAR'),
 '38558168830', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN MILENA MIRANDA SALAZAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '01710081546'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN MONTEIRO DE FREITAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminfreitas.e01710081546@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN MONTEIRO DE FREITAS'),
 '01710081546', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN MONTEIRO DE FREITAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43013524812'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN NASCIMENTO DE SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsousa.43013524812@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN NASCIMENTO DE SOUSA'),
 '43013524812', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN NASCIMENTO DE SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47758690866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN ORTEGA ARRUDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminarruda.47758690866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN ORTEGA ARRUDA'),
 '47758690866', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN ORTEGA ARRUDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51990420842'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN PAIVA GESTEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasmingesteira.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN PAIVA GESTEIRA'),
 '51990420842', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN PAIVA GESTEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48433394827'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN PEREIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsantos.48433394827@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN PEREIRA DOS SANTOS'),
 '48433394827', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN PEREIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51270459821'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN SILVA DE ALMEIDA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminalmeida.51270459821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN SILVA DE ALMEIDA '),
 '51270459821', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN SILVA DE ALMEIDA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '52006858858'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN STEPHANIE RIBEIRO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsilva.52006858858@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN STEPHANIE RIBEIRO DA SILVA'),
 '52006858858', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN STEPHANIE RIBEIRO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43341378812'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN TEIXEIRA CARVALHO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsantos.e43341378812@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN TEIXEIRA CARVALHO SANTOS'),
 '43341378812', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN TEIXEIRA CARVALHO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '41511136812'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN THUANY DA CRUZ IGLESIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminiglesias.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN THUANY DA CRUZ IGLESIAS'),
 '41511136812', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN THUANY DA CRUZ IGLESIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45020891843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN TOMAZ ARSENOVICZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminarsenovicz.45020891843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN TOMAZ ARSENOVICZ'),
 '45020891843', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN TOMAZ ARSENOVICZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40035381884'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN VIEIRA DINIZ LUIZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminluiz.40035381884@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN VIEIRA DINIZ LUIZ'),
 '40035381884', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN VIEIRA DINIZ LUIZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47331268830'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMIN ZAELI SOARES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsilva.e47331268830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMIN ZAELI SOARES DA SILVA'),
 '47331268830', NULL, true); 
 raise notice 'Adicionado o usuario YASMIN ZAELI SOARES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7516061  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMINNE ALVES LESSA MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7516061, 
 3,'yasminnematos.7516061@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMINNE ALVES LESSA MATOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YASMINNE ALVES LESSA MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8461724  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMINNI PARRA TOMAZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8461724, 
 3,'yasminnitomaz.8461724@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMINNI PARRA TOMAZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YASMINNI PARRA TOMAZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44861340870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASMINS MIRANDA SAMPAIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasminsmiranda.44861340870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASMINS MIRANDA SAMPAIO'),
 '44861340870', NULL, true); 
 raise notice 'Adicionado o usuario YASMINS MIRANDA SAMPAIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '45147226850'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YASNARA VANESSA DA PAZ VELOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yasnaraveloso.45147226850@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YASNARA VANESSA DA PAZ VELOSO'),
 '45147226850', NULL, true); 
 raise notice 'Adicionado o usuario YASNARA VANESSA DA PAZ VELOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8917001  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEDA GUIMARÃES DE AQUINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8917001, 
 3,'yedaaquino.8917001@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEDA GUIMARÃES DE AQUINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YEDA GUIMARÃES DE AQUINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '07799754800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEDA MARIA SILVA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yedasantos.07799754800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEDA MARIA SILVA SANTOS'),
 '07799754800', NULL, true); 
 raise notice 'Adicionado o usuario YEDA MARIA SILVA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44052565860'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEDA NUNES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yedasantos.e44052565860@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEDA NUNES DOS SANTOS'),
 '44052565860', NULL, true); 
 raise notice 'Adicionado o usuario YEDA NUNES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38913401843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEDA PEREIRA DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yedacruz.38913401843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEDA PEREIRA DA CRUZ'),
 '38913401843', NULL, true); 
 raise notice 'Adicionado o usuario YEDA PEREIRA DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7954743  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEDDA KLIPPEL AMADORI LOLLOBRIGIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7954743, 
 3,'yeddalollobrigida.7954743@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEDDA KLIPPEL AMADORI LOLLOBRIGIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YEDDA KLIPPEL AMADORI LOLLOBRIGIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '50700003819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEJIDE DANDARA BERNARDES PERES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yejideperes.50700003819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEJIDE DANDARA BERNARDES PERES '),
 '50700003819', NULL, true); 
 raise notice 'Adicionado o usuario YEJIDE DANDARA BERNARDES PERES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '53257403852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YGOR AUGUSTO ARAUJO MEDEIROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ygormedeiros.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YGOR AUGUSTO ARAUJO MEDEIROS'),
 '53257403852', NULL, true); 
 raise notice 'Adicionado o usuario YGOR AUGUSTO ARAUJO MEDEIROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6107966  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YLRAM BATISTA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6107966, 
 3,'ylrambsouza.6107966@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YLRAM BATISTA DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YLRAM BATISTA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8028141  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YNAE ROQUE ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8028141, 
 3,'ynaerocha.8028141@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YNAE ROQUE ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YNAE ROQUE ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47956522870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YNGRID APARECIDA DOS SANTOS SERAFIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yngridserafim.47956522870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YNGRID APARECIDA DOS SANTOS SERAFIM'),
 '47956522870', NULL, true); 
 raise notice 'Adicionado o usuario YNGRID APARECIDA DOS SANTOS SERAFIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44543452879'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YNGRID LAURENTINA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yngridsilva.44543452879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YNGRID LAURENTINA DA SILVA'),
 '44543452879', NULL, true); 
 raise notice 'Adicionado o usuario YNGRID LAURENTINA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44522329814'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YNGRID LIMA MOREIRA ROCHA VITAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yngridvital.44522329814@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YNGRID LIMA MOREIRA ROCHA VITAL'),
 '44522329814', NULL, true); 
 raise notice 'Adicionado o usuario YNGRID LIMA MOREIRA ROCHA VITAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48466075852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YNGRID PEREIRA MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yngridmoreira.48466075852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YNGRID PEREIRA MOREIRA'),
 '48466075852', NULL, true); 
 raise notice 'Adicionado o usuario YNGRID PEREIRA MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8483124  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YOHAN ISE LEON'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8483124, 
 3,'yohanleon.8483124@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YOHAN ISE LEON'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YOHAN ISE LEON'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8172633  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YOLANDA DE LIMA ESPERANÇA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8172633, 
 3,'yolandaesperanca.8172633@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YOLANDA DE LIMA ESPERANÇA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YOLANDA DE LIMA ESPERANÇA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27619013806'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YOLANDA OLIVEIRA MARINHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yolandamarinho.27619013806@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YOLANDA OLIVEIRA MARINHO'),
 '27619013806', NULL, true); 
 raise notice 'Adicionado o usuario YOLANDA OLIVEIRA MARINHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8964840  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YOLANDA PEREIRA DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8964840, 
 3,'yolandadias.8964840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YOLANDA PEREIRA DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YOLANDA PEREIRA DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7958731  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YOLANDA XAVIER DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7958731, 
 3,'yolandasilva.7958731@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YOLANDA XAVIER DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YOLANDA XAVIER DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8382522  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YONARA DE MELO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8382522, 
 3,'yonarasilva.8382522@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YONARA DE MELO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YONARA DE MELO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8198802  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YONE DINIZ FRAZAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8198802, 
 3,'yonefrazao.8198802@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YONE DINIZ FRAZAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YONE DINIZ FRAZAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44603942869'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YONE TAVARES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yonesilva.e44603942869@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YONE TAVARES DA SILVA'),
 '44603942869', NULL, true); 
 raise notice 'Adicionado o usuario YONE TAVARES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8183121  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YONÁ REJANE OLIVEIRA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8183121, 
 3,'yonarocosta.8183121@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YONÁ REJANE OLIVEIRA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YONÁ REJANE OLIVEIRA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51308761805'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YSABELA SILVA DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ysabelaandrade.51308761805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YSABELA SILVA DE ANDRADE'),
 '51308761805', NULL, true); 
 raise notice 'Adicionado o usuario YSABELA SILVA DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36223623836'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YSLA MANZANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yslamanzano.e36223623836@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YSLA MANZANO'),
 '36223623836', NULL, true); 
 raise notice 'Adicionado o usuario YSLA MANZANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44617724893'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YTAMARA LIMA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ytamarasouza.44617724893@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YTAMARA LIMA DE SOUZA'),
 '44617724893', NULL, true); 
 raise notice 'Adicionado o usuario YTAMARA LIMA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8393991  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YUMI FERREIRA GALINDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8393991, 
 3,'yumigalindo.8393991@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YUMI FERREIRA GALINDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YUMI FERREIRA GALINDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7960212  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YUNA DE LURDES DA ROCHA FONSECA ALENCAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7960212, 
 3,'yunaalencar.7960212@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YUNA DE LURDES DA ROCHA FONSECA ALENCAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YUNA DE LURDES DA ROCHA FONSECA ALENCAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '48169125847'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI ANTONIO PESSOA CALADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yuricalado.e48169125847@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI ANTONIO PESSOA CALADO'),
 '48169125847', NULL, true); 
 raise notice 'Adicionado o usuario YURI ANTONIO PESSOA CALADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8432279  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI GUEDES LUESKA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8432279, 
 3,'yurilueska.8432279@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI GUEDES LUESKA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YURI GUEDES LUESKA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '46223369875'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI HENRIQUE DA CRUZ SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yurisilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI HENRIQUE DA CRUZ SILVA'),
 '46223369875', NULL, true); 
 raise notice 'Adicionado o usuario YURI HENRIQUE DA CRUZ SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8592161  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI MARTENAUER SAWELJEW'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8592161, 
 3,'yurisaweljew.8592161@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI MARTENAUER SAWELJEW'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YURI MARTENAUER SAWELJEW'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8022453  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI SCARDINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8022453, 
 3,'yuriscardino.8022453@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI SCARDINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YURI SCARDINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7233906  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI SOUZA SODRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7233906, 
 3,'yurisodre.7233906@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI SOUZA SODRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YURI SOUZA SODRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '49313654857'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YURI VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'yurivieira.e49313654857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YURI VIEIRA'),
 '49313654857', NULL, true); 
 raise notice 'Adicionado o usuario YURI VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27589306843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZADIENE RAMOS GIGANTE SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zadienesousa.27589306843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZADIENE RAMOS GIGANTE SOUSA'),
 '27589306843', NULL, true); 
 raise notice 'Adicionado o usuario ZADIENE RAMOS GIGANTE SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36809201807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIARA GALLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zaiaragallo.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIARA GALLO'),
 '36809201807', NULL, true); 
 raise notice 'Adicionado o usuario ZAIARA GALLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7560338  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIDA MARIA MASCELLANI AZEVEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7560338, 
 3,'zaidaazevedo.7560338@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIDA MARIA MASCELLANI AZEVEDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZAIDA MARIA MASCELLANI AZEVEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8212902  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAINE ETIENE XAVIER LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8212902, 
 3,'zainelopes.8212902@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAINE ETIENE XAVIER LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZAINE ETIENE XAVIER LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '21607617889'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAINE LINDSEI DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zaineloliveira.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAINE LINDSEI DE OLIVEIRA'),
 '21607617889', NULL, true); 
 raise notice 'Adicionado o usuario ZAINE LINDSEI DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8416346  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAINE ROCHA DE SOUZA MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8416346, 
 3,'zainemartins.8416346@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAINE ROCHA DE SOUZA MARTINS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZAINE ROCHA DE SOUZA MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38518048800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAINI DE JESUS FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zainiferreira.e38518048800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAINI DE JESUS FERREIRA'),
 '38518048800', NULL, true); 
 raise notice 'Adicionado o usuario ZAINI DE JESUS FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35682560884'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIRA APARECIDA DE LIRA MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zairamelo.e35682560884@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIRA APARECIDA DE LIRA MELO'),
 '35682560884', NULL, true); 
 raise notice 'Adicionado o usuario ZAIRA APARECIDA DE LIRA MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6238688  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIRA KURY FABRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6238688, 
 3,'zairafabre.6238688@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIRA KURY FABRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZAIRA KURY FABRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7119461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIRA OLIVEIRA CRUZ MACEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7119461, 
 3,'zairamacedo.7119461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIRA OLIVEIRA CRUZ MACEDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZAIRA OLIVEIRA CRUZ MACEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43336692865'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIRA ROCHA CRUDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zairacrude.43336692865@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIRA ROCHA CRUDE'),
 '43336692865', NULL, true); 
 raise notice 'Adicionado o usuario ZAIRA ROCHA CRUDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31609084888'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAIRA VIANA DO ESPIRITO SANTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zairasanto.31609084888@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAIRA VIANA DO ESPIRITO SANTO'),
 '31609084888', NULL, true); 
 raise notice 'Adicionado o usuario ZAIRA VIANA DO ESPIRITO SANTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8201722  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZARA VALERIA BAPTISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8201722, 
 3,'zarabaptista.8201722@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZARA VALERIA BAPTISTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZARA VALERIA BAPTISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9001428479  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZAYRA SOARES DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9001428479, 
 3,'zayraalmeida.9001428479@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZAYRA SOARES DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZAYRA SOARES DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6816401  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZEAZELITA MARIA DA SILVA SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6816401, 
 3,'zeazelitasouza6816401@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZEAZELITA MARIA DA SILVA SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZEAZELITA MARIA DA SILVA SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34338633859'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZEFERINA ALVES DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeferinadias.34338633859@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZEFERINA ALVES DIAS'),
 '34338633859', NULL, true); 
 raise notice 'Adicionado o usuario ZEFERINA ALVES DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35133274807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZEILANDRE CLEIDE GOMES MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeilandremartins.35133274807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZEILANDRE CLEIDE GOMES MARTINS'),
 '35133274807', NULL, true); 
 raise notice 'Adicionado o usuario ZEILANDRE CLEIDE GOMES MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8041661  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELAIDE LIMA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8041661, 
 3,'zelaideoliveira.8041661@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELAIDE LIMA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELAIDE LIMA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '12514178843'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELI MARIA DUARTE DE BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zelibrito.12514178843@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELI MARIA DUARTE DE BRITO'),
 '12514178843', NULL, true); 
 raise notice 'Adicionado o usuario ZELI MARIA DUARTE DE BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8393729  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELI ROCHA BATISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8393729, 
 3,'zelibatista.8393729@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELI ROCHA BATISTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELI ROCHA BATISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15122672873'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA CRISTINA DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeliaalmeida.15122672873@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA CRISTINA DE ALMEIDA'),
 '15122672873', NULL, true); 
 raise notice 'Adicionado o usuario ZELIA CRISTINA DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7386346  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA DE MIRANDA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7386346, 
 3,'zeliacosta.7386346@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA DE MIRANDA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA DE MIRANDA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8036314  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA DIAS BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8036314, 
 3,'zeliabarbosa.8036314@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA DIAS BARBOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA DIAS BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25262773885'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA ETELVINA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeliasilva.25262773885@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA ETELVINA DA SILVA'),
 '25262773885', NULL, true); 
 raise notice 'Adicionado o usuario ZELIA ETELVINA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7331822594  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7331822594, 
 3,'zeliaferrera.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA FERREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7927789  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA HELENO TRINDADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7927789, 
 3,'zeliatrindade.7927789@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA HELENO TRINDADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA HELENO TRINDADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6254705  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA IMACULADA DE OLIVEIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6254705, 
 3,'zeliasilva.6254705@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA IMACULADA DE OLIVEIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA IMACULADA DE OLIVEIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6780644  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA MALUF'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6780644, 
 3,'zeliamaluf.6780644@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA MALUF'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA MALUF'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '16424978860'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA NOEMIA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeliajesus.16424978860@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA NOEMIA DE JESUS'),
 '16424978860', NULL, true); 
 raise notice 'Adicionado o usuario ZELIA NOEMIA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26666968808'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELITA PEREIRA GALVÃO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zelitafaustino.26666968808@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELITA PEREIRA GALVÃO'),
 '26666968808', NULL, true); 
 raise notice 'Adicionado o usuario ZELITA PEREIRA GALVÃO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '18586879851'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELITA SAMPAIO DE PAULA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zelitapaula.18586879851@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELITA SAMPAIO DE PAULA'),
 '18586879851', NULL, true); 
 raise notice 'Adicionado o usuario ZELITA SAMPAIO DE PAULA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36360568837'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELMA BELARMINO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zelmasilva.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELMA BELARMINO DA SILVA'),
 '36360568837', NULL, true); 
 raise notice 'Adicionado o usuario ZELMA BELARMINO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7819706  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELY FERREIRA DA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7819706, 
 3,'zelyrocha.7819706@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELY FERREIRA DA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELY FERREIRA DA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9188631  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE  SILVA DA PAIXÃO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9188631, 
 3,'zenaidespaixao.9188631@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE  SILVA DA PAIXÃO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE  SILVA DA PAIXÃO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7529287  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE ALVES PINTO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7529287, 
 3,'zenaidepinto.7529287@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE ALVES PINTO '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE ALVES PINTO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02716449589'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE BARROS GOMES FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidefernandes.02716449589@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE BARROS GOMES FERNANDES'),
 '02716449589', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE BARROS GOMES FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7286767  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7286767, 
 3,'zenaidecarvalho.7286767@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE DE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '24932166877'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE DE SANTANA CAVA MAZUCHINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidemazuchini.24932166877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE DE SANTANA CAVA MAZUCHINI'),
 '24932166877', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE DE SANTANA CAVA MAZUCHINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '03771719569'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE FREITAS COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidecosta.03771719569@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE FREITAS COSTA'),
 '03771719569', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE FREITAS COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6972276  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE GUEDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6972276, 
 3,'zenaideguedes.6972276@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE GUEDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE GUEDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7386893  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE LIMA CLARO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7386893, 
 3,'zenaideclaro.7386893@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE LIMA CLARO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE LIMA CLARO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '29270431835'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE LIMA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidesouza.29270431835@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE LIMA DE SOUZA'),
 '29270431835', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE LIMA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8451605  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE MARIA DO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8451605, 
 3,'zenaidesantos.8451605@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE MARIA DO SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE MARIA DO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8797854  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE MESSIAS DA SILVA ESEQUIEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8797854, 
 3,'zenaideesequiel.8797854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE MESSIAS DA SILVA ESEQUIEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE MESSIAS DA SILVA ESEQUIEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '01415633894'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE RIBEIRO MARINHO GENERATI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidegenerati.01415633894@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE RIBEIRO MARINHO GENERATI'),
 '01415633894', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE RIBEIRO MARINHO GENERATI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34023561800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE SANTOS DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidejesus.34023561800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE SANTOS DE JESUS'),
 '34023561800', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE SANTOS DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '05451490880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENAIDE SOUZA MIRANDA DE MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenaidemelo.05451490880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENAIDE SOUZA MIRANDA DE MELO'),
 '05451490880', NULL, true); 
 raise notice 'Adicionado o usuario ZENAIDE SOUZA MIRANDA DE MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '12546963856'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENEIDE BATISTA SILVA GUEDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeneideguedes.12546963856@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENEIDE BATISTA SILVA GUEDES'),
 '12546963856', NULL, true); 
 raise notice 'Adicionado o usuario ZENEIDE BATISTA SILVA GUEDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7997701  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENEIDE DA CONCEIÇÃO QUEIROZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7997701, 
 3,'zeneidequeiroz.7997701@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENEIDE DA CONCEIÇÃO QUEIROZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENEIDE DA CONCEIÇÃO QUEIROZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '69402701591'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENEIDE DA SILVA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeneidecosta.69402701591@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENEIDE DA SILVA COSTA'),
 '69402701591', NULL, true); 
 raise notice 'Adicionado o usuario ZENEIDE DA SILVA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8449414  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENEIDE NUNES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8449414, 
 3,'zeneidesilva.8449414@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENEIDE NUNES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENEIDE NUNES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8852596  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENEIDE SATURNINO DOS SANTOS BATISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8852596, 
 3,'zeneidebatista.8852596@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENEIDE SATURNINO DOS SANTOS BATISTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENEIDE SATURNINO DOS SANTOS BATISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '23757426304'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENEIDE SOUSA NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeneidenascimento.23757426304@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENEIDE SOUSA NASCIMENTO'),
 '23757426304', NULL, true); 
 raise notice 'Adicionado o usuario ZENEIDE SOUSA NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35989331851'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENIA GRACIELA DOS SANTOS SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeniasousa.35989331851@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENIA GRACIELA DOS SANTOS SOUSA'),
 '35989331851', NULL, true); 
 raise notice 'Adicionado o usuario ZENIA GRACIELA DOS SANTOS SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7762330  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENIDA LOPES GONCALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7762330, 
 3,'zenidagoncalves.7762330@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENIDA LOPES GONCALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENIDA LOPES GONCALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02376020590'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA FERREIRA DE SENA MARQUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildamarques.02376020590@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA FERREIRA DE SENA MARQUES'),
 '02376020590', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA FERREIRA DE SENA MARQUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '13429660823'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA NEVES TEIXEIRA MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildamelo.13429660823@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA NEVES TEIXEIRA MELO'),
 '13429660823', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA NEVES TEIXEIRA MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8013055  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA RODRIGUES COELHO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8013055, 
 3,'zenildasantos.8013055@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA RODRIGUES COELHO SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA RODRIGUES COELHO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '63264609649'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA RODRIGUES MORAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildamorais.63264609649@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA RODRIGUES MORAIS'),
 '63264609649', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA RODRIGUES MORAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44145614852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA SILVA ABRANTES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildaoliveira.44145614852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA SILVA ABRANTES DE OLIVEIRA'),
 '44145614852', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA SILVA ABRANTES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28232786809'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA SILVA DE MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildamatos.28232786809@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA SILVA DE MATOS'),
 '28232786809', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA SILVA DE MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6787983  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDA VILELA JACOIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6787983, 
 3,'zenildajacoia.6787983@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDA VILELA JACOIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENILDA VILELA JACOIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25547502898'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDE DE SOUSA MEDINA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildemedina.25547502898@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDE DE SOUSA MEDINA'),
 '25547502898', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDE DE SOUSA MEDINA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02317861311'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDE GOMES VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildevieira.02317861311@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDE GOMES VIEIRA'),
 '02317861311', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDE GOMES VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '91798604515'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDE MARQUES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenildesantos.91798604515@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDE MARQUES DOS SANTOS'),
 '91798604515', NULL, true); 
 raise notice 'Adicionado o usuario ZENILDE MARQUES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8093768  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILDO LEAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8093768, 
 3,'zenildoleal.8093768@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILDO LEAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENILDO LEAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27150557813'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENITA AMORIM DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenitasilva.27150557813@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENITA AMORIM DA SILVA'),
 '27150557813', NULL, true); 
 raise notice 'Adicionado o usuario ZENITA AMORIM DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8877653  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENITH FRANCISCA DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8877653, 
 3,'zenithandrade.8877653@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENITH FRANCISCA DE ANDRADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENITH FRANCISCA DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32897888814'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENIVALDA PEREIRA SILVA BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenivaldabarbosa.32897888814@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENIVALDA PEREIRA SILVA BARBOSA'),
 '32897888814', NULL, true); 
 raise notice 'Adicionado o usuario ZENIVALDA PEREIRA SILVA BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '11114655848'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENÓLIA MARIA DE SOUZA NOVAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zenolianovais.11114655848@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENÓLIA MARIA DE SOUZA NOVAIS'),
 '11114655848', NULL, true); 
 raise notice 'Adicionado o usuario ZENÓLIA MARIA DE SOUZA NOVAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '88342573400'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZEODÉLIA MOREIRA DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeodeliadias.88342573400@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZEODÉLIA MOREIRA DIAS'),
 '88342573400', NULL, true); 
 raise notice 'Adicionado o usuario ZEODÉLIA MOREIRA DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32053747897'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZERIFE ZEIDAN DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zerifesantos.32053747897@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZERIFE ZEIDAN DOS SANTOS'),
 '32053747897', NULL, true); 
 raise notice 'Adicionado o usuario ZERIFE ZEIDAN DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34451804825'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZERLENE MOURA SHIMAMURA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zerleneshimamura.34451804825@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZERLENE MOURA SHIMAMURA '),
 '34451804825', NULL, true); 
 raise notice 'Adicionado o usuario ZERLENE MOURA SHIMAMURA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8258406  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZEROIDE PEREIRA DE AQUINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8258406, 
 3,'zeroideaquino.8258406@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZEROIDE PEREIRA DE AQUINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZEROIDE PEREIRA DE AQUINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25493970880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZIBIA DE SANTANA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zibiapereira.25493970880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZIBIA DE SANTANA PEREIRA'),
 '25493970880', NULL, true); 
 raise notice 'Adicionado o usuario ZIBIA DE SANTANA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8849587  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILA CORDEIRO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8849587, 
 3,'zilasilva.8849587@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILA CORDEIRO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILA CORDEIRO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '21572225882'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILAINE DE PAULA CORDEIRO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilainesantos.e21572225882@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILAINE DE PAULA CORDEIRO DOS SANTOS'),
 '21572225882', NULL, true); 
 raise notice 'Adicionado o usuario ZILAINE DE PAULA CORDEIRO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30957454864'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILAY SANTOS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilaysilva.30957454864@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILAY SANTOS DA SILVA'),
 '30957454864', NULL, true); 
 raise notice 'Adicionado o usuario ZILAY SANTOS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '23204845826'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILCA BRUNA DE FRANÇA FERREIRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilcaferreira.23204845826@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILCA BRUNA DE FRANÇA FERREIRA '),
 '23204845826', NULL, true); 
 raise notice 'Adicionado o usuario ZILCA BRUNA DE FRANÇA FERREIRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '11245137875'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA APARECIDA FIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildafior.11245137875@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA APARECIDA FIOR'),
 '11245137875', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA APARECIDA FIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6920616  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA APARECIDA VALDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6920616, 
 3,'zildavaldes.6920616@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA APARECIDA VALDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA APARECIDA VALDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8271101  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA ARAÚJO DA SILVA DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8271101, 
 3,'zildadias.8271101@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA ARAÚJO DA SILVA DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA ARAÚJO DA SILVA DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7906374  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7906374, 
 3,'zildasilva.7906374@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '29417372866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA DE BORBA HEMMEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildahemmel.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA DE BORBA HEMMEL'),
 '29417372866', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA DE BORBA HEMMEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8283389  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA DE JESUS LOPES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8283389, 
 3,'zildasantos.8283389@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA DE JESUS LOPES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA DE JESUS LOPES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '22360863851'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA DOS REIS SANTOS '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildareis.22360863851@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA DOS REIS SANTOS '),
 '22360863851', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA DOS REIS SANTOS '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '06941662867'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA GENEROSO BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildabarbosa.06941662867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA GENEROSO BARBOSA'),
 '06941662867', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA GENEROSO BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8125031  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA LIMA BARBOSA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8125031, 
 3,'zildasilva.8125031@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA LIMA BARBOSA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA LIMA BARBOSA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '13838316614'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA LOPES VIEIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildasantos.e13838316614@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA LOPES VIEIRA DOS SANTOS'),
 '13838316614', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA LOPES VIEIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7569173  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA MARIA CHAVES DO NASCIMENTO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7569173, 
 3,'Zildapereira7569173@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA MARIA CHAVES DO NASCIMENTO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA MARIA CHAVES DO NASCIMENTO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '86553577404'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA MARIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildasantos.86553577404@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA MARIA DOS SANTOS'),
 '86553577404', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA MARIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6762751  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA MASCARENHAS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6762751, 
 3,'zildasilva.6762751@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA MASCARENHAS DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA MASCARENHAS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25445488861'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA MIRANDA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildarodrigues.25445488861@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA MIRANDA RODRIGUES'),
 '25445488861', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA MIRANDA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6685765  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA PRUDENCIO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6685765, 
 3,'zildasilva.6685765@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA PRUDENCIO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA PRUDENCIO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7874171  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA SANTOS NASCIMENTO DE ALMEIDA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7874171, 
 3,'zildaalmeida.7874171@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA SANTOS NASCIMENTO DE ALMEIDA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA SANTOS NASCIMENTO DE ALMEIDA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '98225413504'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA SOUSA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildasantos.98225413504@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA SOUSA SANTOS'),
 '98225413504', NULL, true); 
 raise notice 'Adicionado o usuario ZILDA SOUSA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6949789  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDA VIANA VIEIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6949789, 
 3,'zildasantos.6949789@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDA VIANA VIEIRA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDA VIANA VIEIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35260196813'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDENE DA SILVA SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildenesoares.35260196813@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDENE DA SILVA SOARES'),
 '35260196813', NULL, true); 
 raise notice 'Adicionado o usuario ZILDENE DA SILVA SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '03306699403'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDENE LIMA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildenevieira.03306699403@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDENE LIMA VIEIRA'),
 '03306699403', NULL, true); 
 raise notice 'Adicionado o usuario ZILDENE LIMA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8180482  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDENE MEGDA DE SOUSA	'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8180482, 
 3,'zildenesousa.8180482@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDENE MEGDA DE SOUSA	'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDENE MEGDA DE SOUSA	'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31013912888'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDIANA VITOR NOGUEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zildiananogueira.31013912888@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDIANA VITOR NOGUEIRA'),
 '31013912888', NULL, true); 
 raise notice 'Adicionado o usuario ZILDIANA VITOR NOGUEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6915230  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDINETE DE SOUZA DANTAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6915230, 
 3,'zildinetedantas.6915230@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDINETE DE SOUZA DANTAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDINETE DE SOUZA DANTAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6911081  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDIVANIA DE SOUZA DANTAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6911081, 
 3,'zildivaniadantas.6911081@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDIVANIA DE SOUZA DANTAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDIVANIA DE SOUZA DANTAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6736840  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILDONETE RIBEIRO DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6736840, 
 3,'zildonetealmeida.6736840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILDONETE RIBEIRO DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILDONETE RIBEIRO DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7742215  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILE CAVALCANTE DE SOUZA ABENANTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7742215, 
 3,'zileabenante.7742215@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILE CAVALCANTE DE SOUZA ABENANTE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILE CAVALCANTE DE SOUZA ABENANTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7228155  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILJANE DIAS RABELLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7228155, 
 3,'ziljanerabello.7228155@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILJANE DIAS RABELLO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILJANE DIAS RABELLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35358811515'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilmaalmeida.35358811515@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA ALMEIDA'),
 '35358811515', NULL, true); 
 raise notice 'Adicionado o usuario ZILMA ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8225630  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA ALVES VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8225630, 
 3,'zilmavieira.8225630@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA ALVES VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA ALVES VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7793197  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA DA SILVA DE BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7793197, 
 3,'zilmabrito.7793197@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA DA SILVA DE BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA DA SILVA DE BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33973438870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA FERREIRA BARBOSA TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilmateixeira.33973438870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA FERREIRA BARBOSA TEIXEIRA'),
 '33973438870', NULL, true); 
 raise notice 'Adicionado o usuario ZILMA FERREIRA BARBOSA TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6187048  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA JORGE PESSOA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6187048, 
 3,'zilmapessoa.6187048@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA JORGE PESSOA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA JORGE PESSOA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '10333698886'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA MARIA LIMA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilmasantos.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA MARIA LIMA DOS SANTOS'),
 '10333698886', NULL, true); 
 raise notice 'Adicionado o usuario ZILMA MARIA LIMA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25937998898'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA MARIA RAMOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilmaramos.25937998898@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA MARIA RAMOS'),
 '25937998898', NULL, true); 
 raise notice 'Adicionado o usuario ZILMA MARIA RAMOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7708432  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA MARINHO MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7708432, 
 3,'zilmamendes.7708432@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA MARINHO MENDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA MARINHO MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7812990  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA MOURA LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7812990, 
 3,'zilmalopes.7812990@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA MOURA LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA MOURA LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8249962  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA ROCHA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8249962, 
 3,'zilmasilva.8249962@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA ROCHA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA ROCHA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6800343  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA VIANA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6800343, 
 3,'zilmasantos.6800343@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA VIANA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA VIANA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7124384  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMA VIEIRA SANTOS BARRETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7124384, 
 3,'zilmabarreto.7124384@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMA VIEIRA SANTOS BARRETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILMA VIEIRA SANTOS BARRETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '27511963811'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMARA FERREIRA NOVAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilmaranovaes.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMARA FERREIRA NOVAES'),
 '27511963811', NULL, true); 
 raise notice 'Adicionado o usuario ZILMARA FERREIRA NOVAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '10590065459'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILMARA VIEIRA DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilmaraandrade.e10590065459@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILMARA VIEIRA DE ANDRADE'),
 '10590065459', NULL, true); 
 raise notice 'Adicionado o usuario ZILMARA VIEIRA DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8409536  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILNAY MARTINS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8409536, 
 3,'zilnaysantos.8409536@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILNAY MARTINS DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILNAY MARTINS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38752787800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILNEIDE ALVES VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilneidevieira.38752787800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILNEIDE ALVES VIEIRA'),
 '38752787800', NULL, true); 
 raise notice 'Adicionado o usuario ZILNEIDE ALVES VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6684572  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILNETE LEITE VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6684572, 
 3,'zilnetevieira.6684572@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILNETE LEITE VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILNETE LEITE VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6754287  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILNETE LENIRA MARQUES CABRAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6754287, 
 3,'zilnetecabral.6754287@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILNETE LENIRA MARQUES CABRAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILNETE LENIRA MARQUES CABRAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7487584  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILRENE ALCANTARA MIGUEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7487584, 
 3,'zilrenemiguel.7487584@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILRENE ALCANTARA MIGUEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILRENE ALCANTARA MIGUEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '21881649890'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILVANETE ELIZEU NUNES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilvanetenunes.21881649890@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILVANETE ELIZEU NUNES'),
 '21881649890', NULL, true); 
 raise notice 'Adicionado o usuario ZILVANETE ELIZEU NUNES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '05140739429'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILVIA SOARES CAVALCANTE '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zilviacavalcante.05140739429@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILVIA SOARES CAVALCANTE '),
 '05140739429', NULL, true); 
 raise notice 'Adicionado o usuario ZILVIA SOARES CAVALCANTE '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5232511  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZILVONETE CORDEIRO VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5232511, 
 3,'zilvonetevieira.5232511@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZILVONETE CORDEIRO VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZILVONETE CORDEIRO VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31851900845'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZINAIDE ALVES MATEUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zinaidemateus.e31851900845@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZINAIDE ALVES MATEUS'),
 '31851900845', NULL, true); 
 raise notice 'Adicionado o usuario ZINAIDE ALVES MATEUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '13918736881'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZINEIDE BARBOSA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zineidebsilva.13918736881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZINEIDE BARBOSA DA SILVA'),
 '13918736881', NULL, true); 
 raise notice 'Adicionado o usuario ZINEIDE BARBOSA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6739288  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZIOMAR SOUSA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6739288, 
 3,'ziomarjesus.6739288@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZIOMAR SOUSA DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZIOMAR SOUSA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39692476839'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZIRLEIDE DA SILVA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zirleideferreira@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZIRLEIDE DA SILVA FERREIRA'),
 '39692476839', NULL, true); 
 raise notice 'Adicionado o usuario ZIRLEIDE DA SILVA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7139543  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZIRLEINE MARIA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7139543, 
 3,'zirleineferreira.7139543@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZIRLEINE MARIA FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZIRLEINE MARIA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7815298  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZITA MARIA DE FREITAS VIEIRA DE ABREU'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7815298, 
 3,'zitaabreu.7815298@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZITA MARIA DE FREITAS VIEIRA DE ABREU'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZITA MARIA DE FREITAS VIEIRA DE ABREU'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8797072  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZIULENE ANDRADE SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8797072, 
 3,'ziulenesilva.8797072@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZIULENE ANDRADE SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZIULENE ANDRADE SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7999470  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZODJA FERNANDA GERMANO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7999470, 
 3,'zodjasilva.7999470@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZODJA FERNANDA GERMANO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZODJA FERNANDA GERMANO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9128468  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORA IONARA CONCEIÇÃO SAMPAIO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9128468, 
 3,'zorasampaio.9128468@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORA IONARA CONCEIÇÃO SAMPAIO '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORA IONARA CONCEIÇÃO SAMPAIO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6116337  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE DE ALMEIDA PORTERO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6116337, 
 3,'zoraideportero.6116337@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE DE ALMEIDA PORTERO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE DE ALMEIDA PORTERO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8257256  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE DIAS MIDEGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8257256, 
 3,'zoraidemidega.8257256@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE DIAS MIDEGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE DIAS MIDEGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7214693  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE GONÇALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7214693, 
 3,'zoraidegoncalves.7214693@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE GONÇALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE GONÇALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8055602  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE JONES ARRUDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8055602, 
 3,'zoraidearruda.8055602@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE JONES ARRUDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE JONES ARRUDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8215375  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE MARIA CARDOSO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8215375, 
 3,'zoraidesantos.8215375@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE MARIA CARDOSO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE MARIA CARDOSO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28454474854'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE MARIA DA SILVA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zoraidepereira.28454474854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE MARIA DA SILVA PEREIRA'),
 '28454474854', NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE MARIA DA SILVA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7726180  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE PEREIRA DA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7726180, 
 3,'zoraiderocha.7726180@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE PEREIRA DA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE PEREIRA DA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '13154018867'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE PEREIRA FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zoraidefernandes.13154018867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE PEREIRA FERNANDES'),
 '13154018867', NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE PEREIRA FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '06199159519'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE SILVA FIGUEIREDO DE OLIVEIRA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zoraideoliveira.06199159519@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE SILVA FIGUEIREDO DE OLIVEIRA '),
 '06199159519', NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE SILVA FIGUEIREDO DE OLIVEIRA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8138834  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZORAIDE VIEIRA DA SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8138834, 
 3,'zoraidesilva.8138834@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZORAIDE VIEIRA DA SILVA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZORAIDE VIEIRA DA SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '10127375864'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZUILA DULCIA DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zuilanascimento.10127375864@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZUILA DULCIA DO NASCIMENTO'),
 '10127375864', NULL, true); 
 raise notice 'Adicionado o usuario ZUILA DULCIA DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5672295  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULECA DE ASSIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5672295, 
 3,'zulecaassis.5672295@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULECA DE ASSIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULECA DE ASSIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7005369  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEICA FAVERO LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7005369, 
 3,'zuleicalopes.7005369@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEICA FAVERO LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEICA FAVERO LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '12496963807'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEICA GARCIA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zuleicaoliveira.12496963807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEICA GARCIA DE OLIVEIRA'),
 '12496963807', NULL, true); 
 raise notice 'Adicionado o usuario ZULEICA GARCIA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7805551  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEICA MARIA DE FREITAS NICOMEDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7805551, 
 3,'zuleicanicomedes.7805551@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEICA MARIA DE FREITAS NICOMEDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEICA MARIA DE FREITAS NICOMEDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30820040835'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEICA NEVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zuleicasilva.e30820040835@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEICA NEVES DA SILVA'),
 '30820040835', NULL, true); 
 raise notice 'Adicionado o usuario ZULEICA NEVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6922228  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE ALVES DE MENESES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6922228, 
 3,'zuleidemeneses.6922228@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE ALVES DE MENESES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE ALVES DE MENESES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '05382350809'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE APARECIDA DA SILVA BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zuleidebrito.05382350809@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE APARECIDA DA SILVA BRITO'),
 '05382350809', NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE APARECIDA DA SILVA BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8361819  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE ARAUJO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8361819, 
 3,'zuleidesilva.8361819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE ARAUJO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE ARAUJO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8485593  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE BORGES GASPAR DE SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8485593, 
 3,'zuleidesousa.8485593@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE BORGES GASPAR DE SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE BORGES GASPAR DE SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7739591  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE DA CONCEICAO DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7739591, 
 3,'zuleidecruz.7739591@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE DA CONCEICAO DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE DA CONCEICAO DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7283679  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE LOPES FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7283679, 
 3,'zuleideferreira.7283679@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE LOPES FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE LOPES FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38047593862'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE MARTINHA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zuleidesantos.38047593862@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE MARTINHA DOS SANTOS'),
 '38047593862', NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE MARTINHA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6365643802  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIDE PAULINO DA SILVA MULLER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6365643802, 
 3,'zuleidepsmuller.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIDE PAULINO DA SILVA MULLER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIDE PAULINO DA SILVA MULLER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7777272  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIKA BARONI VERONESI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7777272, 
 3,'zuleikaveronesi.7777272@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIKA BARONI VERONESI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIKA BARONI VERONESI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8469717  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEIKA JULIENE FERREIRA CANTOLLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8469717, 
 3,'zuleikacantolli.8469717@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEIKA JULIENE FERREIRA CANTOLLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEIKA JULIENE FERREIRA CANTOLLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6779034  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULEINE CESCHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6779034, 
 3,'zuleinemonteiro.6779034@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULEINE CESCHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULEINE CESCHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02213828369'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULENE ELIAS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zulenesilva.e02213828369@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULENE ELIAS DA SILVA'),
 '02213828369', NULL, true); 
 raise notice 'Adicionado o usuario ZULENE ELIAS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '11111251800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULMA CRISTINA LAINER '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zulmalainer11111251800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULMA CRISTINA LAINER '),
 '11111251800', NULL, true); 
 raise notice 'Adicionado o usuario ZULMA CRISTINA LAINER '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8268703  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULMIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8268703, 
 3,'zulmirasilva.8268703@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULMIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULMIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8062439  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZULMIRA ROSA OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8062439, 
 3,'zulmiraoliveira.8062439@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZULMIRA ROSA OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZULMIRA ROSA OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8846316  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZURANDI ALVES MEDEIROS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8846316, 
 3,'zurandisantos.8846316@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZURANDI ALVES MEDEIROS DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZURANDI ALVES MEDEIROS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8408068  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÉLIA ALVES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8408068, 
 3,'zeliasouza.8408068@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÉLIA ALVES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZÉLIA ALVES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25415249869'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÉLIA APARECIDA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeliarocha.25415249869@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÉLIA APARECIDA ROCHA'),
 '25415249869', NULL, true); 
 raise notice 'Adicionado o usuario ZÉLIA APARECIDA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8163766  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÉLIA CONCEIÇÃO MATIAS JANUARIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8163766, 
 3,'zeliamatias.8163766@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÉLIA CONCEIÇÃO MATIAS JANUARIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZÉLIA CONCEIÇÃO MATIAS JANUARIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26660669833'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÉLIA DA SILVA ROMANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeliaromano.26660669833@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÉLIA DA SILVA ROMANO'),
 '26660669833', NULL, true); 
 raise notice 'Adicionado o usuario ZÉLIA DA SILVA ROMANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40274389819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÉLIA MARIA SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'zeliasoares.40274389819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÉLIA MARIA SOARES'),
 '40274389819', NULL, true); 
 raise notice 'Adicionado o usuario ZÉLIA MARIA SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8088802  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÉLIA NOGUEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8088802, 
 3,'zelianogueira.8088802@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÉLIA NOGUEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZÉLIA NOGUEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5834104  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÊNIA MARIA DA CUNHA GALVINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5834104, 
 3,'zeniagalvino.5834104@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÊNIA MARIA DA CUNHA GALVINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZÊNIA MARIA DA CUNHA GALVINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8051496  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZÍPORA MARIA DE CARVALHO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8051496, 
 3,'ziporasilva.8051496@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZÍPORA MARIA DE CARVALHO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZÍPORA MARIA DE CARVALHO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6130950  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁBILA GONÇALVES LOPES DA SILVA ZOCA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6130950, 
 3,'abilasilva.6130950@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁBILA GONÇALVES LOPES DA SILVA ZOCA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÁBILA GONÇALVES LOPES DA SILVA ZOCA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39172283866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁDILA DA SILVA DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'adiladias.e39172283866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁDILA DA SILVA DIAS'),
 '39172283866', NULL, true); 
 raise notice 'Adicionado o usuario ÁDILA DA SILVA DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31984078852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁGATA DO CARMO NUNES SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'agatasilva.31984078852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁGATA DO CARMO NUNES SILVA'),
 '31984078852', NULL, true); 
 raise notice 'Adicionado o usuario ÁGATA DO CARMO NUNES SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '51166050866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁGATHA MESQUITA AQUINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'agathaaquino.51166050866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁGATHA MESQUITA AQUINO'),
 '51166050866', NULL, true); 
 raise notice 'Adicionado o usuario ÁGATHA MESQUITA AQUINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37893374802'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁKILA JOVENCIO BEZERRA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'akilabezerra.37893374802@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁKILA JOVENCIO BEZERRA RODRIGUES'),
 '37893374802', NULL, true); 
 raise notice 'Adicionado o usuario ÁKILA JOVENCIO BEZERRA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '15752566819'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁNA PAULA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'anapaula.15752566819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁNA PAULA'),
 '15752566819', NULL, true); 
 raise notice 'Adicionado o usuario ÁNA PAULA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38779290876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁQUILA JERLANE QUERINO MENDES MOURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'aquilamoura.38779290876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁQUILA JERLANE QUERINO MENDES MOURA'),
 '38779290876', NULL, true); 
 raise notice 'Adicionado o usuario ÁQUILA JERLANE QUERINO MENDES MOURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7541830  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁRINA BRANDÃO DE CAMPOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7541830, 
 3,'arinasantos7541830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁRINA BRANDÃO DE CAMPOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÁRINA BRANDÃO DE CAMPOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7449461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁTILLA GONÇALVES SOARES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7449461, 
 3,'atillasantos.7449461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁTILLA GONÇALVES SOARES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÁTILLA GONÇALVES SOARES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33089765870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁUREA BORGES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'aureasantos.33089765870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁUREA BORGES DOS SANTOS'),
 '33089765870', NULL, true); 
 raise notice 'Adicionado o usuario ÁUREA BORGES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '09415932821'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁUREA DA SILVA BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'aureabrito.09415932821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁUREA DA SILVA BRITO'),
 '09415932821', NULL, true); 
 raise notice 'Adicionado o usuario ÁUREA DA SILVA BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '03415507602'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁUREA DE FÁTIMA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'aureapereira.03415507602@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁUREA DE FÁTIMA PEREIRA'),
 '03415507602', NULL, true); 
 raise notice 'Adicionado o usuario ÁUREA DE FÁTIMA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8138869  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁUREA NÉRIA LOPES PIRES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8138869, 
 3,'aureapires.8138869@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁUREA NÉRIA LOPES PIRES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÁUREA NÉRIA LOPES PIRES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '57510225549'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÁUREA PEREIRA COSTA CARAIBA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'aureacaraiba.57510225549@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÁUREA PEREIRA COSTA CARAIBA'),
 '57510225549', NULL, true); 
 raise notice 'Adicionado o usuario ÁUREA PEREIRA COSTA CARAIBA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '25307384831'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA ALVES DE MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelamelo.25307384831@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA ALVES DE MELO'),
 '25307384831', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA ALVES DE MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8206465  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA ANTONIA SILVA DE MORAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8206465, 
 3,'angelamorais.8206465@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA ANTONIA SILVA DE MORAIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA ANTONIA SILVA DE MORAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26132572880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA APARECIDA MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelaamatos.26132572880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA APARECIDA MATOS'),
 '26132572880', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA APARECIDA MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34450758838'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA ARAÚJO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelanascimento.34450758838@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA ARAÚJO NASCIMENTO'),
 '34450758838', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA ARAÚJO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '84104570591'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA CARDOSO SILVA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelajesus.84104570591@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA CARDOSO SILVA DE JESUS'),
 '84104570591', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA CARDOSO SILVA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7953992  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA DE SOUSA LOURENÇO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7953992, 
 3,'angelalourenco.7953992@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA DE SOUSA LOURENÇO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA DE SOUSA LOURENÇO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8795215  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA DE SOUZA BATISTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8795215, 
 3,'angelabatista.8795215@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA DE SOUZA BATISTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA DE SOUZA BATISTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33934188826'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA GLAZIELE DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelamarques.33934188826@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA GLAZIELE DE CARVALHO'),
 '33934188826', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA GLAZIELE DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9176446  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA MARIA DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9176446, 
 3,'angelacruz.9176446@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA MARIA DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA MARIA DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28306987896'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA MARIA DE SOUZA CAVALCANTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelacavalcante.28306987896@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA MARIA DE SOUZA CAVALCANTE'),
 '28306987896', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA MARIA DE SOUZA CAVALCANTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32045236838'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA MARIA OLIVEIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelaoliveira.32045236838@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA MARIA OLIVEIRA DOS SANTOS'),
 '32045236838', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA MARIA OLIVEIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '28421864866'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA MOURA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'angelasilva.28421864866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA MOURA DA SILVA'),
 '28421864866', NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA MOURA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7953291  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÂNGELA REGINA BENIGNO DE OLIVEIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7953291, 
 3,'angelasilva.7953291@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÂNGELA REGINA BENIGNO DE OLIVEIRA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÂNGELA REGINA BENIGNO DE OLIVEIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '40077765800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉDER LOPES MARINHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'edermarinho.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉDER LOPES MARINHO'),
 '40077765800', NULL, true); 
 raise notice 'Adicionado o usuario ÉDER LOPES MARINHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02717384995'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉDINA LUCIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'edinasantos.02717384995@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉDINA LUCIA DOS SANTOS'),
 '02717384995', NULL, true); 
 raise notice 'Adicionado o usuario ÉDINA LUCIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7445016  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉDIS MARIA GOMES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7445016, 
 3,'edissantos.7445016@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉDIS MARIA GOMES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉDIS MARIA GOMES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5737231  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉGLER PEREIRA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5737231, 
 3,'eglerlima.5737231@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉGLER PEREIRA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉGLER PEREIRA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7999186  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLCIO ALBANO RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7999186, 
 3,'elcioribeiro.7999186@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLCIO ALBANO RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉLCIO ALBANO RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '60442470312'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDA ALBUQUERQUE SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'elidasilva.60442470312@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDA ALBUQUERQUE SILVA'),
 '60442470312', NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDA ALBUQUERQUE SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37681536817'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDA BADARÓ DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'elidasantos.37681536817@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDA BADARÓ DOS SANTOS'),
 '37681536817', NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDA BADARÓ DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35336612880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDA CRISTINA DE SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'elidasousa.e35336612880@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDA CRISTINA DE SOUSA'),
 '35336612880', NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDA CRISTINA DE SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7252471  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDA CRISTINA GAMA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7252471, 
 3,'elidapereira.7252471@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDA CRISTINA GAMA PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDA CRISTINA GAMA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32288332832'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDA FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'elidafernandes.32288332832@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDA FERNANDES'),
 '32288332832', NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDA FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8089701  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDA KEILA MAIA DIÓGENES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8089701, 
 3,'elidadiogenes.8089701@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDA KEILA MAIA DIÓGENES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDA KEILA MAIA DIÓGENES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26707219820'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDE NERI LOURENÇO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'elidesilva.26707219820@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDE NERI LOURENÇO SILVA'),
 '26707219820', NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDE NERI LOURENÇO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8057699  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLIDE TORRES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8057699, 
 3,'elidesantos.8057699@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLIDE TORRES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉLIDE TORRES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39672548877'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLISSA SOUSA DE MOURA CAVALCANTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'elissacavalcante.39672548877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLISSA SOUSA DE MOURA CAVALCANTE'),
 '39672548877', NULL, true); 
 raise notice 'Adicionado o usuario ÉLISSA SOUSA DE MOURA CAVALCANTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 754002  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLITA PAULA DO NASCIMENTO MACIEL '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 754002, 
 3,'elitamaciel.754002@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLITA PAULA DO NASCIMENTO MACIEL '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉLITA PAULA DO NASCIMENTO MACIEL '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8919291  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉLLEN BORGES MORAES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8919291, 
 3,'ellenbmoraes.8919291@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉLLEN BORGES MORAES '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉLLEN BORGES MORAES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32896903852'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA AMÉLIA DEL VALE PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericapereira.e32896903852@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA AMÉLIA DEL VALE PEREIRA'),
 '32896903852', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA AMÉLIA DEL VALE PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8825181  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA CRISTINA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8825181, 
 3,'ericaoliveira.8825181@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA CRISTINA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA CRISTINA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8153612  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA CRISTINA FELIPOV'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8153612, 
 3,'ericafelipov.8153612@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA CRISTINA FELIPOV'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA CRISTINA FELIPOV'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '31209089831'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA CRISTINA GONÇALVES DE SOUZA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasouza.e31209089831@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA CRISTINA GONÇALVES DE SOUZA '),
 '31209089831', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA CRISTINA GONÇALVES DE SOUZA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42982801876'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DA CRUZ PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericapereira.42982801876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DA CRUZ PEREIRA'),
 '42982801876', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DA CRUZ PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26885953857'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DA CRUZ SANTOS DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericaoliveira.26885953857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DA CRUZ SANTOS DE OLIVEIRA'),
 '26885953857', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DA CRUZ SANTOS DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33731919800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DA SILVA PINTO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericapinto.33731919800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DA SILVA PINTO '),
 '33731919800', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DA SILVA PINTO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8880875  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DARC DE MELO CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8880875, 
 3,'ericavenancio.8880875@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DARC DE MELO CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DARC DE MELO CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8215243  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DAS GRAÇAS APARECIDA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8215243, 
 3,'ericavieira.8215243@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DAS GRAÇAS APARECIDA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DAS GRAÇAS APARECIDA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '38909396865'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DE CASTRO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasilva.38909396865@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DE CASTRO SILVA'),
 '38909396865', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DE CASTRO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '37207867816'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DE SALES NOGUEIRA MARINHO '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericamarinho.37207867816@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DE SALES NOGUEIRA MARINHO '),
 '37207867816', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DE SALES NOGUEIRA MARINHO '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8956278  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DI TRAGLIA LEONARDI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8956278, 
 3,'ericaleonardi.8956278@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DI TRAGLIA LEONARDI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DI TRAGLIA LEONARDI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44871598810'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA DOS SANTOS CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericacruz.e44871598810@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA DOS SANTOS CRUZ'),
 '44871598810', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA DOS SANTOS CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8160422  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8160422, 
 3,'ericasilva.8160422@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA FERREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7844379  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA FERREIRA DAMASCENO ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7844379, 
 3,'ericaalves.7844379@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA FERREIRA DAMASCENO ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA FERREIRA DAMASCENO ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8209821  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA FERREIRA DOS SANTOS FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8209821, 
 3,'ericafernandes.8209821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA FERREIRA DOS SANTOS FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA FERREIRA DOS SANTOS FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33603879880'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA FERREIRA RAMOS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericafrsantos.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA FERREIRA RAMOS DOS SANTOS'),
 '33603879880', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA FERREIRA RAMOS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39390877857'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA GOMES SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasantos.39390877857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA GOMES SANTOS'),
 '39390877857', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA GOMES SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7716354  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA LOURENÇO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7716354, 
 3,'ericasilva.7716354@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA LOURENÇO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA LOURENÇO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 4178067524  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA MANUELA DE SOUZA BERTUNES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 4178067524, 
 3,'ericabertunes.4178067524@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA MANUELA DE SOUZA BERTUNES '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA MANUELA DE SOUZA BERTUNES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '18692994855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA MARIA CORRÊA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericacorrea.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA MARIA CORRÊA'),
 '18692994855', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA MARIA CORRÊA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39009276856'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA MARIA DA SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasilva.39009276856@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA MARIA DA SILVA '),
 '39009276856', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA MARIA DA SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7958455  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA MARIA DOS SANTOS GOMES BRAZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7958455, 
 3,'ericabraz.7958455@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA MARIA DOS SANTOS GOMES BRAZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA MARIA DOS SANTOS GOMES BRAZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8036977  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA MONTEIRO SACCO DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8036977, 
 3,'ericaalmeida.8036977@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA MONTEIRO SACCO DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA MONTEIRO SACCO DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8398551  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA OLIVEIRA MELO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8398551, 
 3,'ericasilva.8398551@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA OLIVEIRA MELO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA OLIVEIRA MELO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35273040884'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA OLIVEIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasilva.35273040884@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA OLIVEIRA SILVA'),
 '35273040884', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA OLIVEIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8185271  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA PEDREIRA ANDRADE DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8185271, 
 3,'ericajesus.8185271@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA PEDREIRA ANDRADE DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA PEDREIRA ANDRADE DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7950837  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA PEREIRA MARIANNO DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7950837, 
 3,'ericacruz.7950837@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA PEREIRA MARIANNO DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA PEREIRA MARIANNO DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '02145879595'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA REGINA  MARQUES FERNANDES BRASILEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericabrasileiro.02145879595@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA REGINA  MARQUES FERNANDES BRASILEIRO'),
 '02145879595', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA REGINA  MARQUES FERNANDES BRASILEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '35004422850'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA RIBEIRO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasantos.35004422850@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA RIBEIRO DOS SANTOS'),
 '35004422850', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA RIBEIRO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '42208579828'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA SANTOS MARINHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericamarinho.42208579828@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA SANTOS MARINHO'),
 '42208579828', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA SANTOS MARINHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7988958  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA SILVA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7988958, 
 3,'ericalima.7988958@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA SILVA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA SILVA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7888958  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA SILVA LIMA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7888958, 
 3,'ericalima.7888958@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA SILVA LIMA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA SILVA LIMA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8485372  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA SIMONE OLIVEIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8485372, 
 3,'ericasilva.8485372@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA SIMONE OLIVEIRA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA SIMONE OLIVEIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34524416870'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA TAMILES MACEDO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericatamiles34524416870@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA TAMILES MACEDO SANTOS'),
 '34524416870', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA TAMILES MACEDO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '30857530879'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA TROMBINI DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericasantos.30857530879@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA TROMBINI DOS SANTOS'),
 '30857530879', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA TROMBINI DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '26257985803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRICA VÂNIA ALEXANDRE RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'ericarodrigues.26257985803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRICA VÂNIA ALEXANDRE RODRIGUES'),
 '26257985803', NULL, true); 
 raise notice 'Adicionado o usuario ÉRICA VÂNIA ALEXANDRE RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '32725241855'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA ALVES DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'erikajesus.32725241855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA ALVES DE JESUS'),
 '32725241855', NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA ALVES DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8120099  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA BEATRIZ DE SOUZA ARAÚJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8120099, 
 3,'erikabrugnari.8120099@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA BEATRIZ DE SOUZA ARAÚJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA BEATRIZ DE SOUZA ARAÚJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7267789  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA BRASILEIRO FERNANDES CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7267789, 
 3,'erikacruz.7267789@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA BRASILEIRO FERNANDES CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA BRASILEIRO FERNANDES CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33858202860'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA CRISTINA DOS SANTOS LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'erikalima.33858202860@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA CRISTINA DOS SANTOS LIMA'),
 '33858202860', NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA CRISTINA DOS SANTOS LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8451567  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA DOS REIS SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8451567, 
 3,'erikasousa.8451567@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA DOS REIS SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA DOS REIS SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8237344  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA FERNANDES SILVA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8237344, 
 3,'erikasilva.8237344@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA FERNANDES SILVA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA FERNANDES SILVA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '36481870828'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA GOMES CARDOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'erikacardoso.36481870828@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA GOMES CARDOSO'),
 '36481870828', NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA GOMES CARDOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7906552  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA REGINA LEITE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7906552, 
 3,'erikarleite.7906552@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA REGINA LEITE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA REGINA LEITE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '34735092803'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA RODRIGUES LADEIA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'erikasantos.34735092803@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA RODRIGUES LADEIA SANTOS'),
 '34735092803', NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA RODRIGUES LADEIA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '39892924800'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA SANTOS FREIRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'erikafreire.39892924800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA SANTOS FREIRE'),
 '39892924800', NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA SANTOS FREIRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 02101999  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA SOARES FERREIRA CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 02101999, 
 3,'erika.soares02101999@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA SOARES FERREIRA CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA SOARES FERREIRA CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7526369  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA TAMIZARI TAVARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7526369, 
 3,'erikatavares.7526369@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA TAMIZARI TAVARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA TAMIZARI TAVARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '07999635421'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉRIKA VANESSA RIBEIRO CASADO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'erikasilva.07999635421@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉRIKA VANESSA RIBEIRO CASADO DA SILVA'),
 '07999635421', NULL, true); 
 raise notice 'Adicionado o usuario ÉRIKA VANESSA RIBEIRO CASADO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '44444963808'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉVELLYN DA SILVA CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'evellyncarvalho.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉVELLYN DA SILVA CARVALHO'),
 '44444963808', NULL, true); 
 raise notice 'Adicionado o usuario ÉVELLYN DA SILVA CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '33968135881'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÉVILLA VICTOR PASSOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'evillasilva.33968135881@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÉVILLA VICTOR PASSOS SILVA'),
 '33968135881', NULL, true); 
 raise notice 'Adicionado o usuario ÉVILLA VICTOR PASSOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '47634698865'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÍCARO BRYAN FRANÇA GARCIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'icarogarcia.pmsp@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÍCARO BRYAN FRANÇA GARCIA'),
 '47634698865', NULL, true); 
 raise notice 'Adicionado o usuario ÍCARO BRYAN FRANÇA GARCIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8841110  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÍRIS GIANE SOARES LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8841110, 
 3,'irissilva.8841110@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÍRIS GIANE SOARES LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÍRIS GIANE SOARES LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where cpf = '43598131801'  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÍSIS MAIA SANTOS ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 null, 
 3,'isisalves.43598131801@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÍSIS MAIA SANTOS ALVES'),
 '43598131801', NULL, true); 
 raise notice 'Adicionado o usuario ÍSIS MAIA SANTOS ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8407941  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÍSIS RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8407941, 
 3,'isisrodrigues.8407941@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÍSIS RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÍSIS RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7304919  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÍTALA DA PENHA ORRICO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7304919, 
 3,'italaorrico.7304919@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÍTALA DA PENHA ORRICO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÍTALA DA PENHA ORRICO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8093644  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ÍTALO RODRIGO XAVIER CORDEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8093644, 
 3,'italocordeiro.8093644@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ÍTALO RODRIGO XAVIER CORDEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ÍTALO RODRIGO XAVIER CORDEIRO'; 
 END IF; 

END 
$do$ 

