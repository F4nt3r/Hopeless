using HopelessLibary.Enums;
using HopelessLibary.Intefrace;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary;
[Serializable]
public class Skill : ISkill
{
    public Skill(string name
        , int cooldown
        , TargetType targetType
        , SkillType skillType
        , SkillHandlerEvent skillHandler
        , string description)
    {
        Name = name;
        Cooldown = cooldown;
        TargetType = targetType;
        SkillType = skillType;
        SkillHandler = skillHandler;
        Description = description;
    }
    public string Name { get; set; }
    public int Cooldown { get; set; }
    public TargetType TargetType { get; set; }
    public SkillType SkillType { get; set; }
    [JsonIgnore]
    public SkillHandlerEvent SkillHandler { get; set; }
    public string Description { get; set; }
}
