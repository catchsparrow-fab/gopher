DELETE FROM Languages

INSERT INTO Languages (LanguageId, LanguageName) VALUES (1, 'English')
INSERT INTO Languages (LanguageId, LanguageName) VALUES (2, 'Japanese')

GO

AddTranslation 'Languages_English', 'English'
AddTranslation 'Languages_Japanese', 'Japanese'