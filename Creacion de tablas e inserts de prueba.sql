CREATE TABLE [Medico] (
  [id_Medico] uniqueidentifier PRIMARY KEY,
  [especialidad] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Paciente] (
  [id_Paciente] uniqueidentifier PRIMARY KEY,
  [peso] int NOT NULL,
  [estatura] int NOT NULL
)
GO

CREATE TABLE [Cita] (
  [id_Cita] int PRIMARY KEY,
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
  [id_EnferDiagnostico] int PRIMARY KEY,
  [id_Cita] int NOT NULL,
  [id_Enfermedad] int NOT NULL,
  [notas_Diagnostico] nvarchar(MAX) NOT NULL,
  [fase_Enfermedad] nvarchar(50) NOT NULL,
  [fecha_Diagnostico] DATE NOT NULL
)
GO

CREATE TABLE [Medicacion_Paciente] (
  [id_Medicacion_Paciente] int PRIMARY KEY,
  [id_Medicamento] int NOT NULL,
  [id_Cita] int NOT NULL,
  [dosis] nvarchar(50) NOT NULL,
  [intrucciones] nvarchar(50) NOT NULL,
  [fecha_Preesctrito] DATE NOT NULL
)
GO

CREATE TABLE [Medicamento] (
  [id_Medicamento] int PRIMARY KEY,
  [nombre] nvarchar(50)
)
GO

