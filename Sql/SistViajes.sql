

USE master
go

IF EXISTS(SELECT * FROM sysdatabases WHERE name='SistViaje')
    begin
	DROP DATABASE SistViaje
	--GO
    end
go

CREATE DATABASE SistViaje  
go

USE SistViaje  
go

CREATE  table Chofer (
	IDCOD char(4)   NOT NULL Primary key ,
	CHONOM varchar (30) NULL ,
	CHOFIN date NULL ,
	CHOCAT varchar (2) NULL ,
	CHOSBA numeric(8, 0) NULL ,
	CHOIMG Varchar(120)
)   
go

CREATE TABLE Bus (
	BUSNRO int identity(1,1) primary key ,
	BUSPLA varchar (8) NULL , -- Placa
	BUSCAP numeric (8, 0) NULL 
)   
go

CREATE TABLE Ruta (
	RUTCOD varchar (8) NOT NULL Primary Key ,
	RUTNOM varchar (20) NULL ,
	PAGOOCHO numeric(8, 0) NULL ,
	RUTIMG varchar(120)
)   
go

CREATE TABLE Viaje (
	VIANRO char (6) NOT NULL Primary key,
	BUSNRO int  ,
	RUTCOD varchar (8) NULL ,
	IDCOD  char (4)  ,
	VIAHRS char(5)  ,
	VIAFCH date  ,
    COSVIA numeric(8,0) ,
	foreign key(BUSNRO) references BUS(BUSNRO) ,
	foreign key(RUTCOD) references RUTA(RUTCOD) ,
	foreign key(IDCOD) references CHOFER(IDCOD) 
)  
go

CREATE TABLE Pasajeros (
	BOLNRO char (6) NOT NULL primary key ,
	VIANRO char(6) NULL ,
	NOM_PAS varchar (30) NULL ,
	NRO_ASI int NULL,
    TIPO char(1) null,
    PAGO numeric(8,0) null ,
	foreign key(VIANRO) references VIAJE(VIANRO)
)   
go

CREATE TABLE Usuarios (
    codusr int identity primary key ,
    Nombre varchar(30) not NULL ,  
	usuario varchar(10) NOT NULL  ,
	clave  varchar(10) not NULL 
)
go


insert into usuarios values('Raul Salazar' ,'admin','123456')
insert into usuarios values('Juan Castillo' ,'juan12','alfa')

  ---- LENAR TABLA RUTA

INSERT INTO RUTA VALUES ('LMTR','Trujillo',15 , 'TRUJILLO.jpg')  
INSERT INTO RUTA VALUES ('LMCZ','Cuzco',50 , 'CUZCO.jpg')  
INSERT INTO RUTA VALUES ('LMAR','Arequipa',35 , 'AREQUIPA.jpg')  
INSERT INTO RUTA VALUES ('LMHA','Huancavelica', 200 , 'HUANCAVELICA.jpg')  
INSERT INTO RUTA VALUES ('LMTA','Tacna', 300 , 'TACNA.jpg')  
INSERT INTO RUTA VALUES ('LMCH','Chiclayo', 80 , 'CHICLAYO.jpg')  
INSERT INTO RUTA VALUES ('LMIC','Ica', 50 , 'ICA.jpg')  
INSERT INTO RUTA VALUES ('LMHZ','Huaraz', 70 , 'HUARAZ.jpg')  
INSERT INTO RUTA VALUES ('LMHC','Huanuco', 120, 'HUANUCO.jpg')  
INSERT INTO RUTA VALUES ('LMAY','Ayacucho', 170 , 'AYACUCHO.jpg')  
  ---- LLENAR TABLA CHOFER

