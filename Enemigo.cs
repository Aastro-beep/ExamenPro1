using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProm
{
    public class Enemigo
    {
        public int HealthEnemy;
        public int DamageEnemy;
        public Enemigo(int vida, int dano)
        {
            HealthEnemy = vida;
            HealthEnemy = dano;
        }
        public void RecibirDamageEnemy(int cantidad)
        {
            HealthEnemy = HealthEnemy - cantidad;
            if (HealthEnemy < 0)
            {
                HealthEnemy = 0;
            }
        }
        public int ObtenerDamageEnemy()
        {
            return DamageEnemy;
        }
        public bool IsAliveEnemy()
        {
            if (HealthEnemy > 0)
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
