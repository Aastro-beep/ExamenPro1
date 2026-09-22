using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProm
{
    public class Jugador
    {
        public int Health;
        public int Damage;

        public Jugador (int vida, int dano)
        {
            Health = vida;
            Damage = dano;
        }
        public void RecibirDamage(int cantidad)
        {
            Health = Health - cantidad;
            if (Health < 0)
            {
                Health = 0;
            }
        }
        public int ObtenerDamage()
        {
            return Damage;
        }
        public bool IsAlive()
        {
            if (Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
