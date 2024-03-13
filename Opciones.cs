class Opciones
{
    public static void Agregar()
    {
        Console.Clear();
        Console.WriteLine("----- Agregar Producto -----");

        //Pedir datos del productos
        Console.Write("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la cantidad: ");
        if (int.TryParse(Console.ReadLine(), out int cantidad))
        {
            Producto nuevoProducto = new Producto(nombre, cantidad);
            Soporte.inventario.Add(nuevoProducto);

            //Guardar el producto
            Soporte.GuardarInventario();

            Soporte.Verde($"{nombre} ha sido agregado al inventario con éxito.");
        }
        else
        {
            Soporte.Rojo("Cantidad no válida. Asegúrate de ingresar un número entero.");
        }
        Console.WriteLine("Presione enter para continuar.");
        Console.ReadLine();
    }

    public static void ActualizarC()
    {
        Console.Clear();
        Console.WriteLine("----- Actualizar Cantidad -----");

        //Ver la lista
        Soporte.MostrarInventario();

        Console.Write("Ingrese el número del producto que desea actualizar: ");
        if (int.TryParse(Console.ReadLine(), out int indiceProducto) && indiceProducto >= 1 && indiceProducto <= Soporte.inventario.Count)
        {
            Producto productoSeleccionado = Soporte.inventario[indiceProducto - 1];

            Console.Write($"Ingrese la cantidad adicional para {productoSeleccionado.Nombre}: ");
            if (int.TryParse(Console.ReadLine(), out int nuevaCantidad))
            {
                //Suma la nueva cantidad a la cantidad existente
                productoSeleccionado.Cantidad += nuevaCantidad;

                Soporte.GuardarInventario();
                Soporte.Verde($"La cantidad para {productoSeleccionado.Nombre} ha sido actualizada a {productoSeleccionado.Cantidad}.");
            }
            else
            {
                Soporte.Rojo("Cantidad no válida. Asegúrate de ingresar un número entero.");
            }
        }
        else
        {
            Soporte.Rojo("Número de producto no válido. Ingresa un número válido.");
        }

        Soporte.Amarillo("Presiona enter para continuar.");
        Console.ReadLine();
    }

    public static void Visualizar()
    {
        Console.Clear();

        Soporte.MostrarInventario();

        Soporte.Amarillo("Presione enter para continuar.");
        Console.ReadLine();
    }

    public static void Vender()
    {
        Console.Clear();
        Console.WriteLine("----- Vender Productos -----");

        Soporte.MostrarInventario();

        Console.Write("Ingrese el número del producto que desea vender: ");
        if (int.TryParse(Console.ReadLine(), out int indiceProducto) && indiceProducto >= 1 && indiceProducto <= Soporte.inventario.Count)
        {
            Producto productoSeleccionado = Soporte.inventario[indiceProducto - 1];

            Console.Write($"Ingrese la cantidad que desea vender de {productoSeleccionado.Nombre}: ");
            if (int.TryParse(Console.ReadLine(), out int cantidadVenta) && cantidadVenta > 0 && cantidadVenta <= productoSeleccionado.Cantidad)
            {
                // Resta la cantidad vendida de la cantidad existente
                productoSeleccionado.Cantidad -= cantidadVenta;

                Soporte.GuardarInventario();
                Soporte.Verde($"Venta realizada: {cantidadVenta} unidades de {productoSeleccionado.Nombre}.");
            }
            else
            {
                Soporte.Rojo("Cantidad no válida o excede la cantidad disponible. Asegúrate de ingresar un número entero válido.");
            }
        }
        else
        {
            Soporte.Rojo("Número de producto no válido. Ingresa un número válido.");
        }

        Soporte.Amarillo("Presiona enter para continuar.");
        Console.ReadLine();
    }
}