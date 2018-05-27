IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Areas] (
    [Id] int NOT NULL IDENTITY,
    [HasElectricity] bit NOT NULL,
    [IsPrivate] bit NOT NULL,
    [ParentAreaId] int NULL,
    [Square] int NOT NULL,
    CONSTRAINT [PK_Areas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Areas_Areas_ParentAreaId] FOREIGN KEY ([ParentAreaId]) REFERENCES [Areas] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Indications] (
    [Id] int NOT NULL IDENTITY,
    [CurrentIndication] float NOT NULL,
    [LastIndication] float NOT NULL,
    [LoosesPercent] float NOT NULL,
    [Month] int NOT NULL,
    [Year] int NOT NULL,
    CONSTRAINT [PK_Indications] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Members] (
    [Id] int NOT NULL IDENTITY,
    [AdditionalInfo] nvarchar(max) NULL,
    [Address] nvarchar(150) NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [IsActiveMember] bit NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [MiddleName] nvarchar(max) NULL,
    [Phone] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Rates] (
    [Id] int NOT NULL IDENTITY,
    [BankCollectionPercent] float NOT NULL,
    [Date] datetime2 NOT NULL,
    [FinePercent] float NOT NULL,
    [RateName] nvarchar(50) NOT NULL,
    [RateValue] float NOT NULL,
    CONSTRAINT [PK_Rates] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MembersAreas] (
    [Id] int NOT NULL IDENTITY,
    [AreaId] int NOT NULL,
    [MemberId] int NOT NULL,
    [OwnedFrom] datetime2 NOT NULL,
    [OwnedTo] datetime2 NOT NULL,
    CONSTRAINT [PK_MembersAreas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MembersAreas_Areas_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [Areas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MembersAreas_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Payments] (
    [Id] int NOT NULL IDENTITY,
    [DateOfPayment] datetime2 NOT NULL,
    [IndicationId] int NULL,
    [MemberId] int NOT NULL,
    [PaidFor] float NOT NULL,
    [RateId] int NOT NULL,
    [ToPay] float NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Indications_IndicationId] FOREIGN KEY ([IndicationId]) REFERENCES [Indications] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Payments_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Rates_RateId] FOREIGN KEY ([RateId]) REFERENCES [Rates] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Areas_ParentAreaId] ON [Areas] ([ParentAreaId]);

GO

CREATE INDEX [IX_MembersAreas_AreaId] ON [MembersAreas] ([AreaId]);

GO

CREATE INDEX [IX_MembersAreas_MemberId] ON [MembersAreas] ([MemberId]);

GO

CREATE UNIQUE INDEX [IX_Payments_IndicationId] ON [Payments] ([IndicationId]) WHERE [IndicationId] IS NOT NULL;

GO

CREATE INDEX [IX_Payments_MemberId] ON [Payments] ([MemberId]);

GO

CREATE INDEX [IX_Payments_RateId] ON [Payments] ([RateId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180526174600_DataBase Created EF Core', N'2.0.3-rtm-10026');

GO

