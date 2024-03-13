bool continuar = true;

Soporte.CargarInventario();

while (continuar)
{
    Console.Clear();
    Console.WriteLine(@"

    Bienvenidos a Binbo Fresh Market.🏪📈💵

        1- Agregar productos:
        2- Actualizar cantidad:
        3- Ver productos disponibles:
        4- Vender productos:
        X- Salir: 
    ");
    Console.Write("-Digite la opción: ");
    var opcion = Console.ReadLine();

    switch(opcion){
        
        case "1":
            Opciones.Agregar();
        break;

        case "2":
            Opciones.ActualizarC();
        break;

        case "3":
            Opciones.Visualizar();
        break;

        case "4":
            Opciones.Vender();
        break;

        case "X" or "x":
            Soporte.Amarillo("Hasta luego :) ");
            continuar = false;
        break; 

        default:
            Soporte.Rojo("Opción incorrecta. Presione enter para continuar.");
            Console.ReadLine();
        break;
    }
}