create database bdApiGithub;
use bdApiGithub;

/* API_Github: */

CREATE TABLE Usuario (
    login_Usu varchar(150) PRIMARY KEY,
    nome_Usu varchar(150),
    num_Repos Int,
    num_Seg Int,
    num_Seg_Repos Int,
    Email varchar(150),
    Bio varchar(300),
    ultimo_update varchar(50)
);

CREATE TABLE Respositorio (
    id_Repos varchar(150) PRIMARY KEY,
    nome_Repos varchar(150),
    Linguagem varchar(50),
    ultimo_Commit varchar(50),
    Stargazes Int,
    Descricao varchar(250),
    topicos varchar(150),
    Num_seg_Repos Int,
    Num_Whatcher_Repos int,
    Num_contribuidores Int,
    Privado Boolean,
    login_Usu varchar(150)
);

CREATE TABLE Seguidores (
    id_Seg varchar(150) PRIMARY KEY,
    nome_Seg varchar(150),
    LinkFoto varchar(150)
);
CREATE TABLE Relacionamento_1 (
    fk_User_login String,
    fk_Seguidor_idseg String
);
 
ALTER TABLE Respositorio ADD CONSTRAINT FK_Respositorio_2
    FOREIGN KEY (login_Usu)
    REFERENCES Usuario (login_Usu);
 
ALTER TABLE Relacionamento_1 ADD CONSTRAINT FK_Relacionamento_1_1
    FOREIGN KEY (fk_User_login)
    REFERENCES Usuario (login_Usu)
    ON DELETE RESTRICT;
 
ALTER TABLE Relacionamento_1 ADD CONSTRAINT FK_Relacionamento_1_2
    FOREIGN KEY (fk_Seguidor_idseg)
    REFERENCES Seguidores (id_Seg)
    ON DELETE SET NULL;

delimiter $$
create procedure SpaddUser ()
begin
insert into 
end
$$
