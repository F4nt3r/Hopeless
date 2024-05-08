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
    public int MinDmg { get; set; }
    public int MaxDmg { get; set; }
    public int CurrentHP { get; set; }
    public int Initiative { get; set; }
    public List<Buff> Buffs {get;set;}
    public List<DeBuff> DeBuffs {get;set;}
    public Skill? Skill1 { get; }
    public Skill? Skill2 { get; }
    public CharacterType CharacterType { get; set; }
    public ICreature Target { get; set; }
    string BasicAttackDescription => "Atakujesz Wroga za pomocą swojej broni" + Environment.NewLine + "DMG: " + MinDmg + "-" + MaxDmg;
    public void AddBuff(Buff buff);
    public void AddDeBuff(DeBuff debuff);
    public bool IsDead();
    public void TakeDamage(int damage);
    public void BasicAttack<T>(T target, out int dmg) where T : ICreature;
    public void CheckBuffsAndDebuffsAndRemoveIfNeeded();
    public void CheckSkillsCd();
    public void ClearEffetsAfterBattle();

}
