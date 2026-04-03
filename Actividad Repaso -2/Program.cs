using System;

namespace PracticaBus
{
    // 1. ABSTRACCIÓN Y ENCAPSULAMIENTO
    public abstract class Autobus
    {
        // Encapsulamiento: Incluimos ruta, distancia y precio.
        protected string tipoBus;
        protected string nombreRuta;
        protected double distanciaKm;
        protected double precioPasaje;

        protected int capacidadAsientos;
        protected int pasajerosActuales;
        protected double ventasTotales;

        // Constructor actualizado con todos los datos relevantes de la ruta
        public Autobus(string tipoBus, string nombreRuta, double distanciaKm, double precioPasaje, int capacidadAsientos)
        {
            this.tipoBus = tipoBus;
            this.nombreRuta = nombreRuta;
            this.distanciaKm = distanciaKm;
            this.precioPasaje = precioPasaje;
            this.capacidadAsientos = capacidadAsientos;

            this.pasajerosActuales = 0;
            this.ventasTotales = 0;
        }

        // 3. POLIMORFISMO
        // Lo hago virtual por si alguna clase hija quiere cobrar diferente (ej. con descuento),
        // pero por defecto todos cobran multiplicando pasajeros por el precio.
        public virtual void CobrarPasaje(int cantidadPasajeros)
        {
            pasajerosActuales += cantidadPasajeros;
            ventasTotales += cantidadPasajeros * precioPasaje;
        }

        // Método extra para ver la información de la ruta (Demuestra que guardamos los datos)
        public void MostrarInfoRuta()
        {
            Console.WriteLine($"--- Bus {tipoBus} | Ruta: {nombreRuta} ({distanciaKm} km) | Precio: {precioPasaje:C} ---");
        }

        public string MostrarResumen()
        {
            int asientosDisponibles = capacidadAsientos - pasajerosActuales;
            return $"Auto Bus {tipoBus} {pasajerosActuales} Pasajeros Ventas {ventasTotales:#,##0} quedan {asientosDisponibles} asientos disponibles";
        }
    }

    // 2. HERENCIA
    public class AutobusPlatinum : Autobus
    {
        // Le pasamos al padre (base) todos los datos inventados:
        // Ruta: Santo Domingo - Punta Cana, Distancia: 195.5 km, Precio: 1000, Capacidad: 22
        public AutobusPlatinum()
            : base("Plantinum", "Santo Domingo - Punta Cana", 195.5, 1000.0, 22)
        {
        }
    }

    // 2. HERENCIA
    public class AutobusGold : Autobus
    {
        // Le pasamos al padre (base) todos los datos inventados:
        // Ruta: Santo Domingo - Santiago, Distancia: 155.0 km, Precio: 1333.33, Capacidad: 15
        public AutobusGold()
            : base("Gold", "Santo Domingo - Santiago", 155.0, 4000.0 / 3.0, 15)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AutobusPlatinum busPlatinum = new AutobusPlatinum();
            AutobusGold busGold = new AutobusGold();

            // Mostramos los datos de la ruta y distancia que agregamos (opcional, para que el profe vea que los pensaste)
            Console.WriteLine("DATOS DE LAS RUTAS:");
            busPlatinum.MostrarInfoRuta();
            busGold.MostrarInfoRuta();
            Console.WriteLine(); // Salto de línea

            // Simulamos la subida de los pasajeros
            busPlatinum.CobrarPasaje(5);
            busGold.CobrarPasaje(3);

            // Imprimimos el resultado final exigido
            Console.WriteLine("Resultado:");
            Console.WriteLine(busPlatinum.MostrarResumen());
            Console.WriteLine(busGold.MostrarResumen());

            Console.ReadLine();
        }
    }
}