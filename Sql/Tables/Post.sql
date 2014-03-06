CREATE TABLE [dbo].[Post] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Phone]              NVARCHAR (20)  NOT NULL,
    [Email]              NVARCHAR (50)  NOT NULL,
    [Text]               NVARCHAR (MAX) NOT NULL,
    [ApproximateAddress] NVARCHAR (250) NOT NULL,
    [FormattedAddress]   NVARCHAR (250) NULL,
    [Latitude]           FLOAT (53)     NOT NULL,
    [Longtitude]         FLOAT (53)     NOT NULL,
    [Point]              AS             ([geography]::STGeomFromText(((('POINT('+CONVERT([varchar](20),[Longtitude]))+' ')+CONVERT([varchar](20),[Latitude]))+')',(4326))) PERSISTED,
    [CreatedOn]          DATETIME       CONSTRAINT [DF_Post_EditedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([Id] ASC)
);



