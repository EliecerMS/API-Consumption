CREATE TABLE [dbo].[Persona] (
    [id_Persona]       UNIQUEIDENTIFIER NOT NULL,
    [nombre]           NVARCHAR (50)    NOT NULL,
    [primer_Apellido]  NVARCHAR (50)    NOT NULL,
    [segundo_Apellido] NVARCHAR (50)    NOT NULL,
    [fecha_Nacimiento] DATE             NOT NULL,
    [genero]           NVARCHAR (50)    NOT NULL,
    [email]            NVARCHAR (50)    NOT NULL,
    [telefono]         NVARCHAR (50)    NOT NULL,
    [edad]             NVARCHAR (50)    NOT NULL,
    [identificacion]   NVARCHAR (50)    NOT NULL,
    [rol]              NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Persona] ASC)
);

