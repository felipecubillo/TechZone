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
