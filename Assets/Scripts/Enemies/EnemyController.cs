using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float damage = 10f; // 怪物对玩家的伤害值
    [SerializeField] private float damageCooldown = 1f; // 每次伤害之间的冷却时间

    private float lastDamageTime = 0f; // 上次伤害的时间
    private PlayerHealth playerHealth; // 引用玩家血量脚本
    private Vector3 playerPosition = Vector3.zero; // 玩家位置 (0, 0, 0)

    [Header("Rewards")]
    [SerializeField] private int CoinReward = 1;

    [Header("References")]
    [SerializeField] private SkinnedMeshRenderer meshRenderer;

    private EnemyHealth health;

    private Color color;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
        health.OnDeath.AddListener(AwardCoins);
    }

    private void Start()
    {
        // Assign a random hue color
        color = Color.HSVToRGB(Random.value, 1f, 0.85f);
        meshRenderer.material.color = color;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerPosition = Vector3.zero; // 初始化玩家位置
    }

    private void FixedUpdate()
    {
        if (PlayerHealth.isGameOver) return;
        // move towards player
        // player is always at (0, 0, 0)
        Vector3 direction = (Vector3.zero - transform.position).normalized;
        transform.position += moveSpeed * Time.fixedDeltaTime * direction;

        // rotate to face player
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
        }

        // 检查怪物是否接近玩家（(0, 0, 0)）
        if (Vector3.Distance(transform.position, playerPosition) < 0.5f) // 假设距离小于 0.5 时触发伤害
        {
            ApplyDamage();
            Debug.Log("Applying damage to player");
        }
    }

    private void ApplyDamage()
    {
        if (PlayerHealth.isGameOver) return;
        // 确保每次伤害之间有冷却时间
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // 触发玩家扣血
                lastDamageTime = Time.time; // 记录伤害的时间
            }
        }
    }

    private void OnDestroy()
    {
        health.OnDeath.RemoveListener(AwardCoins);
    }

    #region Helper functions
    private void AwardCoins()
    {
        PlayerStats.Instance.AddCoins(CoinReward);
    }
    #endregion

    #region Public APIs
    public Color GetColor() => color;
    #endregion
}
