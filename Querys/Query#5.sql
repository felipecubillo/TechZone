ALTER TABLE Producto
ADD 
    Foto VARBINARY(MAX),
    PrecioColones DECIMAL(10,2) NOT NULL,
    PrecioDolares DECIMAL(10,2) NOT NULL;