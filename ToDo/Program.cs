using System.Runtime.CompilerServices;
using EspacioTarea;

string? cantString="";
int cant=0,contadorID=0;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

bool realizarOtra = true;
do
{
    Console.WriteLine("Seleccione una opcion para realizar: ");
    Console.WriteLine(" 1 : Agregar N tareas pendientes nuevas  ");
    Console.WriteLine(" 2 : Mover tarea pendiente a realizada  ");
    Console.WriteLine(" 3 : Buscar tareas pendientes por descripcion");
    Console.WriteLine(" 4 : Mostrar todas las tareas (pendientes y realizadas)");
    Console.WriteLine(" 0: Salir del programa");

    string? opcion = Console.ReadLine();

    switch(opcion){

        case "0":

            realizarOtra = false;

            break;
            case "1":
                do{
                    Console.WriteLine("Ingrese un numero (N) de tareas a ingresar: ");
                    cantString = Console.ReadLine();
                }while(!int.TryParse(cantString, out cant));

                Random random = new Random();

                for(int i = 0; i < cant; i++)
                {   
                    Tarea nuevaTarea = new Tarea();
                    nuevaTarea.TareaID = contadorID;
                    nuevaTarea.Descripcion = "Tarea de prueba " + (i+1);
                    nuevaTarea.Duracion =  random.Next(10,101); 
                    tareasPendientes.Add(nuevaTarea);
                    contadorID++;
                    }
                break;

        case "2":

            string? idBuscadaString;
            int idBuscada;
            Tarea? tareaTransferida =null;

            do{

                Console.WriteLine("Ingrese la ID de la tarea que va a mover de pendientes a realizadas");
                idBuscadaString = Console.ReadLine();

            }while(!int.TryParse(idBuscadaString, out idBuscada));

            foreach(Tarea T in tareasPendientes){
                if(idBuscada == T.TareaID){
                    tareaTransferida = T;
                }
            }

            if(tareaTransferida != null)
            {
                tareasPendientes.Remove(tareaTransferida);
                tareasRealizadas.Add(tareaTransferida);

                Console.WriteLine($"La tarea con ID:{tareaTransferida.TareaID} fue REALIZADA");
            }
            else
            {
                Console.WriteLine("La tarea con la ID ingresada no existe");
            }
            break;
        case "3":
            Console.WriteLine("Ingrese la descripcion de una tarea para mostrarla por pantalla:");
            string? descripcionBuscada = Console.ReadLine();
            Tarea? tareaMostrar = null;

            if(descripcionBuscada != null)
            {
                foreach(Tarea Tr in tareasPendientes){
                if(Tr.Descripcion.Trim().ToLower().Contains(descripcionBuscada.Trim().ToLower())){
                    tareaMostrar = Tr;
                }
                if(tareaMostrar == null){
                Console.WriteLine("No existe ninguna tarea pendiente con esa descripcion");
                }
                else
                {
                    Console.WriteLine("\n--- Tarea pendiente buscada por descripcion---");
                    Console.WriteLine("Tarea ID: " + tareaMostrar.TareaID);
                    Console.WriteLine("Descripcion : " + tareaMostrar.Descripcion);
                    Console.WriteLine("Duracion : " + tareaMostrar.Duracion);
                    Console.WriteLine("------\n");
                }
                }
            }
            
            
            break;
        case "4":
            Console.WriteLine("------- Tareas Pendientes -------");

            foreach(Tarea mostrarPendiente in tareasPendientes)
            {
                Console.WriteLine("\n------");
                Console.WriteLine("Tarea ID: " + mostrarPendiente.TareaID);
                Console.WriteLine("Descripcion : " + mostrarPendiente.Descripcion);
                Console.WriteLine("Duracion : " + mostrarPendiente.Duracion);
                Console.WriteLine("------\n");
            }

            Console.WriteLine("----------------------------");

            Console.WriteLine("------- Tareas Realizadas -------");

            foreach(Tarea mostraRealizadas in tareasRealizadas)
            {
                Console.WriteLine("\n------");
                Console.WriteLine("Tarea ID: " + mostraRealizadas.TareaID);
                Console.WriteLine("Descripcion : " + mostraRealizadas.Descripcion);
                Console.WriteLine("Duracion : " + mostraRealizadas.Duracion);
                Console.WriteLine("------\n");
            }

            Console.WriteLine("----------------------------");
            break;
    }
}while(realizarOtra == true);