using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary.Intefrace;
public interface ICreature
{
     string Name { get; }
     int MaxHP { get; set; }
     int MinDmg { get; set; }
     int MaxDmg { get; set; }
     int CurrentHP { get; set; }
     int Initiative { get; set; }
     List<Buff> Buffs {get;set;}
     List<DeBuff> DeBuffs {get;set;}
     Skill? Skill1 { get; }
     Skill? Skill2 { get; }
     CharacterType CharacterType { get; set; }
    public Point Location { get; set; }
    string BasicAttackDescription => "You attack the enemy with your weapon" + Environment.NewLine + "DMG: " + MinDmg + "-" + MaxDmg;
     void AddBuff(Buff buff);
     void AddDeBuff(DeBuff debuff);
     bool IsDead();
     void TakeDamage(int damage);
     void BasicAttack<T>(T target, out int dmg) where T : ICreature;
     void CheckBuffsAndDebuffsAndRemoveIfNeeded();
     void CheckSkillsCd();
     void ClearEffetsAfterBattle();

}
