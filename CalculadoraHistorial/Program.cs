
using EspacioCalculadora; // Aseguramos usar tu namespace
        Calculadora calc = new Calculadora();
        bool salir = false;

        do
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine($"   CALCULADORA - VALOR ACTUAL: {calc.Resultado}");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Limpiar valor actual");
            Console.WriteLine("6. Mostrar Historial");
            Console.WriteLine("0. Salir");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Seleccione una opción: ");
            
            string? opcion = Console.ReadLine();
            double numeroIngresado;

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el número a sumar: ");
                    if (double.TryParse(Console.ReadLine(), out numeroIngresado))
                        calc.Sumar(numeroIngresado);
                    break;

                case "2":
                    Console.Write("Ingrese el número a restar: ");
                    if (double.TryParse(Console.ReadLine(), out numeroIngresado))
                        calc.Restar(numeroIngresado);
                    break;

                case "3":
                    Console.Write("Ingrese el número a multiplicar: ");
                    if (double.TryParse(Console.ReadLine(), out numeroIngresado))
                        calc.Multiplicar(numeroIngresado);
                    break;

                case "4":
                    Console.Write("Ingrese el número a dividir: ");
                    if (double.TryParse(Console.ReadLine(), out numeroIngresado))
                    {
                        if (numeroIngresado == 0)
                        {
                            Console.WriteLine("No se puede dividir por cero.");
                        }
                        else
                        {
                            calc.Dividir(numeroIngresado);
                        }
                    }
                    break;

                case "5":
                    calc.Limpiar();
                    Console.WriteLine("Se limpio el valor de la calculadora.");
                    break;

                case "6":
                    calc.MostrarHistorial(); 
                    break;

                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo de la calculadora...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (!salir);
