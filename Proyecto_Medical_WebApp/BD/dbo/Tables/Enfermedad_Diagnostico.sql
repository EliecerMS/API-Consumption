CREATE TABLE [dbo].[Enfermedad_Diagnostico] (
    [id_EnferDiagnostico] INT            NOT NULL,
    [id_Cita]             INT            NOT NULL,
    [id_Enfermedad]       INT            NOT NULL,
    [notas_Diagnostico]   NVARCHAR (MAX) NOT NULL,
    [fase_Enfermedad]     NVARCHAR (50)  NOT NULL,
    [fecha_Diagnostico]   DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_EnferDiagnostico] ASC),
    FOREIGN KEY ([id_Cita]) REFERENCES [dbo].[Cita] ([id_Cita]),
    FOREIGN KEY ([id_Enfermedad]) REFERENCES [dbo].[Enfermedad] ([id_Enfermedad])
);



