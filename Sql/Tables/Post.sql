CREATE TABLE [dbo].[Post] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Phone]      NVARCHAR (20)  NOT NULL,
    [Email]      NVARCHAR (50)  NOT NULL,
    [Address]    NVARCHAR (250) NOT NULL,
    [Latitude]   FLOAT (53)     NOT NULL,
    [Longtitude] FLOAT (53)     NOT NULL,
    [Text]       NVARCHAR (MAX) NOT NULL,
    [CreatedOn]  DATETIME       CONSTRAINT [DF_Post_EditedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([Id] ASC)
);

