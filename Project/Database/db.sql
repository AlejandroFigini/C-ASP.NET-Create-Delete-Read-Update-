create database ProyectoFinal
go 
use ProyectoFinal
go
--Tabla Pais
create table Pais(
Codigo_Pais varchar(3) primary key not null check(len(Codigo_Pais)=3), --Verifico largo de 3 caracteres para Codigo_Pais
Nombre varchar(50) not null,
)
go
--Tabla Ciudad
create table Ciudad(
Codigo_Ciudad varchar(3) not null check(len(Codigo_Ciudad)=3),
Codigo_Pais varchar(3) foreign key references Pais(Codigo_Pais),
Nombre varchar(50) not null,
primary key(Codigo_Pais,Codigo_Ciudad), --Clave primaria compuesta
)
go
--Tabla Usuario
Create table Usuario(
Nombre_Usuario varchar(50) primary key not null,
Contraseña varchar(50) not null,
Nombre_Completo varchar(50) not null,
)
go
--Table Pronostico
Create table Pronostico(
Codigo_Interno int identity primary key,
Usuario varchar(50) foreign key references Usuario(Nombre_Usuario) not null,
Ciudad varchar(3) not null,
Pais varchar(3) not null,
Maxima int not null check(Maxima<55),
Minima int not null check(Minima>-20),
Fecha_Hora datetime  not null, 
VelViento int check(VelViento>0),
Probabilidad int check(Probabilidad between 0 and 100),
Tipo_Cielo varchar(50) check(Tipo_Cielo in ('Despejado','Parcialmente Nuboso','Nuboso')), --Controlo opciones correctas para Tipo_Cielo 
foreign key (Pais,Ciudad) references Ciudad(Codigo_Pais,Codigo_Ciudad),
check(Maxima >=Minima),
)
go

--Datos de Prueba

insert into Pais (Codigo_Pais,Nombre)
			values('URU','Uruguay'),
				('ARG','Argentina'),
				('BRA','Brazil'),
				('CHI','Chile'),
				('POR','Portugal'),
				('CAN','Canada')
go
Insert into Ciudad (Codigo_Ciudad,Codigo_Pais, Nombre)
			values ('Mvd','URU','Montevideo'),
				('Pan','URU','Pando'),
				('Dol','URU','Dolores'),
				('Sal','ARG','Salta'),
				('Bna','ARG','Buenos Aires'),
				('Cor','ARG','Cordoba'),
				('Plt','ARG','Plata'),
				('Rio','BRA','Rio de Janeiro'),
				('Fra','BRA','Fortaleza'),
				('Nat','BRA','Natal'),
				('Pal','BRA','Palmas'),
				('San','CHI','Santiago de Chile'),
				('Pun','CHI','Punta Arenas'),
				('Ari','CHI','Aricas'),
				('Ova','CHI','Ovalle'),
				('Lis','POR','Lisboa'),
				('Far','POR','Faro'),
				('Sin','POR','Sintra'),
				('Tor','CAN','Toronto'),
				('Vic','CAN','Victoria'),
				('Mon','CAN','Montreal'),
				('Sur','CAN','Surrey')

go
Insert into Usuario (Nombre_Usuario, Contraseña, Nombre_Completo)
			Values ('PerezMarcos21','1234marco34','Marco Perez'),
			   	('_AlejoCastro09','5090ing','Alejo Castro'),
				('Sofia_Morales21','9797991NH','Sofia Morales'),
				('_Alejo09','1234','Adrian Masa'),
				('Erramunck21','333344422a','Martin Erramun')

go		
insert into Pronostico(Usuario,Ciudad,Pais,Maxima,Minima,Fecha_Hora,VelViento,Probabilidad,Tipo_Cielo)
			values ('PerezMarcos21','Sal','ARG',25,18,'2022/11/20 12:20',10,60,'Nuboso'),
				('_AlejoCastro09','Dol','URU',20,10,'2022/07/10 13:40',8,40,'Despejado'),
				('_AlejoCastro09','Vic','CAN',20,10,'2022/11/17 13:40',8,40,'Despejado'),
				('PerezMarcos21','Pun','CHI',22,11,'2022/10/10 11:30',15,70,'Parcialmente Nuboso'),
				('PerezMarcos21','Pan','URU',20,10,'2022/11/17 11:30',15,70,'Parcialmente Nuboso'),
				('PerezMarcos21','Pan','URU',23,11,'2022/11/12 11:30',15,70,'Parcialmente Nuboso'),
				('PerezMarcos21','Vic','CAN',18,8,'2022/10/21 12:20',10,60,'Nuboso'),
				('_AlejoCastro09','Lis','POR',20,15,'2022/08/11 13:40',8,40,'Despejado'),
				('_AlejoCastro09','Lis','POR',20,15,'2022/08/11 13:40',8,40,'Despejado')
			
go




											--Procedimientos Almacenados


										--Agregar,Modificar,Eliminar Usuario

