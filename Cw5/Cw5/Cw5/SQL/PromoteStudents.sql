CREATE OR ALTER PROCEDURE PromoteStudents @Studies NVARCHAR(100), @Semester INT
AS
DECLARE @StrInfo Varchar(30)
BEGIN

	SET XACT_ABORT ON;
	
	/* check if Studies exist */
	DECLARE @IdStudies INT = (SELECT IdStudy FROM Studies WHERE name=@Studies);
	IF @IdStudies IS NULL
	BEGIN
		SET @StrInfo = 'Studies does not exist';
		RAISERROR(@StrInfo, 11, 1);
		RETURN;
	END

	/* check if Enrollment exist */
	DECLARE @IdEnrollment INT = (SELECT IdEnrollment FROM Enrollment WHERE (Semester=@Semester) and (IdStudy=@IdStudies));
	IF @IdEnrollment IS NULL
	BEGIN
		SET @StrInfo = 'Enrollment does not exist';
		RAISERROR(@StrInfo, 11, 2);
		RETURN;
	END

	/* begin transaction */
	BEGIN TRAN

		/* check if Enrollment exist */
		DECLARE @IdNextEnrollment INT = (SELECT IdEnrollment FROM Enrollment WHERE (Semester=@Semester+1) and (IdStudy=@IdStudies));
		IF @IdNextEnrollment IS NULL
		BEGIN
			/* if not - add new enrollment where @Semester+1 and StartDate = Today */
			SET @IdNextEnrollment = (Select (MAX(IdEnrollment)+1) FROM Enrollment);

			INSERT INTO Enrollment (IdEnrollment, Semester, IdStudy, StartDate) 
			VALUES (@IdNextEnrollment, @Semester+1, @IdStudies, CAST( GETDATE() AS Date ));
		END

		/* update students */
		UPDATE Student 
		SET IdEnrollment=@IdNextEnrollment
		WHERE IdEnrollment=@IdEnrollment;

		/* return current Enrollment */
		SELECT * FROM Enrollment WHERE IdEnrollment=@IdNextEnrollment;

	COMMIT	
END;