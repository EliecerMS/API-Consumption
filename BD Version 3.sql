CREATE TABLE [Medico] (
  [id_Medico] uniqueidentifier PRIMARY KEY,
  [especialidad] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Paciente] (
  [id_Paciente] uniqueidentifier PRIMARY KEY,
  [peso] interger NOT NULL,
  [estatura] interger NOT NULL
)
GO

CREATE TABLE [Cita] (
  [id_Cita] integer PRIMARY KEY,
  [id_Medico] uniqueidentifier,
  [id_Paciente] uniqueidentifier NOT NULL,
  [notas_Cita] nvarchar(MAX),
  [fecha_Cita] DATE NOT NULL,
  [atendida] BIT NOT NULL,
  [especialidad] nvarchar(50) NOT NULL,
  [motivo] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Enfermedad_Diagnostico] (
  [id_EnferDiagnostico] integer PRIMARY KEY,
  [id_Paciente] uniqueidentifier NOT NULL,
  [id_Cita] integer NOT NULL,
  [id_Enfermedad] integer NOT NULL,
  [notas_Diagnostico] nvarchar(MAX) NOT NULL,
  [fase_Enfermedad] nvarchar(50) NOT NULL,
  [fecha_Diagnostico] DATE NOT NULL
)
GO

CREATE TABLE [Medicacion_Paciente] (
  [id_Medicacion_Paciente] integer PRIMARY KEY,
  [id_Medicamento] integer NOT NULL,
  [id_Cita] integer NOT NULL,
  [dosis] nvarchar(50) NOT NULL,
  [intrucciones] nvarchar(50) NOT NULL,
  [fecha_Preesctrito] DATE NOT NULL
)
GO

CREATE TABLE [Medicamento] (
  [id_Medicamento] integer PRIMARY KEY,
  [nombre] nvarchar(50)
)
GO

CREATE TABLE [Enfermedad] (
  [id_Enfermedad] integer PRIMARY KEY,
  [nombre] nvarchar(50)
)
GO

CREATE TABLE [Persona] (
  [id_Persona] uniqueidentifier PRIMARY KEY,
  [nombre] nvarchar(50) NOT NULL,
  [primer_Apellido] nvarchar(50) NOT NULL,
  [segundo_Apellido] nvarchar(50) NOT NULL,
  [fecha_Nacimiento] DATE NOT NULL,
  [genero] nvarchar(50) NOT NULL,
  [email] nvarchar(50) NOT NULL,
  [telefono] nvarchar(50) NOT NULL,
  [edad] nvarchar(50) NOT NULL,
  [identificacion] nvarchar(50) NOT NULL,
  [rol] nvarchar(50) NOT NULL
)
GO

ALTER TABLE [Cita] ADD FOREIGN KEY ([id_Paciente]) REFERENCES [Paciente] ([id_Paciente])
GO

ALTER TABLE [Cita] ADD FOREIGN KEY ([id_Medico]) REFERENCES [Medico] ([id_Medico])
GO

ALTER TABLE [Medicacion_Paciente] ADD FOREIGN KEY ([id_Cita]) REFERENCES [Cita] ([id_Cita])
GO

ALTER TABLE [Enfermedad_Diagnostico] ADD FOREIGN KEY ([id_Cita]) REFERENCES [Cita] ([id_Cita])
GO

ALTER TABLE [Medicacion_Paciente] ADD FOREIGN KEY ([id_Medicamento]) REFERENCES [Medicamento] ([id_Medicamento])
GO

ALTER TABLE [Enfermedad_Diagnostico] ADD FOREIGN KEY ([id_Enfermedad]) REFERENCES [Enfermedad] ([id_Enfermedad])
GO

ALTER TABLE [Medico] ADD FOREIGN KEY ([id_Medico]) REFERENCES [Persona] ([id_Persona])
GO

ALTER TABLE [Paciente] ADD FOREIGN KEY ([id_Paciente]) REFERENCES [Persona] ([id_Persona])
GO
