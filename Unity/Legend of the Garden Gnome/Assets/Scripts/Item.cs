using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public List<BaseStat> stats { get; set; }
    public string objectSlug { get; set; }

    public Item(List<BaseStat> _stats, string _objectSlug)
    {
        this.stats = _stats;
        this.objectSlug = _objectSlug;
    }
}