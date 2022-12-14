using UnityEngine;

public static class PlayerData
{
    [Header("Player Info")]
    public static string playerName = "Player";
    public static float movementSpeed = 10f;
    public static float dashCooldown = 0.75f;
    public static float dashTime = 0.1f;
    public static float dashSpeed = 50f;

    [Header("Player Stats")]
    public static int health;
    public static int maxHealth;

    [HideInInspector]
    public static bool menuActive;
    public static float playTime;
    public static float levelTime;

}
