exec SP_AddOrUpdateCatalog 'c.languages', 'System languages', 1;
exec SP_AddOrUpdateDataLine 'c.languages', 'en', 'English', NULL, 'English';
exec SP_AddOrUpdateDataLine 'c.languages', 'vi', N'Tiếng Việt', NULL, N'Tiếng Việt';
GO
