INSERT INTO [dbo].[AspNetUsers] (Id, UserName, PasswordHash, SecurityStamp, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, AccessFailedCount, LockoutEnabled) 
VALUES ('f49a3d52-e826-4c1a-9ec9-00857c4148a5', 'admin', 'ANMjFwazB53HGTdy9XizkdmAHovlb1+6bLDvlkcSAvFzV+v2Qy1u07K65eTBHuGZSA==', 'f58dded1-8053-4857-84ff-4dbd7a9f36f8', 'enter.your@email.here', 0, 0, 0, 0, 0)

INSERT INTO AspNetRoles(Id, Name) VALUES ('56470308-4e48-40fb-88d5-b7f617386496', 'Admin')

INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('f49a3d52-e826-4c1a-9ec9-00857c4148a5', '56470308-4e48-40fb-88d5-b7f617386496')