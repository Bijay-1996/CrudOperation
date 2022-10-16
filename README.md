# CrudOperation
# Create DataBase table using the following query
CREATE TABLE [dbo].[Student] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    [DOB]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Id] ASC)
);


Note: Change the datasource as per your system.
