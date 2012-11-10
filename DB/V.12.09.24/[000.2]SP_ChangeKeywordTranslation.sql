IF OBJECT_ID ( 'SP_ChangeKeywordTranslation', 'P' ) IS NOT NULL 
    DROP PROCEDURE SP_ChangeKeywordTranslation;
GO

create proc SP_ChangeKeywordTranslation(
	@keyword varchar(512),
	@newKeyword varchar(512)
)
as
begin
	update [Translation] set [Keyword] = @newKeyword where [Keyword] = @keyword;
end

GO
