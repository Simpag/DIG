using System.Collections.Generic;

public interface IWeapon {
    List<BaseStat> stats { get; set; }
    void PerformAttack();
}
