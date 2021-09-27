CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
		DECLARE @CountOfLetters INT = LEN(@word)
		DECLARE @Index INT = 1
			WHILE @Index <= @CountOfLetters
				BEGIN
				IF(CHARINDEX(SUBSTRING(@word,@Index,1),@setOfLetters) = 0)
					BEGIN
						RETURN 0
					END
					SET @Index += 1
				END
				RETURN 1
END

