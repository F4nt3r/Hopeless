using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary.Intefrace;
public interface ICreature
{
    string Name { get; }
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public int Initiative { get; set; }
    public bool IsDead();
    
    public void TakeDamage(int damage);
    public void BasicAttack<T>(T target, out int dmg) where T : ICreature;
}
