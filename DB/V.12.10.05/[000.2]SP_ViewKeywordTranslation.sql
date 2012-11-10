IF OBJECT_ID ( 'SP_ViewTranslation', 'P' ) IS NOT NULL 
    DROP PROCEDURE SP_ViewTranslation;
GO

create proc SP_ViewTranslation(
	@keyword varchar(512)
)
as
begin
	select [Language], [Value] from [Translation] where [Keyword] = @keyword;
end

GO
