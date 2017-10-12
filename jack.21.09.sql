select * from Reuniao
WHERE Codigo between 60 and 82

SELECT * FROM Familia ORDER BY codigo

SELECT * FROM Crianca WHERE Familia = 111


SELECT * FROM PRESENCA WHERE REUNIAO = 80 (241)

select Reuniao, Count(1) 
from Presenca
WHERE reuniao between 60 and 82
Group by Reuniao

Begin Tran
-- reunião 63
INSERT INTO Presenca (Familia, Reuniao)
SELECT Distinct Familia, 63 FROM Presenca Where Reuniao IN(61,69) and Familia not in (52,82,100,283,270,271) 

-- reunião 65
INSERT INTO Presenca (Familia, Reuniao)
SELECT Distinct Familia, 65 FROM Presenca Where Reuniao IN(67,71) and Familia not in (52,82,100,283,270,271)

-- reunião 76
INSERT INTO Presenca (Familia, Reuniao)
SELECT Distinct Familia, 76 FROM Presenca Where Reuniao IN(72,74)  and Familia not in (52,82,100,283,261,270,271)

-- reunião 80
INSERT INTO Presenca (Familia, Reuniao)
SELECT Distinct Familia, 80 FROM Presenca Where Reuniao IN(78,82)  and Familia not in (52,82,100,283,261,67,272,257,353,49,31,271,270,293,231)


select * from Crianca where familia = 167
UPDATE Crianca set DocumentoOk = 1, sacolinha = 1 where Familia = 167


commit

rollback

select * from familia order by nivel

select * from familia order by nome

select * 
From Sacolas

SELECT * FROM Familia where PresencaJustificada = 1


UPDATE Crianca Set MoralCrista = 1
WHERE Codigo IN(347,91,346,345,164,203,229)

UPDATE Familia Set Nivel = 2 WHERE Codigo = 86

Truncate table Sacolas


SELECT f.Nome, s.Nivel , c.Nome, c.IdadeNominal, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
ORDER BY s.Nivel, f.Nome, c.Nome


select Nivel, count(1) from sacolas group by Nivel order by Nivel

SELECT f.codigo, f.Nome, Count(1), f.Nivel 
FROM Familia f 
JOIN Presenca p
ON f.Codigo = p.Familia
AND	Reuniao > 59
AND Reuniao < 83
WHERE f.Codigo in (select distinct Familia  from sacolas)
Group By  f.codigo,f.Nome, f.Nivel
ORDER By f.Nome


select * from Presenca where Familia = 261 order by reuniao
select * from Colaborador


SELECT s.Codigo, s.SacolaFamilia, F.Nome, c.Nome, c.Sexo, c.IdadeNominal, c.Calcado, c.Roupa, s.Nivel, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
AND c.Codigo NOT IN (SELECT Crianca From ColaboradorCrianca Where  Ano = 2017)
ORDER BY s.Nivel, c.MedidaIdade desc, c.Idade , c.Sexo, c.Nome


SELECT * FROM ColaboradorCrianca 
WHERE Colaborador = 5 and Crianca IN (351) and Ano = 2017


SELECT f.Nome, s.Nivel , count(1)
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
Group By f.Nome, s.Nivel
ORDER BY s.Nivel, f.Nome 


--conferir alunos como TALITA!!!!!
-- filha RN da luciana Caetano
-- duda, isabella
-- alunos outros.


SELECT * FROM ColaboradorCrianca WHERE Ano = 2017

SELECT Codigo From Sacolas WHERE Crianca In(
SELECT Crianca FROM ColaboradorCrianca WHERE Ano = 2017 and Colaborador = 33)



2,4,6,7,9,10,11,13,14,16,17,21,22,27,28,29,30,31,34,41,63,64,80,81,92,101,105,116,119,120