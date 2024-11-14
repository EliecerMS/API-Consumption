CREATE TABLE [dbo].[Paciente] (
    [id_Paciente]      INT           IDENTITY (1, 1) NOT NULL,
    [nombre]           NVARCHAR (50) NOT NULL,
    [primer_Apellido]  NVARCHAR (50) NOT NULL,
    [segundo_Apellido] NVARCHAR (50) NOT NULL,
    [fecha_Nacimiento] DATE          NOT NULL,
    [genero]           NVARCHAR (50) NOT NULL,
    [email]            NVARCHAR (50) NOT NULL,
    [telefono]         NVARCHAR (50) NOT NULL,
    [edad]             NVARCHAR (50) NOT NULL,
    [peso]             INT           NOT NULL,
    [estatura]         INT           NOT NULL,
    [cedula]           NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Paciente] ASC)
);

