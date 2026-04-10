CREATE TABLE Factura(
    IdFactura INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdUsuario VARCHAR(100) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    SubTotal DECIMAL(10,2) NOT NULL,
    TotalCRC DECIMAL(10,2) NOT NULL,
    TotalUSD DECIMAL(10,2) NOT NULL,
    TipoCambio DECIMAL(10,4) NOT NULL,
    TipoPago VARCHAR(20) NOT NULL,
    Documento VARCHAR(100),
    Banco VARCHAR(100),
    TipoTarjeta VARCHAR(50),
    FirmaCliente VARBINARY(MAX),
    DocumentoXML VARBINARY(MAX),
    Estado BIT NOT NULL,
    CONSTRAINT FK_Factura_Cliente
        FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente),

    CONSTRAINT FK_Factura_Usuario
        FOREIGN KEY (IdUsuario)
        REFERENCES Usuario(IdUsuario)
)

GO

CREATE TABLE FacturaDetalle(
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdFactura INT NOT NULL,
    IdProducto INT NOT NULL,

    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    SubTotal DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Detalle_Factura
        FOREIGN KEY (IdFactura)
        REFERENCES Factura(IdFactura),

    CONSTRAINT FK_Detalle_Producto
        FOREIGN KEY (IdProducto)
        REFERENCES Producto(IdProducto)
)
GO