INSERT INTO CHOFER VALUES ('C001','Patricio Herrera','1999-08-10','P',350 , 'chofer01.jpg')  
INSERT INTO CHOFER VALUES ('C002','Jorge Quispe','1997-12-05','S',200 , 'chofer02.jpg')  
INSERT INTO CHOFER VALUES ('C003','Edward Temple','1995-02-11','S',450  , 'chofer03.jpg')  
INSERT INTO CHOFER VALUES ('C004','Elmer Morales','1999-07-10','P',550 , 'chofer04.jpg')  
INSERT INTO CHOFER VALUES ('C005','Marcos Cueva','1997-05-04','P',650 , 'chofer05.jpg')  
INSERT INTO CHOFER VALUES ('C006','Luis Prieto','2003-05-04','S',350 , 'chofer06.jpg')  
INSERT INTO CHOFER VALUES ('C007','Eloy Lazo','2000-04-05','P',350 , 'chofer07.jpg')  
INSERT INTO CHOFER VALUES ('C008','Jaime Benavidez','2001-05-04','S',350 , 'chofer08.jpg')  


  ----LLENAR TABLA BUS
INSERT INTO BUS VALUES ('WH2145',40 )  
INSERT INTO BUS VALUES ('MN1975',60 )  
INSERT INTO BUS VALUES ('PQ5478',50 )  
INSERT INTO BUS VALUES ('RP7812',40 )  
INSERT INTO BUS VALUES ('TP3547',40 )  

  ---- LLANAR TABLA VIAJE

INSERT INTO VIAJE VALUES ('100001',1,'LMTA','C001','10:30','2020-04-20',70)  
INSERT INTO VIAJE VALUES ('100002',2,'LMTA','C002','09:30','2020-04-20',60)  
INSERT INTO VIAJE VALUES ('100003',3,'LMCZ','C003','11:30','2020-04-29',80)  
INSERT INTO VIAJE VALUES ('100004',2,'LMCZ','C002','08:00','2020-04-20',90)  
INSERT INTO VIAJE VALUES ('100005',1,'LMIC','C007','13:30','2020-04-20',60)  
INSERT INTO VIAJE VALUES ('100006',4,'LMIC','C003','15:00','2020-04-24',50)  
INSERT INTO VIAJE VALUES ('100007',5,'LMHZ','C002','21:30','2020-04-28',50)  
INSERT INTO VIAJE VALUES ('100008',1,'LMHZ','C001','12:30','2020-04-26',60)  
INSERT INTO VIAJE VALUES ('100009',3,'LMCH','C004','18:30','2020-04-20',70)  
INSERT INTO VIAJE VALUES ('100010',4,'LMTR','C003','19:00','2020-04-25',70)  
INSERT INTO VIAJE VALUES ('100011',2,'LMCZ','C005','19:40','2020-04-20',80)  
INSERT INTO VIAJE VALUES ('100012',3,'LMIC','C003','17:00','2020-04-24',70)  
INSERT INTO VIAJE VALUES ('100013',3,'LMHA','C002','18:40','2020-04-22',90)  
INSERT INTO VIAJE VALUES ('100014',4,'LMAY','C003','19:00','2020-04-20',30)  
INSERT INTO VIAJE VALUES ('100015',1,'LMTA','C002','19:00','2020-04-21',40)  
INSERT INTO VIAJE VALUES ('100016',1,'LMCZ','C001','17:00','2020-04-20',50)  
INSERT INTO VIAJE VALUES ('100017',4,'LMAR','C002','19:00','2020-04-23',70)  
INSERT INTO VIAJE VALUES ('100018',2,'LMTR','C005','15:00','2020-04-27',60)  
INSERT INTO VIAJE VALUES ('100019',3,'LMTR','C004','19:00','2020-04-26',60)  
INSERT INTO VIAJE VALUES ('100020',4,'LMAY','C005','19:00','2020-04-20',70)  

INSERT INTO VIAJE VALUES ('100021',3,'LMTR','C007','19:00','2020-05-23',60)  
INSERT INTO VIAJE VALUES ('100022',4,'LMAY','C007','19:00','2020-05-20',70)  
INSERT INTO VIAJE VALUES ('100023',2,'LMAY','C003','12:00','2020-01-20',90) 
INSERT INTO VIAJE VALUES ('100024',1,'LMTR','C004','10:00','2020-02-15',90)  
INSERT INTO VIAJE VALUES ('100025',1,'LMIC','C006','08:00','2020-03-11',90)   


