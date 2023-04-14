using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAnimatorController
{
    public static class Params
    {
        public const string IsAlive= nameof(IsAlive);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Death = nameof(Death);
    }
}
