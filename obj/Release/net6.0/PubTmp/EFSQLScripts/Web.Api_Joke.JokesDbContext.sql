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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220527070330_init')
BEGIN
    CREATE TABLE [jokeTypes] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(25) NOT NULL,
        CONSTRAINT [PK_jokeTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220527070330_init')
BEGIN
    CREATE TABLE [users] (
        [id] int NOT NULL IDENTITY,
        [Name] nvarchar(30) NOT NULL,
        CONSTRAINT [PK_users] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220527070330_init')
BEGIN
    CREATE TABLE [jokes] (
        [Id] int NOT NULL IDENTITY,
        [Evaluation] float NOT NULL,
        [EvaluationCount] int NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        [JokeTypeId] int NOT NULL,
        [Temperature] float NOT NULL,
        [SunRain] bit NOT NULL,
        [Wind] float NOT NULL,
        [Snow] bit NOT NULL,
        [Season] tinyint NOT NULL,
        CONSTRAINT [PK_jokes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_jokes_jokeTypes_JokeTypeId] FOREIGN KEY ([JokeTypeId]) REFERENCES [jokeTypes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_jokes_users_UserId] FOREIGN KEY ([UserId]) REFERENCES [users] ([id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220527070330_init')
BEGIN
    CREATE INDEX [IX_jokes_JokeTypeId] ON [jokes] ([JokeTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220527070330_init')
BEGIN
    CREATE INDEX [IX_jokes_UserId] ON [jokes] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220527070330_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220527070330_init', N'6.0.5');
END;
GO

COMMIT;
GO

