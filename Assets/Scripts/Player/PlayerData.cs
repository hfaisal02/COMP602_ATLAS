using UnityEngine;

public static class PlayerData
{
    [Header("Player Stats")]
    public static string playerName = "player";
    public static float movementSpeed = 10f;
    public static float dashCooldown = 0.75f;
    public static float dashTime = 0.1f;
    public static float dashSpeed = 50f;

    [HideInInspector]
    public static bool menuActive;
}
