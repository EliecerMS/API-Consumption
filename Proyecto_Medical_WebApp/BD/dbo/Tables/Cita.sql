CREATE TABLE [dbo].[Cita] (
    [id_Cita]      INT              NOT NULL,
    [id_Medico]    UNIQUEIDENTIFIER NULL,
    [id_Paciente]  UNIQUEIDENTIFIER NOT NULL,
    [notas_Cita]   NVARCHAR (MAX)   NULL,
    [fecha_Cita]   DATE             NOT NULL,
    [atendida]     BIT              NOT NULL,
    [especialidad] NVARCHAR (50)    NOT NULL,
    [motivo]       NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Cita] ASC),
    FOREIGN KEY ([id_Medico]) REFERENCES [dbo].[Medico] ([id_Medico]),
    FOREIGN KEY ([id_Paciente]) REFERENCES [dbo].[Paciente] ([id_Paciente])
);



