using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat {
    public List<StatBonus> BaseAdditives { get; set; }
    
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int _baseValue, string _statName, string _statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = _baseValue;
        this.StatName = _statName;
        this.StatDescription = _statDescription;
    }

    public void AddStatBonus(StatBonus _statBonus)
    {
        this.BaseAdditives.Add(_statBonus);
    }

    public void RemoveStatBonus(StatBonus _statBonus)
    {
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == _statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        this.FinalValue += this.BaseValue;
        return FinalValue;
    }
}
