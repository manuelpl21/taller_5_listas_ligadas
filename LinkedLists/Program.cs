using LinkedLists;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
        int option;

        do
        {
            Console.WriteLine("\n=== MENÚ LISTA DOBLEMENTE LIGADA ===");
            Console.WriteLine("1. Adicionar");
            Console.WriteLine("2. Mostrar hacia adelante");
            Console.WriteLine("3. Mostrar hacia atrás");
            Console.WriteLine("4. Ordenar descendentemente");
            Console.WriteLine("5. Mostrar la(s) moda(s)");
            Console.WriteLine("6. Mostrar gráfico");
            Console.WriteLine("7. Existe");
            Console.WriteLine("8. Eliminar una ocurrencia");
            Console.WriteLine("9. Eliminar todas las ocurrencias");
            Console.WriteLine("0. Salir");
            Console.Write("Selecciona una opción: ");

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                option = -1; // Opción por defecto en el switch
            }

            string input;
            switch (option)
            {
                case 1:
                    Console.Write("Ingresa el valor a adicionar: ");
                    input = Console.ReadLine();
                    doublyLinkedList.InsertInOrder(input);
                    Console.WriteLine($"'{input}' adicionado exitosamente.");
                    break;
                case 2:
                    Console.WriteLine("\nLista hacia adelante:");
                    doublyLinkedList.PrintForward();
                    break;
                case 3:
                    Console.WriteLine("\nLista hacia atrás:");
                    doublyLinkedList.PrintBackward();
                    break;
                case 4:
                    doublyLinkedList.Reverse();
                    Console.WriteLine("El orden de la lista ha sido invertido (orden descendentemente).");
                    break;
                case 5:
                    List<string> modes = doublyLinkedList.GetModes();
                    if (modes.Count == 0)
                    {
                        Console.WriteLine("La lista está vacía.");
                    }
                    else
                    {
                        Console.WriteLine($"La(s) moda(s): {string.Join(", ", modes)}");
                    }
                    break;
                case 6:
                    Console.WriteLine("\nGráfico de ocurrencias:");
                    doublyLinkedList.PrintGraph();
                    break;
                case 7:
                    Console.Write("Ingresa el valor a buscar: ");
                    input = Console.ReadLine();
                    if (doublyLinkedList.Contains(input))
                        Console.WriteLine($"El valor '{input}' SÍ existe en la lista.");
                    else
                        Console.WriteLine($"El valor '{input}' NO existe en la lista.");
                    break;
                case 8:
                    Console.Write("Ingresa el valor a eliminar (primera ocurrencia): ");
                    input = Console.ReadLine();
                    if (doublyLinkedList.RemoveFirst(input))
                        Console.WriteLine("Primera ocurrencia eliminada con éxito.");
                    else
                        Console.WriteLine("El valor no se encontró en la lista.");
                    break;
                case 9:
                    Console.Write("Ingresa el valor a eliminar (todas las ocurrencias): ");
                    input = Console.ReadLine();
                    int removedCount = doublyLinkedList.RemoveAll(input);
                    if (removedCount > 0)
                        Console.WriteLine($"Se eliminaron {removedCount} ocurrencias de '{input}'.");
                    else
                        Console.WriteLine("El valor no se encontró en la lista.");
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

        } while (option != 0);
    }
}