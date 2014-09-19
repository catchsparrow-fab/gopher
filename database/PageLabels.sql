DELETE FROM Languages

INSERT INTO Languages (LanguageId, LanguageName) VALUES (1, 'English')
INSERT INTO Languages (LanguageId, LanguageName) VALUES (2, 'Japanese')

GO

exec AddTranslation 'Languages_English', 'English'
exec AddTranslation 'Languages_Japanese', 'Japanese'

exec AddTranslation 'Header_CustomerSearch', 'Customer search'
exec AddTranslation 'Header_Import', 'Import'
exec AddTranslation 'Header_Administration', 'Administration'
exec AddTranslation 'Header_Greeting', 'Hello'
exec AddTranslation 'Header_LogOff', 'Log off'

exec AddTranslation 'Administration_Tabs_Users', 'Users'
exec AddTranslation 'Administration_Tabs_Codes', 'Codes'
exec AddTranslation 'Administration_Tabs_Translations', 'Translations'
exec AddTranslation 'Administration_Users_NewUser', 'New user'
exec AddTranslation 'Administration_Users_EditUser', 'Edit user'
exec AddTranslation 'Administration_Translations_EditTranslation', 'Edit translation'

exec AddTranslation 'Generic_ClearCache', 'Clear cache'
exec AddTranslation 'Generic_CacheCleared', 'Cache successfully cleared'
exec AddTranslation 'Generic_Name', 'Name'
exec AddTranslation 'Generic_Email', 'Email'
exec AddTranslation 'Generic_Language', 'Language'
exec AddTranslation 'Generic_IsAdmin', 'Is Admin'
exec AddTranslation 'Generic_Save', 'Save'
exec AddTranslation 'Generic_Back', 'Back'