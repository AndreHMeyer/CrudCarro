CREATE DATABASE dbTrabalho06;

USE dbTrabalho06;

CREATE TABLE marca (
	id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50),
    PRIMARY KEY (id)
);

CREATE TABLE modelo (
	id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50),
    idMarca int,
    PRIMARY KEY (id),
    FOREIGN KEY (idMarca) REFERENCES marca(id)
);

CREATE TABLE carro (
	id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50),
    renavam INT,
    placa VARCHAR(7),
    valor DECIMAL(10,2),
    ano YEAR,
    idModelo INT,
    PRIMARY KEY (id),
    FOREIGN KEY (idModelo) REFERENCES modelo(id)
);
    