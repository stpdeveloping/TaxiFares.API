INSERT INTO Cities VALUES(@CityName);
WITH insertedCity AS
	(SELECT @ChangeDate AS changeDate, Id AS id, @Name AS companyName 
	FROM Cities WHERE rowid = last_insert_rowid())
	INSERT INTO Companies(ChangeDate, CityId, Name)
	SELECT * FROM insertedCity;
INSERT INTO Fares(I, II, III, IV, CompanyId) 
	VALUES(@I, @II, @III, @IV, last_insert_rowid());