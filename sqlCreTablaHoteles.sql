USE logistica

/*Creacion de tabla de Hoteles*/
CREATE TABLE Hoteles(
	Id int Identity(1,1) NOT NULL,
	CodigoHotel varchar(50) NOT NULL,
	Nombre varchar(255) NOT NULL,
	Estrellas int NULL,
	Habitaciones int NULL,
	Membresia int NULL

 CONSTRAINT [PK_Hoteles] PRIMARY KEY CLUSTERED 
(Id ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]




