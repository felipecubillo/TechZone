-- Primero eliminar la tabla que tiene la FK
DROP TABLE Usuario;
GO

-- Luego eliminar la tabla padre
DROP TABLE Perfil;
GO

SELECT 
    fk.name AS FK_Name,
    tp.name AS TablaPadre,
    tr.name AS TablaReferenciada
FROM sys.foreign_keys fk
INNER JOIN sys.tables tp ON fk.parent_object_id = tp.object_id
INNER JOIN sys.tables tr ON fk.referenced_object_id = tr.object_id
WHERE tr.name = 'Usuario';

ALTER TABLE Factura
DROP CONSTRAINT FK_Factura_Usuario;
GO

CREATE TABLE Perfil(
    IdPerfil INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL,
    Estado BIT NOT NULL
);

CREATE TABLE Usuario(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    IdPerfil INT NOT NULL,
    Contrasena VARCHAR(50) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Estado BIT,

    CONSTRAINT FK_Usuario_Perfil
        FOREIGN KEY (IdPerfil)
        REFERENCES Perfil(IdPerfil)
);
GO