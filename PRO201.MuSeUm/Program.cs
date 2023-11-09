using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO201.MuSeUm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listado con 2 Administradores
            //Paso 1 crear lista vacia
            List<Administrador> listadoAdministradores = new List<Administrador>();
            //Paso 2 agregar obj al listado (usar constructor)
            listadoAdministradores.Add(new Administrador(1, "jcdiaz", "Juan Carlos", "Diaz", "12345"));
            listadoAdministradores.Add(new Administrador(1, "aperez", "Andres", "Perez", "12346"));

            //Listado con 2 Guias
            List<Guia> listadoGuias = new List<Guia>();
            listadoGuias.Add(new Guia(1, "mgonzalez", "Marcela", "Gonzalkez", "12347"));
            listadoGuias.Add(new Guia(2, "opereira", "Osvaldo", "Pereira", "12348"));

            //Listado con 4 Obras de Arte
            List<ObraArte> listadoObras = new List<ObraArte>();
            listadoObras.Add(new ObraArte(1, "La Mona Lisa", "Leonardo Da Vinci", "1503 - 1506", "descripcion"));
            listadoObras.Add(new ObraArte(2, "La Noche Estrellada", "Vincent Van Gogh", "1889", "descripcion"));
            listadoObras.Add(new ObraArte(3, "La persistencia de la memoria", "Salvador Dali", "1405 - 1506", "descripcion"));
            listadoObras.Add(new ObraArte(4, "La Creacion de Ada", "Miguel Angel", "1512", "descripcion"));

            //Listado con 2 Exposiciones 
            //Crear lista de obras que van en Exp1
            List<ObraArte> obrasExposicion1 = new List<ObraArte>();
            obrasExposicion1.Add(listadoObras[0]);
            obrasExposicion1.Add(listadoObras[1]);
            obrasExposicion1.Add(listadoObras[2]);

            // 1 Exposicion con 2 Obras de Arte
            List<ObraArte> obrasExposicion2 = new List<ObraArte>();
            obrasExposicion2.Add(listadoObras[3]);
            obrasExposicion2.Add(listadoObras[2]);

            Exposicion exposicion1 = new Exposicion(1, "Exposicion de Obras Famosas", "2023-11-01", "2023-12-10", obrasExposicion1);
            Exposicion exposicion2 = new Exposicion(1, "Exposicion de Arte Renacentista", "2023-12-15", "2024-01-15", obrasExposicion2);


            //CREAR LISTADO DE EXPOSICIONES
            List<Exposicion> listadoExposiciones = new List<Exposicion>();
            listadoExposiciones.Add(exposicion1);
            listadoExposiciones.Add(exposicion2);

            //Listado con 1 Galeria (con 1 Exposicion)
            List<Exposicion> listadoExposicionesGaleria = new List<Exposicion>();
            listadoExposicionesGaleria.Add(exposicion1);

            Galeria galeria = new Galeria(1, "Galeria JCD", listadoExposicionesGaleria);
            List<Galeria> listadoGalerias = new List<Galeria>();
            listadoGalerias.Add(galeria);
        
            //Validar que exista usuario
            string tipoUser = LoginUsuario(listadoAdministradores, listadoGuias);
            if (tipoUser == "admin")
            {
                //si existe: mostrar el menu segun tipo usuario
                int opcion = MenuAdministrador();
                //OPCIONES A SEGUIR DEL ADMINISTRADOR
                switch (opcion)
                {
                    case 1:
                        //Console.WriteLine("[1] Ver listado de Guias");
                        //llamar a otro metodo
                        VerListadoGuias(listadoGuias);
                        break;
                    case 2:
                        //Console.WriteLine("[2] Ver listado de Obras de Arte");
                        VerListadoObrasArtes(listadoObras);
                        break;
                    case 3:
                        //Console.WriteLine("[3] Ver listado de Exposiciones");
                        VerListadoExposiciones(listadoExposiciones);
                        break;
                    case 4:
                        //Console.WriteLine("[4] Ver listado de Galerias");
                        VerListadoGalerias(listadoGalerias);
                        break;
                    case 5:
                        Console.WriteLine("[5] Agregar Galerias");
                        //Pedir Datos
                        Console.WriteLine("Ingrese ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Seleccionar exposiscion a agregar");
                        VerListadoExposiciones(listadoExposiciones);
                        //Deberia ser un ciclo para agregar + de 1 galeria al listado
                        Console.WriteLine("Ingresa id de exposicion: ");
                        int exp = int.Parse(Console.ReadLine());
                        List<Exposicion> listaExpoAgregar = new List<Exposicion>();
                        //buscar expo a agregar por id y guardar el obj en listado
                        foreach (Exposicion exposicion in listadoExposiciones)
                        {
                            if (exposicion.Id == exp)
                            {
                                listaExpoAgregar.Add(exposicion);
                            }
                        }
                        Galeria gal = new Galeria(id, nombre, listaExpoAgregar);
                        listadoGalerias.Add(gal);
                        Console.WriteLine("Galeria Agregada!");
                        break;
                    case 6:
                        Console.WriteLine("[6] --- Editar Galeria ---");
                        //agregar exp
                        //1- mostrar id y nombre de galeria para seleccionar
                        //2- mostrar id y nombre de exp de galeria actual y las disponibles
                        //3- seleccionar expo y agregar a galeria
                        foreach (var gale in listadoGalerias)
                        {
                            Console.WriteLine($"ID: {gale.Id} | {gale.Nombre}");
                        }
                        Console.WriteLine("Seleccionar Galeria: ");
                        int galeria_seleccionada = int.Parse(Console.ReadLine());
                        //Recorrer listado de galerias hasta encontrar galeria por ID
                        foreach (var gale in listadoGalerias)
                        {
                            if (gale.Id == galeria_seleccionada)
                            {
                                //mostrar expo actuales
                                Console.WriteLine("EXPOSICIONES ACTUALES EN GALERIA: ");
                                foreach (var expo in gale.ListadoExposiciones)
                                {
                                    Console.WriteLine($"ID: {expo.Id} | {expo.Nombre}");
                                }
                                //mostrar todas las exposiciones
                                Console.WriteLine("Todas las exposiciones!");
                                foreach (var expo in listadoExposiciones)
                                {
                                    Console.WriteLine($"ID: {expo.Id} | {expo.Nombre}");
                                }
                                Console.WriteLine("Seleccionar exposicion a agregar: ");
                                int expo_IdSeleccionada = int.Parse(Console.ReadLine());
                                //buscar el obj
                                Exposicion expoBuscada = BuscaExposicion(expo_IdSeleccionada, listadoExposiciones);
                                if (expoBuscada != null)
                                {
                                    bool existeExpo = false;
                                    //Verificar si exposicion existe en galeria
                                    foreach (var expo in gale.ListadoExposiciones)
                                    {
                                        if (expo.Id == expoBuscada.Id)
                                        {
                                            Console.WriteLine("Ya existe la exposicion en esta galeria");
                                            existeExpo = true;
                                            break;
                                        }
                                    }
                                    //si no se encuentra la exposicion, agregar a la galeria
                                    if (existeExpo)
                                    {
                                        gale.ListadoExposiciones.Add(expoBuscada);
                                        Console.WriteLine("Exposicion Agregada");
                                    }
                                }

                            }

                        }
                        break;
                    case 0:
                        Console.WriteLine("[0] Salir");
                        break;
                }
            }
            else if (tipoUser == "guia")
            {
                int opcion = MenuGuia();
                if (opcion == 1)
                {
                    VerListadoGalerias(listadoGalerias);
                }else if (opcion == 0)
                    {
                    //Salir
                }
                else
                {
                    Console.WriteLine("Opcion Incorrecta");
                }
            }
            else
            {
                Console.WriteLine("No es Usuario");
                Console.ReadLine();
            }
            //si existe: mostrar el menu segun el tipo de usuario
            int opcion = MenuAdministrador();
            Console.WriteLine(opcion);

            //int opcionB = MenuGuia();
            //Console.WriteLine(opcionB);

            
            Console.ReadLine();
        }

        //MENU ADMINISTRADOR
        static int MenuAdministrador()
        {
            Console.WriteLine("--Menu Administrador");
            Console.WriteLine("[1] Ver listado de Guias");
            Console.WriteLine("[2] Ver listado de Obras de Arte");
            Console.WriteLine("[3] Ver listado de Exposiciones");
            Console.WriteLine("[4] Ver listado de Galerias");
            Console.WriteLine("[5] Agregar Galeria");
            Console.WriteLine("[6] Editar Galeria (Agregar Exposicion, verificar primero que no )");
            Console.WriteLine("[0] Salir");
            Console.WriteLine("Selecciona una opcion: ");
            int opcion = int.Parse(Console.ReadLine());
            return opcion;
        }
        //MENU GUIA
        static int MenuGuia()
        {
            Console.WriteLine("--Menu Guia--");
            Console.WriteLine("[1] Ver listado de Galerias");
       
            Console.WriteLine("[0] Salir");
            Console.WriteLine("Selecciona una opcion: ");
            int opcion = int.Parse(Console.ReadLine());
            return 0;
        }

        static void VerListadoGuias(List<Guia> listadoGuias)
        {
            foreach (var guia in listadoGuias)
            {
                Console.WriteLine($"Usuario: {guia.Usuario}");
                Console.WriteLine($"Nombre: { guia.Nombre} { guia.Apellido}");
                Console.WriteLine();
            }
        }

        //RECORRER LISTADO DE ADMINISTRADORES
        static void VerListadoAdmin(List<Administrador> listadoAdministrador)
        {
            foreach (var item in listadoAdministrador)
            {
                Console.WriteLine($"Usuario: {item.Usuario}");
                Console.WriteLine($"Nombre: {item.Nombre} - {item.Apellido}");
            }
        }

        static void VerListadoObrasArtes(List<ObraArte> VerListadoObrasArtes)
        {
            foreach (var item in VerListadoObrasArtes)
            {
                Console.WriteLine($"ID: {item.Id} - | Nombre: {item.Nombre} ");
                Console.WriteLine($"Autor:  - {item.Autor} - | Fecha: {item.Fecha}");
                Console.WriteLine($"Descripcion { item.Descripcion}");
                Console.WriteLine("------------------------------------------");
            }
        }


        static void VerListadoExposiciones(List<Exposicion> VerListadoExposiciones)
        {
            foreach (Exposicion expo in VerListadoExposiciones)
            {
                Console.WriteLine($"---------Exposicion N°: {expo.Id} -------");
                Console.WriteLine($"{expo.Nombre}");
                Console.WriteLine($"Fecha: {expo.FechaInicio} - {expo.FechaTermino}");
                //IMPRIMIR LISTADO DE OBRAS DE LA EXPOSICION
                Console.WriteLine("-------------Obras de exposicion actual:   ");
                VerListadoObrasArtes(expo.ListadoObras);
                Console.WriteLine("Fin de Exposicion");
                Console.WriteLine();
            }

        }

        static void VerListadoGalerias(List<Galeria> listadoGalerias)
        {
            foreach (Galeria gal in listadoGalerias)
            {
                Console.WriteLine($"--------GALERIA N° {gal.Id}--------");
                Console.WriteLine(gal.Nombre);
                VerListadoExposiciones(gal.ListadoExposiciones);
                Console.WriteLine("----Fin Galeria------");
                Console.WriteLine();
            }
        }

        //INICIO DE SESION
        static String LoginUsuario(List<Administrador> listaAdmin, List<Guia> listaGuia)
        {
            Console.WriteLine("Ingrese usuario: ");
            String usuario = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña");
            String password = Console.ReadLine();
            //Verificar si es admin
            foreach (Administrador admin in listaAdmin)
            {
                if (admin.Usuario == usuario && admin.Password == password)
                {
                    return "admin";
                }
            }
            //Verificar si es guia
            foreach (Guia guia in listaGuia)
            {
                if (guia.Usuario == usuario && guia.Password == password)
                {
                    return "guia";
                }
            }
            return "Incorrecto";
        }

        static Exposicion BuscaExposicion(int idBuscar, List<Exposicion> listadoExposiciones)
        {
            foreach (var expo in listadoExposiciones)
            {
                if (expo.Id == idBuscar)
                {
                    return expo;
                }
            }
            return null;
        }

    }
}