CREATE TABLE [Enfermedad] (
  [id_Enfermedad] int PRIMARY KEY,
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





INSERT INTO [Persona] ([id_Persona], [nombre], [primer_Apellido], [segundo_Apellido], [fecha_Nacimiento], [genero], [email], [telefono], [edad], [identificacion], [rol])
VALUES 
('5F57D5AE-3D19-49E9-AF2E-F572D0C13E5E', 'Juan', 'Perez', 'Gomez', '1980-05-15', 'Masculino', 'juan.perez@example.com', '555-1234', '44', '1234567890', 'Medico'),
('3E9F1EAC-33A1-4A72-94A9-5588C88358E0', 'Maria', 'Lopez', 'Sanchez', '1990-07-22', 'Femenino', 'maria.lopez@example.com', '555-2345', '34', '2345678901', 'Paciente'),
('A5E6A87E-5A87-46E5-9A18-1B1D9230AC4A', 'Carlos', 'Garcia', 'Martinez', '1995-03-11', 'Masculino', 'carlos.garcia@example.com', '555-3456', '29', '3456789012', 'Paciente'),
('E9D88A88-0FB1-4A95-A4BB-A5E1DBA7D30E', 'Ana', 'Diaz', 'Rodriguez', '1985-10-30', 'Femenino', 'ana.diaz@example.com', '555-4567', '39', '4567890123', 'Medico'),
('2D2EEDDA-85A5-41B0-B3AA-65A5A88F1A12', 'Luis', 'Hernandez', 'Ruiz', '1988-02-18', 'Masculino', 'luis.hernandez@example.com', '555-5678', '36', '5678901234', 'Paciente'),
('B6D8D3F0-3C94-47F7-A80D-FD46B8A1D1C0', 'Elena', 'Martinez', 'Gonzalez', '1992-11-05', 'Femenino', 'elena.martinez@example.com', '555-6789', '32', '6789012345', 'Medico'),
('FC16B726-1F0F-44C9-9F8A-B67806DBBE5D', 'Javier', 'Perez', 'Vazquez', '1977-08-14', 'Masculino', 'javier.perez@example.com', '555-7890', '47', '7890123456', 'Paciente'),
('6C931542-F98B-4293-BB35-FD4AB7F45C67', 'Laura', 'Gonzalez', 'Lopez', '1983-01-23', 'Femenino', 'laura.gonzalez@example.com', '555-8901', '41', '8901234567', 'Medico'),
('C4133D19-EE29-4E71-9D98-50F02475BBD2', 'Ricardo', 'Santos', 'Mora', '1997-04-09', 'Masculino', 'ricardo.santos@example.com', '555-9012', '27', '9012345678', 'Paciente'),
('039C8F3B-42F1-4C43-B77E-68F34FEC5DAF', 'Patricia', 'Ruiz', 'Perez', '1986-12-12', 'Femenino', 'patricia.ruiz@example.com', '555-0123', '38', '0123456789', 'Medico'),
('1CCCF35E-F13C-4A5B-B36F-B615D2FF99A9', 'Sofia', 'Martinez', 'Rios', '1993-03-14', 'Femenino', 'sofia.martinez@example.com', '555-1122', '31', '1122334455', 'Paciente'),
('AA0B9D2B-25B9-4D5E-97FB-F3F79B9E74FF', 'Miguel', 'Ramirez', 'Gutierrez', '1987-05-19', 'Masculino', 'miguel.ramirez@example.com', '555-2233', '37', '2233445566', 'Medico'),
('806072A1-4B49-4A9F-8C15-4A2077580B6A', 'Gabriela', 'Vargas', 'Silva', '1984-09-30', 'Femenino', 'gabriela.vargas@example.com', '555-3344', '40', '3344556677', 'Paciente'),
('CA9C64B5-82D9-4EC0-9F9C-A8D0CFF515F2', 'David', 'Castro', 'Moreno', '1996-06-01', 'Masculino', 'david.castro@example.com', '555-4455', '28', '4455667788', 'Medico'),
('39267F04-A1EE-47DA-A6A5-DCFBF8138B35', 'Juliana', 'Serrano', 'Ponce', '1992-12-02', 'Femenino', 'juliana.serrano@example.com', '555-5566', '32', '5566778899', 'Paciente'),
('3978F21A-F6D2-4B97-A77A-44050B0786E9', 'Hector', 'Jimenez', 'Lopez', '1991-04-10', 'Masculino', 'hector.jimenez@example.com', '555-6677', '33', '6677889900', 'Medico'),
('3C2FB573-F95A-4B89-BBB0-0F2F031A2905', 'Carolina', 'Gomez', 'Reyes', '1994-07-18', 'Femenino', 'carolina.gomez@example.com', '555-7788', '30', '7788990011', 'Paciente'),
('FB9F3B5F-B7D7-4A72-9E34-40C8F602C33B', 'Oscar', 'Salazar', 'Torres', '1980-11-23', 'Masculino', 'oscar.salazar@example.com', '555-8899', '44', '8899001122', 'Medico');


INSERT INTO [Medico] ([id_Medico], [especialidad])
VALUES 
('5F57D5AE-3D19-49E9-AF2E-F572D0C13E5E', 'Cardiologia'),
('E9D88A88-0FB1-4A95-A4BB-A5E1DBA7D30E', 'Neurologia'),
('B6D8D3F0-3C94-47F7-A80D-FD46B8A1D1C0', 'Pediatria'),
('6C931542-F98B-4293-BB35-FD4AB7F45C67', 'Dermatologia'),
('039C8F3B-42F1-4C43-B77E-68F34FEC5DAF', 'Traumatologia'),
('AA0B9D2B-25B9-4D5E-97FB-F3F79B9E74FF', 'Oftalmologia');


INSERT INTO [Paciente] ([id_Paciente], [peso], [estatura])
VALUES 
('3E9F1EAC-33A1-4A72-94A9-5588C88358E0', 70, 170),
('A5E6A87E-5A87-46E5-9A18-1B1D9230AC4A', 80, 180),
('2D2EEDDA-85A5-41B0-B3AA-65A5A88F1A12', 65, 160),
('FC16B726-1F0F-44C9-9F8A-B67806DBBE5D', 75, 175),
('C4133D19-EE29-4E71-9D98-50F02475BBD2', 85, 185),
('1CCCF35E-F13C-4A5B-B36F-B615D2FF99A9', 90, 190);


INSERT INTO [Cita] ([id_Cita], [id_Medico], [id_Paciente], [notas_Cita], [fecha_Cita], [atendida], [especialidad], [motivo])
VALUES 
(1, '5F57D5AE-3D19-49E9-AF2E-F572D0C13E5E', '3E9F1EAC-33A1-4A72-94A9-5588C88358E0', 'Consulta de rutina', '2024-12-05', 1, 'Cardiologia', 'Dolor en el pecho'),
(2, 'E9D88A88-0FB1-4A95-A4BB-A5E1DBA7D30E', 'A5E6A87E-5A87-46E5-9A18-1B1D9230AC4A', 'Chequeo neurol�gico', '2024-12-06', 0, 'Neurologia', 'Dolores de cabeza frecuentes'),
(3, 'B6D8D3F0-3C94-47F7-A80D-FD46B8A1D1C0', '2D2EEDDA-85A5-41B0-B3AA-65A5A88F1A12', 'Examen pedi�trico', '2024-12-07', 1, 'Pediatria', 'Fiebre'),
(4, '6C931542-F98B-4293-BB35-FD4AB7F45C67', 'FC16B726-1F0F-44C9-9F8A-B67806DBBE5D', 'Consulta dermatol�gica', '2024-12-08', 0, 'Dermatologia', 'Erupciones en la piel'),
(5, '039C8F3B-42F1-4C43-B77E-68F34FEC5DAF', 'C4133D19-EE29-4E71-9D98-50F02475BBD2', 'Consulta traumatol�gica', '2024-12-09', 1, 'Traumatologia', 'Dolor en la rodilla'),
(6, 'AA0B9D2B-25B9-4D5E-97FB-F3F79B9E74FF', '1CCCF35E-F13C-4A5B-B36F-B615D2FF99A9', 'Revisi�n ocular', '2024-12-10', 0, 'Oftalmologia', 'Visi�n borrosa');
INSERT INTO [Cita] ([id_Cita], [id_Medico], [id_Paciente], [notas_Cita], [fecha_Cita], [atendida], [especialidad], [motivo])
VALUES 
(7, 'E9D88A88-0FB1-4A95-A4BB-A5E1DBA7D30E', 'C4133D19-EE29-4E71-9D98-50F02475BBD2', 'Consulta para migra�a', '2024-12-11', 0, 'Neurologia', 'Migra�as recurrentes'),
(8, 'B6D8D3F0-3C94-47F7-A80D-FD46B8A1D1C0', '1CCCF35E-F13C-4A5B-B36F-B615D2FF99A9', 'Consulta pedi�trica', '2024-12-12', 1, 'Pediatria', 'Dolor abdominal');


INSERT INTO [Medicamento] ([id_Medicamento], [nombre])
VALUES 
(1, 'Paracetamol'),
(2, 'Ibuprofeno'),
(3, 'Amoxicilina'),
(4, 'Metformina'),
(5, 'Losartan'),
(6, 'Omeprazol');
INSERT INTO [Medicamento] ([id_Medicamento], [nombre])
VALUES 
(7, 'Sumatript�n'),  -- For migra�as
(8, 'Loperamida');  -- For dolor abdominal


INSERT INTO [Enfermedad] ([id_Enfermedad], [nombre])
VALUES 
(1, 'Hipertensi�n'),
(2, 'Diabetes tipo 2'),
(3, 'Asma'),
(4, 'Artritis'),
(5, 'Gripe'),
(6, 'C�ncer de piel');

INSERT INTO [Enfermedad] ([id_Enfermedad], [nombre])
VALUES 
(7, 'Migra�a'),  -- For migra�as
(8, 'Gastroenteritis');  -- For dolor abdominal


INSERT INTO [Enfermedad_Diagnostico] ([id_EnferDiagnostico], [id_Cita], [id_Enfermedad], [notas_Diagnostico], [fase_Enfermedad], [fecha_Diagnostico])
VALUES 
(1, 1, 1, 'Diagn�stico de hipertensi�n leve', 'Fase inicial', '2024-12-05'),
(2, 2, 2, 'Diagn�stico de diabetes tipo 2', 'Fase controlada', '2024-12-06'),
(3, 3, 3, 'Diagn�stico de asma cr�nica', 'Fase estable', '2024-12-07'),
(4, 4, 4, 'Diagn�stico de artritis reumatoide', 'Fase moderada', '2024-12-08'),
(5, 5, 1, 'Diagn�stico de hipertensi�n severa', 'Fase avanzada', '2024-12-09'),
(6, 6, 6, 'Diagn�stico de c�ncer de piel', 'Fase temprana', '2024-12-10');
INSERT INTO [Enfermedad_Diagnostico] ([id_EnferDiagnostico], [id_Cita], [id_Enfermedad], [notas_Diagnostico], [fase_Enfermedad], [fecha_Diagnostico])
VALUES 
(7, 7, 7, 'Diagn�stico de migra�a cr�nica', 'Fase controlada', '2024-12-11'),  -- For migra�as
(8, 8, 8, 'Diagn�stico de gastroenteritis', 'Fase aguda', '2024-12-12');  


INSERT INTO [Medicacion_Paciente] ([id_Medicacion_Paciente], [id_Cita], [id_Medicamento], [dosis], [intrucciones], [fecha_Preesctrito])
VALUES 
(1, 1, 1, '500mg', 'Tomar cada 8 horas', '2024-12-05'),
(2, 2, 2, '200mg', 'Tomar cada 12 horas', '2024-12-06'),
(3, 3, 3, '500mg', 'Tomar 3 veces al d�a', '2024-12-07'),
(4, 4, 4, '850mg', 'Tomar por la ma�ana', '2024-12-08'),
(5, 5, 5, '50mg', 'Tomar cada noche', '2024-12-09'),
(6, 6, 6, '20mg', 'Tomar 1 vez al d�a', '2024-12-10');
INSERT INTO [Medicacion_Paciente] ([id_Medicacion_Paciente], [id_Cita], [id_Medicamento], [dosis], [intrucciones], [fecha_Preesctrito])
VALUES 
(7, 7, 7, '50mg', 'Tomar 1 vez al d�a', '2024-12-11'),  -- For migra�a (Sumatript�n)
(8, 8, 8, '2mg', 'Tomar 1 vez al d�a', '2024-12-12');  -- For dolor abdominal (Loperamida)

