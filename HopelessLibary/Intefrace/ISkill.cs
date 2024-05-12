using HopelessLibary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary.Intefrace;
public delegate SkillHandlerResponse SkillHandlerEvent(ICreature caster,List<ICreature> creatures);
public record SkillHandlerResponse(string logText,int cd);

public interface ISkill
{
    string Name { get; set; }
    int Cooldown { get; set; }

    TargetType TargetType { get; set; }

    SkillType SkillType { get; set; }
    SkillHandlerEvent SkillHandler { get; set; }
    string Description { get; set; }
}