--Agregar Usuario
create  procedure AgregarUsuario @Nombre_Usuario varchar(50) , @Nombre_Completo varchar(50), @Contraseña varchar(50) AS 
BEGIN 
	if (EXISTS (SELECT Nombre_Usuario FROM Usuario WHERE Nombre_Usuario=@Nombre_Usuario))
		RETURN -1; --Error de codigo duplicado

	INSERT Usuario( Nombre_Usuario,Nombre_Completo ,Contraseña ) VALUES( @Nombre_Usuario ,@Nombre_Completo,@Contraseña );

	if (@@ERROR !=0)
		return -2 --No se realizo alta
	else
		return 1
END
go

--Modificar Usuario
create procedure ModificarUsuario @Nombre_Usuario varchar(50) , @Nombre_Completo varchar(50), @Contraseña varchar(50) as 
begin
	IF (NOT EXISTS (SELECT Nombre_Usuario FROM Usuario WHERE Nombre_Usuario =@Nombre_Usuario))
		RETURN -1;

	UPDATE Usuario 
	SET Nombre_Completo = @Nombre_Completo WHERE Nombre_Usuario =@Nombre_Usuario;
	
	update Usuario
	set Contraseña = @Contraseña where Nombre_Usuario =@Nombre_Usuario;

	
	IF(@@Error!=0)
		RETURN -2
	ELSE
		RETURN 1
end
go

--Eliminar Usuario
create procedure EliminarUsuario @Nombre_Usuario varchar(50) as 
begin
	IF (  EXISTS (SELECT Nombre_Usuario FROM Usuario WHERE Nombre_Completo =@Nombre_Usuario))
		RETURN 0;
	IF ( EXISTS (SELECT Usuario FROM Pronostico WHERE Usuario =@Nombre_Usuario))
		RETURN 0;

	DELETE Usuario WHERE  Nombre_Usuario =@Nombre_Usuario;

	if (@@ERROR !=0)
		return -2 --No se elimino usuario
	else
		return 1 
end
go

--Buscar Usuario
create procedure BuscarUsuario @Nombre_Usuario varchar(50) as 
begin
	select * from Usuario where Nombre_Usuario=@Nombre_Usuario
end
go

									--Agregar,Modificar,Eliminar Pais
--Agregar Pais
CREATE  PROCEDURE AgregarPais @Codigo_Pais varchar(3) ,@Nombre varchar(50) AS 
BEGIN 
	if (EXISTS (SELECT Codigo_Pais FROM Pais WHERE Codigo_Pais=@Codigo_Pais))
		RETURN -1; --Error de codigo duplicado

	INSERT Pais( Codigo_Pais ,Nombre ) VALUES( @Codigo_Pais ,@Nombre );

	if (@@ERROR !=0)
		return -2 --No se realizo alta
	else
		return 1
END
go

--Modificar Pais
create procedure ModificarPais @Codigo_Pais varchar(3) ,@Nombre varchar(50) as
begin
	if (NOT EXISTS (SELECT Codigo_Pais FROM Pais WHERE Codigo_Pais=@Codigo_Pais))
		RETURN -1; --Error al no tener ingresado pais con dicho codigo

	update Pais set Nombre=@Nombre where Codigo_Pais=@Codigo_Pais;

	if (@@ERROR !=0)
		return -2 --No se realizo Modificacion 
	else
		return 1
end
go

--Eliminar Pais
create procedure EliminarPais @Codigo_Pais varchar(3) as   
begin

	if ( NOT EXISTS (SELECT Codigo_Pais FROM Pais WHERE Codigo_Pais =@Codigo_Pais ))
		return -1

	--si llego aca puedo eliminar
	DECLARE @Error int

	BEGIN TRAN

	DELETE Pronostico	WHERE   Pais=@Codigo_Pais ;
	SET @Error=@@ERROR+@Error;

	DELETE Ciudad WHERE   Codigo_Pais =@Codigo_Pais
	SET @Error=@@ERROR;

	DELETE Pais	WHERE   Codigo_Pais=@Codigo_Pais ;
	SET @Error=@@ERROR+@Error;
			
	IF(@Error=0)
	BEGIN
		COMMIT TRAN;
		RETURN 1;
	END
	ELSE
	BEGIN
		ROLLBACK TRAN;
		RETURN -3;
	END	
end
go

--Buscar Pais
Create procedure BuscarPais @Codigo_Pais varchar(3) as
begin
	select * from Pais where Codigo_Pais=@Codigo_Pais
end
go


									--Agregar,Modificar,Eliminar Ciudad

 --Agregar Ciudad
create procedure AgregarCiudad @Codigo_Ciudad varchar(3), @Codigo_Pais varchar(3), @Nombre varchar(50)as 
begin
	if (not exists (select Codigo_Pais from pais where Codigo_Pais=@Codigo_Pais))
		return -2
	if (EXISTS (SELECT Codigo_Ciudad FROM Ciudad WHERE Codigo_Ciudad=@Codigo_Ciudad and Codigo_Pais=@Codigo_Pais))
		RETURN -1; --Error de codigo duplicado
	

	INSERT Ciudad( Codigo_Ciudad, Codigo_Pais ,Nombre ) VALUES( @Codigo_Ciudad,@Codigo_Pais ,@Nombre );

	if (@@ERROR !=0)
		return -3 --No se realizo alta
	else
		return 1
