using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    Left,
    Right
}
public interface IMovable
{
    void Move(Direction direction);
    void Move(int direction);
}
