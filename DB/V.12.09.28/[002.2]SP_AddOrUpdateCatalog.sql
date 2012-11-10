IF OBJECT_ID ( 'SP_AddOrUpdateCatalog', 'P' ) IS NOT NULL 
    DROP PROCEDURE SP_AddOrUpdateCatalog;
GO

create proc SP_AddOrUpdateCatalog(
	@code varchar(512),
	@name nvarchar(512),
	@isCustomizable bit
)
as
begin

	declare @newid as uniqueidentifier;
	select @newid = [Id] from [Catalog] where [Code] = @code;
	
	if @newid is NULL 
		begin
			set @newid = newid();

			insert into EntityHistoryComplex ([Id], [IsActive], [Views], [CreatedAt], [CreatedBy]) values
			(@newid, 1, 0, getdate(), 'admin@webframework.com');

			insert into [Catalog] ([Id], [Code], [Name], [IsCustomizable]) values
			(@newid, @code, @name, @isCustomizable);

		end
	else
		begin
			update [Catalog] set [IsCustomizable] = @isCustomizable, [Name] = @name where [Id] = @newid;
		end

end

GO
