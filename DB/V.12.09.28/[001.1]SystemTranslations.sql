exec SP_AddOrUpdateTranslation 'GUI.LogOnPage.Description', '{0} if you don''t have an account.', 'en';
exec SP_AddOrUpdateTranslation 'GUI.LogOnPage.Description', N'{0} nếu bạn chưa tạo tài khoản.', 'vi';

exec SP_DeleteTranslation 'GUI.LogOnPage.Description1';
exec SP_DeleteTranslation 'GUI.LogOnPage.Description2';

exec SP_AddOrUpdateTranslation 'GUI.ContentItem.Language', 'Language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.ContentItem.Language', N'Ngôn ngữ', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Language', 'Language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Language', N'Ngôn ngữ', 'vi';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.ApplyForUI', 'Apply to UI', 'en';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.ApplyForUI', N'Thay đổi cả giao diện', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.User.Language', 'UI language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.User.Language', N'Ngôn ngữ giao diện', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.UserCustomizedInformation.LanguageNotSelected', 'All languages', 'en';
exec SP_AddOrUpdateTranslation 'GUI.UserCustomizedInformation.LanguageNotSelected', N'Tất cả ngôn ngữ', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.UserCustomizedInformation.ChangeLanguage', 'Change', 'en';
exec SP_AddOrUpdateTranslation 'GUI.UserCustomizedInformation.ChangeLanguage', N'Thay đổi', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Title', 'Choose a language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Title', N'Chọn ngôn ngữ', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Legend', 'Choose a language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.My.ChangeLanguage.Legend', N'Chọn ngôn ngữ', 'vi';
