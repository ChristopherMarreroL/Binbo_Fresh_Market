using Newtonsoft.Json;

public static class Soporte
{
    public static void Verde(string mensaje)
    {
        ConsoleColor colorOriginal = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = colorOriginal;
    }

    public static void Rojo(string mensaje)
    {
        ConsoleColor colorOriginal = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = colorOriginal;
    }

    public static void Amarillo(string mensaje)
    {
        ConsoleColor colorOriginal = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(mensaje);
        Console.ForegroundColor = colorOriginal;
    }


    public static List<Producto> inventario = new List<Producto>();
    const string archivoJson = "Productos.json";

    public static void GuardarInventario()
    {
        string jsonInventario = JsonConvert.SerializeObject(inventario);
        File.WriteAllText(archivoJson, jsonInventario);
    }

    public static void CargarInventario()
    {
        if (File.Exists(archivoJson))
        {
            string jsonInventario = File.ReadAllText(archivoJson);

            inventario = JsonConvert.DeserializeObject<List<Producto>>(jsonInventario);

            Verde("Datos cargados exitosamente.");
        }
        else
        {
            Rojo("No se encontraron datos para cargar.");
        }
        Console.ReadLine();
    }

    public static void MostrarInventario()
    {
        Console.WriteLine("-------- Inventario --------");

        if (inventario.Count == 0)
        {
            Rojo("El inventario esta vacío.");
        }
        else
        {
            for (int i = 0; i < inventario.Count; i++)
            {
                Amarillo($"{i + 1}- {inventario[i].Nombre} / Cantidad: {inventario[i].Cantidad}");
            }
        }
    }
}


public class Producto
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, int cantidad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
    }
}