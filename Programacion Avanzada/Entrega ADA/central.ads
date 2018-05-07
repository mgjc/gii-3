with Ada.Real_Time.Timing_Events;
use Ada.Real_Time.Timing_Events;

with Ada.Real_Time;
use Ada.Real_Time;

package Central is
  SENSOR_JITTER: constant Duration := To_Duration(Milliseconds(150));
  CONTROL_JITTER: constant Duration := To_Duration(Milliseconds(600));
  PRODUCC_MAX: constant Integer := 30;
  PRODUCC_MIN: constant Integer := 0;
  INTERVALO_ALERTA_MONIT: constant Time_Span := Seconds(5);
  TIEMPO_CAMBIO_PRODUCC: constant Time_Span := Seconds(3);

  protected type Central is
    entry Leer_Valor(value: out Integer);
    entry Incremento;
    entry Decremento;
    entry mantener;
    entry inicio;
  private
    produccion_Actual: Integer := 15;
    Incremento_Sin_Aplicar: Boolean := false;
    Decremento_Sin_Aplicar: Boolean := false;
    iniciada: Boolean := false;
    Evento_Incrementar: Timing_Event;
    Evento_Decrementar: Timing_Event;
    Evento_Monitor: Timing_Event;
  end Central;
end Central;
