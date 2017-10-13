
CREATE PROCEDURE PROC_POST
(
@PostID VARCHAR(10),	
@PostTitle VARCHAR(200),
@ShortDescription VARCHAR(300),
@FullDescription VARCHAR(MAX),
@CategoryID INT,
@SubCategoryID INT,
@UniqueURL VARCHAR(300),
@SEOTitle  VARCHAR(100),
@SEODescription  VARCHAR(500),
@SEOKeywords VARCHAR(1000),
@CreatedDate VARCHAR(50),
@CreatedTime VARCHAR(50),
@CreatedBy Int,
@ModifiedDate VARCHAR(50),
@ModifiedTime VARCHAR(50),
@ModifiedBy Int,
@Status Int,
@Flag  INT
)
AS
BEGIN

DECLARE @ROWS_EFFECTED INT;

	IF(@Flag=0)	
	BEGIN

		INSERT INTO Posts
		(Post_Id, PostTitle, ShortDescription, FullDescription, CategoryID, SubCategoryID, UniqueURL, SEOTitle, SEODescription, SEOKeywords, CreatedDate, CreatedTime, CreatedBy, ModifiedDate, ModifiedTime, ModifiedBy, Status_Ind)
		SELECT @PostID,@PostTitle, @ShortDescription, @FullDescription, @CategoryID, @SubCategoryID, @UniqueURL, @SEOTitle, @SEODescription, @SEOKeywords
		,@CreatedDate ,@CreatedTime ,@CreatedBy ,@ModifiedDate ,@ModifiedTime,@ModifiedBy, @Status;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;

	END;

	IF(@Flag=1)
	BEGIN

		UPDATE Posts SET PostTitle=@PostTitle, ShortDescription=@ShortDescription, FullDescription=@FullDescription, CategoryID=@CategoryID, SubCategoryID=@SubCategoryID
		, UniqueURL=@UniqueURL, SEOTitle=@SEOTitle, SEODescription=@SEODescription, SEOKeywords=@SEOKeywords, CreatedDate=@CreatedDate, CreatedTime=@CreatedTime
		, CreatedBy=@CreatedBy, ModifiedDate=@ModifiedDate, ModifiedTime=@ModifiedTime, ModifiedBy=@ModifiedBy, Status_Ind=@Status
		WHERE Posts.Post_Id=@PostID;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;

	END

	
	IF(@Flag=2)
	BEGIN

		UPDATE Posts SET Status_Ind=0 WHERE POST_ID = @PostID;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;

	END


	IF(@Flag=3)
	BEGIN

		SELECT Post_Id, PostTitle, ShortDescription, FullDescription, CategoryID, SubCategoryID, UniqueURL, SEOTitle, SEODescription, SEOKeywords, CreatedDate, CreatedTime
		, CreatedBy, ModifiedDate, ModifiedTime, ModifiedBy, Status_Ind
		FROM Posts 
		WHERE Status_Ind=1;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;

	END

	IF(@Flag= 4)
	BEGIN
		SELECT Post_Id, PostTitle, ShortDescription, FullDescription, CategoryID, SubCategoryID, UniqueURL, SEOTitle, SEODescription, SEOKeywords, CreatedDate, CreatedTime
		, CreatedBy, ModifiedDate, ModifiedTime, ModifiedBy, Status_Ind
		FROM Posts;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;
	END

	IF(@Flag= 5)
	BEGIN

		SELECT Post_Id, PostTitle, ShortDescription, FullDescription, CategoryID, SubCategoryID, UniqueURL, SEOTitle, SEODescription, SEOKeywords, CreatedDate, CreatedTime
		, CreatedBy, ModifiedDate, ModifiedTime, ModifiedBy, Status_Ind
		FROM Posts 
		WHERE Status_Ind=0;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;
	END

	IF(@Flag= 6)
	BEGIN
		SELECT Post_Id, PostTitle, ShortDescription, FullDescription, CategoryID, SubCategoryID, UniqueURL, SEOTitle, SEODescription, SEOKeywords, CreatedDate, CreatedTime
		, CreatedBy, ModifiedDate, ModifiedTime, ModifiedBy, Status_Ind
		FROM Posts 
		WHERE POST_ID=@PostID;

		SELECT @ROWS_EFFECTED = @@ROWCOUNT;

	END

	SELECT @ROWS_EFFECTED;

END;

 