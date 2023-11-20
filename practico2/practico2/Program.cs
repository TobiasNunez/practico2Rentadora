using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace practico2
{
    class Program
    {
        static void Main(string[] args)
        {
            int matricula;
            string marca;
            string color;
            string capacidadTanque;
            bool estado;
            int precioAlquilerDiario;
            int kmPorLitro;
            int velocidadMaxima;
            int capacidadCarga;
            int capacidadMaletero;
            string eleccion = "0";

            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            List<Alquiler> listaAlquileres = new List<Alquiler>();
            Sucursal rentacar1 = new Sucursal(5679, "avenida rocha 526", listaVehiculos, listaAlquileres);

            Deportivo v1 = new Deportivo(4456, "bugatti", "azul", "26.4 galones", true, 200, 5, 260);
            Familiar v2 = new Familiar(5657, "ford", "blanco", "15 galones", false, 100, 4, 200);
            Utilitarios v3 = new Utilitarios(9088, "gol", "verde", "10 galones", false, 90, 7, 170);
            Deportivo v4 = new Deportivo(4346, "ferrari", "rojo", "24.4 galones", false, 200, 5, 260);
            Familiar v5 = new Familiar(5957, "ford", "blanco", "15 galones", false, 100, 4, 200);



            listaVehiculos.Add(v1);
            listaVehiculos.Add(v2);
            listaVehiculos.Add(v3);
            listaVehiculos.Add(v4);


            while (eleccion != "6")
            {
                Console.Clear();
                Console.WriteLine(" _______________________");
                Console.WriteLine("| --AUTOMOTORA VPI--    |");
                Console.WriteLine("| 1- Ubicacion          |");
                Console.WriteLine("| 2- Ingresar Vehiculo  |");
                Console.WriteLine("| 3- Ver vehiculos      |");
                Console.WriteLine("| 4- Registrar alquiler |");
                Console.WriteLine("| 5- Ver alquileres     |");
                Console.WriteLine("| 6- Salir              |");
                Console.WriteLine(" -----------------------");

                eleccion = Console.ReadLine();
                Console.Clear();

                if (eleccion == "1")
                {
                    Sucursal.MostrarInformacionSucursal(rentacar1);
                    Console.ReadKey();
                }
                else if (eleccion == "2")
                {

                    Console.WriteLine("Ingrese matricula:");
                    string matriculaPrueba = Console.ReadLine();
                    while (Validacion.validarEntero(matriculaPrueba) != true)
                    {
                        Console.WriteLine("Debe ingresar una matricula");
                        matriculaPrueba = Console.ReadLine();
                    }
                    matricula = int.Parse(matriculaPrueba);
                    if (rentacar1.existeVehiculo(matricula) == true)
                    {
                        Console.WriteLine("Este vehiculo ya existe");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (rentacar1.existeVehiculo(matricula) == false)
                    {
                        Console.WriteLine("Ingrese marca:");
                        marca = Console.ReadLine();
                        while (Validacion.validarString(marca) != true)
                        {
                            Console.WriteLine("Debe ingresar una marca");
                            marca = Console.ReadLine();
                        }


                        Console.WriteLine("Ingrese el color:");
                        color = Console.ReadLine();
                        while (Validacion.validarString(color) != true)
                        {
                            Console.WriteLine("Debe ingresar un color");
                            color = Console.ReadLine();
                        }


                        Console.WriteLine("Ingrese capacidad del tanque:");
                        capacidadTanque = Console.ReadLine();
                        while (Validacion.validarString(capacidadTanque) != true)
                        {
                            Console.WriteLine("Debe ingresar la capacidad de la entrada");
                            capacidadTanque = Console.ReadLine();
                        }


                        Console.WriteLine("Si el vehículo se encuentra alquilado coloque true, sino coloque false:");
                        string estadoPrueba = Console.ReadLine();
                        while (Validacion.validarBool(estadoPrueba) != true)
                        {
                            Console.WriteLine("Debe colocar true o false");
                            estadoPrueba = Console.ReadLine();
                        }
                        estado = bool.Parse(estadoPrueba);


                        Console.WriteLine("Ingrese el precio del alquiler diario del vehiculo:");
                        string alquilerPrueba = Console.ReadLine();
                        while (Validacion.validarEntero(alquilerPrueba) != true)
                        {
                            Console.WriteLine("Debe ingresar una matricula");
                            alquilerPrueba = Console.ReadLine();
                        }
                        precioAlquilerDiario = int.Parse(alquilerPrueba);


                        Console.WriteLine("Ingrese los litros que consume por kilómetro:");
                        string kmPorLitroPrueba = Console.ReadLine();
                        while (Validacion.validarEntero(kmPorLitroPrueba) != true)
                        {
                            Console.WriteLine("Debe colocar un valor numerico");
                            kmPorLitroPrueba = Console.ReadLine();
                        }
                        kmPorLitro = int.Parse(kmPorLitroPrueba);


                        Console.Clear();
                        Console.WriteLine("Ingrese si el vehiculo es:");
                        Console.WriteLine("1- Deportivo");
                        Console.WriteLine("2- Utilitario");
                        Console.WriteLine("3- Familiar");
                        string tipoVehiculo = Console.ReadLine();
                        while (tipoVehiculo != "1" && tipoVehiculo != "2" && tipoVehiculo != "3")
                        {
                            Console.WriteLine("Debe ingresar 1, 2 o 3");
                            tipoVehiculo = Console.ReadLine();
                        }
                        if (tipoVehiculo == "1")
                        {

                            Console.WriteLine("Ingrese velocidad maxima del vehiculo");
                            string velocidadMaximaPrueba = Console.ReadLine();
                            while (Validacion.validarEntero(velocidadMaximaPrueba) != true)
                            {
                                Console.WriteLine("La velocidad es incorrecta, debe colocar un valor numerico");
                                velocidadMaximaPrueba = Console.ReadLine();
                            }
                            velocidadMaxima = int.Parse(velocidadMaximaPrueba);
                            Deportivo nuevoDeportivo = new Deportivo(matricula, marca, color, capacidadTanque, estado, precioAlquilerDiario, kmPorLitro, velocidadMaxima);
                            listaVehiculos.Add(nuevoDeportivo);
                            Console.WriteLine("El vehiculo ha sido registrado con exito");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (tipoVehiculo == "2")
                        {
                            Console.WriteLine("Ingrese la capacidad de carga del vehiculo");
                            string capacidadCargaPrueba = Console.ReadLine();
                            while (Validacion.validarEntero(capacidadCargaPrueba) != true)
                            {
                                Console.WriteLine("La capacidad de carga colocada es incorrecta, debe colocar un valor numerico");
                                capacidadCargaPrueba = Console.ReadLine();
                            }
                            capacidadCarga = int.Parse(capacidadCargaPrueba);
                            Utilitarios nuevoUtilitario = new Utilitarios(matricula, marca, color, capacidadTanque, estado, precioAlquilerDiario, kmPorLitro, capacidadCarga);
                            listaVehiculos.Add(nuevoUtilitario);
                            Console.WriteLine("El vehiculo ha sido registrado con exito");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ingrese la capacidad del maletero del vehiculo");
                            string capacidadMaleteroPrueba = Console.ReadLine();
                            while (Validacion.validarEntero(capacidadMaleteroPrueba) != true)
                            {
                                Console.WriteLine("La capacidad de maletero colocada es incorrecta, debe colocar un valor numerico");
                                capacidadMaleteroPrueba = Console.ReadLine();
                            }
                            capacidadMaletero = int.Parse(capacidadMaleteroPrueba);
                            Familiar nuevoFamiliar = new Familiar(matricula, marca, color, capacidadTanque, estado, precioAlquilerDiario, kmPorLitro, capacidadMaletero);
                            listaVehiculos.Add(nuevoFamiliar);
                            Console.WriteLine("El vehiculo ha sido registrado con exito");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                }
                else if (eleccion == "3")
                {
                    Sucursal.DarVehiculos(listaVehiculos);
                }
                else if (eleccion == "4")
                {
                    string codigoAlquiler;
                    int documento;
                    string nombre;
                    string apellido;
                    int telefono;
                    int precioTotal = 0;
                    DateTime fechaRetiro;
                    int cantDias;
                    int matriculaAlquiler;

                    string alquileres = "0";

                    while (alquileres != "2")
                    {
                        Console.WriteLine("1- Comenzar a alquilar vehiculos");
                        Console.WriteLine("2- Volver al menu principal");
                        alquileres = Console.ReadLine();
                        if (alquileres == "1")
                        {
                            string listita = "0";
                            List<Vehiculo> vehiculosAlquiler = new List<Vehiculo>();
                            while (listita != "2")
                            {
                                Console.WriteLine("Presione enter para ver los vehiculos disponibles");
                                Console.ReadKey();
                                Sucursal.mostrarVehiculosLibres(listaVehiculos);
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine("Coloque la matricula del auto que desea alquilar: ");
                                string matriculaAlquilerPrueba = Console.ReadLine();
                                while (Validacion.validarEntero(matriculaAlquilerPrueba) != true)
                                {
                                    Console.WriteLine("Debe ingresar una matricula.");
                                    matriculaAlquilerPrueba = Console.ReadLine();
                                }
                                matriculaAlquiler = int.Parse(matriculaAlquilerPrueba);
                                Vehiculo vehiculoAlquilado = rentacar1.alquilarVehiculo(matriculaAlquiler);

                                if (vehiculoAlquilado == null)
                                {
                                    Console.WriteLine("Este no existe o ya se encuentra alquilado, elija otro vehiculo");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Este vehiculo se encuentra libre, lo agregaremos a su alquiler");
                                    vehiculosAlquiler.Add(vehiculoAlquilado);
                                    Console.ReadLine();
                                }

                                if (vehiculosAlquiler.Count > 0)
                                {
                                    Console.WriteLine("1- Si quiere seguir ingresando vehiculos");
                                    Console.WriteLine("2- Si quiere continuar con el procedimiento");
                                    listita = Console.ReadLine();

                                    while (listita != "1" && listita != "2")
                                    {
                                        Console.WriteLine("Debe ingresar 1 o 2");
                                        listita = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Debe ingresar al menos un vehiculo");

                                }
                            }

                            Console.WriteLine("Ingrese el codigo del alquiler: ");
                            codigoAlquiler = Console.ReadLine();
                            while (Validacion.validarString(codigoAlquiler) != true)
                            {
                                Console.WriteLine("Debe colocar un codigo de alquiler.");
                                codigoAlquiler = Console.ReadLine();
                            }

                            Console.WriteLine("Ingrese el documento del inquilino: ");
                            string documentoPrueba = Console.ReadLine();
                            while (Validacion.validarEntero(documentoPrueba) != true)
                            {
                                Console.WriteLine("Debe ingresar el documento del inquilino.");
                                documentoPrueba = Console.ReadLine();
                            }
                            documento = int.Parse(documentoPrueba);


                            Console.WriteLine("Ingrese el nombre del inquilino: ");
                            nombre = Console.ReadLine();
                            while (Validacion.validarString(nombre) != true)
                            {
                                Console.WriteLine("Debe ingresar el nombre del inquilino.");
                                nombre = Console.ReadLine();
                            }

                            Console.WriteLine("Ingrese el apellido del inquilino: ");
                            apellido = Console.ReadLine();
                            while (Validacion.validarString(apellido) != true)
                            {
                                Console.WriteLine("Deebe colocar el apellido del inquilino.");
                                apellido = Console.ReadLine();
                            }


                            Console.WriteLine("Ingrese el telefono del inquilino: ");
                            string telefonoPrueba = Console.ReadLine();
                            while (Validacion.validarEntero(telefonoPrueba) != true)
                            {
                                Console.WriteLine("Debe ingresar el telefono del inquilino.");
                                telefonoPrueba = Console.ReadLine();
                            }
                            telefono = int.Parse(telefonoPrueba);

                            Console.WriteLine("Ingrese fecha de retiro, ejemplo: 2023-11-15 12:30:00. ");
                            string fechaRetiroPrueba = Console.ReadLine();
                            while (Validacion.validarFecha(fechaRetiroPrueba) != true)
                            {
                                Console.WriteLine("Debe ingresar una fecha");
                                fechaRetiroPrueba = Console.ReadLine();
                            }
                            fechaRetiro = DateTime.Parse(fechaRetiroPrueba);

                            Console.WriteLine("Ingrese la cantidad de dias del alquiler: ");
                            string cantDiasPrueba = Console.ReadLine();
                            while (Validacion.validarEntero(cantDiasPrueba) != true)
                            {
                                Console.WriteLine("Debe ingresar la cantidad de dias que dura el alquiler.");
                                cantDiasPrueba = Console.ReadLine();
                            }
                            cantDias = int.Parse(cantDiasPrueba);

                            Alquiler nuevoAlquiler = new Alquiler(codigoAlquiler, documento, nombre, apellido, telefono, precioTotal, fechaRetiro, cantDias, vehiculosAlquiler);
                            nuevoAlquiler.setPrecioTotal(nuevoAlquiler.CalcularPrecioTotal(nuevoAlquiler.getDetalleAlquiler(), vehiculosAlquiler));
                            Console.WriteLine($"El registro del alquiler ha sido realizado con exito y el precio total del mismo es ${nuevoAlquiler.getPrecioTotal()}");
                            listaAlquileres.Add(nuevoAlquiler);
                            alquileres = "3";
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (alquileres == "3")
                        {
                            break;
                        }

                    }
                }
                else if (eleccion == "5")
                {
                    if (rentacar1.existeAlquiler(listaAlquileres) == false)
                    {
                        Console.WriteLine("Aun no hay alquileres registrados.");
                    }

                    Sucursal.darAlquileres(listaAlquileres);
                }
            }
        }
    }


    class Sucursal
    {
        private int numero;
        private string direccion;
        private List<Vehiculo> listaVehiculos;
        private List<Alquiler> listaAlquiler;

        public Sucursal(int numero, string direccion, List<Vehiculo> listaVehiculos, List<Alquiler> listaAlquiler)
        {
            this.numero = numero;
            this.direccion = direccion;
            this.listaVehiculos = listaVehiculos;
            this.listaAlquiler = listaAlquiler;
        }

        public void setNumero(int numero) => this.numero = numero;
        public int getNumero() => numero;

        public void setDireccion(string direccion) => this.direccion = direccion;
        public string getDireccion() => direccion;

        public static void MostrarInformacionSucursal(Sucursal sucursal)
        {
            Console.WriteLine("\n------ Información de la Sucursal ------");
            Console.WriteLine($"Sucursal: {sucursal.getNumero()} - {sucursal.getDireccion()}");
            Console.WriteLine($"-----------------------------------------");


        }

        public static void darAlquileres(List<Alquiler> listaAlquileres)
        {
            foreach (Alquiler item in listaAlquileres)
            {
                Console.WriteLine(" +----Alquileres-------------------------------------------------------+");
                Console.WriteLine($"| Codigo Alquiler: {item.getCodigoAlquiler()}                          ");
                Console.WriteLine($"| Documento: {item.getDocumento()}                                     ");
                Console.WriteLine($"| Nombre: {item.getNombre()}                                           ");
                Console.WriteLine($"| Apellido: {item.getApellido()}                                       ");
                Console.WriteLine($"| Telefono: {item.getTelefono()}                                       ");
                item.mostrarMatriculas(item.getVehiculosAlquiler());
                Console.WriteLine($"| Cantidad de vehiculos: {item.getVehiculosAlquiler().Count}           ");
                Console.WriteLine($"| Cantidad de Dias: {item.getDetalleAlquiler().getCantDias()}          ");
                Console.WriteLine($"| Fecha Retiro: {item.getDetalleAlquiler().getFechaRetiro()}           ");
                Console.WriteLine($"| Precio total: ${item.getPrecioTotal()}                                ");
                Console.WriteLine(" +---------------------------------------------------------------------+");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void DarVehiculos(List<Vehiculo> listaVehiculos)
        {

            foreach (Vehiculo vehiculo in listaVehiculos)
            {
                Console.WriteLine(" +-Detalles Vehiculos--------------------------------------------------+");
                Console.WriteLine($"| Matrícula: {vehiculo.getMatricula()}                                 ");
                Console.WriteLine($"| Tipo: {vehiculo.ObtenerTipo()}                                       ");
                Console.WriteLine($"| Marca: {vehiculo.getMarca()}                                         ");
                Console.WriteLine($"| Color: {vehiculo.getColor()}                                         ");
                Console.WriteLine($"| Capacidad de Tanque: {vehiculo.getCapacidadTanque()}                 ");
                Console.WriteLine($"| Estado: {vehiculo.getEstado()}                                       ");
                Console.WriteLine($"| Precio de Alquiler Diario: {vehiculo.getPrecioAlquilerDiario()}      ");
                Console.WriteLine($"| Kilómetros por Litro: {vehiculo.getKmPorLitro()}                     ");

                if (vehiculo is Deportivo)
                {
                    Console.WriteLine($"| Velocidad Máxima: {((Deportivo)vehiculo).getVelocidadMaxima()}   ");
                }
                else if (vehiculo is Utilitarios)
                {
                    Console.WriteLine($"| Capacidad de Carga: {((Utilitarios)vehiculo).getCapacidadCarga()}");
                }
                else if (vehiculo is Familiar)
                {
                    Console.WriteLine($"| Capacidad de Maletero: {((Familiar)vehiculo).getCapacidadMaletero()}");
                }
                Console.WriteLine(" +---------------------------------------------------------------------+");
            }
            Console.ReadKey();
            Console.Clear();

        }

        public static void mostrarVehiculosLibres(List<Vehiculo> listaVehiculos)
        {
            foreach (Vehiculo vehiculo in listaVehiculos)
            {
                if (vehiculo.getEstado() == false)
                {
                    Console.WriteLine(" +-Detalles Vehiculos--------------------------------------------------+");
                    Console.WriteLine($"| Matrícula: {vehiculo.getMatricula()}                                 ");
                    Console.WriteLine($"| Tipo: {vehiculo.ObtenerTipo()}                                       ");
                    Console.WriteLine($"| Marca: {vehiculo.getMarca()}                                         ");
                    Console.WriteLine($"| Color: {vehiculo.getColor()}                                         ");
                    Console.WriteLine($"| Capacidad de Tanque: {vehiculo.getCapacidadTanque()}                 ");
                    Console.WriteLine($"| Estado: {vehiculo.getEstado()}                                       ");
                    Console.WriteLine($"| Precio de Alquiler Diario: {vehiculo.getPrecioAlquilerDiario()}      ");
                    Console.WriteLine($"| Kilómetros por Litro: {vehiculo.getKmPorLitro()}                     ");

                    if (vehiculo is Deportivo)
                    {
                        Console.WriteLine($"| Velocidad Máxima: {((Deportivo)vehiculo).getVelocidadMaxima()}   ");
                    }
                    else if (vehiculo is Utilitarios)
                    {
                        Console.WriteLine($"| Capacidad de Carga: {((Utilitarios)vehiculo).getCapacidadCarga()}");
                    }
                    else if (vehiculo is Familiar)
                    {
                        Console.WriteLine($"| Capacidad de Maletero: {((Familiar)vehiculo).getCapacidadMaletero()}");
                    }
                    Console.WriteLine(" +---------------------------------------------------------------------+");
                }
            }
            Console.ReadKey();
            Console.Clear();

        }

        public bool existeVehiculo(int matricula)
        {
            foreach (var item in this.listaVehiculos)
            {
                if (item.getMatricula() == matricula)
                {
                    return true;
                }
            }
            return false;
        }   

        public Vehiculo alquilarVehiculo(int matricula)
        {
            foreach (var item in this.listaVehiculos)
            {
                if (item.getMatricula() == matricula)
                {
                    if (item.getEstado() == false)
                    {
                        item.setEstado(true);
                        return item;
                    }
                }
            }
            return null;
        }

        public bool existeAlquiler(List<Alquiler> listaAlquileres)
        {
            if (listaAlquileres.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

    class Alquiler
    {
        private string codigoAlquiler;
        private int documento;
        private string nombre;
        private string apellido;
        private int telefono;
        private int precioTotal;
        private DetalleAlquiler detalleAlquiler;
        private List<Vehiculo> vehiculosAlquiler;

        public Alquiler(string codigoAlquiler, int documento, string nombre, string apellido, int telefono, int precioTotal, DateTime fechaRetiro,
            int cantDias, List<Vehiculo> vehiculosAlquiler)
        {
            this.codigoAlquiler = codigoAlquiler;
            this.documento = documento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.precioTotal = precioTotal;
            this.vehiculosAlquiler = vehiculosAlquiler;
            this.detalleAlquiler = new DetalleAlquiler(fechaRetiro, cantDias, vehiculosAlquiler.Count);
        }

        public void setCodigoAlquiler(string codigoAlquiler) => this.codigoAlquiler = codigoAlquiler;
        public string getCodigoAlquiler() => codigoAlquiler;

        public void setDocumento(int documento) => this.documento = documento;
        public int getDocumento() => documento;

        public void setNombre(string nombre) => this.nombre = nombre;
        public string getNombre() => nombre;

        public void setApellido(string apellido) => this.apellido = apellido;
        public string getApellido() => apellido;

        public void setTelefono(int telefono) => this.telefono = telefono;
        public int getTelefono() => telefono;

        public void setPrecioTotal(int precioTotal) => this.precioTotal = precioTotal;
        public int getPrecioTotal() => precioTotal;

        public void setVehiculosAlquiler(List<Vehiculo> vehiculosAlquiler) => this.vehiculosAlquiler = vehiculosAlquiler;
        public List<Vehiculo> getVehiculosAlquiler() => vehiculosAlquiler;

        public DetalleAlquiler getDetalleAlquiler()
        {
            return this.detalleAlquiler;
        }

        public int CalcularPrecioTotal(DetalleAlquiler alquiler, List<Vehiculo> vehiculos)
        {
            int total = 0;

            foreach (var item in vehiculos)
            {
                total += item.getPrecioAlquilerDiario() * alquiler.getCantDias();
            }

            return total;
        }

        public void mostrarMatriculas(List<Vehiculo> vehiculos)
        {
            Console.WriteLine($"| Matriculas: ");
            foreach (var item in vehiculos)
            {
                Console.WriteLine("|  " + item.getMatricula());
            }

        }


    }

    class DetalleAlquiler
    {
        private DateTime fechaRetiro;
        private int cantDias;
        private int cantVehiculos;

        public DetalleAlquiler(DateTime fechaRetiro, int cantDias, int cantVehiculos)
        {
            this.fechaRetiro = fechaRetiro;
            this.cantDias = cantDias;
            this.cantVehiculos = cantVehiculos;
        }

        public void setFechaRetiro(DateTime fechaRetiro) => this.fechaRetiro = fechaRetiro;
        public DateTime getFechaRetiro() => fechaRetiro;

        public void setCantDias(int cantDias) => this.cantDias = cantDias;
        public int getCantDias() => cantDias;

        public void setCantVehiculos(int cantVehiculos) => this.cantVehiculos = cantVehiculos;
        public int getCantVehiculos() => cantVehiculos;

    }


    class Vehiculo
    {
        protected int matricula;
        protected string marca;
        protected string color;
        protected string capacidadTanque;
        protected bool estado;
        protected int precioAlquilerDiario;
        protected int kmPorLitro;

        public Vehiculo(int matricula, string marca, string color, string capacidadTanque, bool estado, int precioAlquilerDiario, int kmPorLitro)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.color = color;
            this.capacidadTanque = capacidadTanque;
            this.estado = estado;
            this.precioAlquilerDiario = precioAlquilerDiario;
            this.kmPorLitro = kmPorLitro;
        }

        public void setMatricula(int matricula) => this.matricula = matricula;
        public int getMatricula() => matricula;

        public void setMarca(string marca) => this.marca = marca;
        public string getMarca() => marca;

        public void setColor(string color) => this.color = color;
        public string getColor() => color;

        public void setCapacidadTanque(string capacidadTanque) => this.capacidadTanque = capacidadTanque;
        public string getCapacidadTanque() => capacidadTanque;

        public void setEstado(bool estado) => this.estado = estado;
        public bool getEstado() => estado;

        public void setPrecioAlquilerDiario(int precioAlquilerDiario) => this.precioAlquilerDiario = precioAlquilerDiario;
        public int getPrecioAlquilerDiario() => precioAlquilerDiario;

        public void setKmPorLitro(int kmPorLitro) => this.kmPorLitro = kmPorLitro;
        public int getKmPorLitro() => kmPorLitro;

        public virtual string ObtenerTipo()
        {
            return "Vehículo genérico";
        }

    }


    class Deportivo : Vehiculo
    {
        private int velocidadMaxima;

        public Deportivo(int matricula, string marca, string color, string capacidadTanque, bool estado, int precioAlquilerDiario, int kmPorLitro, int velocidadMaxima) : base(matricula, marca,
            color, capacidadTanque, estado, precioAlquilerDiario, kmPorLitro)
        {
            this.velocidadMaxima = velocidadMaxima;
        }

        public void setVelocidadMaxima(int velocidadMaxima) => this.velocidadMaxima = velocidadMaxima;
        public int getVelocidadMaxima() => velocidadMaxima;

        public override string ObtenerTipo()
        {
            return "Deportivo";
        }
    }

    class Utilitarios : Vehiculo
    {
        private int capacidadCarga;

        public Utilitarios(int matricula, string marca, string color, string capacidadTanque, bool estado, int precioAlquilerDiario, int kmPorLitro, int capacidadCarga) : base(matricula, marca, color, capacidadTanque, estado, precioAlquilerDiario, kmPorLitro)
        {
            this.capacidadCarga = capacidadCarga;
        }

        public void setCapacidadCarga(int capacidadCarga) => this.capacidadCarga = capacidadCarga;
        public int getCapacidadCarga() => capacidadCarga;

        public override string ObtenerTipo()
        {
            return "Utilitario";
        }

    }

    class Familiar : Vehiculo
    {
        private int capacidadMaletero;

        public Familiar(int matricula, string marca, string color, string capacidadTanque, bool estado, int precioAlquilerDiario, int kmPorLitro, int capacidadMaletero) : base(matricula, marca, color, capacidadTanque, estado, precioAlquilerDiario, kmPorLitro)
        {
            this.capacidadMaletero = capacidadMaletero;
        }
        public void setCapacidadMaletero(int capacidadMaletero) => this.capacidadMaletero = capacidadMaletero;
        public int getCapacidadMaletero() => capacidadMaletero;

        public override string ObtenerTipo()
        {
            return "Familiar";
        }

    }


    class Validacion
    {
        public static bool validarString(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("La cadena no puede estar vacía.");
                    return false;
                }
                string resultado = input.ToLower();
                return true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Debe ingresar un documento");
                Console.ReadKey();
                Console.Clear();

                return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
                return false;
            }
        }

        public static bool validarEntero(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("La entrada no puede estar vacía.");
                    return false;
                }

                int resultado = int.Parse(input);

                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("La entrada no es un número entero válido.");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("La entrada está fuera del rango de un número entero válido.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
                return false;
            }
        }

        public static bool validarBool(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("La entrada no puede estar vacía.");
                    return false;
                }

                bool resultado = bool.Parse(input);

                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("La entrada no es un bool.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
                return false;
            }

        }

        public static bool validarFecha(string input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("La entrada no puede estar vacía.");
                    return false;
                }

                DateTime resultado = DateTime.Parse(input);

                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("La entrada no es una fecha válida.");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("La entrada está fuera del rango de una fecha válida.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
                return false;
            }
        }


    }

}
