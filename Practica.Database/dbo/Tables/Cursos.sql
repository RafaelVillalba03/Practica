CREATE TABLE [dbo].[Cursos] (
    [CursoId] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED ([CursoId] ASC),
    CONSTRAINT [FK_Cursos_Cursos] FOREIGN KEY ([CursoId]) REFERENCES [dbo].[Cursos] ([CursoId])
);

