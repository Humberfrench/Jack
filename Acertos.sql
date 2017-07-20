use dbJack

--ACERTO FAMILIAS BANIDAS -STATUS

SET IDENTITY_INSERT StatusFamilia ON

Insert into StatusFamilia 
(Codigo, Descricao, PermiteSacola)
VALUES (13, 'Familia Banida Por Problemas',0)


SET IDENTITY_INSERT StatusFamilia OFF

UPDATE Familia 
SET Status = 13 , Sacolinha = 0, Consistente = 0, 
	Nivel = 99, BlackListPasso1 = 1, BlackListPasso2 = 1,
	DataAtualizacao = GETDATE()
WHERE Codigo IN(52, 82, 100, 283, 339)

UPDATE Familia Set Contato = '94549-9085' WHERE Codigo = 100

UPDATE Familia Set Contato = '97786-7172' WHERE Codigo = 283

UPDATE Familia Set Contato = '99458-7443' WHERE Codigo = 339

SELECT * FROM Familia WHERE Status = 13 Order by Nome

SELECT * FROM Crianca Where DocumentoOk = 0

SELECT * FROM Crianca Where DocumentoOk = 1

UPDATE Crianca SET DocumentoOk = 0 WHERE Familia IN(52, 82, 100, 283, 339)
