--Tabla provincia
CREATE TABLE Provincia(
    IdProvincia INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
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
    Fotografia VARBINARY(MAX),

    CONSTRAINT FK_Cliente_Provincia
        FOREIGN KEY (IdProvincia)
        REFERENCES Provincia(IdProvincia)
)
GO

--Tabla marca
CREATE TABLE Marca(
    IdMarca INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL
)
GO

--tabla modelo
CREATE TABLE Modelo(
    IdModelo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL
)
GO

--Tabla Tipo dispositivo
CREATE TABLE TipoDispositivo(
    IdTipoDispositivo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(100) NOT NULL
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
    Porcentaje DECIMAL(5,2)
)
GO

--Tabla stock
CREATE TABLE IngresoStock(
    IdIngreso INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    FacturaCompra VARCHAR(100),
    Observaciones VARCHAR(300)
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