USE [dbJack]
GO
/****** Object:  Table [dbo].[StatusTratamento]    Script Date: 26/12/2017 11:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatusTratamento](
	[StatusTratamentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StatusTratamento] PRIMARY KEY CLUSTERED 
(
	[StatusTratamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TiposDeProblema]    Script Date: 26/12/2017 11:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposDeProblema](
	[TiposDeProblemaId] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDeProblema] PRIMARY KEY CLUSTERED 
(
	[TiposDeProblemaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tratamento]    Script Date: 26/12/2017 11:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tratamento](
	[TratamentoId] [int] IDENTITY(1,1) NOT NULL,
	[FamiliaId] [int] NOT NULL,
	[StatusTratamentoId] [int] NOT NULL,
	[DescricaoProblema] [varchar](1000) NOT NULL,
	[DataInicio] [date] NULL,
	[DataFim] [date] NULL,
	[DataCadastro] [date] NOT NULL,
	[DataAtualizacao] [date] NOT NULL,
 CONSTRAINT [PK_Tratamento] PRIMARY KEY CLUSTERED 
(
	[TratamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TratamentoTiposDeProblema]    Script Date: 26/12/2017 11:08:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamentoTiposDeProblema](
	[TratamentoTipoDeProblemaId] [int] IDENTITY(1,1) NOT NULL,
	[TiposDeProblemaId] [int] NOT NULL,
	[TratamentoId] [int] NOT NULL,
 CONSTRAINT [PK_TratamentoTiposDeProblema] PRIMARY KEY CLUSTERED 
(
	[TratamentoTipoDeProblemaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Tratamento]  WITH CHECK ADD  CONSTRAINT [FK_Tratamento_Familia] FOREIGN KEY([FamiliaId])
REFERENCES [dbo].[Familia] ([Codigo])
GO
ALTER TABLE [dbo].[Tratamento] CHECK CONSTRAINT [FK_Tratamento_Familia]
GO
ALTER TABLE [dbo].[Tratamento]  WITH CHECK ADD  CONSTRAINT [FK_Tratamento_StatusTratamento] FOREIGN KEY([StatusTratamentoId])
REFERENCES [dbo].[StatusTratamento] ([StatusTratamentoId])
GO
ALTER TABLE [dbo].[Tratamento] CHECK CONSTRAINT [FK_Tratamento_StatusTratamento]
GO
ALTER TABLE [dbo].[TratamentoTiposDeProblema]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoTiposDeProblema_TiposDeProblema] FOREIGN KEY([TiposDeProblemaId])
REFERENCES [dbo].[TiposDeProblema] ([TiposDeProblemaId])
GO
ALTER TABLE [dbo].[TratamentoTiposDeProblema] CHECK CONSTRAINT [FK_TratamentoTiposDeProblema_TiposDeProblema]
GO
ALTER TABLE [dbo].[TratamentoTiposDeProblema]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoTiposDeProblema_Tratamento] FOREIGN KEY([TratamentoId])
REFERENCES [dbo].[Tratamento] ([TratamentoId])
GO
ALTER TABLE [dbo].[TratamentoTiposDeProblema] CHECK CONSTRAINT [FK_TratamentoTiposDeProblema_Tratamento]
GO
