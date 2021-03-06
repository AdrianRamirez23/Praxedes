USE [Praxedes]
GO
/****** Object:  Table [dbo].[GrupoFamiliar]    Script Date: 28/02/2021 9:29:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupoFamiliar](
	[Usuario] [varchar](25) NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Genero] [varchar](25) NOT NULL,
	[Parentesco] [varchar](25) NULL,
	[Edad] [int] NOT NULL,
	[MenorEdad] [varchar](2) NULL,
	[FechaNacimiento] [date] NULL,
 CONSTRAINT [PK_GrupoFamiliar] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC,
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_GrupoFamiliar] UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 28/02/2021 9:29:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [varchar](25) NOT NULL,
	[Contrasena] [varchar](25) NOT NULL,
	[Token] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GrupoFamiliar]  WITH CHECK ADD  CONSTRAINT [FK_GrupoFamiliar_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Usuario])
GO
ALTER TABLE [dbo].[GrupoFamiliar] CHECK CONSTRAINT [FK_GrupoFamiliar_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[GrupoFamiliar_CRUD]    Script Date: 28/02/2021 9:29:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GrupoFamiliar_CRUD](
@opc int,
@Usuario varchar(25),
@Cedula varchar(25),
@Nombres varchar(50),
@Apellidos varchar(50),
@Genero varchar(25),
@Parentesco varchar(25),
@Edad int,
@FechaNacimiento date)
AS

IF @opc=1 BEGIN

   SELECT * FROM GrupoFamiliar WHERE Usuario=@Usuario


END

IF @opc=2 BEGIN

    INSERT INTO GrupoFamiliar
	SELECT @Usuario, @Cedula, @Nombres, @Apellidos, @Genero, @Parentesco, @Edad, 
	CASE WHEN @Edad>18 THEN 'Si' ELSE 'No' END, CASE WHEN @Edad<18 THEN @FechaNacimiento ELSE NULL END

END

IF @opc=3 BEGIN

   UPDATE GrupoFamiliar
   SET Nombres=@Nombres, Apellidos=@Apellidos, Genero=@Genero, Parentesco=@Parentesco, Edad=@Edad, 
   MenorEdad=(CASE WHEN @Edad<18 THEN 'Si' ELSE 'No' END), FechaNacimiento=(CASE WHEN @Edad<18 THEN @FechaNacimiento ELSE NULL END)
   WHERE Usuario=@Usuario AND Cedula=@Cedula

END

IF @opc=4 BEGIN

     DELETE GrupoFamiliar WHERE Usuario=@Usuario  AND Cedula=@Cedula

END

GO
/****** Object:  StoredProcedure [dbo].[Usuarios_CRUD]    Script Date: 28/02/2021 9:29:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Usuarios_CRUD](
@opc int,
@Usuario varchar(25),
@Contrasena varchar(25),
@Token varchar(200)
)
AS

IF @opc=1 BEGIN

   IF EXISTS  ( SELECT '' FROM Usuarios WHERE Usuario=@Usuario AND Contrasena=@Contrasena) BEGIN

      SELECT CONVERT(BIT,1)
   END ELSE BEGIN
     
	  SELECT CONVERT(BIT,0)

   END



END

IF @opc=2 BEGIN

UPDATE Usuarios
SET Token=@Token
WHERE Usuario=@Usuario AND Contrasena=@Contrasena

END

GO