INSERT INTO pasajeros VALUES ('000001','100001','Clauda Vasquez',1,'E',40)  
INSERT INTO pasajeros VALUES ('000002','100002','Carlos Paredes',2,'A' ,50)  
INSERT INTO pasajeros VALUES ('000003','100001','Juan Sanchez',3,'A' ,70)  
INSERT INTO pasajeros VALUES ('000004','100001','Adela Meza',4,'N' ,70)  
INSERT INTO pasajeros VALUES ('000005','100002','Gloria Delgado',12,'N' ,60)  
INSERT INTO pasajeros VALUES ('000006','100001','Virma Mejia',6,'E' ,70)  
INSERT INTO pasajeros VALUES ('000007','100001','Jose Linares',7,'A',70)  
INSERT INTO pasajeros VALUES ('000008','100002','Jenifer Cruzado',8,'A' ,50)  
INSERT INTO pasajeros VALUES ('000009','100002','Ramon Cercado',9,'A' ,50)  
INSERT INTO pasajeros VALUES ('000010','100001','Teresa Edgar',10,'A' ,20)  
INSERT INTO pasajeros VALUES ('000011','100001','Carolina Retamozo',11,'N',30)  
INSERT INTO pasajeros VALUES ('000012','100002','Shandy Paredes',12,'A' ,40)  
INSERT INTO pasajeros VALUES ('000013','100001','Nurith Guillen',13,'A',70)  
INSERT INTO pasajeros VALUES ('000014','100002','Daniel Vergara',14,'N',50)  
INSERT INTO pasajeros VALUES ('000015','100001','Johana Lopez',10,'A',70)  
INSERT INTO pasajeros VALUES ('000016','100003','huachua Ernestina',11,'E' ,70)  
INSERT INTO pasajeros VALUES ('000017','100004','Cardenas Juana',5,'A',70)  
INSERT INTO pasajeros VALUES ('000018','100004','Leon Malpartida',2,'A' ,50)  
INSERT INTO pasajeros VALUES ('000019','100004','Gonzales carrillo',4,'N' ,70)  
INSERT INTO pasajeros VALUES ('000020','100005','Mio Gamboa',7,'A' ,70)  
INSERT INTO pasajeros VALUES ('000021','100005','Maldonado Huaman',11,'A' ,70)  
INSERT INTO pasajeros VALUES ('000022','100005','Gaspar Acosta',14,'E' ,60)  
INSERT INTO pasajeros VALUES ('000023','100006','Echegaray Felix',10,'E' ,60)  
INSERT INTO pasajeros VALUES ('000024','100006','Cano Siu',8,'N' ,70)  
INSERT INTO pasajeros VALUES ('000025','100006','Melgarejo percy',9,'N',70)  
INSERT INTO pasajeros VALUES ('000026','100006','Grijalva Alan ',13,'A' ,70)  
INSERT INTO pasajeros VALUES ('000027','100007','Marin LOPEZ',5,'A' ,70)  
INSERT INTO pasajeros VALUES ('000028','100007','Johana Lopez',14,'A',70)  
INSERT INTO pasajeros VALUES ('000029','100008','huachua Ernestina',11,'N',70)  
INSERT INTO pasajeros VALUES ('000030','100008','Cardenas Juana',5,'E',70)  
INSERT INTO pasajeros VALUES ('000031','100009','Leon Malpartida',2,'N' ,70)  
INSERT INTO pasajeros VALUES ('000032','100009','Gonzales carrillo',4,'E' ,70)  
INSERT INTO pasajeros VALUES ('000033','100010','Mio Gamboa',7,'E' ,70)  
INSERT INTO pasajeros VALUES ('000034','100011','Maldonado Huaman',11,'A' ,70)  
INSERT INTO pasajeros VALUES ('000035','100012','Gaspar Acosta',14,'N',70)  
INSERT INTO pasajeros VALUES ('000036','100013','Echegaray Felix',10,'A' ,70)  
INSERT INTO pasajeros VALUES ('000037','100014','Cano Siu',08,'E' ,70)  
INSERT INTO pasajeros VALUES ('000038','100015','Melgarejo percy',09,'N' ,70)  
INSERT INTO pasajeros VALUES ('000039','100016','Grijalva Alan ',13,'A' ,70)  
INSERT INTO pasajeros VALUES ('000040','100017','Marin LOPEZ',5,'N' ,70)  
INSERT INTO pasajeros VALUES ('000041','100018','Johana Lopez',14,'E' ,70)  

