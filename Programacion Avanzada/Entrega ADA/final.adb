with Ada.Text_IO;
with Central;
with Ada.Numerics.Discrete_Random;
with Ada.Real_Time;
use Ada.Real_Time;


procedure Final is
  -- Constantes compartidas
  CONSUMO_MAX_CIUDAD: constant Integer := 90;
  CONSUMO_MIN_CIUDAD: constant Integer := 15;

  -- Variable para actualizar el consumo de la ciudad
  -- La tarea 'Actualizador_Ciudad' lo marca, el resto de tareas leen y actuan
  consumo: Integer := 35;
  pragma Volatile(consumo);
  pragma Atomic(consumo);

  -- Tenemos una tarea que representa una ciudad, se refrescara cada 6s
  task type Actualizador_Ciudad is
  end Actualizador_Ciudad;

  task body Actualizador_Ciudad is
    subtype RngRange is Integer range -3..3;
    package Random is new Ada.Numerics.Discrete_Random(RngRange);
    seed: Random.Generator;
    tiempo_operacion: Time;
    consumo_Actual: Integer;
    Intervalo_Resfresco: constant Time_Span := Seconds(6);
  begin
    Random.reset(seed);

    tiempo_operacion := Clock;
    loop
      consumo_Actual := consumo;
      consumo_Actual := consumo_Actual + Random.random(seed);
      if consumo_Actual > CONSUMO_MAX_CIUDAD then
        consumo_Actual := CONSUMO_MAX_CIUDAD;
      end if;
      if consumo_Actual < CONSUMO_MIN_CIUDAD then
        consumo_Actual := CONSUMO_MIN_CIUDAD;
      end if;
      consumo := consumo_Actual;
      tiempo_operacion := tiempo_operacion + Intervalo_Resfresco;
      delay until tiempo_operacion;
    end loop;
  end Actualizador_Ciudad;

  centrales: Array(1..3) of Central.Central;
  centrales_usadas: Array(1..3) of Boolean;
  valores_actuales: Array(1..3) of Integer;
  city: Actualizador_Ciudad;
  consumo_Ciudad: Integer;

  min_value: Integer;
  min_value_index: Integer;
  max_value: Integer;
  max_value_index: Integer;

  produccion: Integer;
  produccion_esperada: Integer;

  tiempo_operacion: Time;
  ratio: Float;

   Intervalo_Resfresco: constant Time_Span := Seconds(1);
   retraso_Inicio: constant Time_Span := MilliSeconds(300);
begin
  tiempo_operacion := Clock;

  for i in centrales'Range loop
    centrales(i).inicio;
  end loop;

   -- Retardo tras iniciar las centrales
   tiempo_operacion := tiempo_operacion + retraso_Inicio;
   delay until tiempo_operacion;

  loop
    consumo_Ciudad := consumo;

    -- Leemos los valores de las centrales
    for i in centrales'Range loop
      centrales(i).Leer_Valor(valores_actuales(i));
    end loop;

    -- Suma los valores de las centrales a la produccion
    produccion := 0;
    for i in valores_actuales'Range loop
      produccion := produccion + valores_actuales(i);
    end loop;

    -- Calcula la produccion actual para ver si el sistema es estable
    ratio := Float(produccion - consumo_Ciudad) / Float(consumo_Ciudad);
    if ratio < -0.05 then
      Ada.Text_IO.Put("PELIGRO BAJADA");
    elsif ratio > 0.05 then
      Ada.Text_IO.Put("PELIGRO SOBRECARGA");
    else
      Ada.Text_IO.Put("ESTABLE");
    end if;

    Ada.Text_IO.Put_Line(" Consumo:" & consumo_Ciudad'Img & " Produccion:" & produccion'Img);

    for i in centrales_usadas'Range loop
      centrales_usadas(i) := false;
    end loop;

    produccion_esperada := produccion;
    for i in valores_actuales'Range loop
      if produccion_esperada < consumo_Ciudad then
        min_value := Central.PRODUCC_MAX;
        min_value_index := -1;
        for j in valores_actuales'Range loop
          if valores_actuales(j) <= min_value and centrales_usadas(j) = false then
            min_value_index := j;
            min_value := valores_actuales(j);
          end if;
        end loop;

        if min_value_index /= -1 then
          Ada.Text_IO.Put_Line("SUBO " & min_value_index'Img);
          produccion_esperada := produccion_esperada + 1;
          centrales(min_value_index).Incremento;
          centrales_usadas(min_value_index) := true;
        else
          Ada.Text_IO.Put_Line("Error al hacer el Incremento");
        end if;
      elsif produccion_esperada > consumo_Ciudad then
        max_value := Central.PRODUCC_MIN;
        max_value_index := -1;

        for j in valores_actuales'Range loop
          if valores_actuales(j) >= max_value and centrales_usadas(j) = false then
            max_value_index := j;
            max_value := valores_actuales(j);
          end if;
        end loop;

        if max_value_index /= -1 then
          Ada.Text_IO.Put_Line("BAJO " & max_value_index'Img);
          produccion_esperada := produccion_esperada - 1;
          centrales(max_value_index).Decremento;
          centrales_usadas(max_value_index) := true;
        else
          Ada.Text_IO.Put_Line("Error al hacer el decremento");
        end if;
      end if;
    end loop;

    for i in centrales_usadas'Range loop
      if centrales_usadas(i) = false then
        centrales(i).mantener;
      end if;
    end loop;

    tiempo_operacion := tiempo_operacion + Intervalo_Resfresco;
    delay until tiempo_operacion;
  end loop;
end Final;
