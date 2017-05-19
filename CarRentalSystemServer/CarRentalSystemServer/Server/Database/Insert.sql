INSERT INTO [dbo].[Manufacturers] VALUES ('Audi', 0)
INSERT INTO [dbo].[Manufacturers] VALUES ('BMW', 0)
INSERT INTO [dbo].[Manufacturers] VALUES ('Mercedes', 0)

GO

INSERT INTO [dbo].[Cars] VALUES ('A1', 30, 1, 0, 0)
INSERT INTO [dbo].[Cars] VALUES ('A3', 50, 1, 0, 0)
INSERT INTO [dbo].[Cars] VALUES ('A4', 80, 1, 0, 0)
INSERT INTO [dbo].[Cars] VALUES ('A6', 90, 1, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('A7', 110, 1, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('A8', 115, 1, 1, 0)

INSERT INTO [dbo].[Cars] VALUES ('1er', 40, 2, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('3er', 70, 2, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('4er', 90, 2, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('5er', 95, 2, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('6er', 130, 2, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('7er', 110, 2, 1, 0)

INSERT INTO [dbo].[Cars] VALUES ('A-class', 35, 3, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('B-class', 55, 3, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('C-class', 90, 3, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('E-class', 110, 3, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('S-class', 135, 3, 1, 0)
INSERT INTO [dbo].[Cars] VALUES ('G-class', 150, 3, 1, 0)

GO

INSERT INTO [dbo].[Customers] VALUES ('admin', '?$??]i????????D?s???l?]7S{x?', 'Admin', 'Admin', 0)

GO

INSERT INTO [dbo].[CustomersCars] VALUES (1, 1, '2017-03-03', NULL)
INSERT INTO [dbo].[CustomersCars] VALUES (2, 1, '2017-04-04', NULL)
INSERT INTO [dbo].[CustomersCars] VALUES (3, 1, '2017-03-04', NULL)

GO