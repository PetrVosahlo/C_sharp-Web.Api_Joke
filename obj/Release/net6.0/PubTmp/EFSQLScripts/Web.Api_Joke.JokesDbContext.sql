IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    CREATE TABLE [jokes_Weather] (
        [Id] int NOT NULL IDENTITY,
        [Evaluation] float NOT NULL,
        [EvaluationCount] int NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [WeatherType] nvarchar(15) NOT NULL,
        [Temperature] nvarchar(15) NOT NULL,
        [WindSpeed] nvarchar(15) NOT NULL,
        [Season] nvarchar(15) NOT NULL,
        CONSTRAINT [PK_jokes_Weather] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    CREATE TABLE [jokeTypes] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(25) NOT NULL,
        CONSTRAINT [PK_jokeTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    CREATE TABLE [users] (
        [Name] nvarchar(450) NOT NULL,
        [Password] nvarchar(30) NOT NULL,
        CONSTRAINT [PK_users] PRIMARY KEY ([Name])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    CREATE TABLE [jokes_General] (
        [Id] int NOT NULL IDENTITY,
        [ChangePassword] nvarchar(15) NULL,
        [Evaluation] float NOT NULL,
        [EvaluationCount] int NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserName] nvarchar(450) NOT NULL,
        [JokeTypeId] int NOT NULL,
        CONSTRAINT [PK_jokes_General] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_jokes_General_jokeTypes_JokeTypeId] FOREIGN KEY ([JokeTypeId]) REFERENCES [jokeTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_jokes_General_users_UserName] FOREIGN KEY ([UserName]) REFERENCES [users] ([Name]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    CREATE INDEX [IX_jokes_General_JokeTypeId] ON [jokes_General] ([JokeTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    CREATE INDEX [IX_jokes_General_UserName] ON [jokes_General] ([UserName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615131528_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220615131528_init', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615164926_WeaherTypeLengthIncrased')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[jokes_Weather]') AND [c].[name] = N'WeatherType');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [jokes_Weather] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [jokes_Weather] ALTER COLUMN [WeatherType] nvarchar(30) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615164926_WeaherTypeLengthIncrased')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220615164926_WeaherTypeLengthIncrased', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615170028_WeatherTypeStringLengthIncreasedTo60')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[jokes_Weather]') AND [c].[name] = N'WeatherType');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [jokes_Weather] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [jokes_Weather] ALTER COLUMN [WeatherType] nvarchar(60) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220615170028_WeatherTypeStringLengthIncreasedTo60')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220615170028_WeatherTypeStringLengthIncreasedTo60', N'6.0.5');
END;
GO

COMMIT;
GO