end
go

--Modificar Ciudad
create procedure ModificarCiudad @Codigo_Ciudad varchar(3), @Codigo_Pais varchar(3), @Nombre varchar(50) as
begin
	IF (NOT EXISTS (SELECT Codigo_Ciudad FROM Ciudad WHERE Codigo_Ciudad =@Codigo_Ciudad and Codigo_Pais=@Codigo_Pais))
		RETURN -1;


	UPDATE Ciudad 
	SET Nombre = @Nombre
	WHERE Codigo_Ciudad =@Codigo_Ciudad and Codigo_Pais =@Codigo_Pais
	

	IF(@@Error!=0)
		RETURN -2
	ELSE
		RETURN 1
end
go

--Eliminar Ciudad
create procedure EliminarCiudad @Codigo_Ciudad varchar(3), @Codigo_Pais varchar(3) as 
begin
	
	IF (NOT EXISTS (SELECT Codigo_Ciudad FROM Ciudad WHERE Codigo_Ciudad =@Codigo_Ciudad and Codigo_Pais=@Codigo_Pais))
		RETURN -1;

	--si llego aca puedo eliminar
	DECLARE @Error int

	BEGIN TRAN

	DELETE Pronostico	WHERE  Ciudad =@Codigo_Ciudad and Pais=@Codigo_Pais ;
	SET @Error=@@ERROR+@Error;

	DELETE Ciudad WHERE  Codigo_Ciudad =@Codigo_Ciudad and Codigo_Pais =@Codigo_Pais
	SET @Error=@@ERROR;
	
	
	
	IF(@Error=0)
	BEGIN
		COMMIT TRAN;
		RETURN 1;
	END
	ELSE
	BEGIN
		ROLLBACK TRAN;
		RETURN -2;
	END	
end
go

--Buscar Ciudad
create procedure BuscarCiudad @Codigo_Ciudad varchar(3) , @Codigo_Pais varchar(3) AS 
begin
	select * from Ciudad where Codigo_Ciudad=@Codigo_Ciudad and Codigo_Pais=@Codigo_Pais
end
go


--Cantidad de pronosticos por Usuario
create procedure CantidadPronosticos_Usuario @Nombre_Usuario varchar(50), @Cant int output as 
begin
	Select @Cant=COUNT(*) From Pronostico where Usuario=@Nombre_Usuario
end
go


--Listar Pronosticos para el dia de la fecha 
create procedure ListarPronosticos_Fecha  @Fecha varchar(50) as 
begin
	select  * from Pronostico where CONVERT(date,Fecha_Hora)=CONVERT (date, @Fecha)
end
go


--Logueo de usuarios
create procedure Logueo @Nombre_Usuario varchar(50), @Contraseña varchar(50) as 
begin
	Select * From Usuario U Where U.Nombre_Usuario = @Nombre_Usuario AND U.Contraseña = @Contraseña
end
go


--Listar Ciudad
Create procedure ListarCiudad as 
begin
	select * from Ciudad
end
go

--Listar Pronosticos por fecha con orden
create procedure ListarPronosticoFechaDescendente as    ---------------------------------------------------------------------------------
begin
select * from Pronostico order by Fecha_Hora desc
end
go

--Listar Pais
create procedure ListarPais as 
begin
	select * from Pais
end
go


--Registrar un Pronostico
create procedure RegistrarPronostico  @Usuario varchar(50),@Ciudad varchar(3),@Pais varchar(3),@Maxima int,@Minima int,@Fecha_Hora datetime,@VelViento int,@Probabilidad int,@Tipo_Cielo varchar(50) as 
begin

	if (not exists (select Codigo_Ciudad from Ciudad where Codigo_Ciudad=@Ciudad and Codigo_Pais=@Pais))
		return -1
	if (not exists (select Codigo_Pais from Pais where Codigo_Pais=@Pais))
		return -2
	if (not exists (select Nombre_Usuario from Usuario where Nombre_Usuario=@Usuario))
		return -3
	if	(@Fecha_Hora<GETDATE())
		return -4
	INSERT Pronostico( Usuario,Ciudad,Pais,Maxima,Minima,Fecha_Hora,VelViento,Probabilidad ,Tipo_Cielo) VALUES(@Usuario,@Ciudad,@Pais,@Maxima,@Minima,@Fecha_Hora,@VelViento,@Probabilidad ,@Tipo_Cielo);

	if (@@ERROR !=0)
		return -5 --No se realizo alta
	else
		return 1
end
go


--Listar de Pronósticos por Ciudad
create procedure ListarPronosticosCiudad @Codigo_Pais varchar(3) ,@Codigo_Ciudad varchar(3) as
begin
	select * from Pronostico where Ciudad=@Codigo_Ciudad and Pais=@Codigo_Pais
end
go