INSERT INTO pasajeros VALUES ('000042','100019','Cama Roxama',2,'N' ,70)  
INSERT INTO pasajeros VALUES ('000043','100019','Lopez Donayre, juan',4,'E' ,70)  
INSERT INTO pasajeros VALUES ('000044','100019','Lopez Vera, Ana',7,'E' ,70)  
INSERT INTO pasajeros VALUES ('000045','100020','Maldonado Huaman',11,'A' ,70)  
INSERT INTO pasajeros VALUES ('000046','100020','Diaz Gaspar Alicia',14,'N',70)  
INSERT INTO pasajeros VALUES ('000047','100020','Pezo Zuta Eliana',10,'A' ,70)  
INSERT INTO pasajeros VALUES ('000048','100021','Carrasco Cano Maribel',08,'E' ,70)  
INSERT INTO pasajeros VALUES ('000049','100021','Quispe Rojas, percy',09,'N' ,70)  
INSERT INTO pasajeros VALUES ('000050','100021','Grijalva Alan ',13,'A' ,70)  
INSERT INTO pasajeros VALUES ('000051','100022','Marin LOPEZ',5,'N' ,70)  
INSERT INTO pasajeros VALUES ('000052','100023','Mauricio Jimenez',1,'E',63)  
INSERT INTO pasajeros VALUES ('000053','100023','Jose Salazar',2,'E',63)  
INSERT INTO pasajeros VALUES ('000054','100023','Alan Paucar',3,'A',90)  
INSERT INTO pasajeros VALUES ('000055','100023','Jimena Sanchez',4,'A',90)  
INSERT INTO pasajeros VALUES ('000056','100023','Raul Rodriguez',5,'A',90)  
INSERT INTO pasajeros VALUES ('000057','100023','Abelardo Quispe',6,'A',90)  

INSERT INTO pasajeros VALUES ('000058','100024','Raul Abelardo Quispe',1,'A',90)  
INSERT INTO pasajeros VALUES ('000059','100024','Andrea Basilio',4,'A',90)  
INSERT INTO pasajeros VALUES ('000060','100024','Romina Rodriguez',5,'A',90)  
INSERT INTO pasajeros VALUES ('000061','100024','Dayana Aaron',6,'A',90)  
INSERT INTO pasajeros VALUES ('000062','100024','Samir Aguilar',7,'A',90)  
INSERT INTO pasajeros VALUES ('000063','100024','Miguel Dextre',8,'E',63)  
INSERT INTO pasajeros VALUES ('000064','100024','Rosa Cardenas',9,'A',90)  
INSERT INTO pasajeros VALUES ('000065','100024','Jimena Thebaziel',11,'A',90)  
INSERT INTO pasajeros VALUES ('000066','100024','Alan Fuentes',12,'A',90)  
INSERT INTO pasajeros VALUES ('000067','100024','Bryan Cardenas',13,'E',63)  
INSERT INTO pasajeros VALUES ('000068','100024','Dayana Zulman',17,'A',90)  
INSERT INTO pasajeros VALUES ('000069','100024','Juan Quispe',18,'A',90)  

