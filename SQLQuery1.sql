CREATE TABLE [dbo].[CandyUser] (
    [Id]            INT        NOT NULL DEFAULT 0,
    [name]          NVARCHAR(50) NULL DEFAULT 0,
    [familyname]    NVARCHAR(50) NULL DEFAULT 0,
    [username]      NVARCHAR(50) NULL DEFAULT 0,
    [password]      NVARCHAR(50) NULL DEFAULT 0,
    [score]         INT        NULL DEFAULT 0,
    [topscore]      INT        NULL DEFAULT 0,
    [countgame]     INT        NULL DEFAULT 0,
    [friend]        NVARCHAR(50) NULL DEFAULT 0,
    [incompetition] NVARCHAR(50) NULL DEFAULT 0,
    [countwin]      INT        NULL DEFAULT 0,
    [countlose]     INT        NULL DEFAULT 0,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

