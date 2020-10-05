USE [master]
GO
/****** Object:  Database [cast]    Script Date: 04/10/2020 22:18:25 ******/
CREATE DATABASE [cast]
USE [cast]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 04/10/2020 22:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[Id] [uniqueidentifier] NOT NULL,
	[descricao] [nchar](250) NOT NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[curso]    Script Date: 04/10/2020 22:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[curso](
	[id] [uniqueidentifier] NOT NULL,
	[descricao] [nchar](250) NOT NULL,
	[dataInicio] [datetime] NOT NULL,
	[dataFim] [datetime] NOT NULL,
	[quantidadeAluno] [int] NULL,
	[categoriaId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_curso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[curso]  WITH CHECK ADD  CONSTRAINT [FK_curso_categoria] FOREIGN KEY([categoriaId])
REFERENCES [dbo].[categoria] ([Id])
GO
ALTER TABLE [dbo].[curso] CHECK CONSTRAINT [FK_curso_categoria]
GO
USE [master]
GO
ALTER DATABASE [cast] SET  READ_WRITE 
GO
