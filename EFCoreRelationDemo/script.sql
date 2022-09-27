IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Employeess] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Employeess] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EmployeeAddresses] (
    [Id] int NOT NULL IDENTITY,
    [AddressLine1] nvarchar(max) NULL,
    [AddressLine2] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [ZipCode] int NOT NULL,
    [EmployeeId] int NOT NULL,
    CONSTRAINT [PK_EmployeeAddresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmployeeAddresses_Employeess_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employeess] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_EmployeeAddresses_EmployeeId] ON [EmployeeAddresses] ([EmployeeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927150554_InitialDBCreation', N'3.1.29');

GO

ALTER TABLE [Employeess] ADD [DepartmentId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [Department] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Employeess_DepartmentId] ON [Employeess] ([DepartmentId]);

GO

ALTER TABLE [Employeess] ADD CONSTRAINT [FK_Employeess_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927151155_DepartmentAdded', N'3.1.29');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927151954_PublisherAdded', N'3.1.29');

GO

CREATE TABLE [Publishers] (
    [PubId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Publishers] PRIMARY KEY ([PubId])
);

GO

CREATE TABLE [Books] (
    [BKId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [PubId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BKId]),
    CONSTRAINT [FK_Books_Publishers_PubId] FOREIGN KEY ([PubId]) REFERENCES [Publishers] ([PubId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Books_PubId] ON [Books] ([PubId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927152207_PublisherUpdated', N'3.1.29');

GO

