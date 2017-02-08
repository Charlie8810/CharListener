CREATE PROCEDURE [dbo].[sp_SRV_ListenerIA]
	@nombre_tarea VARCHAR(500)
AS
BEGIN
  
DECLARE @retorno int = 0, 
				@ejecutadoHoy int = 0, 
				@enHorasDeEjecucion int = 0,
				@horaInicio time = '16:00:00.0000000',
				@horaFin time = '17:00:00.0000000';



select @ejecutadoHoy = count(1) 
from SRV_ListenerIA_Log
where CONVERT(date,Fecha_Ejecucion) =  CONVERT(date,GETDATE())

/*SI NO SE EJECUTO HOY*/
IF @ejecutadoHoy = 0
BEGIN
	/*SI ESTAMOS EN LAS HORAS DE EJECUCION*/
	IF CONVERT(time,GETDATE()) BETWEEN @horaInicio AND @horaFin
		BEGIN
			--EXEC msdb.dbo.sp_start_job @nombre_tarea
			insert into SRV_ListenerIA_Log values (GETDATE(),@nombre_tarea);
			set @retorno = 1;
		END	
	
END


select @retorno retorno;

END

GO

CREATE TABLE [dbo].[SRV_ListenerIA_Log] (
[Fecha_Ejecucion] datetime NULL ,
[Anotacion] varchar(500) COLLATE Modern_Spanish_CI_AS NULL 
)
ON [PRIMARY]
GO