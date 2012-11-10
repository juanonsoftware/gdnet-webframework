IF OBJECT_ID ( 'SP_AddOrUpdateTranslation', 'P' ) IS NOT NULL 
    DROP PROCEDURE SP_AddOrUpdateTranslation;
GO

create proc [dbo].[SP_AddOrUpdateTranslation](
	@keyword varchar(512),
	@value ntext,
	@language char(2)
)
as
begin

	declare @newid as uniqueidentifier;
	select @newid = [Id] from Translation where [Keyword] = @keyword and [Language] = @language;
	
	if @newid is NULL 
		begin
			set @newid = newid();

			insert into EntityHistoryComplex ([Id], [IsActive], [Views], [CreatedAt], [CreatedBy]) values
			(@newid, 1, 0, getdate(), 'admin@webframework.com');

			insert into Translation ([Id], [Keyword], [Language], [Value]) values
			(@newid, @keyword, @language, @value);
		end
	else
		begin
			update Translation set [Value] = @value where [Id] = @newid;
		end

end

GO
