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
exec AddTranslation 'Generic_Password', 'Password'
exec AddTranslation 'Generic_Success', 'Success'
exec AddTranslation 'Generic_Error', 'Error'
exec AddTranslation 'Generic_Status', 'Status'

exec AddTranslation 'Login_Welcome', 'Welcome to GOPHER.'
exec AddTranslation 'Login_Welcome_Subheader', 'Please enter your username and password to continue.'
exec AddTranslation 'Login_LogIn', 'Log in'
exec AddTranslation 'Login_RememberMe', 'Remember me'

exec AddTranslation 'Account_OldPassword', 'Old password'
exec AddTranslation 'Account_NewPassword', 'New password'
exec AddTranslation 'Account_ConfirmNewPassword', 'Confirm new password'
exec AddTranslation 'Account_Tabs_MyPreferences', 'My preferences'
exec AddTranslation 'Account_Tabs_ChangeMyPassword', 'Change my password'
exec AddTranslation 'Account_YouAreLoggedInAs', 'You''re logged in as'

exec AddTranslation 'Import_Info', 'Choose an ECCUBE or TempoVisor file on your computer to upload.'
exec AddTranslation 'Import_Upload', 'Upload'
exec AddTranslation 'Import_SuccessfullyUploaded', 'Successfully uploaded'
exec AddTranslation 'Import_ErrorUploadingFile', 'Errors occured during file upload'
exec AddTranslation 'Import_Summary', 'Summary'
exec AddTranslation 'Import_FileName', 'File name'
exec AddTranslation 'Import_Parser', 'Parser'
exec AddTranslation 'Import_ParserStatus', 'Parser status'
exec AddTranslation 'Import_FileFormat', 'File format'
exec AddTranslation 'Import_FileSize', 'File size'
exec AddTranslation 'Import_RowsInFile', 'Rows in file'
exec AddTranslation 'Import_DatabaseImport', 'Database import'
exec AddTranslation 'Import_DatabaseImportStatus', 'Database import status'
exec AddTranslation 'Import_RowsAffected', 'RowsAffected'