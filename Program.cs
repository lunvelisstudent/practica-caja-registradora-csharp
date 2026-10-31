using System;

/*
 * Práctica: "Caja Registradora de la Papelería"
 * Equipo: Lunvelis Campus
 * Integrantes: Irvin Gael Hernández Serrano y Kevin Alexander Ugalde Chávez
 * Matrículas: 261160011 y 261160001
 */
class Program
{
    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("\n===== CAJA REGISTRADORA =====\n1. Calcular cambio en billetes y monedas\n2. Aplicar descuento por tipo de cliente\n3. Validar fecha de entrega\n4. Verificar folio capicúa\n5. Redondear precio y diferencia de inventario\n6. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case 1: // Cambio en billetes y monedas (solo con / y %)
                    Console.Write("Precio: ");
                    int precio = int.Parse(Console.ReadLine());
                    Console.Write("Pago: ");
                    int pago = int.Parse(Console.ReadLine());

                    if (pago < precio)
                        Console.WriteLine("Pago insuficiente, faltan $" + (precio - pago));
                    else if (pago == precio)
                        Console.WriteLine("Pago exacto, no hay cambio");
                    else
                    {
                        int cambio = pago - precio;
                        Console.WriteLine("Cambio: " + cambio);
                        if (cambio / 200 > 0) Console.WriteLine(cambio / 200 + " billete de 200");
                        cambio = cambio % 200;
                        if (cambio / 100 > 0) Console.WriteLine(cambio / 100 + " billete de 100");
                        cambio = cambio % 100;
                        if (cambio / 50 > 0) Console.WriteLine(cambio / 50 + " billete de 50");
                        cambio = cambio % 50;
                        if (cambio / 20 > 0) Console.WriteLine(cambio / 20 + " billete de 20");
                        cambio = cambio % 20;
                        if (cambio / 10 > 0) Console.WriteLine(cambio / 10 + " moneda de 10");
                        cambio = cambio % 10;
                        if (cambio / 5 > 0) Console.WriteLine(cambio / 5 + " moneda de 5");
                        cambio = cambio % 5;
                        if (cambio / 2 > 0) Console.WriteLine(cambio / 2 + " moneda de 2");
                        cambio = cambio % 2;
                        if (cambio > 0) Console.WriteLine(cambio + " moneda de 1");
                    }
                    break;

                case 2: // Descuento por tipo de cliente
                    Console.Write("Subtotal: ");
                    double subtotal = double.Parse(Console.ReadLine());
                    Console.Write("Tipo de cliente (E = Estudiante, D = Docente, G = General): ");
                    char tipo = Console.ReadLine()[0];
                    Console.Write("¿Tiene credencial? (S/N): ");
                    char respuesta = Console.ReadLine()[0];
                    bool tieneCredencial = (respuesta == 'S' || respuesta == 's');

                    double porcentaje = 0;
                    bool tipoValido = true;
                    bool esDocente = false;

                    switch (tipo)
                    {
                        case 'E': case 'e': porcentaje = 15; break;
                        case 'D': case 'd': porcentaje = 10; esDocente = true; break;
                        case 'G': case 'g': porcentaje = 0; break;
                        default: tipoValido = false; Console.WriteLine("Tipo de cliente no válido"); break;
                    }

                    if (tipoValido)
                    {
                        // Descuento adicional del 5 %
                        if ((subtotal >= 500 && tieneCredencial) || esDocente) porcentaje = porcentaje + 5;

                        double descuento = subtotal * porcentaje / 100;
                        Console.WriteLine("Subtotal: $" + subtotal.ToString("0.0#"));
                        Console.WriteLine("Descuento total: " + porcentaje.ToString("0.0#") + " % = $" + descuento.ToString("0.0#"));
                        Console.WriteLine("Total a pagar: $" + (subtotal - descuento).ToString("0.0#"));
                    }
                    break;

                case 3: // Validar fecha (switch con fall-through)
                    Console.Write("Día: ");
                    int dia = int.Parse(Console.ReadLine());
                    Console.Write("Mes: ");
                    int mes = int.Parse(Console.ReadLine());
                    Console.Write("Año: ");
                    int anio = int.Parse(Console.ReadLine());

                    bool esBisiesto = (anio % 4 == 0 && anio % 100 != 0) || anio % 400 == 0;
                    int diasMes = 0;

                    switch (mes)
                    {
                        case 1: case 3: case 5: case 7: case 8: case 10: case 12: diasMes = 31; break;
                        case 4: case 6: case 9: case 11: diasMes = 30; break;
                        case 2: if (esBisiesto) diasMes = 29; else diasMes = 28; break;
                        default: diasMes = 0; break;
                    }

                    bool fechaValida = (mes >= 1 && mes <= 12) && (dia >= 1 && dia <= diasMes);
                    Console.WriteLine((fechaValida ? "Fecha válida" : "Fecha inválida") + (esBisiesto ? ", año bisiesto" : ", año no bisiesto"));
                    break;

                case 4: // Folio capicúa (dígitos solo con / y %)
                    Console.Write("Folio (4 dígitos): ");
                    int folio = int.Parse(Console.ReadLine());

                    if (folio >= 1000 && folio <= 9999)
                    {
                        int d1 = folio / 1000;
                        int d2 = (folio / 100) % 10;
                        int d3 = (folio / 10) % 10;
                        int d4 = folio % 10;

                        bool esCapicua = (d1 == d4) && (d2 == d3);
                        int suma = d1 + d2 + d3 + d4;
                        long producto = (long)d1 * d2 * d3 * d4;

                        Console.WriteLine((esCapicua ? "Es capicúa" : "No es capicúa") + ", suma = " + suma + (suma % 2 == 0 ? " (par)" : " (impar)") + ", producto = " + producto);
                    }
                    else
                        Console.WriteLine("Folio inválido");
                    break;

                case 5: // Redondeo con cast y diferencia de inventario
                    Console.Write("Precio: ");
                    double valor = double.Parse(Console.ReadLine());
                    int redondeado = (int)(valor + 0.5);
                    double ajuste = redondeado - valor;

                    Console.WriteLine(valor + " -> " + redondeado);
                    if (ajuste > 0)
                        Console.WriteLine("Parte decimal agregada: " + ajuste.ToString("F2"));
                    else if (ajuste < 0)
                        Console.WriteLine("Parte decimal descartada: " + (-ajuste).ToString("F2"));
                    else
                        Console.WriteLine("El precio ya era entero");

                    Console.Write("\nPiezas esperadas: ");
                    int esperadas = int.Parse(Console.ReadLine());
                    Console.Write("Piezas contadas: ");
                    int contadas = int.Parse(Console.ReadLine());

                    int diferencia = contadas - esperadas;
                    int absoluto = (diferencia < 0) ? -diferencia : diferencia; // valor absoluto con ternario

                    if (diferencia == 0)
                        Console.WriteLine("Inventario correcto");
                    else if (contadas < esperadas)
                        Console.WriteLine("Faltan " + absoluto + " piezas");
                    else
                        Console.WriteLine("Sobran " + absoluto + " piezas");
                    break;

                case 6:
                    Console.WriteLine("Gracias por usar la caja registradora");
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }

        } while (opcion != 6);
    }
}
