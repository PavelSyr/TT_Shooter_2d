using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TT_Shooter_2d.Enemies
{
    interface IEnemyFactory
    {
        GameObject Instatinate();
    }
}
