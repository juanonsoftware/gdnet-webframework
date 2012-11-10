IF OBJECT_ID ( 'SP_DeleteTranslation', 'P' ) IS NOT NULL 
    DROP PROCEDURE SP_DeleteTranslation;
GO

create proc SP_DeleteTranslation(
	@keyword varchar(512)
)
as
begin
	declare @tranid as uniqueidentifier;
	select @tranid = [Id] from Translation where [Keyword] = @keyword;
	
	if @tranid is NOT NULL 
		begin

			delete Translation where [Id] = @tranid;
			delete EntityHistoryComplex where [Id] = @tranid;

		end

end

GO
