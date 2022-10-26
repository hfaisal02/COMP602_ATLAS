using UnityEngine;
using TMPro;

public class UIPlayer : MonoBehaviour
{
    GameManager gm;

    public Animator anim;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;

    void Awake()
    {
        PlayerBehaviour.OnHealthChanged += PlayHealthFlash;
    }

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        nameText.text = "[" + PlayerData.playerName + "]";
        healthText.text = gm.health + " / " + gm.maxHealth;
    }

    void PlayHealthFlash(int amount)
    {
        anim.SetTrigger("Damage Taken");
    }
}
