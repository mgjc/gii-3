with Ada.Text_IO;

package body Central is
  protected body Central is
    procedure Alerta_Monitor(event: in out Timing_Event) is
    begin
      Ada.Text_IO.Put_Line("ALERTA: MONITORIZACIO“N");
    end Alerta_Monitor;

    procedure Restablecer_Monitor is
    begin
      Set_Handler(Evento_Monitor,
                  INTERVALO_ALERTA_MONIT,
                  Alerta_Monitor'Access);
    end Restablecer_Monitor;

    procedure Llamada_Incremento(event: in out Timing_Event) is
    begin
      produccion_Actual := produccion_Actual + 1;
      Incremento_Sin_Aplicar := false;
    end Llamada_Incremento;

    procedure Llamada_Decremento(event: in out Timing_Event) is
    begin
      produccion_Actual := produccion_Actual - 1;
      Decremento_Sin_Aplicar := false;
    end Llamada_Decremento;

    entry inicio
    when iniciada = false is
    begin
      Restablecer_Monitor;
      iniciada := true;
    end inicio;

    entry Leer_Valor(value: out Integer)
    when iniciada is
    begin
      delay SENSOR_JITTER;
      value := produccion_Actual;
    end Leer_Valor;

    entry Incremento
    when iniciada and produccion_Actual < PRODUCC_MAX is
      cancelado: Boolean;
    begin
      Restablecer_Monitor;
      if Incremento_Sin_Aplicar = false then
        if Decremento_Sin_Aplicar then
          Cancel_Handler(Evento_Decrementar, cancelado);
          if cancelado = false then
            Ada.Text_IO.Put_Line("Decremento cancelado por error");
            return;
          end if;
          Decremento_Sin_Aplicar := false;
        end if;

        delay CONTROL_JITTER;

        Set_Handler(Evento_Incrementar,
                    TIEMPO_CAMBIO_PRODUCC,
                    Llamada_Incremento'Access);
        Incremento_Sin_Aplicar := true;
      end if;
    end Incremento;

    entry Decremento
    when iniciada and produccion_Actual > PRODUCC_MIN is
      cancelado: Boolean;
    begin
      Restablecer_Monitor;
      if Decremento_Sin_Aplicar = false then
        if Incremento_Sin_Aplicar then
          Cancel_Handler(Evento_Incrementar, cancelado);
          if cancelado = false then
            Ada.Text_IO.Put_Line("Incremento cancelado por error");
            return;
          end if;
          Incremento_Sin_Aplicar := false;
        end if;

        delay CONTROL_JITTER;

        Set_Handler(Evento_Decrementar,
                    TIEMPO_CAMBIO_PRODUCC,
                    Llamada_Decremento'Access);
        Decremento_Sin_Aplicar := true;
      end if;
    end Decremento;

    entry mantener
    when iniciada is
      cancelado: Boolean;
    begin
      Restablecer_Monitor;

      if Decremento_Sin_Aplicar then
        Cancel_Handler(Evento_Decrementar, cancelado);
        if cancelado = false then
          Ada.Text_IO.Put_Line("Decremento cancelado por error");
          return;
        end if;
        Decremento_Sin_Aplicar := false;
      end if;

      if Incremento_Sin_Aplicar then
        Cancel_Handler(Evento_Incrementar, cancelado);
        if cancelado = false then
          Ada.Text_IO.Put_Line("Incremento cancelado por error");
          return;
        end if;
        Incremento_Sin_Aplicar := false;
      end if;
    end mantener;
  end Central;
end Central;
