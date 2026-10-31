using System;
using System.Globalization;

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
        // Para que se vean bien los acentos y para escribir los decimales con punto (45.67)
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== CAJA REGISTRADORA =====");
            Console.WriteLine("1. Calcular cambio en billetes y monedas");
            Console.WriteLine("2. Aplicar descuento por tipo de cliente");
            Console.WriteLine("3. Validar fecha de entrega");
            Console.WriteLine("4. Verificar folio capicúa");
            Console.WriteLine("5. Redondear precio y diferencia de inventario");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                // ---------------------------------------------------
                // OPCIÓN 1: Calcular cambio en billetes y monedas
                // ---------------------------------------------------
                case 1:
                {
                    Console.Write("Precio: ");
                    int precio = int.Parse(Console.ReadLine());
                    Console.Write("Pago: ");
                    int pago = int.Parse(Console.ReadLine());

                    if (pago < precio)
                    {
                        Console.WriteLine("Pago insuficiente, faltan $" + (precio - pago));
                    }
                    else if (pago == precio)
                    {
                        Console.WriteLine("Pago exacto, no hay cambio");
                    }
                    else
                    {
                        int cambio = pago - precio;
                        Console.WriteLine("Cambio: " + cambio);

                        // En cada denominación se usa / para contar y % para lo que sobra
                        int b200 = cambio / 200;
                        cambio = cambio % 200;
                        int b100 = cambio / 100;
                        cambio = cambio % 100;
                        int b50 = cambio / 50;
                        cambio = cambio % 50;
                        int b20 = cambio / 20;
                        cambio = cambio % 20;
                        int m10 = cambio / 10;
                        cambio = cambio % 10;
                        int m5 = cambio / 5;
                        cambio = cambio % 5;
                        int m2 = cambio / 2;
                        cambio = cambio % 2;
                        int m1 = cambio;

                        if (b200 > 0)
                        {
                            Console.WriteLine(b200 + " billete de 200");
                        }
                        if (b100 > 0)
                        {
                            Console.WriteLine(b100 + " billete de 100");
                        }
                        if (b50 > 0)
                        {
                            Console.WriteLine(b50 + " billete de 50");
                        }
                        if (b20 > 0)
                        {
                            Console.WriteLine(b20 + " billete de 20");
                        }
                        if (m10 > 0)
                        {
                            Console.WriteLine(m10 + " moneda de 10");
                        }
                        if (m5 > 0)
                        {
                            Console.WriteLine(m5 + " moneda de 5");
                        }
                        if (m2 > 0)
                        {
                            Console.WriteLine(m2 + " moneda de 2");
                        }
                        if (m1 > 0)
                        {
                            Console.WriteLine(m1 + " moneda de 1");
                        }
                    }
                    break;
                }

                // ---------------------------------------------------
                // OPCIÓN 2: Aplicar descuento por tipo de cliente
                // ---------------------------------------------------
                case 2:
                {
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

                    // switch sobre el tipo de cliente (mayúscula y minúscula con case agrupados)
                    switch (tipo)
                    {
                        case 'E':
                        case 'e':
                            porcentaje = 15;
                            break;
                        case 'D':
                        case 'd':
                            porcentaje = 10;
                            esDocente = true;
                            break;
                        case 'G':
                        case 'g':
                            porcentaje = 0;
                            break;
                        default:
                            tipoValido = false;
                            Console.WriteLine("Tipo de cliente no válido");
                            break;
                    }

                    if (tipoValido)
                    {
                        // Descuento adicional del 5 %
                        if ((subtotal >= 500 && tieneCredencial) || esDocente)
                        {
                            porcentaje = porcentaje + 5;
                        }

                        double descuento = subtotal * porcentaje / 100;
                        double total = subtotal - descuento;

                        Console.WriteLine("Subtotal: $" + subtotal.ToString("0.0#"));
                        Console.WriteLine("Descuento total: " + porcentaje.ToString("0.0#") + " % = $" + descuento.ToString("0.0#"));
                        Console.WriteLine("Total a pagar: $" + total.ToString("0.0#"));
                    }
                    break;
                }

                // ---------------------------------------------------
                // OPCIÓN 3: Validar fecha de entrega
                // ---------------------------------------------------
                case 3:
                {
                    Console.Write("Día: ");
                    int dia = int.Parse(Console.ReadLine());
                    Console.Write("Mes: ");
                    int mes = int.Parse(Console.ReadLine());
                    Console.Write("Año: ");
                    int anio = int.Parse(Console.ReadLine());

                    // 1. ¿El año es bisiesto?
                    bool esBisiesto = (anio % 4 == 0 && anio % 100 != 0) || anio % 400 == 0;

                    // 2. Días del mes con switch y fall-through (case agrupados sin código entre ellos)
                    int diasMes = 0;
                    switch (mes)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            diasMes = 31;
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            diasMes = 30;
                            break;
                        case 2:
                            if (esBisiesto)
                            {
                                diasMes = 29;
                            }
                            else
                            {
                                diasMes = 28;
                            }
                            break;
                        default:
                            diasMes = 0;
                            break;
                    }

                    // 3. Validar mes y día
                    bool fechaValida = (mes >= 1 && mes <= 12) && (dia >= 1 && dia <= diasMes);

                    // 4. Mostrar el resultado
                    if (fechaValida)
                    {
                        Console.Write("Fecha válida");
                    }
                    else
                    {
                        Console.Write("Fecha inválida");
                    }
                    if (esBisiesto)
                    {
                        Console.WriteLine(", año bisiesto");
                    }
                    else
                    {
                        Console.WriteLine(", año no bisiesto");
                    }
                    break;
                }

                // ---------------------------------------------------
                // OPCIÓN 4: Verificar folio capicúa
                // ---------------------------------------------------
                case 4:
                {
                    Console.Write("Folio (4 dígitos): ");
                    int folio = int.Parse(Console.ReadLine());

                    if (folio >= 1000 && folio <= 9999)
                    {
                        // Separar los 4 dígitos solo con / y %
                        int d1 = folio / 1000;
                        int d2 = (folio / 100) % 10;
                        int d3 = (folio / 10) % 10;
                        int d4 = folio % 10;

                        bool esCapicua = (d1 == d4) && (d2 == d3);
                        int suma = d1 + d2 + d3 + d4;
                        long producto = (long)d1 * d2 * d3 * d4;

                        if (esCapicua)
                        {
                            Console.Write("Es capicúa");
                        }
                        else
                        {
                            Console.Write("No es capicúa");
                        }

                        if (suma % 2 == 0)
                        {
                            Console.WriteLine(", suma = " + suma + " (par), producto = " + producto);
                        }
                        else
                        {
                            Console.WriteLine(", suma = " + suma + " (impar), producto = " + producto);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Folio inválido");
                    }
                    break;
                }

                // ---------------------------------------------------
                // OPCIÓN 5: Redondear precio y diferencia de inventario
                // ---------------------------------------------------
                case 5:
                {
                    // Parte A: redondeo con cast y suma de 0.5
                    Console.Write("Precio: ");
                    double precio = double.Parse(Console.ReadLine());

                    int redondeado = (int)(precio + 0.5);
                    double ajuste = redondeado - precio;

                    Console.WriteLine(precio + " -> " + redondeado);
                    if (ajuste > 0)
                    {
                        Console.WriteLine("Parte decimal agregada: " + ajuste.ToString("F2"));
                    }
                    else if (ajuste < 0)
                    {
                        Console.WriteLine("Parte decimal descartada: " + (-ajuste).ToString("F2"));
                    }
                    else
                    {
                        Console.WriteLine("El precio ya era entero");
                    }

                    // Parte B: diferencia de inventario
                    Console.WriteLine();
                    Console.Write("Piezas esperadas: ");
                    int esperadas = int.Parse(Console.ReadLine());
                    Console.Write("Piezas contadas: ");
                    int contadas = int.Parse(Console.ReadLine());

                    int diferencia = contadas - esperadas;
                    // Valor absoluto con el operador ternario
                    int absoluto = (diferencia < 0) ? -diferencia : diferencia;

                    if (diferencia == 0)
                    {
                        Console.WriteLine("Inventario correcto");
                    }
                    else if (contadas < esperadas)
                    {
                        Console.WriteLine("Faltan " + absoluto + " piezas");
                    }
                    else
                    {
                        Console.WriteLine("Sobran " + absoluto + " piezas");
                    }
                    break;
                }

                // ---------------------------------------------------
                // OPCIÓN 6: Salir
                // ---------------------------------------------------
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
