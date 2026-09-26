Declare @nomeFile varchar(max)
declare @backupSetId as int
 
set @nomeFile = 'C:\XXXX_' + REPLACE(REPLACE(REPLACE(convert(varchar(50),Getdate(), 120),':','_'),' ','__'),'.','_') + '.bak'

BACKUP DATABASE [XXXX] TO  DISK = @nomeFile WITH NOFORMAT, INIT,  NAME = N'XXX-Full database backup', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO
select @backupSetId = position from msdb..backupset where database_name=N'XXXX' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N'XXXX' )
if @backupSetId is null begin raiserror(N'Verification failed. Unable to find backup information for the database ''XXXX''.', 16, 1) end
RESTORE VERIFYONLY FROM  DISK = @nomeFile WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND