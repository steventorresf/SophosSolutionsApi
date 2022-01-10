USE ErpDB
GO

IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'VentaDetalle') BEGIN
	DROP TABLE VentaDetalle;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Venta') BEGIN
	DROP TABLE Venta;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Producto') BEGIN
	DROP TABLE Producto;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Cliente') BEGIN
	DROP TABLE Cliente;
END

CREATE TABLE Cliente (
	IdCliente int identity(1,1) NOT NULL,
	Identificacion nvarchar(50) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	Apellido nvarchar(100) NOT NULL,
	Telefono nvarchar(100) NOT NULL,

	CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente)
)

CREATE TABLE Producto (
	IdProducto int identity(1,1) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	ValorUnitario numeric NOT NULL,

	CONSTRAINT PK_Producto PRIMARY KEY (IdProducto)
)

CREATE TABLE Venta (
	IdVenta int identity(1,1) NOT NULL,
	IdCliente int NOT NULL,
	FechaVenta datetime NOT NULL,

	CONSTRAINT PK_Venta PRIMARY KEY (IdVenta),
	CONSTRAINT FK_Venta_001 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
)

CREATE TABLE VentaDetalle (
	IdVentaDetalle int identity(1,1) NOT NULL,
	IdVenta int NOT NULL,
	IdProducto int NOT NULL,
	Cantidad numeric NOT NULL,
	ValorUnitario numeric NOT NULL,

	CONSTRAINT PK_VentaDetalle PRIMARY KEY (IdVentaDetalle),
	CONSTRAINT FK_VentaDetalle_001 FOREIGN KEY (IdVenta) REFERENCES Venta(IdVenta),
	CONSTRAINT FK_VentaDetalle_002 FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
)