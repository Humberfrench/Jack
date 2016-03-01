USE [dbCECAM]
GO
/****** Object:  StoredProcedure [dbo].[pr_ObterCriancasFamilia]    Script Date: 23/02/2016 09:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[pr_ObterCriancasFamilia] (@id_familia int)
AS

	SELECT	cr.*, st.*, kt.*
	FROM	tb_crianca cr
	JOIN	tb_familia_crianca fc
	ON		cr.id_crianca = fc.id_crianca
	AND		fc.id_familia = @id_familia
	JOIN	tb_status st
	ON		cr.id_status = st.id_status 
	JOIN	tb_kit kt
	ON		cr.id_kit = kt.id_kit

