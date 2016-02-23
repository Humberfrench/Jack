create procedure pr_chamada_nomes (@id_reuniao int)
AS

SELECT	id_familia, nm_mae
FROM	tb_familia
WHERE	id_familia NOT IN ( SELECT	id_familia	
							FROM	tb_familia_presenca
							WHERE	id_reuniao = @id_reuniao)

GO