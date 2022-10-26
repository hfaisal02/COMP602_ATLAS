using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public static event HandleBossDefeated OnBossDefeated;
    public delegate void HandleBossDefeated();

    void OnDestroy()
    {
        OnBossDefeated?.Invoke();
    }
}
