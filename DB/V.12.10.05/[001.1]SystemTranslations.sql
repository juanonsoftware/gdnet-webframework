exec SP_AddOrUpdateTranslation 'GUI.Common.DropDownList.NullAsAll', '--- All ---', 'en';
exec SP_AddOrUpdateTranslation 'GUI.Common.DropDownList.NullAsAll', N'--- Bất kỳ ---', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.Common.DropDownList.NullAsNone', 'None', 'en';
exec SP_AddOrUpdateTranslation 'GUI.Common.DropDownList.NullAsNone', N'Không', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Language', 'Content language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Language', N'Ngôn ngữ nội dung', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.LanguageUI', 'UI language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.LanguageUI', N'Ngôn ngữ giao diện', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.Common.SiteCopyRight', 'Copyright (C) 2012. All rights reserved.', 'en';
exec SP_AddOrUpdateTranslation 'GUI.Common.SiteCopyRight', N'Copyright (C) 2012. All rights reserved.', 'vi';

exec SP_ChangeKeywordTranslation 'GUI.DetailsPage.AuthorInfo.SearchTooltip', 'GUI.UserDetails.SearchContent';
exec SP_AddOrUpdateTranslation 'GUI.UserDetails.SearchContent', 'Search all contents', 'en';
exec SP_AddOrUpdateTranslation 'GUI.UserDetails.SearchContent', N'Xem các bài viết', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.DetailsPage.Title', '{0} - Details of Content', 'en';
exec SP_AddOrUpdateTranslation 'GUI.DetailsPage.Title', N'{0} - Xem nội dung', 'vi';

GO
