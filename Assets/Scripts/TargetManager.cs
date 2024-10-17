using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<Target> Targets {  get; private set; }
    public Target Leader { get; private set; }

    private void Awake()
    {
        Targets = FindObjectsByType<Target>(0).ToList();
        Leader = Targets[0];
    }

    private void Update()
    {
        Targets = FindObjectsByType<Target>(0).ToList();
        Leader = Targets[0];
    }
}
