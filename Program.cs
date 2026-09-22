using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool volverAJugar = true;
            while (volverAJugar)
            {
                Console.Clear();
                Console.WriteLine("-----------------------");
                Console.WriteLine("---   BIENVENIDO A ---");
                Console.WriteLine("--- JUEGO DE TURNOS ---");
                Console.WriteLine("-----------------------");
                Console.WriteLine("¡Crea tu JUGADOR! Ingrese la vida (Máx. 100)");
                int vidaJugador = Convert.ToInt32(Console.ReadLine());
                if (vidaJugador > 100)
                {
                    vidaJugador = 100;
                }
                Console.WriteLine("Indique cuánto daño haces (Máx. 100)");
                int danoJugador = Convert.ToInt32(Console.ReadLine());
                if (danoJugador > 100)
                {
                    danoJugador = 100;
                }
                Jugador jugador = new Jugador(vidaJugador, danoJugador);

                Console.WriteLine("¡Crea tu ENEMIGO! Ingrese la cantidad");
                int cantidadEnemigos = Convert.ToInt32(Console.ReadLine());
                List<Enemigo> listaDeEnemigos = new List<Enemigo>();

                for (int i = 0; i< cantidadEnemigos; i++)
                {
                    Console.WriteLine("Indique la vida del enemigo (Máx. 100)");
                    int vidaEnemigo = Convert.ToInt32(Console.ReadLine());
                    if (vidaEnemigo > 100)
                    {
                        vidaEnemigo = 100;
                    }
                    Console.WriteLine("Indique el daño del enemigo (Máx. 100)");
                    int danoEnemigo = Convert.ToInt32(Console.ReadLine());
                    if (danoEnemigo > 100)
                    {
                        danoEnemigo = 100;
                    }
                    Enemigo enemigoCreado = new Enemigo(vidaEnemigo, danoEnemigo);
                    listaDeEnemigos.Add(enemigoCreado);
                }

                Console.WriteLine("¡Hecho! Presione Enter...");
                Console.ReadLine();
                while (jugador.IsAlive())
                {
                    bool enemigosVivos = false;
                    for (int i = 0; i< listaDeEnemigos.Count; i++)
                    {
                        if (listaDeEnemigos[i].IsAliveEnemy())
                        {
                            enemigosVivos = true;
                            break;
                        }
                    }
                    if (enemigosVivos == false)
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"Nuevo JUGADOR. Vida: {jugador.Health} Daño: {jugador.ObtenerDamage()}");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("--- LISTA DE ENEMIGOS ---");
                    Console.WriteLine("--------------------------");

                    for (int i = 0; i < listaDeEnemigos.Count; i++)
                        if (listaDeEnemigos[i].IsAliveEnemy())
                        {
                            Console.WriteLine($"{i + 1}- Enemigo {i + 1} y Vida: {listaDeEnemigos[i].HealthEnemy}");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}- Enemigo {i + 1} - Muerto");
                        }
                    Console.WriteLine("¡Seleccione el NUMERO de enemigo para ATACAR!");
                    int opcion = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (opcion >= 0 && opcion < listaDeEnemigos.Count)
                    {
                        if (listaDeEnemigos[opcion].IsAliveEnemy())
                        {
                            listaDeEnemigos[opcion].RecibirDamageEnemy(jugador.ObtenerDamage());
                            Console.WriteLine($"¡Atacaste al enemigo {opcion + 1} y lograste {jugador.ObtenerDamage()} de DAÑO!");
                        }
                        else
                        {
                            Console.WriteLine("El enemigo ya está muerto... ¡déjalo morir en paz!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error... saltando turno...");
                    }
                    for (int i = 0; i < listaDeEnemigos.Count; i++)
                    {
                        if (listaDeEnemigos[i].IsAliveEnemy())
                        {
                            jugador.RecibirDamage(listaDeEnemigos[i].ObtenerDamageEnemy());
                            Console.WriteLine($"¡El enemigo {i + 1} te ATACÓ y LOGRÓ {listaDeEnemigos[i].ObtenerDamageEnemy()} de DAÑO!");
                        }
                    }
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                }
                //mensaje final
                Console.Clear();
                if (jugador.IsAlive())
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--- ¡¡VICTORY!! ¡Eliminaste TODO! ---");
                    Console.WriteLine("      Recompensa: 5 moneditas");
                    Console.WriteLine("--------------------------------------");
                }
                else
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("--- ¡FATALITY! ¡TÚ fuiste el eliminado! ---");
                    Console.WriteLine("         Te quitaron 5 moneditas");
                    Console.WriteLine("-------------------------------------------");
                }
                Console.WriteLine("¿Quieres empezar de nuevo? (si/no)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "si")
                {
                    volverAJugar = false;
                    Console.WriteLine("¡Gracias por jugar! Hasta luego.");
                }
            }
        }
    }
}
