CREATE TABLE [dbo].[Medico] (
    [id_Medico]    UNIQUEIDENTIFIER NOT NULL,
    [especialidad] NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Medico] ASC),
    FOREIGN KEY ([id_Medico]) REFERENCES [dbo].[Persona] ([id_Persona])
);



