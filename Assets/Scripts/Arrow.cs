using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IObjectDestroyer
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private int force;
    [SerializeField] private float arrowLifeTime;
    [SerializeField] private TriggerDamage triggerDamage;
    [SerializeField] private Player player;

    public int Force
    {
        get { return force; }
        set { force = value; }
    }

    public void Destroy(GameObject gameObject)
    {
        player.returnArrowToPool(this);
    }

    public void SetImpulse(Vector2 direction, int force, Player player)
    {
        this.player = player;
        triggerDamage.Init(this);
        triggerDamage.Parent = player.gameObject;
        rigidBody.AddForce(direction * force, ForceMode2D.Impulse);
        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        StartCoroutine(ArrowLife());
    }

    private IEnumerator ArrowLife()
    {
        yield return new WaitForSeconds(arrowLifeTime);
        Destroy(gameObject);
        yield break;

    }



}
