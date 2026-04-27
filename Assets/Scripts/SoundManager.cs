using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Enemy SFX")]
    [SerializeField] private AudioClip enemyDeathCoinSFX;

    [Header("UI SFX")]
    [SerializeField] private AudioClip buttonClickSFX;

    [Header("Player SFX")]
    [SerializeField] private AudioClip playerHitSFX;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySFX(AudioClip clip) //function for playing sound effect
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayEnemyDeathCoinSFX()
    {
        PlaySFX(enemyDeathCoinSFX);
    }

    public void PlayButtonClickSFX()
    {
        PlaySFX(buttonClickSFX);
    }

    public void PlayPlayerHitSFX()
    {
        PlaySFX(playerHitSFX);
    }

}