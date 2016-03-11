CREATE TABLE [dbo].[Gallery] (
    [GalleryID]  INT          IDENTITY (1, 1) NOT NULL,
    [CategoryID] INT          NOT NULL,
    [PhotoName]  VARCHAR (50) NOT NULL,
    [OrderIndex] INT          NULL,
    CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED ([GalleryID] ASC),
    CONSTRAINT [FK_Gallery_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID])
);

