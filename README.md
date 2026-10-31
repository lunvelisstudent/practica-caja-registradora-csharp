# Práctica: Caja Registradora de la Papelería

Equipo **Lunvelis Campus**

- Irvin Gael Hernández Serrano
- Kevin Alexander Ugalde Chávez

Matrículas: 261160011 y 261160001

## Descripción

Programa de consola en C# con un menú controlado por `switch`. Usa los tipos `int`, `long`, `double`, `char` y `bool`.

```
===== CAJA REGISTRADORA =====
1. Calcular cambio en billetes y monedas
2. Aplicar descuento por tipo de cliente
3. Validar fecha de entrega
4. Verificar folio capicúa
5. Redondear precio y diferencia de inventario
6. Salir
Elige una opción:
```

| Opción | Qué hace |
|--------|----------|
| 1 | Calcula el cambio con la menor cantidad de billetes y monedas (solo con `/` y `%`) |
| 2 | Descuento por tipo de cliente (Estudiante 15 %, Docente 10 %, General 0 %) y 5 % adicional según la condición |
| 3 | Valida una fecha y dice si el año es bisiesto (`switch` con fall-through) |
| 4 | Revisa si un folio de 4 dígitos es capicúa, y calcula suma y producto de sus dígitos |
| 5 | Redondea un precio con cast y calcula la diferencia de inventario |
| 6 | Salir |

## Cómo ejecutarlo

**Con Visual Studio:** crea un proyecto nuevo de tipo *Aplicación de consola* (C#), reemplaza todo el contenido de `Program.cs` con el de este repositorio y presiona F5.

**Con la terminal** (necesitas el SDK de .NET):

```
dotnet new console -n CajaRegistradora
cd CajaRegistradora
(reemplaza el archivo Program.cs por el de este repositorio)
dotnet run
```

## Archivos

- `Program.cs`: código del programa
- `README.md`: este archivo
