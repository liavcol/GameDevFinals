using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObjective : Objective
{
    [SerializeField] private DoorScript door;

    private void Start() => door.OnDoorOpened += ObjectiveAccomplished;

    protected override void ObjectiveAccomplished() => OnObjectiveAccomplished?.Invoke();
}
