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




select * from Sacolas

UPDATE Sacolas set Codigo = id

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


SELECT s.Codigo, s.SacolaFamilia, F.Nome, c.Nome, c.Sexo, c.IdadeNominal, c.Calcado, c.Roupa, s.Nivel, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
AND c.Codigo IN (SELECT Crianca From ColaboradorCrianca Where  Ano = 2017 and Colaborador = 28)
ORDER BY s.Nivel, c.MedidaIdade desc, c.Idade , c.Sexo, c.Nome

--conferir alunos como TALITA!!!!!
-- filha RN da luciana Caetano
-- duda, isabella
-- alunos outros.


SELECT * FROM ColaboradorCrianca WHERE Ano = 2017

SELECT Codigo From Sacolas WHERE Crianca In(
SELECT Crianca FROM ColaboradorCrianca WHERE Ano = 2017 and Colaborador = 43)




SELECT s.Codigo, s.SacolaFamilia, F.Nome, c.Nome, c.Sexo, c.IdadeNominal, c.Calcado, c.Roupa, s.Nivel, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
ORDER BY s.Nivel, f.Nome, c.MedidaIdade desc, c.Idade , c.Sexo, c.Nome


select * from familia order by nome

select * from Sacolas
WHERE Crianca NOT IN (SELECT Crianca From ColaboradorCrianca where Ano = 2017)
AND Liberado = 1


SELECT s.Codigo, s.SacolaFamilia, F.Nome, c.Nome, c.Sexo, c.IdadeNominal, c.Calcado, c.Roupa, s.Nivel, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
AND c.Codigo NOT IN (SELECT Crianca From ColaboradorCrianca Where  Ano = 2017)
AND Liberado = 1
ORDER BY s.Nivel, c.MedidaIdade desc, c.Idade , c.Sexo, c.Nome

--porfamilia
SELECT s.Codigo, s.SacolaFamilia, F.Nome, c.Nome, c.Sexo, c.IdadeNominal, c.Calcado, c.Roupa, s.Nivel, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
AND c.Codigo NOT IN (SELECT Crianca From ColaboradorCrianca Where  Ano = 2017)
AND Liberado = 0
ORDER BY s.Nivel, F.Nome, s.SacolaFamilia, c.MedidaIdade desc, c.Idade , c.Sexo, c.Nome

--quantitativo todos
SELECT Idade, MedidaIdade, Count(1) Quantidade
FROM Crianca
WHERE Codigo IN (
select Crianca from Sacolas
WHERE Crianca NOT IN (SELECT Crianca From ColaboradorCrianca where Ano = 2017)
AND Liberado = 1)
GROUP BY Idade, MedidaIdade
ORDER BY MedidaIdade Desc, idade

--quantitativo com sexo
SELECT Idade, MedidaIdade, Sexo, Count(1) Quantidade
FROM Crianca
WHERE Codigo IN (
select Crianca from Sacolas
WHERE Crianca NOT IN (SELECT Crianca From ColaboradorCrianca where Ano = 2017)
AND Liberado = 1)
GROUP BY Idade, Sexo, MedidaIdade
ORDER BY MedidaIdade Desc, idade, Sexo

delete from sacolas where id >= 641



SELECT s.Codigo, s.SacolaFamilia, F.Nome, c.Nome, c.Sexo, c.IdadeNominal, c.Calcado, c.Roupa, s.Nivel, s.Liberado
FROM Sacolas s
JOIN Familia f
ON s.FamiliaRepresentante = f.Codigo
JOIN Crianca c
ON s.Crianca = c.Codigo
AND c.Codigo NOT IN (SELECT Crianca From ColaboradorCrianca Where  Ano = 2017)
AND s.Liberado = 1
ORDER BY  c.MedidaIdade desc, c.Idade , c.Sexo, c.Nome





309,307,139,138,79,285,140,106,136,141,137,38,78,283,282,39,124,23,174,176,175,84,143,324