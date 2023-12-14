use master;
go
drop database if exists edunovawp3;
go
-- ovo je komentar
create database edunovawp3 collate Croatian_CI_AS;
go
--drop database edunovawp3;
--use master
use edunovawp3;

create table smjerovi(
sifra int not null primary key identity(1,1),
naziv varchar(50) not null,
trajanje int null, --null se ne piše. Ako ne piše not null onda se podrazumjeva null
cijena decimal(18,2), -- iako ništa ne piše je null
vaucer bit
);

create table grupe(

	sifra			int			not null primary key identity(1,1),
	naziv			varchar(5)	not null,
	smjer			int			not null,
	datumpocetka	datetime,
	maxpolaznika	int			not null,
	predavac		int

);


create table polaznici(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
email varchar(100),
oib char(11),
brojugovora varchar(10)
);

create table predavaci(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
email varchar(100) not null,
oib char(11),
iban varchar(50)
);

-- ako nešto pogriješim onda mogu obrisati tablicu pa ponovo kreirati
--drop table predavaci;


create table clanovi(
grupa int not null,
polaznik int not null
);

-- kreiranje vanjskih ključeva
alter table grupe add foreign key (smjer) references smjerovi(sifra);
alter table grupe add foreign key (predavac) references predavaci(sifra);

alter table clanovi add foreign key (grupa) references grupe(sifra);
alter table clanovi add foreign key (polaznik) references polaznici(sifra);










