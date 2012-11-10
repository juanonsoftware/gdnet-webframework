-- Allow NULL on EntityHistoryId, it will be updated by NHibernate
alter table [EntityLog]
alter column [EntityHistoryId] uniqueidentifier NULL
GO

-- Remove FirstLogId
alter table [EntityHistoryComplex]
drop constraint [FK_EntityHistoryComplex_EntityLog_FirstLog]
GO

alter table [EntityHistoryComplex]
drop column [FirstLogId]
GO

alter table [EntityHistoryComplex] drop column [LastModifiedAt], [LastModifiedBy]
GO