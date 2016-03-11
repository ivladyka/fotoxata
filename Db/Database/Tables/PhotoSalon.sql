CREATE TABLE [dbo].[PhotoSalon] (
    [PhotoSalonID]     INT           IDENTITY (1, 1) NOT NULL,
    [Address]          VARCHAR (50)  NOT NULL,
    [Active]           BIT           CONSTRAINT [DF_PhotoSalon_Active] DEFAULT ((1)) NOT NULL,
    [Phone1]           VARCHAR (20)  NULL,
    [Phone2]           VARCHAR (20)  NULL,
    [Phone3]           VARCHAR (20)  NULL,
    [Description]      VARCHAR (MAX) NULL,
    [ButtonImage]      VARCHAR (50)  NULL,
    [ButtonImageHover] VARCHAR (50)  NULL,
    [Address_ru]       VARCHAR (50)  NULL,
    [Address_en]       VARCHAR (50)  NULL,
    [Description_ru]   VARCHAR (MAX) NULL,
    [Description_en]   VARCHAR (MAX) NULL,
    CONSTRAINT [PK_PhotoSalon] PRIMARY KEY CLUSTERED ([PhotoSalonID] ASC)
);

