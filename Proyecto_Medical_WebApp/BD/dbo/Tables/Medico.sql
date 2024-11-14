CREATE TABLE [dbo].[Medico] (
    [id_Medico]        INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           NVARCHAR (50) NOT NULL,
    [primer_Apellido]  NVARCHAR (50) NOT NULL,
    [segundo_Apellido] NVARCHAR (50) NOT NULL,
    [email]            NVARCHAR (50) NOT NULL,
    [telefono]         NVARCHAR (50) NOT NULL,
    [especialidad]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Medico] ASC)
);

