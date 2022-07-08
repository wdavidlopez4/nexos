# nexos
prueba tecnica empresa nexos

# configuracion de proyecto back end y front end
    
## versiones y recomendaciones
    asp .net core v6 en vs studio 2022
    ef core 6
    ef core oracle 6

# configuracion oracle DB

## ejecucion del comando para el script de oracle
    alter session set "_ORACLE_SCRIPT"=true;

## crear el usuario para la db
    create user c##nexos_db_prueba identified by 123456 default tablespace users quota unlimited on users;

## habilitar todos los permisos al usuario, para que no tengasmo problemas con EF core
    grant connect, resource to c##nexos_db_prueba;

    GRANT ALL PRIVILEGES TO c##nexos_db_prueba
    GRANT EXECUTE ANY PROCEDURE TO c##nexos_db_prueba
    GRANT UNLIMITED TABLESPACE TO c##nexos_db_prueba
    GRANT create table to c##nexos_db_prueba
    GRANT create session to c##nexos_db_prueba

### sugerencia para observar el usuario creado
    select * from all_users

## creamos la nueva coneccion a la db
    image.png

## ruta para cambiar el coneccion string de la DB
    nexos.infrastructure.nexosdbcontext.cs
