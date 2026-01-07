using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Projekt.Scripts.System.Auras
{
    public internal interface IAura
    {
        void OnApply(PlayerController player);
        void OnRemove(PlayerController player);
        void Tick(PlayerController player, float deltaTime);
    }
}
