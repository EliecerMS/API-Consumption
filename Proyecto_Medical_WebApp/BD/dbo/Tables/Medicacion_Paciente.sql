CREATE TABLE [dbo].[Medicacion_Paciente] (
    [id_Medicacion_Paciente] INT           IDENTITY (1, 1) NOT NULL,
    [id_Medicamento]         INT           NOT NULL,
    [id_Paciente]            INT           NOT NULL,
    [id_Cita]                INT           NOT NULL,
    [dosis]                  NVARCHAR (50) NOT NULL,
    [intrucciones]           NVARCHAR (50) NOT NULL,
    [fecha_Preesctrito]      DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Medicacion_Paciente] ASC),
    FOREIGN KEY ([id_Cita]) REFERENCES [dbo].[Cita] ([id_Cita]),
    FOREIGN KEY ([id_Medicamento]) REFERENCES [dbo].[Medicamento] ([id_Medicamento]),
    FOREIGN KEY ([id_Paciente]) REFERENCES [dbo].[Paciente] ([id_Paciente])
);

