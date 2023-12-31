USE [studant_class_management_db]
GO
/****** Object:  Table [dbo].[aluno]    Script Date: 07/10/2023 16:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aluno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](255) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[senha] [varchar](255) NOT NULL,
 CONSTRAINT [PK_aluno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aluno_turma]    Script Date: 07/10/2023 16:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aluno_turma](
	[aluno_id] [int] NULL,
	[turma_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[turma]    Script Date: 07/10/2023 16:35:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[turma_id] [int] NOT NULL,
	[turma] [varchar](255) NOT NULL,
	[ano] [int] NOT NULL,
 CONSTRAINT [PK_turma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aluno_turma]  WITH CHECK ADD  CONSTRAINT [aluno_id] FOREIGN KEY([aluno_id])
REFERENCES [dbo].[aluno] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aluno_turma] CHECK CONSTRAINT [aluno_id]
GO
ALTER TABLE [dbo].[aluno_turma]  WITH CHECK ADD  CONSTRAINT [turma_id] FOREIGN KEY([turma_id])
REFERENCES [dbo].[turma] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[aluno_turma] CHECK CONSTRAINT [turma_id]
GO
