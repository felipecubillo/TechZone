--Tabla provincia
CREATE TABLE Provincia(
    IdProvincia INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
)
GO

--Tabla cliente
CREATE TABLE Cliente(
    Identificacion VARCHAR(20) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(80) NOT NULL,
    Sexo CHAR(1) CHECK (Sexo IN ('M','F')),
    Telefono VARCHAR(20),
    Correo VARCHAR(100),
    DireccionExacta VARCHAR(200),
    IdProvincia INT NOT NULL,
	Estado bit,
    Fotografia VARBINARY(MAX),

    CONSTRAINT FK_Cliente_Provincia
        FOREIGN KEY (IdProvincia)
        REFERENCES Provincia(IdProvincia)
)
GO

--Tabla marca
CREATE TABLE Marca(
    IdMarca INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL,
	Estado bit
)
GO

--tabla modelo
CREATE TABLE Modelo(
    IdModelo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL,
	Estado bit
)
GO

--Tabla Tipo dispositivo
CREATE TABLE TipoDispositivo(
    IdTipoDispositivo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL,
	Estado bit
)
GO

--Tabla productos
CREATE TABLE Producto(
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    CodigoIndustria VARCHAR(50) UNIQUE,
    IdTipoDispositivo INT NOT NULL,
    IdModelo INT NOT NULL,
    IdMarca INT NOT NULL,
    Color VARCHAR(50),
    Caracteristicas VARCHAR(500),
    Extras VARCHAR(300),
    CantidadStock INT DEFAULT 0,
	Estado bit,
    DocumentoEspecificaciones VARBINARY(MAX),

    CONSTRAINT FK_Producto_Tipo
        FOREIGN KEY (IdTipoDispositivo)
        REFERENCES TipoDispositivo(IdTipoDispositivo),

    CONSTRAINT FK_Producto_Modelo
        FOREIGN KEY (IdModelo)
        REFERENCES Modelo(IdModelo),

    CONSTRAINT FK_Producto_Marca
        FOREIGN KEY (IdMarca)
        REFERENCES Marca(IdMarca)
)
GO

--Tabla foto
CREATE TABLE ProductoFoto(
    IdFoto INT IDENTITY(1,1) PRIMARY KEY,
    IdProducto INT NOT NULL,
    Foto VARBINARY(MAX),

    CONSTRAINT FK_ProductoFoto_Producto
        FOREIGN KEY (IdProducto)
        REFERENCES Producto(IdProducto)
)
GO

--Tabla impuesto
CREATE TABLE Impuesto(
    IdImpuesto INT PRIMARY KEY,
    Descripcion VARCHAR(50),
    Porcentaje DECIMAL(5,2),
	Estado bit
)
GO

--Tabla stock
CREATE TABLE IngresoStock(
    IdIngreso INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    FacturaCompra VARCHAR(100),
    Observaciones VARCHAR(300),
	Estado bit
)
GO

--Tabla detalle ingreso
CREATE TABLE DetalleIngresoStock(
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdIngreso INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,

    CONSTRAINT FK_DetalleIngreso_Ingreso
        FOREIGN KEY (IdIngreso)
        REFERENCES IngresoStock(IdIngreso),

    CONSTRAINT FK_DetalleIngreso_Producto
        FOREIGN KEY (IdProducto)
        REFERENCES Producto(IdProducto)
)
GO

--Tabla Perfil
Create table Perfil(
	IdPerfil int Identity (1,1) Primary key,
	Descripcion varchar(50) not null,
	Estado bit not null
)

--Tabla Usuario
CREATE TABLE Usuario(
    IdUsuario VARCHAR(100) PRIMARY KEY,
    IdPerfil INT NOT NULL,
    Contrasena VARCHAR(50) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Correo VARCHAR(50) NOT NULL,
    Estado BIT

    CONSTRAINT FK_Usuario_Perfil
        FOREIGN KEY (IdPerfil)
        REFERENCES Perfil(IdPerfil)
)
GO

