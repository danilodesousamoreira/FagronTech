USE [master]
GO
/****** Object:  Database [FagronTech]    Script Date: 16/04/2021 13:44:15 ******/
CREATE DATABASE [FagronTech]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FagronTech', FILENAME = N'/var/opt/mssql/data/FagronTech.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FagronTech_log', FILENAME = N'/var/opt/mssql/data/FagronTech_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FagronTech] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FagronTech].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FagronTech] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FagronTech] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FagronTech] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FagronTech] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FagronTech] SET ARITHABORT OFF 
GO
ALTER DATABASE [FagronTech] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FagronTech] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FagronTech] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FagronTech] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FagronTech] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FagronTech] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FagronTech] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FagronTech] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FagronTech] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FagronTech] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FagronTech] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FagronTech] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FagronTech] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FagronTech] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FagronTech] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FagronTech] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FagronTech] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FagronTech] SET RECOVERY FULL 
GO
ALTER DATABASE [FagronTech] SET  MULTI_USER 
GO
ALTER DATABASE [FagronTech] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FagronTech] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FagronTech] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FagronTech] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FagronTech] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FagronTech] SET QUERY_STORE = OFF
GO
USE [FagronTech]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/04/2021 13:44:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[Sobrenome] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[ProfissaoId] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profissao]    Script Date: 16/04/2021 13:44:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profissao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeProfissao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Profissao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nome], [Sobrenome], [CPF], [DataNascimento], [ProfissaoId]) VALUES (1, N'Danilo', N'Moreira', N'12288048697', CAST(N'1994-06-13' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Profissao] ON 

INSERT [dbo].[Profissao] ([Id], [NomeProfissao]) VALUES (1, N'Programador')
INSERT [dbo].[Profissao] ([Id], [NomeProfissao]) VALUES (2, N'Analista')
INSERT [dbo].[Profissao] ([Id], [NomeProfissao]) VALUES (3, N'Gerente')
INSERT [dbo].[Profissao] ([Id], [NomeProfissao]) VALUES (4, N'Estagiário')
SET IDENTITY_INSERT [dbo].[Profissao] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Profissao] FOREIGN KEY([ProfissaoId])
REFERENCES [dbo].[Profissao] ([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Profissao]
GO
USE [master]
GO
ALTER DATABASE [FagronTech] SET  READ_WRITE 
GO