INSERT INTO pasajeros VALUES ('000070','100025','Bryan Cardenas',6,'E',63)  
INSERT INTO pasajeros VALUES ('000071','100025','Ericka Zulman',4,'A',90)  
INSERT INTO pasajeros VALUES ('000072','100025','Joseph Quispe',7,'A',90)  
INSERT INTO pasajeros VALUES ('000073','100025','Bryan Bazo',9,'E',63)  
INSERT INTO pasajeros VALUES ('000074','100025','Raul Huaman',11,'A',90)  
INSERT INTO pasajeros VALUES ('000075','100025','Juan Quispe',12,'A',90)  
INSERT INTO pasajeros VALUES ('000076','100025','Bryan Cardenas',13,'E',63)  
INSERT INTO pasajeros VALUES ('000077','100025','Adely Barrantes',14,'A',90)  
INSERT INTO pasajeros VALUES ('000078','100025','Juan Sanchez',18,'A',90)  
go


create procedure sp_adicionar_chofer
(
@nomChofer varchar(30),
@fechaIng date ,
@categoria varchar(1),
@costo numeric(8,0) ,
 @foto varchar(120)
)
as
begin
  declare @cuenta int
  declare @codigo char(4)
  select @cuenta = isnull(SUBSTRING(max(idcod),2,3),0) + 1 from chofer

  set @codigo = 'C' + RIGHT('000'+LTRIM(@cuenta),3)

  insert into chofer values(@codigo , @nomChofer ,@fechaIng , @categoria , @costo , @foto )
end
go


create procedure sp_adicionar_pasajeros
(
@VIA CHAR(6),@NOM VARCHAR(30), @ASI INT ,
@TP CHAR(1), @PG NUMERIC(8,0) 
)
AS
BEGIN
  DECLARE @BOL CHAR(6),@CUENTA INT
  SELECT @CUENTA=ISNULL(MAX(BOLNRO),0)+1 FROM pasajeros
  SET @BOL=RIGHT('00000'+LTRIM(@CUENTA),6)
  INSERT INTO pasajeros VALUES(@BOL,@VIA,@NOM,@ASI,@TP,@PG)
END
go

create procedure sp_iniciar_sesion
(
@user varchar(50) ,
@pass varchar(50)
)
as
begin
   select * from usuarios
   where usuario = @user and clave = @pass
end
go


create procedure sp_reporte_cant_chofer
as
begin
  select CHONOM as 'chofer', count(*) as 'cant'
  from pasajeros p inner join viaje v
  on v.VIANRO = p.VIANRO
  inner join chofer c
  on c.IDCOD = v.IDCOD
  group by CHONOM
  end
go

create procedure sp_logear
(
@user varchar(50) ,
@pass varchar(50)
)
as
begin
   select * from usuarios
   where usuario = @user and clave = @pass
end
go


create procedure sp_adicionar_viaje
(
@bus int ,
@ruta char(8) ,
@chofer char(8) ,
@hora char(10) ,
@fecha date,
@costo numeric(8,2)
)
as
begin
  declare @cuenta int
  select  @cuenta = isnull(max(vianro),100000) + 1 from viaje
  insert into viaje values(@cuenta , @bus , @ruta , @chofer , @hora , @fecha , @costo)
end
go

create procedure sp_reporte_total_ruta
as
begin
  select RUTNOM as 'ruta', SUM(PAGO)as 'total'
  from pasajeros p inner join viaje v
  on v.VIANRO = p.VIANRO
  inner join ruta r
  on r.RUTCOD = v.RUTCOD
  group by RUTNOM
end
go


create procedure sp_reporte_total_mes(@anio int)
as
begin
  select MONTH(VIAFCH) as 'nro' , DATENAME(MONTH , VIAFCH) as 'mes', sum(PAGO) as 'total'
  from Viaje v inner join Pasajeros p
  on p.VIANRO = v.VIANRO
  where YEAR(VIAFCH) = @anio
  group by MONTH(VIAFCH) , DATENAME(MONTH , VIAFCH)
  order by MONTH(VIAFCH)  asc
end
go




execute sp_reporte_total_ruta

execute sp_reporte_cant_chofer

execute sp_reporte_total_mes 2020


