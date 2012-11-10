IF OBJECT_ID ( 'SP_AddOrUpdateDataLine', 'P' ) IS NOT NULL 
    DROP PROCEDURE SP_AddOrUpdateDataLine;
GO

create proc SP_AddOrUpdateDataLine(
	@catalogCode varchar(512),
	@code varchar(512),
	@name nvarchar(512),
	@parentCode varchar(512),
	@description ntext	
)
as
begin

	declare @catalogId as uniqueidentifier;
	declare @dataLineId as uniqueidentifier;
	declare @parentId as uniqueidentifier;
	declare @dataLineLastPosition as int;
	select @catalogId = [Id] from [Catalog] where [Code] = @catalogCode;
	select @dataLineId = [Id] from [DataLine] where [Code] = @code and [CatalogId] = @catalogId;
	select @parentId = [Id] from [DataLine] where [Code] = @parentCode and [CatalogId] = @catalogId;
	select @dataLineLastPosition = [Position] from [DataLine] where [CatalogId] = @catalogId order by [Position] desc;

	if @catalogId is not NULL 
		begin
			if @dataLineLastPosition is NULL
				set @dataLineLastPosition = 1;
			else
				set @dataLineLastPosition = @dataLineLastPosition + 1;

			declare @newid as uniqueidentifier;
			set @newid = newid();

			insert into EntityHistoryComplex ([Id], [IsActive], [Views], [CreatedAt], [CreatedBy]) values
			(@newid, 1, 0, getdate(), 'admin@webframework.com');

			if @dataLineId is NULL

				insert into [DataLine] ([Id], [CatalogId], [ParentId], [Code], [Name], [Position]) values
				(@newid, @catalogId, @parentId, @code, @name, @dataLineLastPosition);

			else
				update [DataLine] set [Name] = @name, [ParentId] = @parentId where [Id] = @dataLineId;
				
		end
	else
		raiserror('The catalog %s is not exists', 10, 1, @catalogCode);

end

GO
