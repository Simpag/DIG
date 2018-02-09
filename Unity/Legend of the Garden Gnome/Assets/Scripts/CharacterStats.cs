using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Damage", "Your damage amount"));        
    }

    public void AddStatBonus(List<BaseStat> _statBonuses)
    {
        foreach(BaseStat _statBonus in _statBonuses)
        {
            stats.Find(x => x.StatName == _statBonus.StatName).AddStatBonus(new StatBonus(_statBonus.BaseValue)); //If the stat matches the bonus stat name
        }
    }

    public void RemoveStatBonus(List<BaseStat> _statBonuses)
    {
        foreach (BaseStat _statBonus in _statBonuses)
        {
            stats.Find(x => x.StatName == _statBonus.StatName).RemoveStatBonus(new StatBonus(_statBonus.BaseValue)); //If the stat matches the bonus stat name
        }
    }
}
