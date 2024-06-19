using UnityEngine;

public interface IDamageable
{
    public void DecreaseHealth(int damage);
    public void DecreaseHealth(int damage, Vector2 knockback);
}
