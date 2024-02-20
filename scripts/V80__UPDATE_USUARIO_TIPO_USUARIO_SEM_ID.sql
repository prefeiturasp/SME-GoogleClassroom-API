update usuarios 
set usuario_tipo =4
where cpf notnull  and id isnull 
and organization_path ='/funcionarios';