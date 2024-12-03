CREATE TABLE [dbo].[Paciente] (
    [id_Paciente] UNIQUEIDENTIFIER NOT NULL,
    [peso]        INT              NOT NULL,
    [estatura]    INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Paciente] ASC),
    FOREIGN KEY ([id_Paciente]) REFERENCES [dbo].[Persona] ([id_Persona])
);



