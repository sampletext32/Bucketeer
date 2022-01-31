using System;
using UnityEngine;

[Serializable]
public class TaskItem
{
    [Range(0, 1)]
    public float colorR;

    [Range(0, 1)]
    public float colorG;

    [Range(0, 1)]
    public float colorB;

    public int correctAnswer;
}