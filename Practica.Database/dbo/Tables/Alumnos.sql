CREATE TABLE [dbo].[Alumnos] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]          NVARCHAR (50) NOT NULL,
    [Apellido1]       NVARCHAR (50) NOT NULL,
    [Apellido2]       NVARCHAR (50) NOT NULL,
    [FechaNacimiento] DATE          NOT NULL,
    [Sexo]            CHAR (1)      NOT NULL,
    [Direccion]       NVARCHAR (50) NULL,
    [Provincia]       NVARCHAR (50) NOT NULL,
    [Localidad]       NVARCHAR (50) NOT NULL,
    [Telefono]        NVARCHAR (50) NOT NULL,
    [CursoId]         INT           NOT NULL,
    [Email]           NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Alumnos_Cursos] FOREIGN KEY ([CursoId]) REFERENCES [dbo].[Cursos] ([CursoId])
);

