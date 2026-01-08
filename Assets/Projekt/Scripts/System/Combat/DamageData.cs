using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Projekt.Scripts.System.Combat
{
    public struct DamageData
    {
        public int Amount;
        public bool IsUnblockable;

        public DamageData(int amount, bool unblockable = false)
        {
            Amount = amount;
            IsUnblockable = unblockable;
        }
    }
}
