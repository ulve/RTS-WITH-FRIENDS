﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : TeamObject, ISelectable
{
  public float Speed;
  public UnitType UnitType;
  public Target Target
  {
    get; set;
  }
  public virtual void Update()
  {
    Move();
  }

  public virtual void Move()
  {
    if (Target != null)
    {
      transform.position = Vector2.MoveTowards(transform.position, Target.GetTargetPosition(), Time.deltaTime * Speed);
      if (Vector2.Distance(transform.position, Target.GetTargetPosition()) < Target.AcceptableDistance())
      {
        Target = null;
      }
    }
  }

  public override void OnRightClick(Vector2 position)
  {
    if (!IsOwnTeam()) {
      return;
    }
    this.Target = new StaticPositionTarget(position);
    print(UnitType + " got " + position + " as target");
  }
}
