CREATE DATABASE IF NOT EXISTS pansiyon;
USE pansiyon;

CREATE TABLE IF NOT EXISTS musteri (
    tckimlik VARCHAR(11) PRIMARY KEY,
    ad VARCHAR(50),
    soyad VARCHAR(50),
    tel VARCHAR(15),
    cinsiyet VARCHAR(10),
    odano INT,
    yatakno INT
);