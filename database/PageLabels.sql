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