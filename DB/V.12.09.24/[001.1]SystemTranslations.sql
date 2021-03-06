exec SP_AddOrUpdateTranslation 'GUI.DetailsPage.AuthorInfo.SearchTooltip', 'Search content created by this author', 'en';
exec SP_AddOrUpdateTranslation 'GUI.DetailsPage.AuthorInfo.SearchTooltip', N'Xem các bài viết theo tác giả này', 'vi';

exec SP_ChangeKeywordTranslation 'GUI.RegisterModel.Email', 'GUI.User.Email';
exec SP_ChangeKeywordTranslation 'GUI.AccountInformation.Password', 'GUI.User.Password';
exec SP_ChangeKeywordTranslation 'GUI.LogOnModel.UserName', 'GUI.User.UserName';
exec SP_ChangeKeywordTranslation 'GUI.RegisterModel.ConfirmPassword', 'GUI.User.ConfirmPassword';
exec SP_ChangeKeywordTranslation 'GUI.Account.ConfirmPassword.Error', 'GUI.User.ConfirmPassword.Error';

exec SP_AddOrUpdateTranslation 'GUI.Search.ByAuthor.Description', 'Search all content created by {0}', 'en';
exec SP_AddOrUpdateTranslation 'GUI.Search.ByAuthor.Description', N'Xem các bài viết theo tác giả {0}', 'vi';

