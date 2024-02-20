DO 
$do$ 
BEGIN 

IF EXISTS (SELECT * from usuarios where id = 8175861  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ACASSIA REGINA NASCIMENTO MEDEIROS DE FARIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8175861, 
 3,'acassiafaria.8175861@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ACASSIA REGINA NASCIMENTO MEDEIROS DE FARIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ACASSIA REGINA NASCIMENTO MEDEIROS DE FARIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6186211  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADILSON SANTANA SIMOES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6186211, 
 3,'adilsonsimoes.6186211@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADILSON SANTANA SIMOES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADILSON SANTANA SIMOES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6954413  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA ALEXANDRE DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6954413, 
 3,'adrianadias.6954413@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA ALEXANDRE DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA ALEXANDRE DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7283199  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA BONIFACIO CALIMAN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7283199, 
 3,'adrianacaliman.7283199@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA BONIFACIO CALIMAN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA BONIFACIO CALIMAN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7101597  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA DA SILVA LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7101597, 
 3,'adrianalopes.7101597@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA DA SILVA LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA DA SILVA LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7955227  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA FERNANDES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7955227, 
 3,'adrianasilva.7955227@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA FERNANDES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA FERNANDES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8103518  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA IDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8103518, 
 3,'adrianaide.8103518@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA IDE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA IDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7793821  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA PEREIRA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7793821, 
 3,'adrianarocha.7793821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA PEREIRA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA PEREIRA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8358290  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA SANTOS MORGADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8358290, 
 3,'adrianamorgado.8358290@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA SANTOS MORGADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA SANTOS MORGADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7327889  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA SOUSA DE QUEIROZ CAETANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7327889, 
 3,'adrianacaetano.7327889@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA SOUSA DE QUEIROZ CAETANO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA SOUSA DE QUEIROZ CAETANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6860362  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ADRIANA TAKAHAMA NEPOMUCENO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6860362, 
 3,'adriananepomuceno.6860362@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ADRIANA TAKAHAMA NEPOMUCENO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ADRIANA TAKAHAMA NEPOMUCENO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8285519  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AGNES DOS SANTOS PINHEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8285519, 
 3,'agnespinheiro.8285519@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AGNES DOS SANTOS PINHEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AGNES DOS SANTOS PINHEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7758456  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AGNES HANASHIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7758456, 
 3,'agneshanashiro.7758456@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AGNES HANASHIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AGNES HANASHIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8017662  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALBERTO MAFFEI DELMONDS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8017662, 
 3,'albertodelmonds.8017662@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALBERTO MAFFEI DELMONDS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALBERTO MAFFEI DELMONDS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7249144  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALBINO SILVA MOREIRA FILHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7249144, 
 3,'albinofilho.7249144@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALBINO SILVA MOREIRA FILHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALBINO SILVA MOREIRA FILHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7160933  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALCIONE SILVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7160933, 
 3,'alcionesilveira.7160933@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALCIONE SILVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALCIONE SILVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6693458  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALESSANDRA DOS SANTOS AMARAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6693458, 
 3,'alessandraamaral.6693458@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALESSANDRA DOS SANTOS AMARAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALESSANDRA DOS SANTOS AMARAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8958807  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALESSANDRA MAYARA BRAGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8958807, 
 3,'alessandrabraga.8958807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALESSANDRA MAYARA BRAGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALESSANDRA MAYARA BRAGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6339301  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALESSANDRA PEREIRA ROSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6339301, 
 3,'alessandrarosa.6339301@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALESSANDRA PEREIRA ROSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALESSANDRA PEREIRA ROSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7772645  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALEX BENJAMIM DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7772645, 
 3,'alexlima.7772645@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALEX BENJAMIM DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALEX BENJAMIM DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179020  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALEX WILSON DA SILVA FONSECA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179020, 
 3,'alexfonseca.9179020@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALEX WILSON DA SILVA FONSECA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALEX WILSON DA SILVA FONSECA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6741002  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALEXANDRE OLIVEIRA DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6741002, 
 3,'alexandrearaujo.6741002@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALEXANDRE OLIVEIRA DE ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALEXANDRE OLIVEIRA DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8502358  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALEXANDRE RODRIGUES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8502358, 
 3,'alexandresantos.8502358@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALEXANDRE RODRIGUES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALEXANDRE RODRIGUES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8244588  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALINE DIAS GIRIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8244588, 
 3,'alinegirio.8244588@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALINE DIAS GIRIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALINE DIAS GIRIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161627  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALINE LOPES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161627, 
 3,'alinesantos.9161627@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALINE LOPES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALINE LOPES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8422079  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ALLAN CAVALCANTI DE MOURA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8422079, 
 3,'allanmoura.8422079@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ALLAN CAVALCANTI DE MOURA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ALLAN CAVALCANTI DE MOURA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7753543  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AMANDA BIANCHI LEONARDO RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7753543, 
 3,'amandarodrigues.7753543@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AMANDA BIANCHI LEONARDO RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AMANDA BIANCHI LEONARDO RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7359039  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AMANDA FERREIRA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7359039, 
 3,'amandarodrigues.7359039@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AMANDA FERREIRA RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AMANDA FERREIRA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9204491  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AMANDA FRANCISCA RODRIGUES PENCAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9204491, 
 3,'amandapencal.9204491@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AMANDA FRANCISCA RODRIGUES PENCAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AMANDA FRANCISCA RODRIGUES PENCAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8419311  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AMANDA FUSCO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8419311, 
 3,'amandafusco.8419311@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AMANDA FUSCO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AMANDA FUSCO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7712693  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA BEATRIZ BIZZARRO TERRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7712693, 
 3,'anaterra.7712693@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA BEATRIZ BIZZARRO TERRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA BEATRIZ BIZZARRO TERRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7562071  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA BÁRBARA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7562071, 
 3,'anasantos.7562071@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA BÁRBARA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA BÁRBARA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7979142  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA CAROLINA ENCISO DE SA ACQUESTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7979142, 
 3,'anaacquesta.7979142@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA CAROLINA ENCISO DE SA ACQUESTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA CAROLINA ENCISO DE SA ACQUESTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8235007  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA CAROLINA LIMA CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8235007, 
 3,'anacarvalho.8235007@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA CAROLINA LIMA CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA CAROLINA LIMA CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7569530  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA FLAVIA MIRANDA CAMBRAIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7569530, 
 3,'anacambraia.7569530@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA FLAVIA MIRANDA CAMBRAIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA FLAVIA MIRANDA CAMBRAIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8426333  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA HELENA BRANCO MAIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8426333, 
 3,'anamaia.8426333@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA HELENA BRANCO MAIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA HELENA BRANCO MAIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7252668  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA KARLA CHAVES MUNER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7252668, 
 3,'anamuner.7252668@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA KARLA CHAVES MUNER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA KARLA CHAVES MUNER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7471734  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA LUCIA FERREIRA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7471734, 
 3,'analima.7471734@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA LUCIA FERREIRA DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA LUCIA FERREIRA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8080275  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA LUISA PATRICIO CAMPOS DE OLIVEIRA LENK CATELANI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8080275, 
 3,'anacatelani.8080275@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA LUISA PATRICIO CAMPOS DE OLIVEIRA LENK CATELANI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA LUISA PATRICIO CAMPOS DE OLIVEIRA LENK CATELANI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 747173  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA LÚCIA FERREIRA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 747173, 
 3,'anaflima.747173@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA LÚCIA FERREIRA DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA LÚCIA FERREIRA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8195901  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA MARIA DE LUCA FERNANDES DE ALCANTARA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8195901, 
 3,'anaalcantara.8195901@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA MARIA DE LUCA FERNANDES DE ALCANTARA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA MARIA DE LUCA FERNANDES DE ALCANTARA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 1325671  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA MARIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 1325671, 
 3,'anasantos.1325671@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA MARIA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA MARIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7223811  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA MARIA POMARINO MONASTERIOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7223811, 
 3,'anamonasterios.7223811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA MARIA POMARINO MONASTERIOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA MARIA POMARINO MONASTERIOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 1370898  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA MARIA SPREAFICO MORENO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 1370898, 
 3,'anamoreno.1370898@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA MARIA SPREAFICO MORENO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA MARIA SPREAFICO MORENO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8273227  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA CASSULINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8273227, 
 3,'anacassulino.8273227@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA CASSULINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA CASSULINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179101  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA CIRILO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179101, 
 3,'anacirilo.9179101@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA CIRILO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA CIRILO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7432313  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA COPELLI CARDOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7432313, 
 3,'anacardoso.7432313@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA COPELLI CARDOSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA COPELLI CARDOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7772513  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA FIGUEIREDO MARQUES STRUMILLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7772513, 
 3,'anastrumillo.7772513@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA FIGUEIREDO MARQUES STRUMILLO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA FIGUEIREDO MARQUES STRUMILLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7712651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA NASCIMENTO DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7712651, 
 3,'anaandrade.7712651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA NASCIMENTO DE ANDRADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA NASCIMENTO DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8117128  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA NICOLI LAMEDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8117128, 
 3,'analameda.8117128@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA NICOLI LAMEDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA NICOLI LAMEDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8193576  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANA PAULA PEREIRA GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8193576, 
 3,'anagibim.8193576@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANA PAULA PEREIRA GOMES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANA PAULA PEREIRA GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8359229  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANANDA GRINKRAUT'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8359229, 
 3,'anandagrinkraut.8359229@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANANDA GRINKRAUT'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANANDA GRINKRAUT'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6481205  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDERSON PEREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6481205, 
 3,'andersonsilva.6481205@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDERSON PEREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDERSON PEREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8422028  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDRE DE PINA MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8422028, 
 3,'andremoreira.8422028@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDRE DE PINA MOREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDRE DE PINA MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6566677  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA CAETANO DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6566677, 
 3,'andreaaraujo.6566677@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA CAETANO DE ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA CAETANO DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7441754  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA DOS SANTOS OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7441754, 
 3,'andreaoliveira.7441754@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA DOS SANTOS OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA DOS SANTOS OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8116482  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA MARIANA NUNES DA COSTA TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8116482, 
 3,'andreateixeira.8116482@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA MARIANA NUNES DA COSTA TEIXEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA MARIANA NUNES DA COSTA TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7336365  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA REGINA DE CARVALHO CASANOVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7336365, 
 3,'andreacasanova.7336365@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA REGINA DE CARVALHO CASANOVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA REGINA DE CARVALHO CASANOVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8078475  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA REGINA MACIEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8078475, 
 3,'andreamaciel.8078475@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA REGINA MACIEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA REGINA MACIEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6966454  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA ROSCHEL RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6966454, 
 3,'andrearibeiro.6966454@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA ROSCHEL RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA ROSCHEL RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8130523  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA TAVARES MARQUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8130523, 
 3,'andreamarques.8130523@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA TAVARES MARQUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA TAVARES MARQUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8112533  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREA WANG CATALANI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8112533, 
 3,'andreacatalani.8112533@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREA WANG CATALANI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREA WANG CATALANI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6342434  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREIA BARBOSA RIBEIRO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6342434, 
 3,'andreiasouza.6342434@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREIA BARBOSA RIBEIRO DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREIA BARBOSA RIBEIRO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8278415  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREIA RODRIGUES GAROFALO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8278415, 
 3,'andreiagarofalo.8278415@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREIA RODRIGUES GAROFALO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREIA RODRIGUES GAROFALO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8393648  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDRESSA DA SILVA CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8393648, 
 3,'andressacarvalho.8393648@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDRESSA DA SILVA CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDRESSA DA SILVA CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7929790  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDREZA BRIGANDO DOS REIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7929790, 
 3,'andrezareis.7929790@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDREZA BRIGANDO DOS REIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDREZA BRIGANDO DOS REIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7804857  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANDRÉIA FERNANDES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7804857, 
 3,'andreiasouza.7804857@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANDRÉIA FERNANDES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANDRÉIA FERNANDES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8968551  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANGELA ANTONIA SANTOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8968551, 
 3,'angelasilva.8968551@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANGELA ANTONIA SANTOS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANGELA ANTONIA SANTOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6081991  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANGELA AQUINO DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6081991, 
 3,'angelacarvalho.6081991@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANGELA AQUINO DE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANGELA AQUINO DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8105197  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANGELICA APARECIDA TAVARES D AMATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8105197, 
 3,'angelicaamato.8105197@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANGELICA APARECIDA TAVARES D AMATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANGELICA APARECIDA TAVARES D AMATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8026327  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANGELICA DADARIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8026327, 
 3,'angelicadadario.8026327@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANGELICA DADARIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANGELICA DADARIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7720742  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANGELICA ISIDORO COSTA PELAEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7720742, 
 3,'angelicapelaez.7720742@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANGELICA ISIDORO COSTA PELAEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANGELICA ISIDORO COSTA PELAEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7222971  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANITA CLEIDE DE FELICE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7222971, 
 3,'anitafelice.7222971@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANITA CLEIDE DE FELICE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANITA CLEIDE DE FELICE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8104085  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANNA CAROLINA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8104085, 
 3,'annasantos.8104085@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANNA CAROLINA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANNA CAROLINA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7418078  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANNA LUISA DE CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7418078, 
 3,'annacastro.7418078@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANNA LUISA DE CASTRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANNA LUISA DE CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8084513  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANNA PAOLA BRAGA SANTINE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8084513, 
 3,'annasantine.8084513@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANNA PAOLA BRAGA SANTINE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANNA PAOLA BRAGA SANTINE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8109885  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANTONELLA ZOGBI GOMES PINTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8109885, 
 3,'antonellapinto.8109885@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANTONELLA ZOGBI GOMES PINTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANTONELLA ZOGBI GOMES PINTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8588040  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANTONIA GERALDA DE ARAUJO ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8588040, 
 3,'antoniarocha.8588040@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANTONIA GERALDA DE ARAUJO ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANTONIA GERALDA DE ARAUJO ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9245201  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANTONIO CAMILO NOGUEIRA GUEDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9245201, 
 3,'antonioguedes.9245201@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANTONIO CAMILO NOGUEIRA GUEDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANTONIO CAMILO NOGUEIRA GUEDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5047676  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ANTONIO CARLOS PRESTES CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5047676, 
 3,'antoniocampos.5047676@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ANTONIO CARLOS PRESTES CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ANTONIO CARLOS PRESTES CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8015902  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario APARECIDO SUTERO DA SILVA JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8015902, 
 3,'aparecidojunior.8015902@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('APARECIDO SUTERO DA SILVA JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario APARECIDO SUTERO DA SILVA JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8271305  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ARLETE RODRIGUES MORAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8271305, 
 3,'arletemoraes.8271305@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ARLETE RODRIGUES MORAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ARLETE RODRIGUES MORAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6057390  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ARLIEDJA GOMES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6057390, 
 3,'arliedjasantos.6057390@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ARLIEDJA GOMES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ARLIEDJA GOMES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8035431  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AURENY CRISTINA PEREIRA SILVA ROCHAEL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8035431, 
 3,'aurenyrochael.8035431@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AURENY CRISTINA PEREIRA SILVA ROCHAEL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AURENY CRISTINA PEREIRA SILVA ROCHAEL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7922655  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario AVELINE ROCHA MUNER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7922655, 
 3,'avelinemuner.7922655@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('AVELINE ROCHA MUNER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario AVELINE ROCHA MUNER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9178996  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BARBARA SANCHES ROLIM DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9178996, 
 3,'barbarasilva.9178996@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BARBARA SANCHES ROLIM DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BARBARA SANCHES ROLIM DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9128981  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BEATRIZ CRISTINA DOS SANTOS LUIZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9128981, 
 3,'beatrizluiz.9128981@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BEATRIZ CRISTINA DOS SANTOS LUIZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BEATRIZ CRISTINA DOS SANTOS LUIZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8811695  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BEATRIZ DE JESUS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8811695, 
 3,'beatrizsilva.8811695@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BEATRIZ DE JESUS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BEATRIZ DE JESUS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8954623  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BIANCA ORTOLAN DIAS DO VALLE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8954623, 
 3,'biancavalle.8954623@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BIANCA ORTOLAN DIAS DO VALLE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BIANCA ORTOLAN DIAS DO VALLE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7299800  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRAZ GOMES DA SILVA FILHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7299800, 
 3,'brazfilho.7299800@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRAZ GOMES DA SILVA FILHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRAZ GOMES DA SILVA FILHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9154698  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRENO LYOGI OKAMURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9154698, 
 3,'brenookamura.9154698@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRENO LYOGI OKAMURA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRENO LYOGI OKAMURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8136432  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRIGIT MARIA DOS PASSOS RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8136432, 
 3,'brigitrodrigues.8136432@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRIGIT MARIA DOS PASSOS RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRIGIT MARIA DOS PASSOS RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8019568  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNA ACIOLI SILVA MACHADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8019568, 
 3,'brunamachado.8019568@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNA ACIOLI SILVA MACHADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNA ACIOLI SILVA MACHADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8361665  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNA MEIRA ALTINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8361665, 
 3,'brunaaltino.8361665@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNA MEIRA ALTINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNA MEIRA ALTINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161511  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNA VEGA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161511, 
 3,'brunasilva.9161511@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNA VEGA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNA VEGA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179038  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNNA GOMES VIANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179038, 
 3,'brunnaviana.9179038@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNNA GOMES VIANA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNNA GOMES VIANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8024154  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNO CARVALHO DA SILVA BARROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8024154, 
 3,'brunobarros.8024154@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNO CARVALHO DA SILVA BARROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNO CARVALHO DA SILVA BARROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7970099  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNO DE SOUZA RODRIGUES FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7970099, 
 3,'brunoferreira.7970099@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNO DE SOUZA RODRIGUES FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNO DE SOUZA RODRIGUES FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8905754  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario BRUNO LOPES CORREIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8905754, 
 3,'brunocorreia.8905754@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('BRUNO LOPES CORREIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario BRUNO LOPES CORREIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8030405  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAIO MARQUES FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8030405, 
 3,'caiofernandes.8030405@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAIO MARQUES FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAIO MARQUES FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8927553  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAMILA RAMOS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8927553, 
 3,'camilasilva.8927553@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAMILA RAMOS DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAMILA RAMOS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7228287  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAMILA RAMOS FRANCO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7228287, 
 3,'camilaramos.7228287@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAMILA RAMOS FRANCO DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAMILA RAMOS FRANCO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8198144  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAMILA SANTO LISBOA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8198144, 
 3,'camilalisboa.8198144@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAMILA SANTO LISBOA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAMILA SANTO LISBOA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8415510  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARINA JAKITAS FONSECA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8415510, 
 3,'carinafonseca.8415510@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARINA JAKITAS FONSECA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARINA JAKITAS FONSECA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161431  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARINA WEISHAUPT VIEIRA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161431, 
 3,'carinalima.9161431@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARINA WEISHAUPT VIEIRA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARINA WEISHAUPT VIEIRA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8148546  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLA DUARTE DA LUZ CUNHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8148546, 
 3,'carlacunha.8148546@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLA DUARTE DA LUZ CUNHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLA DUARTE DA LUZ CUNHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6937497  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLA MARIA BRICHESE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6937497, 
 3,'carlabrichese.6937497@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLA MARIA BRICHESE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLA MARIA BRICHESE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5561728  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLA REGINA FERREIRA DE FREITAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5561728, 
 3,'carlafreitas.5561728@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLA REGINA FERREIRA DE FREITAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLA REGINA FERREIRA DE FREITAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7703929  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLA SIMONE DE ALMEIDA BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7703929, 
 3,'carlabrito.7703929@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLA SIMONE DE ALMEIDA BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLA SIMONE DE ALMEIDA BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7971966  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLA VANESSA MARTINELI FRAGOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7971966, 
 3,'carlafragoso.7971966@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLA VANESSA MARTINELI FRAGOSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLA VANESSA MARTINELI FRAGOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9262083  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLOS ALBERTO FACHINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9262083, 
 3,'carlosfachini.9262083@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLOS ALBERTO FACHINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLOS ALBERTO FACHINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7248369  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLOS ALBERTO MENDES DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7248369, 
 3,'carloslima.7248369@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLOS ALBERTO MENDES DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLOS ALBERTO MENDES DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9266381  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLOS ANTONIO ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9266381, 
 3,'carlosalves.9266381@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLOS ANTONIO ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLOS ANTONIO ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7493614  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CARLOS AUGUSTO TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7493614, 
 3,'carlosteixeira.7493614@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CARLOS AUGUSTO TEIXEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CARLOS AUGUSTO TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7779259  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLINA BASTOS MENDONCA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7779259, 
 3,'carolinamendonca.7779259@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLINA BASTOS MENDONCA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLINA BASTOS MENDONCA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161589  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLINA FIDALGO DEL RY'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161589, 
 3,'carolinary.9161589@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLINA FIDALGO DEL RY'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLINA FIDALGO DEL RY'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7706359  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLINA PENDLOSKI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7706359, 
 3,'carolinapendloski.7706359@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLINA PENDLOSKI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLINA PENDLOSKI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8122393  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLINA SOUSA COELHO DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8122393, 
 3,'carolinadias.8122393@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLINA SOUSA COELHO DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLINA SOUSA COELHO DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274002  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLINE GOODMAN LORETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274002, 
 3,'carolineloreto.8274002@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLINE GOODMAN LORETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLINE GOODMAN LORETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8095337  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLINNE MENDES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8095337, 
 3,'carolinnesilva.8095337@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLINNE MENDES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLINNE MENDES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9266399  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CAROLLINE DE SOUZA MACEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9266399, 
 3,'carollinemacedo.9266399@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CAROLLINE DE SOUZA MACEDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CAROLLINE DE SOUZA MACEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7521634  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CASSIANA PAULA COMINATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7521634, 
 3,'cassianacominato.7521634@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CASSIANA PAULA COMINATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CASSIANA PAULA COMINATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5805988  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CEILA MARCONDES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5805988, 
 3,'ceilasouza.5805988@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CEILA MARCONDES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CEILA MARCONDES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6104291  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CELI APARECIDA AGOSTINELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6104291, 
 3,'celiagostinelli.6104291@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CELI APARECIDA AGOSTINELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CELI APARECIDA AGOSTINELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9200681  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CELIA AFONSO CARNEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9200681, 
 3,'celiacarneiro.9200681@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CELIA AFONSO CARNEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CELIA AFONSO CARNEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5579708  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CELIA REGINA NOGUEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5579708, 
 3,'celianogueira.5579708@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CELIA REGINA NOGUEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CELIA REGINA NOGUEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9191356  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CELSO AGUILERA SANTORO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9191356, 
 3,'celsosantoro.9191356@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CELSO AGUILERA SANTORO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CELSO AGUILERA SANTORO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5378389  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CHRISTINA ALEXANDRA TELLES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5378389, 
 3,'christinasilva.5378389@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CHRISTINA ALEXANDRA TELLES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CHRISTINA ALEXANDRA TELLES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8110468  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CHRISTINE KOCHI GOLIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8110468, 
 3,'christinegolin.8110468@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CHRISTINE KOCHI GOLIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CHRISTINE KOCHI GOLIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8387389  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CIBELE AGNES CRUZ DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8387389, 
 3,'cibelesantos.8387389@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CIBELE AGNES CRUZ DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CIBELE AGNES CRUZ DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161368  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CILIRIA SOARES ALVES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161368, 
 3,'ciliriasantos.9161368@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CILIRIA SOARES ALVES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CILIRIA SOARES ALVES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9129065  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CINTHIA FRANCISCA SCHULTZ DE CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9129065, 
 3,'cinthiacastro.9129065@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CINTHIA FRANCISCA SCHULTZ DE CASTRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CINTHIA FRANCISCA SCHULTZ DE CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8162174  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CINTHIA YUMI YABUTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8162174, 
 3,'cinthiayabuta.8162174@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CINTHIA YUMI YABUTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CINTHIA YUMI YABUTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7721854  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CINTIA MITSUE KAMURA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7721854, 
 3,'cintiakamura.7721854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CINTIA MITSUE KAMURA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CINTIA MITSUE KAMURA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7993790  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CINTIA PAES DOS SANTOS ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7993790, 
 3,'cintiaalves.7993790@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CINTIA PAES DOS SANTOS ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CINTIA PAES DOS SANTOS ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9163786  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLARISSA EMI HIRAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9163786, 
 3,'clarissahirao.9163786@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLARISSA EMI HIRAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLARISSA EMI HIRAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9123334  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDETE BARCELOS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9123334, 
 3,'claudetesilva.9123334@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDETE BARCELOS DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDETE BARCELOS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8107017  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIA CARVALHO MALTESE BOATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8107017, 
 3,'claudiaboato.8107017@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIA CARVALHO MALTESE BOATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIA CARVALHO MALTESE BOATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7746717  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIA LOPES MACEDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7746717, 
 3,'claudiamacedo.7746717@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIA LOPES MACEDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIA LOPES MACEDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7933827  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIA MARIA APPUGLIESE GIROTTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7933827, 
 3,'claudiagirotto.7933827@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIA MARIA APPUGLIESE GIROTTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIA MARIA APPUGLIESE GIROTTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8512523  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIA MONTEIRO QUEIROZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8512523, 
 3,'claudiaqueiroz.8512523@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIA MONTEIRO QUEIROZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIA MONTEIRO QUEIROZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7762666  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIA REGINA MISTRELI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7762666, 
 3,'claudiamistreli.7762666@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIA REGINA MISTRELI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIA REGINA MISTRELI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5721458  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5721458, 
 3,'claudiosantos.5721458@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7347791  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIO MAROJA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7347791, 
 3,'claudiomaroja.7347791@sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIO MAROJA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIO MAROJA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7205830  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAUDIO SANTANA BISPO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7205830, 
 3,'claudiobispo.7205830@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAUDIO SANTANA BISPO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAUDIO SANTANA BISPO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8956481  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLAYTON TEODORO CORREIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8956481, 
 3,'claytoncorreia.8956481@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLAYTON TEODORO CORREIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLAYTON TEODORO CORREIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8926786  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLEBERSON DA SILVA PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8926786, 
 3,'clebersonpereira.8926786@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLEBERSON DA SILVA PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLEBERSON DA SILVA PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8021368  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLEDNA SANDRA NASCIMENTO COSTA MEDEIROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8021368, 
 3,'clednacosta.8021368@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLEDNA SANDRA NASCIMENTO COSTA MEDEIROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLEDNA SANDRA NASCIMENTO COSTA MEDEIROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7308418  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLEIDE DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7308418, 
 3,'cleideoliveira.7308418@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLEIDE DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLEIDE DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7234660  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLEUBER GONCALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7234660, 
 3,'cleubergoncalves.7234660@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLEUBER GONCALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLEUBER GONCALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7075227  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CLOVIS SANTOS DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7075227, 
 3,'cloviscarvalho.7075227@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CLOVIS SANTOS DE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CLOVIS SANTOS DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8205078  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTIANE AKEMI CONTRERAS ENDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8205078, 
 3,'cristianeendo.8205078@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTIANE AKEMI CONTRERAS ENDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTIANE AKEMI CONTRERAS ENDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7765207  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTIANE ERIKA TANIKAWA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7765207, 
 3,'cristianetanikawa.7765207@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTIANE ERIKA TANIKAWA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTIANE ERIKA TANIKAWA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7371764  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTIANE FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7371764, 
 3,'cristianesilva.7371764@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTIANE FERREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTIANE FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8106479  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTIANE LOPES TEIXEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8106479, 
 3,'cristianeteixeira.8106479@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTIANE LOPES TEIXEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTIANE LOPES TEIXEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7811756  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTIANE PAIVA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7811756, 
 3,'cristianesilva.7811756@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTIANE PAIVA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTIANE PAIVA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6187102  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTIANE SEVERO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6187102, 
 3,'cristianesantos.6187102@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTIANE SEVERO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTIANE SEVERO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8115257  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTINA MORAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8115257, 
 3,'cristinamorais.8115257@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTINA MORAIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTINA MORAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8049980  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario CRISTOBAL ROBERTO AFONSO GARCIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8049980, 
 3,'cristobalgarcia.8049980@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('CRISTOBAL ROBERTO AFONSO GARCIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario CRISTOBAL ROBERTO AFONSO GARCIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8162913  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA ALVES MENEZES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8162913, 
 3,'danielamenezes.8162913@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA ALVES MENEZES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA ALVES MENEZES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7773315  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA BITENCOURT MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7773315, 
 3,'danielamartins.7773315@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA BITENCOURT MARTINS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA BITENCOURT MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8042853  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA DUELIS DE MELLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8042853, 
 3,'danielamello.8042853@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA DUELIS DE MELLO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA DUELIS DE MELLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8090670  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA ESPÓSITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8090670, 
 3,'danielaesposito.8090670@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA ESPÓSITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA ESPÓSITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8125015  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA GOMES DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8125015, 
 3,'danielaalmeida.8125015@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA GOMES DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA GOMES DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8112908  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA PEREIRA CHICON'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8112908, 
 3,'danielachicon.8112908@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA PEREIRA CHICON'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA PEREIRA CHICON'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9245197  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELA SALU MATEUS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9245197, 
 3,'danielasilva.9245197@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELA SALU MATEUS DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELA SALU MATEUS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8775281  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANIELE MACHADO LISBOA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8775281, 
 3,'danielelisboa.8775281@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANIELE MACHADO LISBOA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANIELE MACHADO LISBOA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8905703  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DANILO COSTA NUNES ANDRADE LEITE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8905703, 
 3,'daniloleite.8905703@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DANILO COSTA NUNES ANDRADE LEITE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DANILO COSTA NUNES ANDRADE LEITE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6079865  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DEBORAH CRISTINA TORRES TALHAFERRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6079865, 
 3,'deborahtalhaferro.6079865@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DEBORAH CRISTINA TORRES TALHAFERRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DEBORAH CRISTINA TORRES TALHAFERRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7557892  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DEISE ALVES CASSIANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7557892, 
 3,'deisecassiano.7557892@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DEISE ALVES CASSIANO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DEISE ALVES CASSIANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7557892  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DEISE ALVES CASSIANO MACHADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7557892, 
 3,'deisemachado.7557892@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DEISE ALVES CASSIANO MACHADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DEISE ALVES CASSIANO MACHADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6583121  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DELMA APARECIDA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6583121, 
 3,'delmasilva.6583121@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DELMA APARECIDA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DELMA APARECIDA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5239095  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DENISE MARI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5239095, 
 3,'denisemari.5239095@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DENISE MARI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DENISE MARI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7249055  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DENISE OLIVEIRA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7249055, 
 3,'deniselima.7249055@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DENISE OLIVEIRA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DENISE OLIVEIRA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7794894  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DENISE RAFAELA SAES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7794894, 
 3,'denisesilva.7794894@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DENISE RAFAELA SAES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DENISE RAFAELA SAES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274223  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DIEGO FERREIRA DE FARIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274223, 
 3,'diegofarias.8274223@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DIEGO FERREIRA DE FARIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DIEGO FERREIRA DE FARIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5886732  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DILMA MARIA DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5886732, 
 3,'dilmanascimento.5886732@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DILMA MARIA DO NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DILMA MARIA DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179119  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DOLORES MILARE PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179119, 
 3,'dolorespereira.9179119@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DOLORES MILARE PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DOLORES MILARE PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7831609  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DOUGLAS DE CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7831609, 
 3,'douglascastro.7831609@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DOUGLAS DE CASTRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DOUGLAS DE CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8090050  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DOUGLAS MARIS ANTUNES COELHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8090050, 
 3,'douglascoelho.8090050@edu.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DOUGLAS MARIS ANTUNES COELHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DOUGLAS MARIS ANTUNES COELHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8578362  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario DOUGLAS NATANAEL NASCIMENTO DA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8578362, 
 3,'douglascosta.8578362@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('DOUGLAS NATANAEL NASCIMENTO DA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario DOUGLAS NATANAEL NASCIMENTO DA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7289863  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDEMILSON BARBOSA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7289863, 
 3,'edemilsonsantos.7289863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDEMILSON BARBOSA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDEMILSON BARBOSA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6448470  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDEVALDO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6448470, 
 3,'edevaldosantos.6448470@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDEVALDO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDEVALDO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6811515  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDILEUZA DA CONCEICAO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6811515, 
 3,'edileuzasilva.6811515@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDILEUZA DA CONCEICAO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDILEUZA DA CONCEICAO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7746822  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDINILSON PATROCINIO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7746822, 
 3,'edinilsonoliveira.7746822@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDINILSON PATROCINIO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDINILSON PATROCINIO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6866263  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDMILDE DE JESUS SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6866263, 
 3,'edmildesoares.6866263@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDMILDE DE JESUS SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDMILDE DE JESUS SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7525729  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDMILSON JOSE DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7525729, 
 3,'edmilsoncruz.7525729@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDMILSON JOSE DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDMILSON JOSE DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8049297  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDMILSON SILVA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8049297, 
 3,'edmilsonsantos.8049297@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDMILSON SILVA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDMILSON SILVA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8387613  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDNEIA MACHADO DE ALCANTARA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8387613, 
 3,'edneiaalcantara.8387613@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDNEIA MACHADO DE ALCANTARA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDNEIA MACHADO DE ALCANTARA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8094411  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDUARDO MURAKAMI DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8094411, 
 3,'eduardosilva.8094411@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDUARDO MURAKAMI DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDUARDO MURAKAMI DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8083436  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EDUARDO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8083436, 
 3,'eduardopereira.8083436@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EDUARDO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EDUARDO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179071  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELAINE CRISTINA LIMA FOLSTER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179071, 
 3,'elainefolster.9179071@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELAINE CRISTINA LIMA FOLSTER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELAINE CRISTINA LIMA FOLSTER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5081378  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELAINE FELISBERTO MENDES ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5081378, 
 3,'elainealves.5081378@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELAINE FELISBERTO MENDES ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELAINE FELISBERTO MENDES ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7544090  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELAINE MARCONDES SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7544090, 
 3,'elainesoares.7544090@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELAINE MARCONDES SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELAINE MARCONDES SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6845070  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELENICE DE CARVALHO RODA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6845070, 
 3,'eleniceroda.6845070@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELENICE DE CARVALHO RODA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELENICE DE CARVALHO RODA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7930232  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELEONORA CORDEIRO MATTOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7930232, 
 3,'eleonoramattoso.7930232@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELEONORA CORDEIRO MATTOSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELEONORA CORDEIRO MATTOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7786808  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELEUSA GERMANO MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7786808, 
 3,'eleusamartins.7786808@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELEUSA GERMANO MARTINS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELEUSA GERMANO MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9154647  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIANA CRISTINA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9154647, 
 3,'elianasilva.9154647@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIANA CRISTINA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIANA CRISTINA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8115249  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIANA MENEGON ZACCARELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8115249, 
 3,'elianazaccarelli.8115249@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIANA MENEGON ZACCARELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIANA MENEGON ZACCARELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5676568  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIANE CRISTINA LIBERATORI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5676568, 
 3,'elianeliberatori.5676568@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIANE CRISTINA LIBERATORI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIANE CRISTINA LIBERATORI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7330286  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIAS TERTO ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7330286, 
 3,'eliasalves.7330286@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIAS TERTO ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIAS TERTO ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6568891  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIETE CARMINHOTTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6568891, 
 3,'elietecarminhotto.6568891@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIETE CARMINHOTTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIETE CARMINHOTTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7450214  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELISANDRA FELIX VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7450214, 
 3,'elisandravieira.7450214@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELISANDRA FELIX VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELISANDRA FELIX VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274304  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIZA OLIVEIRA MURAKOSHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274304, 
 3,'elizamurakoshi.8274304@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIZA OLIVEIRA MURAKOSHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIZA OLIVEIRA MURAKOSHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8095728  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIZABETE BEATRIZ PINTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8095728, 
 3,'elizabetepinto.8095728@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIZABETE BEATRIZ PINTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIZABETE BEATRIZ PINTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7790031  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELIZABETH DE PAULA RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7790031, 
 3,'elizabethribeiro.7790031@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELIZABETH DE PAULA RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELIZABETH DE PAULA RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179011  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELLEN VIEIRA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179011, 
 3,'ellenoliveira.9179011@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELLEN VIEIRA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELLEN VIEIRA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7538260  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELLIS MARA BARBOSA ELIAS MARTA E SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7538260, 
 3,'ellissilva.7538260@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELLIS MARA BARBOSA ELIAS MARTA E SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELLIS MARA BARBOSA ELIAS MARTA E SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7407939  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELOISA MARA GIORGINA CORDEIRO BASSO DALLMANN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7407939, 
 3,'eloisadallmann.7407939@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELOISA MARA GIORGINA CORDEIRO BASSO DALLMANN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELOISA MARA GIORGINA CORDEIRO BASSO DALLMANN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5662991  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELTON LUCIO CARDOZO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5662991, 
 3,'eltoncardozo.5662991@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELTON LUCIO CARDOZO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELTON LUCIO CARDOZO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6223702  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ELZA MARIA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6223702, 
 3,'elzalima.6223702@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ELZA MARIA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ELZA MARIA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7370725  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario EMELI APARECIDA DE FATIMA DOS SANTOS MELO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7370725, 
 3,'emelimelo.7370725@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('EMELI APARECIDA DE FATIMA DOS SANTOS MELO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario EMELI APARECIDA DE FATIMA DOS SANTOS MELO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7531966  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ERIC MOREIRA EUFRAUSINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7531966, 
 3,'ericeufrausino.7531966@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ERIC MOREIRA EUFRAUSINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ERIC MOREIRA EUFRAUSINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6043437  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ERIKA FERRAZ GASPARINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6043437, 
 3,'erikagasparini.6043437@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ERIKA FERRAZ GASPARINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ERIKA FERRAZ GASPARINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7482418  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ESTELA FERNANDES ALIENDE RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7482418, 
 3,'estelaribeiro.7482418@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ESTELA FERNANDES ALIENDE RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ESTELA FERNANDES ALIENDE RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9147691  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ETHORE BELLATO GIACOMIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9147691, 
 3,'ethoregiacomin.9147691@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ETHORE BELLATO GIACOMIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ETHORE BELLATO GIACOMIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9187502  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FABIANA CRISTINA TORRES DE PAULO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9187502, 
 3,'fabianapaulo.9187502@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FABIANA CRISTINA TORRES DE PAULO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FABIANA CRISTINA TORRES DE PAULO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9154701  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FABIO LORUSSO RIBEIRO COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9154701, 
 3,'fabiocosta.9154701@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FABIO LORUSSO RIBEIRO COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FABIO LORUSSO RIBEIRO COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7926961  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FABIOLA CAUS SIMOES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7926961, 
 3,'fabiolasimoes.7926961@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FABIOLA CAUS SIMOES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FABIOLA CAUS SIMOES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7491778  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FABRICIO EDUARDO DOS SANTOS FIGUEIREDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7491778, 
 3,'fabriciofigueiredo.7491778@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FABRICIO EDUARDO DOS SANTOS FIGUEIREDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FABRICIO EDUARDO DOS SANTOS FIGUEIREDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5559855  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FATIMA BONIFACIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5559855, 
 3,'fatimabonifacio.5559855@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FATIMA BONIFACIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FATIMA BONIFACIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6753744  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FATIMA CRISTINA ABRAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6753744, 
 3,'fatimaabrao.6753744@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FATIMA CRISTINA ABRAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FATIMA CRISTINA ABRAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5565570  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FATIMA DE LOURDES AMPUERO DAVANCO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5565570, 
 3,'fatimadavanco.5565570@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FATIMA DE LOURDES AMPUERO DAVANCO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FATIMA DE LOURDES AMPUERO DAVANCO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7819374  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FATIMA MARIA DOS SANTOS DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7819374, 
 3,'fatimaoliveira.7819374@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FATIMA MARIA DOS SANTOS DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FATIMA MARIA DOS SANTOS DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8573051  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FELIPE ZUCULIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8573051, 
 3,'felipefonseca.8573051@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FELIPE ZUCULIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FELIPE ZUCULIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6741274  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA ALVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6741274, 
 3,'fernandasilva.6741274@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA ALVES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA ALVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8117705  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA APARECIDA MARQUES FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8117705, 
 3,'fernandafernandes.8117705@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA APARECIDA MARQUES FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA APARECIDA MARQUES FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8570345  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA BARBOSA DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8570345, 
 3,'fernandanascimento.8570345@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA BARBOSA DO NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA BARBOSA DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274011  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA BORGES DO NASCIMENTO CHAGAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274011, 
 3,'fernandachagas.8274011@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA BORGES DO NASCIMENTO CHAGAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA BORGES DO NASCIMENTO CHAGAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8020205  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA DEMITRIO MARTIN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8020205, 
 3,'fernandamartin.8020205@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA DEMITRIO MARTIN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA DEMITRIO MARTIN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7704593  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA GOMES PACELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7704593, 
 3,'fernandapacelli.7704593@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA GOMES PACELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA GOMES PACELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8107807  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA LOURENCO DE MENEZES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8107807, 
 3,'fernandamenezes.8107807@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA LOURENCO DE MENEZES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA LOURENCO DE MENEZES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9157514  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA OLIVEIRA DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9157514, 
 3,'fernandacruz.9157514@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA OLIVEIRA DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA OLIVEIRA DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8901945  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA SANTANA LUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8901945, 
 3,'fernandaluz.8901945@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA SANTANA LUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA SANTANA LUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8160597  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDA SOBRAL CAPASSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8160597, 
 3,'fernandacapasso.8160597@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDA SOBRAL CAPASSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDA SOBRAL CAPASSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7947054  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDO DE ALMEIDA PRADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7947054, 
 3,'fernandoprado.7947054@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDO DE ALMEIDA PRADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDO DE ALMEIDA PRADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8872627  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDO MARTINS GOUVEIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8872627, 
 3,'fernandogouveia.8872627@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDO MARTINS GOUVEIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDO MARTINS GOUVEIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8839239  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FERNANDO PADULA NOVAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8839239, 
 3,'fernandonovaes.8839239@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FERNANDO PADULA NOVAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FERNANDO PADULA NOVAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7753551  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FLAVIA ALBUQUERQUE E SILVA AMADOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7753551, 
 3,'flaviaamador.7753551@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FLAVIA ALBUQUERQUE E SILVA AMADOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FLAVIA ALBUQUERQUE E SILVA AMADOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179054  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FLAVIA COSTA CORREA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179054, 
 3,'flaviacorrea.9179054@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FLAVIA COSTA CORREA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FLAVIA COSTA CORREA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8002819  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FLAVIA DOS SANTOS ARCAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8002819, 
 3,'flaviaarcas.8002819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FLAVIA DOS SANTOS ARCAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FLAVIA DOS SANTOS ARCAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8381461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FRANCIANNE ALINE OLIVEIRA BARROS DE SOUZA VASIUNAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8381461, 
 3,'franciannevasiunas.8381461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FRANCIANNE ALINE OLIVEIRA BARROS DE SOUZA VASIUNAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FRANCIANNE ALINE OLIVEIRA BARROS DE SOUZA VASIUNAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7738579  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FRANCIELI ARAUJO GUERRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7738579, 
 3,'francieliguerra.7738579@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FRANCIELI ARAUJO GUERRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FRANCIELI ARAUJO GUERRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7509014  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FRANCISCO BEZERRA DA SILVA JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7509014, 
 3,'franciscojunior.7509014@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FRANCISCO BEZERRA DA SILVA JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FRANCISCO BEZERRA DA SILVA JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6663079  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FRANCISCO EUGENIO DE MICO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6663079, 
 3,'franciscomico.6663079@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FRANCISCO EUGENIO DE MICO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FRANCISCO EUGENIO DE MICO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9158570  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario FRANK ITINOCE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9158570, 
 3,'frankitinoce.9158570@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('FRANK ITINOCE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario FRANK ITINOCE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7772866  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GABRIELA GUIMENTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7772866, 
 3,'gabrielaguimenti.7772866@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GABRIELA GUIMENTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GABRIELA GUIMENTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8894205  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GABRIELLA FERREIRA LOPES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8894205, 
 3,'gabriellaoliveira.8894205@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GABRIELLA FERREIRA LOPES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GABRIELLA FERREIRA LOPES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9178988  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GEISA MARINA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9178988, 
 3,'geisasilva.9178988@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GEISA MARINA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GEISA MARINA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7884940  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GENI DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7884940, 
 3,'genisantos.7884940@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GENI DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GENI DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6083714  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GERALDO LUIZ FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6083714, 
 3,'geraldosilva.6083714@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GERALDO LUIZ FERREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GERALDO LUIZ FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8015724  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GERSON ALVES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8015724, 
 3,'gersonoliveira.8015724@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GERSON ALVES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GERSON ALVES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8195269  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GILCIA MARIA SALOMON BEZERRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8195269, 
 3,'gilciabezerra.8195269@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GILCIA MARIA SALOMON BEZERRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GILCIA MARIA SALOMON BEZERRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8427496  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GILDO JOSE DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8427496, 
 3,'gildosantos.8427496@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GILDO JOSE DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GILDO JOSE DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5096537  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GILVAN ALVES DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5096537, 
 3,'gilvansouza.5096537@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GILVAN ALVES DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GILVAN ALVES DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5384231  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GINA LAIS ABENZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5384231, 
 3,'ginaabenza.5384231@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GINA LAIS ABENZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GINA LAIS ABENZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7737165  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GIOVANNA  GUELLER OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7737165, 
 3,'giovannaoliveira.7737165@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GIOVANNA  GUELLER OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GIOVANNA  GUELLER OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7748922  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GIOVANNA LUISI SERRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7748922, 
 3,'giovannaserra.7748922@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GIOVANNA LUISI SERRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GIOVANNA LUISI SERRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7124872  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GISELE DA SILVA GUIMARAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7124872, 
 3,'giseleguimaraes.7124872@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GISELE DA SILVA GUIMARAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GISELE DA SILVA GUIMARAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8086044  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GISELE DE CASTRO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8086044, 
 3,'giselepereira.8086044@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GISELE DE CASTRO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GISELE DE CASTRO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9187464  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GISLAINE DA SILVA BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9187464, 
 3,'gislainebrito.9187464@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GISLAINE DA SILVA BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GISLAINE DA SILVA BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8373639  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GIZELE CERQUEIRA DE AQUINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8373639, 
 3,'gizeleaquino.8373639@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GIZELE CERQUEIRA DE AQUINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GIZELE CERQUEIRA DE AQUINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7252587  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GLADIS CASSAPIAN BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7252587, 
 3,'gladisbarbosa.7252587l@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GLADIS CASSAPIAN BARBOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GLADIS CASSAPIAN BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8089795  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GLAUCIA CRISTINE SILVA BURCKLER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8089795, 
 3,'glauciaburckler.8089795@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GLAUCIA CRISTINE SILVA BURCKLER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GLAUCIA CRISTINE SILVA BURCKLER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7751567  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GLAUCIA RODRIGUES ALVES DE ALENCAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7751567, 
 3,'glauciaalencar.7751567@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GLAUCIA RODRIGUES ALVES DE ALENCAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GLAUCIA RODRIGUES ALVES DE ALENCAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7773234  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GLEIDIS MALERMAN SAAT'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7773234, 
 3,'gleidissaat.7773234@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GLEIDIS MALERMAN SAAT'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GLEIDIS MALERMAN SAAT'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6549390  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GLORIA BINAGHI GALLAGHER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6549390, 
 3,'gloriagallagher.6549390@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GLORIA BINAGHI GALLAGHER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GLORIA BINAGHI GALLAGHER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7376022  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GRAZIELA BURRINI SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7376022, 
 3,'grazielasilva.7376022@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GRAZIELA BURRINI SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GRAZIELA BURRINI SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8890331  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GUILHERME AVELINO VENTURIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8890331, 
 3,'guilhermeventurim.8890331@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GUILHERME AVELINO VENTURIM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GUILHERME AVELINO VENTURIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6666507  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GUILHERME CASSIMIRO PAGNI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6666507, 
 3,'guilhermepagni.6666507@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GUILHERME CASSIMIRO PAGNI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GUILHERME CASSIMIRO PAGNI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7800461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GUILHERME CUNHA DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7800461, 
 3,'guilhermecarvalho.7800461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GUILHERME CUNHA DE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GUILHERME CUNHA DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9123342  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario GUILHERME MOYSES FRANCO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9123342, 
 3,'guilhermefranco.9123342@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('GUILHERME MOYSES FRANCO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario GUILHERME MOYSES FRANCO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8212210  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HEDNA LADY RIBEIRO FIGUEREDO BENJAMIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8212210, 
 3,'hednabenjamim.8212210@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HEDNA LADY RIBEIRO FIGUEREDO BENJAMIM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HEDNA LADY RIBEIRO FIGUEREDO BENJAMIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7754817  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HELENA MARIA NOVARETTI FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7754817, 
 3,'helenaferreira.7754817@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HELENA MARIA NOVARETTI FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HELENA MARIA NOVARETTI FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7348622  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HELGA KOORO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7348622, 
 3,'helgakooro.7348622@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HELGA KOORO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HELGA KOORO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6858015  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HELOISA CICONELLO RODRIGUES GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6858015, 
 3,'heloisagomes.6858015@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HELOISA CICONELLO RODRIGUES GOMES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HELOISA CICONELLO RODRIGUES GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8286311  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HELOISA TEVES SCATTINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8286311, 
 3,'heloisascattini.8286311@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HELOISA TEVES SCATTINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HELOISA TEVES SCATTINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7884834  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HERMANY DE SOUZA ROBERTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7884834, 
 3,'hermanyroberto.7884834@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HERMANY DE SOUZA ROBERTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HERMANY DE SOUZA ROBERTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9251162  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HEVERTON MAESTRE GIOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9251162, 
 3,'hevertongios.9251162@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HEVERTON MAESTRE GIOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HEVERTON MAESTRE GIOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7551231  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HILDA MITIKO IUAMOTO PACHECO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7551231, 
 3,'hildapacheco.7551231@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HILDA MITIKO IUAMOTO PACHECO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HILDA MITIKO IUAMOTO PACHECO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6123147  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario HUMBERTO LUIS DE  JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6123147, 
 3,'humbertojesus.6123147@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('HUMBERTO LUIS DE  JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario HUMBERTO LUIS DE  JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161449  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario IAN TAIRA SIMOES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161449, 
 3,'iansimoes.9161449@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('IAN TAIRA SIMOES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario IAN TAIRA SIMOES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9262075  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario INGRED DE SOUZA ROCHA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9262075, 
 3,'ingredsilva.9262075@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('INGRED DE SOUZA ROCHA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario INGRED DE SOUZA ROCHA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6739482  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario IRAN DA CUNHA SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6739482, 
 3,'iransousa.6739482@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('IRAN DA CUNHA SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario IRAN DA CUNHA SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8015953  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ISAAC DA SILVA SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8015953, 
 3,'isaacsantana.8015953@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ISAAC DA SILVA SANTANA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ISAAC DA SILVA SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 1314921  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ISABEL CRISTINA GUANAES BITTENCOURT'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 1314921, 
 3,'isabelbittencourt.1314921@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ISABEL CRISTINA GUANAES BITTENCOURT'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ISABEL CRISTINA GUANAES BITTENCOURT'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8982112  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ISABELA DE ALMEIDA GALVAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8982112, 
 3,'isabelagalvao.8982112@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ISABELA DE ALMEIDA GALVAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ISABELA DE ALMEIDA GALVAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8244987  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ISABELLA DE OLIVEIRA NERI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8244987, 
 3,'isabellaneri.8244987@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ISABELLA DE OLIVEIRA NERI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ISABELLA DE OLIVEIRA NERI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161457  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ISABELLA SOARES DE SOUZA BARROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161457, 
 3,'isabellabarros.9161457@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ISABELLA SOARES DE SOUZA BARROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ISABELLA SOARES DE SOUZA BARROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8106495  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ISABELLE PINHEIRO DIAS DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8106495, 
 3,'isabellecruz.8106495@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ISABELLE PINHEIRO DIAS DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ISABELLE PINHEIRO DIAS DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5405629  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario IVANA CRISTINA MORGANI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5405629, 
 3,'ivanamorgani.5405629@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('IVANA CRISTINA MORGANI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario IVANA CRISTINA MORGANI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6764720  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario IVANI FERREIRA MOURA VINHAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6764720, 
 3,'ivanivinhais.6764720@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('IVANI FERREIRA MOURA VINHAIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario IVANI FERREIRA MOURA VINHAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6666337  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JACQUELINE APARECIDA MAIA TRIPOLI DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6666337, 
 3,'jacquelinesantos.6666337@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JACQUELINE APARECIDA MAIA TRIPOLI DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JACQUELINE APARECIDA MAIA TRIPOLI DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6581412  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JAIR FONSECA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6581412, 
 3,'jairsantos.6581412@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JAIR FONSECA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JAIR FONSECA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9111701  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JANAINA FERREIRA BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9111701, 
 3,'janainabarbosa.9111701@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JANAINA FERREIRA BARBOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JANAINA FERREIRA BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6773346  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JANE MUNHOZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6773346, 
 3,'janemunhoz.6773346@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JANE MUNHOZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JANE MUNHOZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7733241  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JAQUELINE DOS SANTOS MORAIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7733241, 
 3,'jaquelinemorais.7733241@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JAQUELINE DOS SANTOS MORAIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JAQUELINE DOS SANTOS MORAIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8113009  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JESSICA GIARLETTA LOMAS DE OLIVEIRA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8113009, 
 3,'jessicarocha.8113009@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JESSICA GIARLETTA LOMAS DE OLIVEIRA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JESSICA GIARLETTA LOMAS DE OLIVEIRA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8785571  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JESSICA PRISCILA GOMES DRUMOND'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8785571, 
 3,'jessicadrumond.8785571@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JESSICA PRISCILA GOMES DRUMOND'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JESSICA PRISCILA GOMES DRUMOND'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8589313  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JIOVAN VITALINO RAMOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8589313, 
 3,'jiovanramos.8589313@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JIOVAN VITALINO RAMOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JIOVAN VITALINO RAMOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5996678  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOCELI PEREIRA LOPES ZEMINOI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5996678, 
 3,'jocelizeminoi.5996678@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOCELI PEREIRA LOPES ZEMINOI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOCELI PEREIRA LOPES ZEMINOI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6483399  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JONAS ALVES DE SENA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6483399, 
 3,'jonassena.6483399@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JONAS ALVES DE SENA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JONAS ALVES DE SENA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5669430  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JORGE HENRIQUE APOLINARIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5669430, 
 3,'jorgeapolinario.5669430@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JORGE HENRIQUE APOLINARIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JORGE HENRIQUE APOLINARIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6960545  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSE ALVES FERREIRA NETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6960545, 
 3,'joseneto.6960545@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSE ALVES FERREIRA NETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSE ALVES FERREIRA NETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7810946  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSE BELARMINO DE SALES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7810946, 
 3,'josesales.7810946@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSE BELARMINO DE SALES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSE BELARMINO DE SALES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8021791  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSE CARLOS SUCI JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8021791, 
 3,'josejunior.8021791@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSE CARLOS SUCI JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSE CARLOS SUCI JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6757251  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSE MEDEIROS SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6757251, 
 3,'josesoares.6757251@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSE MEDEIROS SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSE MEDEIROS SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7495277  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSEIANE ALVAREZ DOS SANTOS GOTARDI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7495277, 
 3,'joseianegotardi.7495277@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSEIANE ALVAREZ DOS SANTOS GOTARDI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSEIANE ALVAREZ DOS SANTOS GOTARDI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6495826  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSIAS RODRIGUES SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6495826, 
 3,'josiassoares.6495826@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSIAS RODRIGUES SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSIAS RODRIGUES SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8192020  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSÉ ARI DE OLIVEIRA  JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8192020, 
 3,'josejunior.8192020@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSÉ ARI DE OLIVEIRA  JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSÉ ARI DE OLIVEIRA  JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7332122  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSÉ LOPES MOREIRA FILHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7332122, 
 3,'josefilho.7332122@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSÉ LOPES MOREIRA FILHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSÉ LOPES MOREIRA FILHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7285388  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOSÉ ROBERTO DE CAMPOS LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7285388, 
 3,'joselima.7285388@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOSÉ ROBERTO DE CAMPOS LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOSÉ ROBERTO DE CAMPOS LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6989454  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOVINO SOARES PEREIRA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6989454, 
 3,'jovinosantos.6989454@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOVINO SOARES PEREIRA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOVINO SOARES PEREIRA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7868685  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JOÃO ROSALVO DA SILVA JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7868685, 
 3,'joaojunior.7868685@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JOÃO ROSALVO DA SILVA JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JOÃO ROSALVO DA SILVA JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7220189  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JUCARA INGLEZ RIBEIRO GONTARCZIK'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7220189, 
 3,'jucaragontarczik.7220189@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JUCARA INGLEZ RIBEIRO GONTARCZIK'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JUCARA INGLEZ RIBEIRO GONTARCZIK'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8461040  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JUCICLEIDE DA CONCEICAO GOMES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8461040, 
 3,'jucicleidegomes.8461040@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JUCICLEIDE DA CONCEICAO GOMES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JUCICLEIDE DA CONCEICAO GOMES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8124850  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JUCILEIA ALVES PEREIRA VICENTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8124850, 
 3,'jucileiavicente.8124850@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JUCILEIA ALVES PEREIRA VICENTE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JUCILEIA ALVES PEREIRA VICENTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8206252  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JUCILENE ALVES GOMES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8206252, 
 3,'jucilenesilva.8206252@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JUCILENE ALVES GOMES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JUCILENE ALVES GOMES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8272867  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIA MERCEDES PEREZ FLORIDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8272867, 
 3,'juliaflorido.8272867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIA MERCEDES PEREZ FLORIDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIA MERCEDES PEREZ FLORIDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8117063  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA FIACADORI COURI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8117063, 
 3,'julianacouri.8117063@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA FIACADORI COURI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA FIACADORI COURI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8130205  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA LEMOS DEMAY'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8130205, 
 3,'julianademay.8130205@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA LEMOS DEMAY'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA LEMOS DEMAY'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8890315  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA MARIA MAZZETI SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8890315, 
 3,'julianasilva.8890315@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA MARIA MAZZETI SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA MARIA MAZZETI SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8533474  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA MIEKO ODANI SIGAHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8533474, 
 3,'julianasigahi.8533474@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA MIEKO ODANI SIGAHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA MIEKO ODANI SIGAHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8433143  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA MINUCELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8433143, 
 3,'julianaminucelli.8433143@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA MINUCELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA MINUCELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8467145  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA MOREIRA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8467145, 
 3,'julianasilva.8467145@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA MOREIRA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA MOREIRA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8449805  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA NAJADOS HOFFMANN FABRI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8449805, 
 3,'julianafabri.8449805@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA NAJADOS HOFFMANN FABRI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA NAJADOS HOFFMANN FABRI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8245151  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA NICOA NEGREIROS LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8245151, 
 3,'julianalopes.8245151@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA NICOA NEGREIROS LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA NICOA NEGREIROS LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8279934  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA OLIVEIRA FIGUEIREDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8279934, 
 3,'julianafigueiredo.8279934@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA OLIVEIRA FIGUEIREDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA OLIVEIRA FIGUEIREDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8282854  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA TOLEDO PASTORELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8282854, 
 3,'julianapastorelli.8282854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA TOLEDO PASTORELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA TOLEDO PASTORELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9123351  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIANA TOSTES SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9123351, 
 3,'julianasoares.9123351@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIANA TOSTES SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIANA TOSTES SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8907218  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JULIO RICARDO COSTA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8907218, 
 3,'juliolima.8907218@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JULIO RICARDO COSTA DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JULIO RICARDO COSTA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6318517  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JURACI SANTIAGO DA CONCEICAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6318517, 
 3,'juraciconceicao.6318517@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JURACI SANTIAGO DA CONCEICAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JURACI SANTIAGO DA CONCEICAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7904908  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario JUSSARA BRITO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7904908, 
 3,'jussarasouza.7904908@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('JUSSARA BRITO DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario JUSSARA BRITO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8193916  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KALIGIANE DORGELMA FELIX DA SILVA LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8193916, 
 3,'kaligianelima.8193916@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KALIGIANE DORGELMA FELIX DA SILVA LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KALIGIANE DORGELMA FELIX DA SILVA LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9219188  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KAMILA GRANZOTTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9219188, 
 3,'kamilagranzotto.9219188@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KAMILA GRANZOTTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KAMILA GRANZOTTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274134  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KAMILA MOREIRA NARESSI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274134, 
 3,'kamilanaressi.8274134@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KAMILA MOREIRA NARESSI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KAMILA MOREIRA NARESSI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8228779  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KAMILA RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8228779, 
 3,'kamilarodrigues.8228779@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KAMILA RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KAMILA RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161503  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KARINA GAMA DOS SANTOS DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161503, 
 3,'karinaandrade.9161503@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KARINA GAMA DOS SANTOS DE ANDRADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KARINA GAMA DOS SANTOS DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8055564  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KARLA APARECIDA MAESTRINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8055564, 
 3,'karlamaestrini.8055564@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KARLA APARECIDA MAESTRINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KARLA APARECIDA MAESTRINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7951221  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KARLA DE OLIVEIRA QUEIROZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7951221, 
 3,'karlaqueiroz.7951221@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KARLA DE OLIVEIRA QUEIROZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KARLA DE OLIVEIRA QUEIROZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274291  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KARLA EVELYN COOK'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274291, 
 3,'karlacook.8274291@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KARLA EVELYN COOK'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KARLA EVELYN COOK'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7208057  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KAROLINE DA SILVA CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7208057, 
 3,'karolinecampos.7208057@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KAROLINE DA SILVA CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KAROLINE DA SILVA CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8090742  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KATIA APARECIDA DE CASTRO SOUZA '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8090742, 
 3,'katiasouza.8090742@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KATIA APARECIDA DE CASTRO SOUZA '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KATIA APARECIDA DE CASTRO SOUZA '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7765291  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KATIA IARED SEBASTIAO ROMANELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7765291, 
 3,'katiaromanelli.7765291@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KATIA IARED SEBASTIAO ROMANELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KATIA IARED SEBASTIAO ROMANELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6882854  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KATIA REGINA CAVALCANTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6882854, 
 3,'katiacavalcanti.6882854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KATIA REGINA CAVALCANTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KATIA REGINA CAVALCANTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6751369  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KATIA SANCHES BIZARRO DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6751369, 
 3,'katialima.6751369@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KATIA SANCHES BIZARRO DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KATIA SANCHES BIZARRO DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6922741  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KATIANE COSTA PAIVA SIMONE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6922741, 
 3,'katianesimone.6922741@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KATIANE COSTA PAIVA SIMONE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KATIANE COSTA PAIVA SIMONE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8225575  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KAUAN ESPOSITO DA CONCEICAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8225575, 
 3,'kauanconceicao.8225575@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KAUAN ESPOSITO DA CONCEICAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KAUAN ESPOSITO DA CONCEICAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7341482  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELI CRISTINA CORREIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7341482, 
 3,'kelicorreia.7341482@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELI CRISTINA CORREIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELI CRISTINA CORREIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7206917  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELL SILENE SILVA NEVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7206917, 
 3,'kellneves.7206917@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELL SILENE SILVA NEVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELL SILENE SILVA NEVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8023107  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELLY CRISTINA BATISTA ORTEGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8023107, 
 3,'kellyortega.8023107@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELLY CRISTINA BATISTA ORTEGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELLY CRISTINA BATISTA ORTEGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7496362  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELLY CRISTINA FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7496362, 
 3,'kellysilva.7496362@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELLY CRISTINA FERREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELLY CRISTINA FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7832699  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELLY CRISTINA LEME MEIRELES DE PAULA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7832699, 
 3,'kellypaula.7832699@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELLY CRISTINA LEME MEIRELES DE PAULA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELLY CRISTINA LEME MEIRELES DE PAULA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7722061  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELLY CRISTINA PANTALEAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7722061, 
 3,'kellypantaleao.7722061@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELLY CRISTINA PANTALEAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELLY CRISTINA PANTALEAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8769605  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario KELLY CRISTINA SILVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8769605, 
 3,'kellysilveira.8769605@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('KELLY CRISTINA SILVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario KELLY CRISTINA SILVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8053332  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LAIS DE SOUSA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8053332, 
 3,'laisrocha.8053332@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LAIS DE SOUSA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LAIS DE SOUSA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8002436  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LAIS LOPES ROBLES ALVES FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8002436, 
 3,'laisferreira.8002436@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LAIS LOPES ROBLES ALVES FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LAIS LOPES ROBLES ALVES FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274231  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LARISSA SANTOS DAS NEVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274231, 
 3,'larissaneves.8274231@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LARISSA SANTOS DAS NEVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LARISSA SANTOS DAS NEVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8872619  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LAUDINA DE ANDRADE SALOMAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8872619, 
 3,'laudinasalomao.8872619@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LAUDINA DE ANDRADE SALOMAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LAUDINA DE ANDRADE SALOMAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6973256  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LAZARO NAPOLEAO INACIO FILHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6973256, 
 3,'lazarofilho.6973256@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LAZARO NAPOLEAO INACIO FILHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LAZARO NAPOLEAO INACIO FILHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8894221  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEANDRO DANIEL SANTOS CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8894221, 
 3,'leandrocarvalho.8894221@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEANDRO DANIEL SANTOS CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEANDRO DANIEL SANTOS CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8832773  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEANDRO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8832773, 
 3,'leandrosantos.8832773@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEANDRO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEANDRO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7929561  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEANDRO DOS SANTOS MESSIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7929561, 
 3,'leandromessias.7929561@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEANDRO DOS SANTOS MESSIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEANDRO DOS SANTOS MESSIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7323875  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEANDRO GOMES MOLINA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7323875, 
 3,'leandromolina.7323875@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEANDRO GOMES MOLINA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEANDRO GOMES MOLINA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8233926  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEANDRO YUDI SACA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8233926, 
 3,'leandrosaca.8233926@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEANDRO YUDI SACA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEANDRO YUDI SACA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6816720  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEILA OLIVEIRA ERNESTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6816720, 
 3,'leilaernesto.6816720@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEILA OLIVEIRA ERNESTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEILA OLIVEIRA ERNESTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7945272  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LEILANE MARIA DA COSTA CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7945272, 
 3,'leilanecarvalho.7945272@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LEILANE MARIA DA COSTA CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LEILANE MARIA DA COSTA CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8110484  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LETICIA DE ALMEIDA ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8110484, 
 3,'leticiaandrade.8110484@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LETICIA DE ALMEIDA ANDRADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LETICIA DE ALMEIDA ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179062  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LETICIA TIEMI SAITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179062, 
 3,'leticiasaito.9179062@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LETICIA TIEMI SAITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LETICIA TIEMI SAITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9149872  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LETICIA ZAMPRONIO SALUM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9149872, 
 3,'leticiasalum.9149872@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LETICIA ZAMPRONIO SALUM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LETICIA ZAMPRONIO SALUM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 3155901  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LICINIA MARIA UDVARY'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 3155901, 
 3,'liciniaudvary.3155901@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LICINIA MARIA UDVARY'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LICINIA MARIA UDVARY'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 1366491  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIDIA MARIA BORGES DO VAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 1366491, 
 3,'lidiaval.1366491@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIDIA MARIA BORGES DO VAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIDIA MARIA BORGES DO VAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7780648  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIEGE NIGRO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7780648, 
 3,'liegesilva.7780648@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIEGE NIGRO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIEGE NIGRO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9245227  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIEGEN CLEMMYL RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9245227, 
 3,'liegenrodrigues.9245227@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIEGEN CLEMMYL RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIEGEN CLEMMYL RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6806988  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIGIA ALVES DE LIMA GUERRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6806988, 
 3,'ligiaguerra.6806988@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIGIA ALVES DE LIMA GUERRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIGIA ALVES DE LIMA GUERRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8356491  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIGIA CARDOSO DOS REIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8356491, 
 3,'ligiareis.8356491@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIGIA CARDOSO DOS REIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIGIA CARDOSO DOS REIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7917031  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LILIAN GRANATO DE SALLES FERRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7917031, 
 3,'lilianferro.7917031@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LILIAN GRANATO DE SALLES FERRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LILIAN GRANATO DE SALLES FERRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7366388  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LILIAN MACIEL DA SILVA PARISI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7366388, 
 3,'lilianparisi.7366388@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LILIAN MACIEL DA SILVA PARISI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LILIAN MACIEL DA SILVA PARISI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7999950  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LILIAN MEIBACH BRANDOLES DE MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7999950, 
 3,'lilianmatos.7999950@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LILIAN MEIBACH BRANDOLES DE MATOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LILIAN MEIBACH BRANDOLES DE MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179097  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LILIANE SUSANA NOGUEIRA QUINOMES TANIGUCHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179097, 
 3,'lilianetaniguchi.9179097@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LILIANE SUSANA NOGUEIRA QUINOMES TANIGUCHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LILIANE SUSANA NOGUEIRA QUINOMES TANIGUCHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161520  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LINDSEY DE FARIA CID REZENDE DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161520, 
 3,'lindseysilva.9161520@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LINDSEY DE FARIA CID REZENDE DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LINDSEY DE FARIA CID REZENDE DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8178721  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIVIA DA CRUZ ESPERANCA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8178721, 
 3,'liviaesperanca.8178721@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIVIA DA CRUZ ESPERANCA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIVIA DA CRUZ ESPERANCA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7298587  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LIVIA LEDIER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7298587, 
 3,'liviavieira.7298587@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LIVIA LEDIER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LIVIA LEDIER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8982091  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LOUISE VON FRUHAUF HUBLARD'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8982091, 
 3,'louisehublard.8982091@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LOUISE VON FRUHAUF HUBLARD'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LOUISE VON FRUHAUF HUBLARD'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8113653  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUANA BARBOZA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8113653, 
 3,'luanasilva.8113653@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUANA BARBOZA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUANA BARBOZA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9128921  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUANA IKEMOTO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9128921, 
 3,'luanasilva.9128921@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUANA IKEMOTO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUANA IKEMOTO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7405839  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUANNA CAETANO MACIEL DE SOUSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7405839, 
 3,'luannasousa.7405839@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUANNA CAETANO MACIEL DE SOUSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUANNA CAETANO MACIEL DE SOUSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8358940  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCAS AMBROZIO LOPES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8358940, 
 3,'lucassilva.8358940@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCAS AMBROZIO LOPES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCAS AMBROZIO LOPES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7276974  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA ARANTES CRESCENTE DO NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7276974, 
 3,'lucianaarantes.7276974@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA ARANTES CRESCENTE DO NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA ARANTES CRESCENTE DO NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8461511  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA CARDOSO DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8461511, 
 3,'lucianasouza.8461511@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA CARDOSO DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA CARDOSO DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7958625  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA CASTELANI CASIMIRO OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7958625, 
 3,'lucianaoliveira.7958625@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA CASTELANI CASIMIRO OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA CASTELANI CASIMIRO OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7988966  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7988966, 
 3,'lucianaferreira.7988966@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7716559  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA HELENA FANDINHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7716559, 
 3,'lucianafandinho.7716559@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA HELENA FANDINHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA HELENA FANDINHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8197890  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA MARIA DE BARROS NOVELLO SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8197890, 
 3,'lucianasantos.8197890@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA MARIA DE BARROS NOVELLO SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA MARIA DE BARROS NOVELLO SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8011052  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA RODRIGUES AMATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8011052, 
 3,'lucianaamato.8011052@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA RODRIGUES AMATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA RODRIGUES AMATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8121303  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANA XAVIER FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8121303, 
 3,'lucianaferreira.8121303@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANA XAVIER FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANA XAVIER FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6390331  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANE DE LOURDES CAPUTO TONHATO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6390331, 
 3,'lucianetonhato.6390331@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANE DE LOURDES CAPUTO TONHATO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANE DE LOURDES CAPUTO TONHATO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7515243  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIANO GUIDORZZI GIROTTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7515243, 
 3,'lucianogirotto.7515243@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIANO GUIDORZZI GIROTTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIANO GUIDORZZI GIROTTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8036080  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCIENE APARECIDA GRISOLIO CIOFFI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8036080, 
 3,'lucienecioffi.8036080@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCIENE APARECIDA GRISOLIO CIOFFI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCIENE APARECIDA GRISOLIO CIOFFI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6843531  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUCINEIDE MARIA ACAUA ARABI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6843531, 
 3,'lucineidearabi.6843531@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUCINEIDE MARIA ACAUA ARABI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUCINEIDE MARIA ACAUA ARABI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8104441  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUDMILLA MOREIRA ELER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8104441, 
 3,'ludmillaeler.8104441@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUDMILLA MOREIRA ELER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUDMILLA MOREIRA ELER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161767  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUISA IVANA ALMEIDA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161767, 
 3,'luisasilva.9161767@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUISA IVANA ALMEIDA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUISA IVANA ALMEIDA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8010838  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUIZ AUGUSTO DE LUCCA GASPERETTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8010838, 
 3,'luizgasperetti.8010838@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUIZ AUGUSTO DE LUCCA GASPERETTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUIZ AUGUSTO DE LUCCA GASPERETTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7226446  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUIZ CARLOS FARIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7226446, 
 3,'luizfaria.7226446@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUIZ CARLOS FARIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUIZ CARLOS FARIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9162721  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUIZ GUSTAVO ZANATTA JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9162721, 
 3,'luizjunior.9162721@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUIZ GUSTAVO ZANATTA JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUIZ GUSTAVO ZANATTA JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7257651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUIZ MASSAYUKI SAMPAIO ITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7257651, 
 3,'luizito.7257651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUIZ MASSAYUKI SAMPAIO ITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUIZ MASSAYUKI SAMPAIO ITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5917344  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUIZ PAULO CARNEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5917344, 
 3,'luizcarneiro.5917344@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUIZ PAULO CARNEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUIZ PAULO CARNEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7761775  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario LUZINETE COSTA GOIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7761775, 
 3,'luzinetegois.7761775@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('LUZINETE COSTA GOIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario LUZINETE COSTA GOIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8107840  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MAIRA LADEIA RODRIGUES CURTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8107840, 
 3,'mairacurti.8107840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MAIRA LADEIA RODRIGUES CURTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MAIRA LADEIA RODRIGUES CURTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8275467  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MAIRA TEODORO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8275467, 
 3,'mairasilva.8275467@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MAIRA TEODORO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MAIRA TEODORO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7491883  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MALDE MARIA VILAS BOAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7491883, 
 3,'maldeboas.7491883@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MALDE MARIA VILAS BOAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MALDE MARIA VILAS BOAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6762867  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCEL PINEZI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6762867, 
 3,'marcelpinezi.6762867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCEL PINEZI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCEL PINEZI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8979456  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCEL VILLEMOR JOFILY DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8979456, 
 3,'marcellima.8979456@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCEL VILLEMOR JOFILY DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCEL VILLEMOR JOFILY DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161333  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELA TARDIOLI DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161333, 
 3,'marcelasantos.9161333@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELA TARDIOLI DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELA TARDIOLI DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8175519  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELLA MULLER MIRANDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8175519, 
 3,'marcellamiranda.8175519@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELLA MULLER MIRANDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELLA MULLER MIRANDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8464057  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELLE MARQUES DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8464057, 
 3,'marcelleandrade.8464057@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELLE MARQUES DE ANDRADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELLE MARQUES DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7245343  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELO BARBOSA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7245343, 
 3,'marcelooliveira.7245343@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELO BARBOSA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELO BARBOSA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6440797  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6440797, 
 3,'marcelosantos.6440797@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8831025  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELO GOMES ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8831025, 
 3,'marceloalves.8831025@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELO GOMES ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELO GOMES ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6983065  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCELO RIVELINO RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6983065, 
 3,'marcelorodrigues.6983065@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCELO RIVELINO RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCELO RIVELINO RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7764871  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA ANDREA BONIFACIO DA COSTA OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7764871, 
 3,'marciaoliveira.7764871@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA ANDREA BONIFACIO DA COSTA OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA ANDREA BONIFACIO DA COSTA OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6013651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA BATISTA NOGUEIRA SHIMODA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6013651, 
 3,'marciashimoda.6013651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA BATISTA NOGUEIRA SHIMODA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA BATISTA NOGUEIRA SHIMODA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7171722  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA DA SILVA ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7171722, 
 3,'marciaaraujo.7171722@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA DA SILVA ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA DA SILVA ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7536577  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7536577, 
 3,'marciaferreira.7536577@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5780454  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA HELENA MATSUSHITA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5780454, 
 3,'marciamatsushita.5780454@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA HELENA MATSUSHITA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA HELENA MATSUSHITA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6874592  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA LANDI BASSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6874592, 
 3,'marciabasso.6874592@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA LANDI BASSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA LANDI BASSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7407360  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIA MENDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7407360, 
 3,'marciamendes.7407360@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIA MENDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIA MENDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8142513  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIELLE JUDAS FERREIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8142513, 
 3,'marciellesilva.8142513@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIELLE JUDAS FERREIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIELLE JUDAS FERREIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8485062  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCIO RODRIGUES DE PADUA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8485062, 
 3,'marciopadua.8485062@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCIO RODRIGUES DE PADUA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCIO RODRIGUES DE PADUA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7212585  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCO ANTONIO HERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7212585, 
 3,'marcoherreira.7212585@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCO ANTONIO HERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCO ANTONIO HERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6691030  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCO ANTONIO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6691030, 
 3,'marcopereira.6691030@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCO ANTONIO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCO ANTONIO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6003486  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCO ANTONIO RIBEIRO DE ANDRADE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6003486, 
 3,'marcoandrade.6003486@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCO ANTONIO RIBEIRO DE ANDRADE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCO ANTONIO RIBEIRO DE ANDRADE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7562713  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCOS EVANGELISTA BORGHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7562713, 
 3,'marcosborghi.7562713@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCOS EVANGELISTA BORGHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCOS EVANGELISTA BORGHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8890340  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCOS GUILHERME MOREIRA PINTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8890340, 
 3,'marcospinto.8890340@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCOS GUILHERME MOREIRA PINTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCOS GUILHERME MOREIRA PINTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7509235  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCOS HAMADA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7509235, 
 3,'marcoshamada.7509235@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCOS HAMADA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCOS HAMADA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9123661  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARCOS VINICIUS DE JESUS OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9123661, 
 3,'marcosoliveira.9123661@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARCOS VINICIUS DE JESUS OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARCOS VINICIUS DE JESUS OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7537859  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARI CELI VIANA VARELA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7537859, 
 3,'marivarela.7537859@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARI CELI VIANA VARELA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARI CELI VIANA VARELA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9149163  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA AMELIA KUHLMANN FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9149163, 
 3,'mariafernandes.9149163@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA AMELIA KUHLMANN FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA AMELIA KUHLMANN FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6518010  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA ANTONIA HERRERA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6518010, 
 3,'mariaherrera.6518010@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA ANTONIA HERRERA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA ANTONIA HERRERA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7525176  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA APARECIDA FAVA IGREJA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7525176, 
 3,'mariaigreja.7525176@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA APARECIDA FAVA IGREJA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA APARECIDA FAVA IGREJA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5868106  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA APARECIDA GAUDENCIO OLUWATUYI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5868106, 
 3,'mariaoluwatuyi.5868106@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA APARECIDA GAUDENCIO OLUWATUYI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA APARECIDA GAUDENCIO OLUWATUYI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9255729  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA CAROLINA GODINHO DE FREITAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9255729, 
 3,'mariafreitas.9255729@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA CAROLINA GODINHO DE FREITAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA CAROLINA GODINHO DE FREITAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5676959  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA CECILIA BORGES PUPO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5676959, 
 3,'mariapupo.5676959@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA CECILIA BORGES PUPO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA CECILIA BORGES PUPO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9199934  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA CECILIA TOLEDO CATALANI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9199934, 
 3,'mariacatalani.9199934@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA CECILIA TOLEDO CATALANI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA CECILIA TOLEDO CATALANI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8028044  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA CLAUDIA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8028044, 
 3,'mariasilva.8028044@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA CLAUDIA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA CLAUDIA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6162517  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA CRISTINA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6162517, 
 3,'mariasilva.6162517@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA CRISTINA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA CRISTINA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5908892  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA DE FATIMA DE BRUM CAVALHEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5908892, 
 3,'mariacavalheiro.5908892@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA DE FATIMA DE BRUM CAVALHEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA DE FATIMA DE BRUM CAVALHEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6803709  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA DE LOURDES SOARES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6803709, 
 3,'mariasilva.6803709@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA DE LOURDES SOARES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA DE LOURDES SOARES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7105410  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA DIRCELY SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7105410, 
 3,'mariasoares.7105410@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA DIRCELY SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA DIRCELY SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 3027732  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA ESTELA QUEIROZ DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 3027732, 
 3,'mariaoliveira.3027732@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA ESTELA QUEIROZ DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA ESTELA QUEIROZ DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7765304  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA FERNANDA CRISTOFOLETTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7765304, 
 3,'mariacristofoletti.7765304@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA FERNANDA CRISTOFOLETTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA FERNANDA CRISTOFOLETTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9164685  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA GERUSENEIDE SILVA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9164685, 
 3,'mariajesus.9164685@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA GERUSENEIDE SILVA DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA GERUSENEIDE SILVA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8008809  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA HELENA LUCATELLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8008809, 
 3,'marialucatelli.8008809@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA HELENA LUCATELLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA HELENA LUCATELLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7496061  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA IRANILDA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7496061, 
 3,'mariasilva.7496061@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA IRANILDA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA IRANILDA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7289472  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA LUCIA ADELAIDE RUBIM DE MORAES FERRANDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7289472, 
 3,'mariaferranda.7289472@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA LUCIA ADELAIDE RUBIM DE MORAES FERRANDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA LUCIA ADELAIDE RUBIM DE MORAES FERRANDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 3169901  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA LUISA ASSIS CARDOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 3169901, 
 3,'mariacardoso.3169901@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA LUISA ASSIS CARDOSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA LUISA ASSIS CARDOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7763875  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA PAULA BENEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7763875, 
 3,'mariabenez.7763875@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA PAULA BENEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA PAULA BENEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161341  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA PAULA HONORATO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161341, 
 3,'mariasantos.9161341@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA PAULA HONORATO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA PAULA HONORATO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9127119  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIA SILVA MENEZES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9127119, 
 3,'mariamenezes.9127119@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIA SILVA MENEZES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIA SILVA MENEZES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161678  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA DE OLIVEIRA CARDOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161678, 
 3,'marianacardoso.9161678@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA DE OLIVEIRA CARDOSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA DE OLIVEIRA CARDOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8279578  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA GALVES MARQUES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8279578, 
 3,'marianaoliveira.8279578@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA GALVES MARQUES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA GALVES MARQUES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8416397  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA MOI BONFIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8416397, 
 3,'marianabonfim.8416397@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA MOI BONFIM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA MOI BONFIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274606  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA OTANI CASSEB'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274606, 
 3,'marianacasseb.8274606@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA OTANI CASSEB'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA OTANI CASSEB'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8018316  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA PAULINO SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8018316, 
 3,'marianasoares.8018316@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA PAULINO SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA PAULINO SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8238545  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA PORFIRIO SIQUEIRA VALADARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8238545, 
 3,'marianavaladares.8238545@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA PORFIRIO SIQUEIRA VALADARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA PORFIRIO SIQUEIRA VALADARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8799636  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA SANTOS DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8799636, 
 3,'marianalima.8799636@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA SANTOS DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA SANTOS DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8246068  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA SILVA DE ALMEIDA CAMISA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8246068, 
 3,'marianacamisa.8246068@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA SILVA DE ALMEIDA CAMISA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA SILVA DE ALMEIDA CAMISA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8115231  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANA SIMOES FERREIRA DO O'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8115231, 
 3,'marianao.8115231@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANA SIMOES FERREIRA DO O'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANA SIMOES FERREIRA DO O'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8284440  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANGELA PACHECO ROCHA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8284440, 
 3,'mariangelasantos.8284440@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANGELA PACHECO ROCHA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANGELA PACHECO ROCHA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8207461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIANNE SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8207461, 
 3,'mariannesilva.8207461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIANNE SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIANNE SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161643  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIELE CORAL DE MORAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161643, 
 3,'marielemoraes.9161643@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIELE CORAL DE MORAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIELE CORAL DE MORAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7865864  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARILEIDE SANTANA LIMA E SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7865864, 
 3,'marileidesilva.7865864@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARILEIDE SANTANA LIMA E SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARILEIDE SANTANA LIMA E SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6603980  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARILUCI IRIA DE SOUZA MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6603980, 
 3,'marilucimoreira.6603980@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARILUCI IRIA DE SOUZA MOREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARILUCI IRIA DE SOUZA MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8282862  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARINA DE CAMPOS GONZAGA BENE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8282862, 
 3,'marinabene.8282862@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARINA DE CAMPOS GONZAGA BENE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARINA DE CAMPOS GONZAGA BENE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6955819  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARINEUSA MEDEIROS DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6955819, 
 3,'marineusasilva.6955819@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARINEUSA MEDEIROS DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARINEUSA MEDEIROS DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9126082  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARISA NITTOLO COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9126082, 
 3,'marisacosta.9126082@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARISA NITTOLO COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARISA NITTOLO COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7753578  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARISSOL FRANCO BLOISI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7753578, 
 3,'marissolbloisi.7753578@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARISSOL FRANCO BLOISI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARISSOL FRANCO BLOISI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8450277  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARITA RONAY MATOS TUNES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8450277, 
 3,'maritatunes.8450277@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARITA RONAY MATOS TUNES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARITA RONAY MATOS TUNES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 1186116  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARIZA LEIKO KUBO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 1186116, 
 3,'marizakubo.1186116@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARIZA LEIKO KUBO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARIZA LEIKO KUBO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6757529  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MARLI DA CONCEICAO VIDIGAL CARDOSO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6757529, 
 3,'marlicardoso.6757529@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MARLI DA CONCEICAO VIDIGAL CARDOSO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MARLI DA CONCEICAO VIDIGAL CARDOSO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8972877  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MATEUS DO CARMO CUNHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8972877, 
 3,'mateuscunha.8972877@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MATEUS DO CARMO CUNHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MATEUS DO CARMO CUNHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7233507  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MATILDE APARECIDA DA SILVA FRANCO CAMPANHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7233507, 
 3,'matildecampanha.7233507@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MATILDE APARECIDA DA SILVA FRANCO CAMPANHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MATILDE APARECIDA DA SILVA FRANCO CAMPANHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7961979  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MAYRA BARROS DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7961979, 
 3,'mayradias.7961979@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MAYRA BARROS DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MAYRA BARROS DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8077622  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MAYRA REGINA VIDAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8077622, 
 3,'mayravidal.8077622@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MAYRA REGINA VIDAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MAYRA REGINA VIDAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6759009  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MEIRE CRISTINA DAVID'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6759009, 
 3,'meiredavid.6759009@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MEIRE CRISTINA DAVID'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MEIRE CRISTINA DAVID'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9187499  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MELANIE MICHIKO GUNJI MARCOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9187499, 
 3,'melaniemarcos.9187499@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MELANIE MICHIKO GUNJI MARCOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MELANIE MICHIKO GUNJI MARCOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7934581  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MELINA RODOLPHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7934581, 
 3,'melinarodolpho.7934581@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MELINA RODOLPHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MELINA RODOLPHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161775  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MERIELI NERI COSTA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161775, 
 3,'merielijesus.9161775@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MERIELI NERI COSTA DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MERIELI NERI COSTA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7825633  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MICHELE FERREIRA TENORIO DE MORAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7825633, 
 3,'michelemoraes.7825633@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MICHELE FERREIRA TENORIO DE MORAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MICHELE FERREIRA TENORIO DE MORAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8115214  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MICHELLE ALESSANDRA DE CASTRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8115214, 
 3,'michellecastro.8115214@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MICHELLE ALESSANDRA DE CASTRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MICHELLE ALESSANDRA DE CASTRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8390886  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MILENE TEODORO FREIRE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8390886, 
 3,'milenefreire.8390886@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MILENE TEODORO FREIRE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MILENE TEODORO FREIRE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161473  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MIRENA BOKLIS BERER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161473, 
 3,'mirenaberer.9161473@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MIRENA BOKLIS BERER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MIRENA BOKLIS BERER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7756763  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MIRIAN MATSUMOTO ISHIBASHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7756763, 
 3,'mirianishibashi.7756763@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MIRIAN MATSUMOTO ISHIBASHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MIRIAN MATSUMOTO ISHIBASHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7270585  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MONICA BUENO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7270585, 
 3,'monicaoliveira.7270585@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MONICA BUENO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MONICA BUENO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7769831  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MONICA CARDIAL TOBIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7769831, 
 3,'monicatobias.7769831@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MONICA CARDIAL TOBIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MONICA CARDIAL TOBIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7376065  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MONICA CARVALHO TANG'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7376065, 
 3,'monicatang.7376065@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MONICA CARVALHO TANG'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MONICA CARVALHO TANG'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8285551  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MONICA CORDEIRO NOGUEIRA DA CRUZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8285551, 
 3,'monicacruz.8285551@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MONICA CORDEIRO NOGUEIRA DA CRUZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MONICA CORDEIRO NOGUEIRA DA CRUZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6809235  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MONICA DE OLIVEIRA PRADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6809235, 
 3,'monicaprado.6809235@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MONICA DE OLIVEIRA PRADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MONICA DE OLIVEIRA PRADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8175128  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MONICA IDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8175128, 
 3,'monicaido.8175128@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MONICA IDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MONICA IDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6945341  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MORGANA ALEXANDRE DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6945341, 
 3,'morganadias.6945341@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MORGANA ALEXANDRE DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MORGANA ALEXANDRE DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6668917  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario MOZART VITALINO JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6668917, 
 3,'mozartjunior.6668917@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('MOZART VITALINO JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario MOZART VITALINO JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7722141  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NANCI DE OLIVEIRA SOUEID'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7722141, 
 3,'nancisoueid.7722141@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NANCI DE OLIVEIRA SOUEID'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NANCI DE OLIVEIRA SOUEID'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8273014  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NATALIA DE OLIVEIRA SIMANOVISHI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8273014, 
 3,'nataliasimanovishi.8273014@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NATALIA DE OLIVEIRA SIMANOVISHI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NATALIA DE OLIVEIRA SIMANOVISHI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8201366  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NATALIA GOES ASSIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8201366, 
 3,'nataliaassis.8201366@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NATALIA GOES ASSIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NATALIA GOES ASSIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8038732  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NATALIA SILVA ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8038732, 
 3,'nataliaalves.8038732@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NATALIA SILVA ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NATALIA SILVA ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8896810  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NATASHA GUIMARAES DE MESQUITA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8896810, 
 3,'natashamesquita.8896810@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NATASHA GUIMARAES DE MESQUITA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NATASHA GUIMARAES DE MESQUITA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8399387  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NATHALIA SOARES DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8399387, 
 3,'nathaliaoliveira.8399387@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NATHALIA SOARES DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NATHALIA SOARES DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8031754  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NATHASHA ABRAHAO VILANOVA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8031754, 
 3,'nathashasantos.8031754@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NATHASHA ABRAHAO VILANOVA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NATHASHA ABRAHAO VILANOVA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161571  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NELAINE CARDOSO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161571, 
 3,'nelainesantos.9161571@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NELAINE CARDOSO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NELAINE CARDOSO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7230702  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NELSI MARIA DE JESUS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7230702, 
 3,'nelsijesus.7230702@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NELSI MARIA DE JESUS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NELSI MARIA DE JESUS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7331011  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NELSON RICARDO MATOS GUILHAMATI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7331011, 
 3,'nelsonguilhamati.7331011@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NELSON RICARDO MATOS GUILHAMATI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NELSON RICARDO MATOS GUILHAMATI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5312299  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario NILZA ROSA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5312299, 
 3,'nilzasouza.5312299@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('NILZA ROSA DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario NILZA ROSA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8816247  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario OLIVIA TAKEUCHI E SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8816247, 
 3,'oliviasilva.8816247@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('OLIVIA TAKEUCHI E SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario OLIVIA TAKEUCHI E SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8868824  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario OMAR CASSIM NETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8868824, 
 3,'omarneto.8868824@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('OMAR CASSIM NETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario OMAR CASSIM NETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8171211  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ONEZIO CRISTOVAO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8171211, 
 3,'oneziocristovao.8171211@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ONEZIO CRISTOVAO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ONEZIO CRISTOVAO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5866634  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario OSVALDO BRAGA MARCONDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5866634, 
 3,'osvaldomarcondes.5866634@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('OSVALDO BRAGA MARCONDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario OSVALDO BRAGA MARCONDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8367027  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA BENICIO DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8367027, 
 3,'patriciasilva.8367027@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA BENICIO DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA BENICIO DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8285543  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA DE ALMEIDA LEITE GALLETTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8285543, 
 3,'patriciagalletta.8285543@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA DE ALMEIDA LEITE GALLETTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA DE ALMEIDA LEITE GALLETTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8448094  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8448094, 
 3,'patriciaoliveira.8448094@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7368640  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA DE PONTES SIQUEIRA BONFIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7368640, 
 3,'patriciabonfim.7368640@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA DE PONTES SIQUEIRA BONFIM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA DE PONTES SIQUEIRA BONFIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6016669  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA DOMINGUEZ LEME CAMPOY'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6016669, 
 3,'patriciacampoy.6016669@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA DOMINGUEZ LEME CAMPOY'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA DOMINGUEZ LEME CAMPOY'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9202854  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA LUCENA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9202854, 
 3,'patriciasilva.9202854@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA LUCENA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA LUCENA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6201601  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA MARTINS DA SILVA REDE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6201601, 
 3,'patriciarede.6201601@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA MARTINS DA SILVA REDE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA MARTINS DA SILVA REDE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161597  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA PANDOVAN DOS SANTOS DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161597, 
 3,'patriciaoliveira.9161597@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA PANDOVAN DOS SANTOS DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA PANDOVAN DOS SANTOS DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7448996  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA ROZO DUARTE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7448996, 
 3,'patriciaduarte.7448996@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA ROZO DUARTE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA ROZO DUARTE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7945299  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA SCHATZ PELLICCIOTTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7945299, 
 3,'patriciapellicciotti.7945299@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA SCHATZ PELLICCIOTTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA SCHATZ PELLICCIOTTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7507704  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PATRICIA SIMOES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7507704, 
 3,'patriciasilva.7507704@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PATRICIA SIMOES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PATRICIA SIMOES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8018839  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULA COSTA VEIRA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8018839, 
 3,'paulasilva.8018839@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULA COSTA VEIRA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULA COSTA VEIRA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7965460  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULA DE CARVALHO GUIMARAES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7965460, 
 3,'paulaguimaraes.7965460@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULA DE CARVALHO GUIMARAES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULA DE CARVALHO GUIMARAES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9179046  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULA SIMOES GARCIA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9179046, 
 3,'paulagarcia.9179046@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULA SIMOES GARCIA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULA SIMOES GARCIA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8028907  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULO HENRIQUE CARDOSO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8028907, 
 3,'paulosantos.8028907@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULO HENRIQUE CARDOSO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULO HENRIQUE CARDOSO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9163859  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULO MACHADO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9163859, 
 3,'paulooliveira.9163859@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULO MACHADO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULO MACHADO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6005446  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULO SALVADOR CARAMMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6005446, 
 3,'paulocaramma.6005446@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULO SALVADOR CARAMMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULO SALVADOR CARAMMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8513481  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PAULO VICTOR GRANGEIRO LUCENA TORRES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8513481, 
 3,'paulotorres.8513481@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PAULO VICTOR GRANGEIRO LUCENA TORRES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PAULO VICTOR GRANGEIRO LUCENA TORRES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9149929  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PEDRO LEITE COELHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9149929, 
 3,'pedrocoelho.9149929@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PEDRO LEITE COELHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PEDRO LEITE COELHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8415811  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PRISCILA DA SILVA LEANDRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8415811, 
 3,'priscilaleandro.8415811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PRISCILA DA SILVA LEANDRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PRISCILA DA SILVA LEANDRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7907770  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PRISCILA DE OLIVEIRA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7907770, 
 3,'priscilavieira.7907770@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PRISCILA DE OLIVEIRA VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PRISCILA DE OLIVEIRA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7945302  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PRISCILA LEONARDI DOS SANTOS ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7945302, 
 3,'priscilaaraujo.7945302@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PRISCILA LEONARDI DOS SANTOS ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PRISCILA LEONARDI DOS SANTOS ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7877722  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PRISCILLA BARBARA ALVES BICUDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7877722, 
 3,'priscillabicudo.7877722@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PRISCILLA BARBARA ALVES BICUDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PRISCILLA BARBARA ALVES BICUDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7447370  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario PRISCILLA KONOMI TANAKA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7447370, 
 3,'priscillatanaka.7447370@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('PRISCILLA KONOMI TANAKA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario PRISCILLA KONOMI TANAKA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7524919  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAFAEL BATISTA ORTEGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7524919, 
 3,'rafaelortega.7524919@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAFAEL BATISTA ORTEGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAFAEL BATISTA ORTEGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8462259  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAFAEL FERNANDO DA SILVA SANTOS FITIPALDI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8462259, 
 3,'rafaelfitipaldi.8462259@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAFAEL FERNANDO DA SILVA SANTOS FITIPALDI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAFAEL FERNANDO DA SILVA SANTOS FITIPALDI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8148937  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAFAELA BOTELHO LOPES DE MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8148937, 
 3,'rafaelamatos.8148937@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAFAELA BOTELHO LOPES DE MATOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAFAELA BOTELHO LOPES DE MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7722001  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAFAELA DE MELO DIEDRICH'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7722001, 
 3,'rafaeladiedrich.7722001@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAFAELA DE MELO DIEDRICH'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAFAELA DE MELO DIEDRICH'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8239100  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAFAELLA TORRES SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8239100, 
 3,'rafaellasantos.8239100@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAFAELLA TORRES SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAFAELLA TORRES SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7949766  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAQUEL RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7949766, 
 3,'raquelrodrigues.7949766@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAQUEL RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAQUEL RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8545022  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RAVI BRAZ DE CAMPOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8545022, 
 3,'ravicampos.8545022@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RAVI BRAZ DE CAMPOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RAVI BRAZ DE CAMPOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8241996  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGIANE ALVES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8241996, 
 3,'regianesilva.8241996@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGIANE ALVES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGIANE ALVES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7121458  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGIANE PAULINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7121458, 
 3,'regianepaulino.7121458@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGIANE PAULINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGIANE PAULINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9111590  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGILANE PAULINO DA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9111590, 
 3,'regilanerocha.9111590@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGILANE PAULINO DA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGILANE PAULINO DA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5531365  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGINA CELI DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5531365, 
 3,'reginaoliveira.5531365@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGINA CELI DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGINA CELI DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6686338  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGINA CELIA FORTUNA BROTI GAVASSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6686338, 
 3,'reginagavassa.6686338@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGINA CELIA FORTUNA BROTI GAVASSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGINA CELIA FORTUNA BROTI GAVASSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161635  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGINA PEREIRA DE OLIVEIRA MACHADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161635, 
 3,'reginamachado.9161635@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGINA PEREIRA DE OLIVEIRA MACHADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGINA PEREIRA DE OLIVEIRA MACHADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8219141  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario REGIVANE SILVA ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8219141, 
 3,'regivanealmeida.8219141@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('REGIVANE SILVA ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario REGIVANE SILVA ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8451478  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA ALMEIDA VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8451478, 
 3,'renatavieira.8451478@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA ALMEIDA VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA ALMEIDA VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7907338  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA DE OLIVEIRA LELLIS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7907338, 
 3,'renatalellis.7907338@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA DE OLIVEIRA LELLIS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA DE OLIVEIRA LELLIS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161295  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA FERREIRA ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161295, 
 3,'renataalves.9161295@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA FERREIRA ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA FERREIRA ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8247064  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA GARRIDO AZEVEDO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8247064, 
 3,'renataoliveira.8247064@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA GARRIDO AZEVEDO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA GARRIDO AZEVEDO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8105219  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA GONCALVES LEITE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8105219, 
 3,'renataleite.8105219@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA GONCALVES LEITE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA GONCALVES LEITE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8110263  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA MACIEL NUNES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8110263, 
 3,'renatanunes.8110263@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA MACIEL NUNES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA MACIEL NUNES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9187472  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA MALEH GATTI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9187472, 
 3,'renatagatti.9187472@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA MALEH GATTI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA MALEH GATTI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6764410  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA MONACO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6764410, 
 3,'renatamonaco.6764410@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA MONACO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA MONACO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8173605  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATA VIDICA MARQUES DA ROSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8173605, 
 3,'renatarosa.8173605@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATA VIDICA MARQUES DA ROSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATA VIDICA MARQUES DA ROSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8457531  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATO BALHE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8457531, 
 3,'renatobalhe.8457531@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATO BALHE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATO BALHE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8206937  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATO GIL CARNEIRO DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8206937, 
 3,'renatosantos.8206937@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATO GIL CARNEIRO DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATO GIL CARNEIRO DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8425191  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATO GONDIM RIOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8425191, 
 3,'renatorios.8425191@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATO GONDIM RIOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATO GONDIM RIOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6918697  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATO OTTO ORTLEPP JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6918697, 
 3,'renatojunior.6918697@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATO OTTO ORTLEPP JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATO OTTO ORTLEPP JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7844085  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATO RANZINI RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7844085, 
 3,'renatorodrigues.7844085@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATO RANZINI RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATO RANZINI RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6683134  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RENATO VIEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6683134, 
 3,'renatovieira.6683134@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RENATO VIEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RENATO VIEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8434018  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RICARDO DOS ANJOS SENA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8434018, 
 3,'ricardosena.8434018@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RICARDO DOS ANJOS SENA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RICARDO DOS ANJOS SENA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7487282  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RICARDO PERES DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7487282, 
 3,'ricardoalmeida.7487282@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RICARDO PERES DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RICARDO PERES DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6809472  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RITA DE CASSIA ESTEVES DE AGUIAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6809472, 
 3,'ritaaguiar.6809472@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RITA DE CASSIA ESTEVES DE AGUIAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RITA DE CASSIA ESTEVES DE AGUIAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7790783  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RIVA CAETANO DE SOUZA SILVEIRA DENYS MOREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7790783, 
 3,'rivamoreira.7790783@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RIVA CAETANO DE SOUZA SILVEIRA DENYS MOREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RIVA CAETANO DE SOUZA SILVEIRA DENYS MOREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8172056  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROBERTA COVRE GASPARINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8172056, 
 3,'robertagasparini.8172056@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROBERTA COVRE GASPARINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROBERTA COVRE GASPARINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7800045  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROBERTA CRISTINA TORRES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7800045, 
 3,'robertasilva.7800045@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROBERTA CRISTINA TORRES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROBERTA CRISTINA TORRES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7496338  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROBERTO CARLOS RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7496338, 
 3,'robertoribeiro.7496338@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROBERTO CARLOS RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROBERTO CARLOS RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9123849  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROBERTO HERREIRA BUENO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9123849, 
 3,'robertobueno.9123849@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROBERTO HERREIRA BUENO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROBERTO HERREIRA BUENO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7531206  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROBSON MAIDA PROFENZANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7531206, 
 3,'robsonprofenzano.7531206@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROBSON MAIDA PROFENZANO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROBSON MAIDA PROFENZANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8090394  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RODOLFO TADEU LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8090394, 
 3,'rodolfolopes.8090394@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RODOLFO TADEU LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RODOLFO TADEU LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7248849  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RODRIGA APARECIDA THEODORO DA SILVA SERAVALLI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7248849, 
 3,'rodrigaseravalli.7248849@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RODRIGA APARECIDA THEODORO DA SILVA SERAVALLI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RODRIGA APARECIDA THEODORO DA SILVA SERAVALLI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8979898  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RODRIGO JAIR MORANDI METZNER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8979898, 
 3,'rodrigometzner.8979898@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RODRIGO JAIR MORANDI METZNER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RODRIGO JAIR MORANDI METZNER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6744184  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROGERIO COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6744184, 
 3,'rogeriocosta.6744184@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROGERIO COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROGERIO COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7905904  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROGERIO MARCELO FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7905904, 
 3,'rogerioferreira.7905904@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROGERIO MARCELO FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROGERIO MARCELO FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7563370  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROMULO ARAUJO FERNANDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7563370, 
 3,'romulofernandes.7563370@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROMULO ARAUJO FERNANDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROMULO ARAUJO FERNANDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6941583  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RONALDO JOSE DA SILVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6941583, 
 3,'ronaldosilveira.6941583@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RONALDO JOSE DA SILVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RONALDO JOSE DA SILVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 4662997  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSA DE JESUS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 4662997, 
 3,'rosasilva.4662997@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSA DE JESUS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSA DE JESUS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5727979  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSANA APARECIDA MOREIRA DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5727979, 
 3,'rosanalima.5727979@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSANA APARECIDA MOREIRA DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSANA APARECIDA MOREIRA DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6753761  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSANGELA MARIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6753761, 
 3,'rosangelasantos.6753761@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSANGELA MARIA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSANGELA MARIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7296045  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSANGELA RODRIGUES DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7296045, 
 3,'rosangelasilva.7296045@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSANGELA RODRIGUES DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSANGELA RODRIGUES DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7255667  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSELI DE BRITO CABRAL'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7255667, 
 3,'roselicabral.7255667@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSELI DE BRITO CABRAL'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSELI DE BRITO CABRAL'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7327625  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSELI DO CARMO PEREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7327625, 
 3,'roselipereira.7327625@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSELI DO CARMO PEREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSELI DO CARMO PEREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5810426  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSELI MARCELLI SANTOS DE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5810426, 
 3,'roselicarvalho.5810426@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSELI MARCELLI SANTOS DE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSELI MARCELLI SANTOS DE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6770011  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSELI ZAMPIROLLI BERKOVITS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6770011, 
 3,'roseliberkovits.6770011@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSELI ZAMPIROLLI BERKOVITS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSELI ZAMPIROLLI BERKOVITS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5602505  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSENEIDE DE JESUS SANTANA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5602505, 
 3,'roseneidesantana.5602505@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSENEIDE DE JESUS SANTANA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSENEIDE DE JESUS SANTANA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7766041  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ROSIMEIRE MINGUTA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7766041, 
 3,'rosimeirecosta.7766041@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ROSIMEIRE MINGUTA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ROSIMEIRE MINGUTA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9163794  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RUBENS FEITOSA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9163794, 
 3,'rubenssouza.9163794@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RUBENS FEITOSA DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RUBENS FEITOSA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7768915  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario RUTH LOBATO TEIXEIRA MATSUMOTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7768915, 
 3,'ruthmatsumoto.7768915@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('RUTH LOBATO TEIXEIRA MATSUMOTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario RUTH LOBATO TEIXEIRA MATSUMOTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161716  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SABRINA PESSONI PIMENTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161716, 
 3,'sabrinapimenta.9161716@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SABRINA PESSONI PIMENTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SABRINA PESSONI PIMENTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8111073  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SAMARA MANZANO BREDA LEITE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8111073, 
 3,'samaraleite.8111073@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SAMARA MANZANO BREDA LEITE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SAMARA MANZANO BREDA LEITE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8782971  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SAMIA ROCHA ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8782971, 
 3,'samiaalves.8782971@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SAMIA ROCHA ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SAMIA ROCHA ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7944136  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SAMIR AHMAD DOS SANTOS MUSTAPHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7944136, 
 3,'samirmustapha.7944136@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SAMIR AHMAD DOS SANTOS MUSTAPHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SAMIR AHMAD DOS SANTOS MUSTAPHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8080461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SAMIRA NOVO LOPES '; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8080461, 
 3,'samiralopes.8080461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SAMIRA NOVO LOPES '),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SAMIRA NOVO LOPES '; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7312245  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SANDRA LEIA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7312245, 
 3,'sandrasilva.7312245@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SANDRA LEIA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SANDRA LEIA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5034388  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SANDRA MARIA SCAGLIARINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5034388, 
 3,'sandrascagliarini.5034388@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SANDRA MARIA SCAGLIARINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SANDRA MARIA SCAGLIARINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7975821  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SANDRA SALAVANDRO RODRIGUES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7975821, 
 3,'sandrarodrigues.7975821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SANDRA SALAVANDRO RODRIGUES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SANDRA SALAVANDRO RODRIGUES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6869998  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SANDRO ALEX GARCES DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6869998, 
 3,'sandrosantos.6869998@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SANDRO ALEX GARCES DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SANDRO ALEX GARCES DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8211663  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SANDY VIEIRA SOARES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8211663, 
 3,'sandysoares.8211663@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SANDY VIEIRA SOARES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SANDY VIEIRA SOARES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5365627  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SEBASTIAO PLACERES JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5365627, 
 3,'sebastiaojunior.5365627@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SEBASTIAO PLACERES JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SEBASTIAO PLACERES JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6120156  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SELMA APARECIDA SOUZA DA SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6120156, 
 3,'selmasilva.6120156@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SELMA APARECIDA SOUZA DA SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SELMA APARECIDA SOUZA DA SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8194157  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SELMA LUCIA DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8194157, 
 3,'selmasantos.8194157@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SELMA LUCIA DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SELMA LUCIA DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8196991  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SHIRLEI NADALUTI MONTEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8196991, 
 3,'shirleimonteiro.8196991@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SHIRLEI NADALUTI MONTEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SHIRLEI NADALUTI MONTEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7307705  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SHIRLEY COSTA DE OLIVEIRA FILETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7307705, 
 3,'shirleyfileto.7307705@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SHIRLEY COSTA DE OLIVEIRA FILETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SHIRLEY COSTA DE OLIVEIRA FILETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7743734  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SHIRLEY DA SILVA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7743734, 
 3,'shirleysantos.7743734@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SHIRLEY DA SILVA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SHIRLEY DA SILVA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6752284  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SHIRLEY REGINA DOS SANTOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6752284, 
 3,'shirleysilva.6752284@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SHIRLEY REGINA DOS SANTOS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SHIRLEY REGINA DOS SANTOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6771572  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SHIRLEY RODRIGUES DINIZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6771572, 
 3,'shirleydiniz.6771572@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SHIRLEY RODRIGUES DINIZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SHIRLEY RODRIGUES DINIZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8119538  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVANA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8119538, 
 3,'silvanasouza.8119538@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVANA DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVANA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6737790  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVANA MOURA RIGUENGO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6737790, 
 3,'silvanariguengo.6737790@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVANA MOURA RIGUENGO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVANA MOURA RIGUENGO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7350724  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVIA HELENA DA SILVA SABARA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7350724, 
 3,'silviasabara.7350724@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVIA HELENA DA SILVA SABARA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVIA HELENA DA SILVA SABARA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6809197  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVIA REGINA GONZAGA DE OLIVEIRA PARADA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6809197, 
 3,'silviaparada.6809197@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVIA REGINA GONZAGA DE OLIVEIRA PARADA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVIA REGINA GONZAGA DE OLIVEIRA PARADA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7768346  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVIA SINICIATO CANAVESE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7768346, 
 3,'silviacanavese.7768346@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVIA SINICIATO CANAVESE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVIA SINICIATO CANAVESE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8534128  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVIO APARECIDO DE VASCONCELOS JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8534128, 
 3,'silviojunior.8534128@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVIO APARECIDO DE VASCONCELOS JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVIO APARECIDO DE VASCONCELOS JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7368607  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SILVIO MICAELA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7368607, 
 3,'silviomicaela.7368607@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SILVIO MICAELA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SILVIO MICAELA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8502480  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIMONE DE OLIVEIRA HÚNGARO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8502480, 
 3,'simonehungaro.8502480@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIMONE DE OLIVEIRA HÚNGARO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIMONE DE OLIVEIRA HÚNGARO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6955801  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIMONE DOS SANTOS ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6955801, 
 3,'simonerocha.6955801@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIMONE DOS SANTOS ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIMONE DOS SANTOS ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8152381  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIMONE GARRIDO DE SOUZA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8152381, 
 3,'simonesantos.8152381@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIMONE GARRIDO DE SOUZA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIMONE GARRIDO DE SOUZA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6770509  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIMONE KETI STEFANELLI BIUSSI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6770509, 
 3,'simonebiussi.6770509@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIMONE KETI STEFANELLI BIUSSI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIMONE KETI STEFANELLI BIUSSI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7511591  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIMONE MEGUMI KAMEI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7511591, 
 3,'simonekamei.7511591@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIMONE MEGUMI KAMEI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIMONE MEGUMI KAMEI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8372624  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIMONE PORFIRIO MASCARENHAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8372624, 
 3,'simonemascarenhas.8372624@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIMONE PORFIRIO MASCARENHAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIMONE PORFIRIO MASCARENHAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8218391  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SIRLENI BATISTA UENOJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8218391, 
 3,'sirleniuenojo.8218391@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SIRLENI BATISTA UENOJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SIRLENI BATISTA UENOJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6669239  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SOLANGE COSTA DE SENA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6669239, 
 3,'solangesena.6669239@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SOLANGE COSTA DE SENA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SOLANGE COSTA DE SENA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7485166  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SOLANGE CRISTINA CORREGIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7485166, 
 3,'solangecorregio.7485166@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SOLANGE CRISTINA CORREGIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SOLANGE CRISTINA CORREGIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161686  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario STEFANIE MATTOSO PEREIRA BUENO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161686, 
 3,'stefaniebueno.9161686@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('STEFANIE MATTOSO PEREIRA BUENO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario STEFANIE MATTOSO PEREIRA BUENO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8984549  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario STELLA CURIATI MIMESSI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8984549, 
 3,'stellamimessi.8984549@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('STELLA CURIATI MIMESSI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario STELLA CURIATI MIMESSI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8280401  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario STELLA FONTES RAMOS ZARANTONELLO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8280401, 
 3,'stellazarantonello.8280401@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('STELLA FONTES RAMOS ZARANTONELLO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario STELLA FONTES RAMOS ZARANTONELLO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8198306  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario STEPHANIE LOUISE MARIN DE ALMEIDA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8198306, 
 3,'stephaniealmeida.8198306@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('STEPHANIE LOUISE MARIN DE ALMEIDA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario STEPHANIE LOUISE MARIN DE ALMEIDA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6751971  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SUELI APARECIDA DE PAULA MONDINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6751971, 
 3,'suelimondini.6751971@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SUELI APARECIDA DE PAULA MONDINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SUELI APARECIDA DE PAULA MONDINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7449887  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SUELI DE LIMA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7449887, 
 3,'suelilima.7449887@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SUELI DE LIMA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SUELI DE LIMA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7243022  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SUELI FUNARI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7243022, 
 3,'suelifunari.7243022@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SUELI FUNARI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SUELI FUNARI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5208092  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SUELY MANDARI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5208092, 
 3,'suelymandari.5208092@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SUELY MANDARI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SUELY MANDARI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7946775  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SUSEN COVRE FRANZINI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7946775, 
 3,'susenfranzini.7946775@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SUSEN COVRE FRANZINI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SUSEN COVRE FRANZINI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9129146  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SUZANA SOUZA OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9129146, 
 3,'suzanaoliveira.9129146@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SUZANA SOUZA OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SUZANA SOUZA OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5250668  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario SYLVETE MEDEIROS CORREA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5250668, 
 3,'sylvetecorrea.5250668@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('SYLVETE MEDEIROS CORREA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario SYLVETE MEDEIROS CORREA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8249164  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TAIS MOTA ESTEVES HEINECK'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8249164, 
 3,'taisheineck.8249164@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TAIS MOTA ESTEVES HEINECK'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TAIS MOTA ESTEVES HEINECK'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7840381  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TAIZE GROTTO DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7840381, 
 3,'taizeoliveira.7840381@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TAIZE GROTTO DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TAIZE GROTTO DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8804699  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TALES CAPDEVILA GRYGA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8804699, 
 3,'talesgryga.8804699@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TALES CAPDEVILA GRYGA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TALES CAPDEVILA GRYGA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8283753  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TALITA ALVES SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8283753, 
 3,'talitasilva.8283753@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TALITA ALVES SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TALITA ALVES SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8026131  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TALITA CARNEIRO DE MATOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8026131, 
 3,'talitamatos.8026131@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TALITA CARNEIRO DE MATOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TALITA CARNEIRO DE MATOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161309  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TALITA LEMOS NEVES BARRETO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161309, 
 3,'talitabarreto.9161309@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TALITA LEMOS NEVES BARRETO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TALITA LEMOS NEVES BARRETO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8101728  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TALITA SILVA DIAS LEME'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8101728, 
 3,'talitaleme.8101728@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TALITA SILVA DIAS LEME'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TALITA SILVA DIAS LEME'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7917821  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TALITA VIEIRA ROBERTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7917821, 
 3,'talitaroberto.7917821@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TALITA VIEIRA ROBERTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TALITA VIEIRA ROBERTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8906840  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TAMIRES SANTIAGO DE SOUZA ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8906840, 
 3,'tamiresrocha.8906840@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TAMIRES SANTIAGO DE SOUZA ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TAMIRES SANTIAGO DE SOUZA ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9199942  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TAMIRIS ALLEBRANDT'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9199942, 
 3,'tamirisallebrandt.9199942@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TAMIRIS ALLEBRANDT'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TAMIRIS ALLEBRANDT'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7756143  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TANIA APARECIDA FEITOSA MEDEIROS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7756143, 
 3,'taniamedeiros.7756143@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TANIA APARECIDA FEITOSA MEDEIROS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TANIA APARECIDA FEITOSA MEDEIROS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5397341  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TANIA NARDI DE PADUA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5397341, 
 3,'taniapadua.5397341@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TANIA NARDI DE PADUA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TANIA NARDI DE PADUA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6865623  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TANIA REGINA GOLZIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6865623, 
 3,'taniagolzio.6865623@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TANIA REGINA GOLZIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TANIA REGINA GOLZIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7831072  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TANIA SANGER ROCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7831072, 
 3,'taniarocha.7831072@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TANIA SANGER ROCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TANIA SANGER ROCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8419914  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TARCISIO LINHARES FILGUEIRAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8419914, 
 3,'tarcisiofilgueiras.8419914@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TARCISIO LINHARES FILGUEIRAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TARCISIO LINHARES FILGUEIRAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6235867  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TARCISO CORREIA MARCOLINO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6235867, 
 3,'tarcisomarcolino.6235867@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TARCISO CORREIA MARCOLINO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TARCISO CORREIA MARCOLINO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161392  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TASSIANE DE PAULA SUDBRACK'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161392, 
 3,'tassianesudbrack.9161392@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TASSIANE DE PAULA SUDBRACK'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TASSIANE DE PAULA SUDBRACK'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7287160  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATHIANA AUGUSTA RODRIGUES LOURENCO MARTINEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7287160, 
 3,'tathianamartinez.7287160@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATHIANA AUGUSTA RODRIGUES LOURENCO MARTINEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATHIANA AUGUSTA RODRIGUES LOURENCO MARTINEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7363371  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA ANDOLFATO DE ALCANTARA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7363371, 
 3,'tatianaalcantara.7363371@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA ANDOLFATO DE ALCANTARA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA ANDOLFATO DE ALCANTARA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7493886  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA APARECIDA MILANEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7493886, 
 3,'tatianamilanez.7493886@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA APARECIDA MILANEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA APARECIDA MILANEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7906650  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA DO NASCIMENTO FONSECA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7906650, 
 3,'tatianafonseca.7906650@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA DO NASCIMENTO FONSECA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA DO NASCIMENTO FONSECA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8022691  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA FERREIRA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8022691, 
 3,'tatianacosta.8022691@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA FERREIRA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA FERREIRA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8389322  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA NUNES GALLI CHAVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8389322, 
 3,'tatianachaves.8389322@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA NUNES GALLI CHAVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA NUNES GALLI CHAVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7727798  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA SETSUE ITOKAZU'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7727798, 
 3,'tatianaitokazu.7727798@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA SETSUE ITOKAZU'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA SETSUE ITOKAZU'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8209383  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANA SILVA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8209383, 
 3,'tatianacosta.8209383@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANA SILVA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANA SILVA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7523637  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANE ALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7523637, 
 3,'tatianealves.7523637@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANE ALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANE ALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8020523  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANE APARECIDA LOPES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8020523, 
 3,'tatianelopes.8020523@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANE APARECIDA LOPES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANE APARECIDA LOPES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7714513  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TATIANE MARION SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7714513, 
 3,'tatianesantos.7714513@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TATIANE MARION SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TATIANE MARION SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7979495  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TAYNA MOURA SIMOES GOIABEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7979495, 
 3,'taynagoiabeira.7979495@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TAYNA MOURA SIMOES GOIABEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TAYNA MOURA SIMOES GOIABEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7982453  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TELMA MARIA RIBEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7982453, 
 3,'telmaribeiro.7982453@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TELMA MARIA RIBEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TELMA MARIA RIBEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5841186  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TERESA CRISTINA DOS SANTOS FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5841186, 
 3,'teresaferreira.5841186@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TERESA CRISTINA DOS SANTOS FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TERESA CRISTINA DOS SANTOS FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9111450  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAILA VALERIA CARVALHO SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9111450, 
 3,'thailasilva.9111450@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAILA VALERIA CARVALHO SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAILA VALERIA CARVALHO SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7763425  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS BLASIO MARTINS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7763425, 
 3,'thaismartins.7763425@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS BLASIO MARTINS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS BLASIO MARTINS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8405361  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS CRISTINA ALVES DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8405361, 
 3,'thaisaraujo.8405361@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS CRISTINA ALVES DE ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS CRISTINA ALVES DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8242119  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS DA CRUZ HEER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8242119, 
 3,'thaisheer.8242119@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS DA CRUZ HEER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS DA CRUZ HEER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9115986  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS DE OLIVEIRA SANTOS AVELAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9115986, 
 3,'thaisavelar.9115986@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS DE OLIVEIRA SANTOS AVELAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS DE OLIVEIRA SANTOS AVELAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9187481  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS DOS SANTOS NAZARETH'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9187481, 
 3,'thaisnazareth.9187481@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS DOS SANTOS NAZARETH'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS DOS SANTOS NAZARETH'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7707151  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS FERNANDES SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7707151, 
 3,'thaissilva.7707151@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS FERNANDES SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS FERNANDES SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8274444  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THAIS MARTINS ROGERIO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8274444, 
 3,'thaisrogerio.8274444@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THAIS MARTINS ROGERIO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THAIS MARTINS ROGERIO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8786721  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THALITA CRISTINA BORGES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8786721, 
 3,'thalitaborges.8786721@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THALITA CRISTINA BORGES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THALITA CRISTINA BORGES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8410470  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THIAGO DE OLIVEIRA SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8410470, 
 3,'thiagosantos.8410470@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THIAGO DE OLIVEIRA SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THIAGO DE OLIVEIRA SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7918534  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THIAGO FABIANO BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7918534, 
 3,'thiagobrito.7918534@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THIAGO FABIANO BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THIAGO FABIANO BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7906943  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THIAGO FERNANDO FERREIRA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7906943, 
 3,'thiagocosta.7906943@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THIAGO FERNANDO FERREIRA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THIAGO FERNANDO FERREIRA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8492077  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THIAGO PACHECO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8492077, 
 3,'thiagopacheco.8492077@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THIAGO PACHECO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THIAGO PACHECO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8208077  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THIAGO PEREIRA SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8208077, 
 3,'thiagosouza.8208077@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THIAGO PEREIRA SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THIAGO PEREIRA SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8161682  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario THIAGO SOUZA FIJOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8161682, 
 3,'thiagosouza.8161682@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('THIAGO SOUZA FIJOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario THIAGO SOUZA FIJOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8418942  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TIEMI KERR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8418942, 
 3,'tiemikerr.8418942@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TIEMI KERR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TIEMI KERR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6928081  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario TIRZA SIMOES SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6928081, 
 3,'tirzasantos.6928081@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('TIRZA SIMOES SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario TIRZA SIMOES SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9176349  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario UALACE ABADE MACHADO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9176349, 
 3,'ualacemachado.9176349@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('UALACE ABADE MACHADO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario UALACE ABADE MACHADO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6754198  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario UELINTON DE SEIXAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6754198, 
 3,'uelintonseixas.6754198@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('UELINTON DE SEIXAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario UELINTON DE SEIXAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8085269  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VALDIMIR COELHO PINHEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8085269, 
 3,'valdimirpinheiro.8085269@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VALDIMIR COELHO PINHEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VALDIMIR COELHO PINHEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7405863  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VALDIRENE PIRES FLORIANO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7405863, 
 3,'valdirenefloriano.7405863@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VALDIRENE PIRES FLORIANO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VALDIRENE PIRES FLORIANO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7467702  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VALDOILA BEZERRA DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7467702, 
 3,'valdoilasouza.7467702@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VALDOILA BEZERRA DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VALDOILA BEZERRA DE SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8110387  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VALERIA ROMA DE FREITAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8110387, 
 3,'valeriafreitas.8110387@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VALERIA ROMA DE FREITAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VALERIA ROMA DE FREITAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8182116  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VALERIA TORRES CASEMIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8182116, 
 3,'valeriacasemiro.8182116@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VALERIA TORRES CASEMIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VALERIA TORRES CASEMIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6784275  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANDERLANIA PEREIRA DE ANDRADE FIGUEIREDO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6784275, 
 3,'vanderlaniafigueiredo.6784275@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANDERLANIA PEREIRA DE ANDRADE FIGUEIREDO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANDERLANIA PEREIRA DE ANDRADE FIGUEIREDO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7331215  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANDREIA CRISTIAN DE OLIVEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7331215, 
 3,'vandreiaoliveira.7331215@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANDREIA CRISTIAN DE OLIVEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANDREIA CRISTIAN DE OLIVEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8114633  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANESSA APARECIDA NOGUEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8114633, 
 3,'vanessanogueira.8114633@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANESSA APARECIDA NOGUEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANESSA APARECIDA NOGUEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161651  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANESSA ARAUJO DIAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161651, 
 3,'vanessadias.9161651@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANESSA ARAUJO DIAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANESSA ARAUJO DIAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8796114  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANESSA CONDE CARVALHO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8796114, 
 3,'vanessacarvalho.8796114@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANESSA CONDE CARVALHO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANESSA CONDE CARVALHO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8158401  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANESSA DA COSTA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8158401, 
 3,'vanessacosta.8158401@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANESSA DA COSTA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANESSA DA COSTA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7507241  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANESSA EROICO LAMEIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7507241, 
 3,'vanessalameira.7507241@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANESSA EROICO LAMEIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANESSA EROICO LAMEIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7978791  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VANESSA PEREIRA DE ARAUJO SZCZERBOWSKI'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7978791, 
 3,'vanessaszczerbowski.7978791@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VANESSA PEREIRA DE ARAUJO SZCZERBOWSKI'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VANESSA PEREIRA DE ARAUJO SZCZERBOWSKI'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7779208  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VERA BEATRIZ DE ALMEIDA ALBA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7779208, 
 3,'veraalba.7779208@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VERA BEATRIZ DE ALMEIDA ALBA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VERA BEATRIZ DE ALMEIDA ALBA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7368844  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VERA LENY SILVA PASTORE'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7368844, 
 3,'verapastore.7368844@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VERA LENY SILVA PASTORE'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VERA LENY SILVA PASTORE'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7789238  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VERONICA BOMFIM DE AGUIAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7789238, 
 3,'veronicaaguiar.7789238@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VERONICA BOMFIM DE AGUIAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VERONICA BOMFIM DE AGUIAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161708  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VICTORIA SANCHES PEREIRA GIMENEZ'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161708, 
 3,'victoriagimenez.9161708@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VICTORIA SANCHES PEREIRA GIMENEZ'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VICTORIA SANCHES PEREIRA GIMENEZ'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7768664  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VILMA APARECIDA GALHEGO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7768664, 
 3,'vilmagalhego.7768664@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VILMA APARECIDA GALHEGO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VILMA APARECIDA GALHEGO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8282811  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VILMA FERREIRA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8282811, 
 3,'vilmaferreira.8282811@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VILMA FERREIRA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VILMA FERREIRA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8862958  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VINICIUS AUGUSTO DO PRADO MELLO SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8862958, 
 3,'viniciussouza.8862958@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VINICIUS AUGUSTO DO PRADO MELLO SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VINICIUS AUGUSTO DO PRADO MELLO SOUZA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7980302  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VINICIUS ROLIM DELLANAVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7980302, 
 3,'viniciusdellanava.7980302@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VINICIUS ROLIM DELLANAVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VINICIUS ROLIM DELLANAVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8106461  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VITOR DE MATTOS NASCIMENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8106461, 
 3,'vitornascimento.8106461@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VITOR DE MATTOS NASCIMENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VITOR DE MATTOS NASCIMENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6506828  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE APARECIDA RODRIGUES PINTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6506828, 
 3,'vivianepinto.6506828@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE APARECIDA RODRIGUES PINTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE APARECIDA RODRIGUES PINTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8285713  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE FERRI ROSS PERUCHA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8285713, 
 3,'vivianeperucha.8285713@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE FERRI ROSS PERUCHA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE FERRI ROSS PERUCHA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8961387  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE MARIA DA ROCHA BRITO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8961387, 
 3,'vivianebrito.8961387@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE MARIA DA ROCHA BRITO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE MARIA DA ROCHA BRITO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7807741  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE RIBEIRO VILAS BOAS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7807741, 
 3,'vivianeboas.7807741@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE RIBEIRO VILAS BOAS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE RIBEIRO VILAS BOAS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7240431  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VIVIANE ROLIM'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7240431, 
 3,'vivianerolim.7240431@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VIVIANE ROLIM'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VIVIANE ROLIM'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7371705  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario VLADIMIR MANDELLI BARBOSA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7371705, 
 3,'vladimirbarbosa.7371705@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('VLADIMIR MANDELLI BARBOSA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario VLADIMIR MANDELLI BARBOSA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9255699  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAGNER EMIDIO XAVIER'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9255699, 
 3,'wagnerxavier.9255699@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAGNER EMIDIO XAVIER'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAGNER EMIDIO XAVIER'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7806507  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALESKA BIANCA MARCONDES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7806507, 
 3,'waleskamarcondes.7806507@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALESKA BIANCA MARCONDES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALESKA BIANCA MARCONDES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 9161376  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WALKIRIA APARECIDA ISIDORO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 9161376, 
 3,'walkiriaisidoro.9161376@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WALKIRIA APARECIDA ISIDORO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WALKIRIA APARECIDA ISIDORO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8416711  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WAYNE TEIXEIRA GONCALVES'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8416711, 
 3,'waynegoncalves.8416711@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WAYNE TEIXEIRA GONCALVES'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WAYNE TEIXEIRA GONCALVES'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7405413  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELINGTON MATIAS DOS SANTOS SILVA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7405413, 
 3,'welingtonsilva.7405413@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELINGTON MATIAS DOS SANTOS SILVA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELINGTON MATIAS DOS SANTOS SILVA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7348053  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WELLINGTON DE OLIVEIRA ALENCAR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7348053, 
 3,'wellingtonalencar.7348053@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WELLINGTON DE OLIVEIRA ALENCAR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WELLINGTON DE OLIVEIRA ALENCAR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6782906  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WENDEL DI PAOLA DO CARMO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6782906, 
 3,'wendelcarmo.6782906@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WENDEL DI PAOLA DO CARMO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WENDEL DI PAOLA DO CARMO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7938501  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WERLEN MORAIS DOS SANTOS'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7938501, 
 3,'werlensantos.7938501@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WERLEN MORAIS DOS SANTOS'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WERLEN MORAIS DOS SANTOS'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8224111  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILIANS DE ARAUJO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8224111, 
 3,'wiliansaraujo.8224111@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILIANS DE ARAUJO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILIANS DE ARAUJO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8820163  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILLIAN GABELON FURLAN'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8820163, 
 3,'willianfurlan.8820163@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILLIAN GABELON FURLAN'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILLIAN GABELON FURLAN'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7922329  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON DE CARVALHO JUNIOR'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7922329, 
 3,'wilsonjunior.7922329@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON DE CARVALHO JUNIOR'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON DE CARVALHO JUNIOR'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8972915  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario WILSON NOEL PAILO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8972915, 
 3,'wilsonpailo.8972915@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('WILSON NOEL PAILO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario WILSON NOEL PAILO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 7365462  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YEDA PEIXINHO BENTO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 7365462, 
 3,'yedabento.7365462@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YEDA PEIXINHO BENTO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YEDA PEIXINHO BENTO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 8410631  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario YOLANDA OLIVEIRA SALGUEIRO'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 8410631, 
 3,'yolandasalgueiro.8410631@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('YOLANDA OLIVEIRA SALGUEIRO'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario YOLANDA OLIVEIRA SALGUEIRO'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 6684823  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZELIA JORGE PESSOA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 6684823, 
 3,'zeliapessoa.6684823@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZELIA JORGE PESSOA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZELIA JORGE PESSOA'; 
 END IF; 

IF EXISTS (SELECT * from usuarios where id = 5810876  and usuario_tipo = 3 limit 1) THEN
 raise notice 'Já existe o usuario ZENILSON JOSE DE SOUZA'; 
 ELSE 
INSERT INTO public.usuarios 
(id, usuario_tipo, email, organization_path, data_inclusao, data_atualizacao, nome, cpf, google_classroom_id, existe_google) 
 VALUES(
 5810876, 
 3,'zenilsonsouza.5810876@edu.sme.prefeitura.sp.gov.br', '/funcionarios', now()
 , NULL, upper('ZENILSON JOSE DE SOUZA'),
 null, NULL, true); 
 raise notice 'Adicionado o usuario ZENILSON JOSE DE SOUZA'; 
 END IF; 

END 
$do$ 

