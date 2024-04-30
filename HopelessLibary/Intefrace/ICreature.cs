﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary.Intefrace;
public interface ICreature
{
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
    public int Initiative { get; set; }
    public void TakeDamage(int damage);
    public int BasicAttack();
}
