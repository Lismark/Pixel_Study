using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class Player : GroundDetection
{
    [SerializeField] private float moveSpeed = 6f;
    #region Свойство MoveSpeed
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            if (value > 1f)
            {
                moveSpeed = value;
            }
        }
    }
    #endregion

    [SerializeField] private float force = 10f;
    #region Свойство Force
    public float Force
    {
        get { return force; }
        set
        {
            if( value > 1f)
            {
                force = value;
            }
        }
    }
    #endregion
    [SerializeField] private int armor;
    public int Armor
    { get; set; }
    [SerializeField] private int playerDamage;


    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float minHeight;
    [SerializeField] private bool isCheatMode;
    private Vector3 direction;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isJumping;
    [SerializeField] private Arrow arrow;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private float rechargeTime;
    [SerializeField] private int arrowForce;
    [SerializeField] private int arrowsCount = 3;
    [SerializeField] private BuffReciever buffReciever;


    private List<Arrow> arrowsPool;
    private Arrow currentArrow;

    public int ArrowForce
    {
        get { return arrowForce; }
        set { arrowForce = value; }
    }

    public float RechargeTime
    {
        get { return rechargeTime; }
        set { rechargeTime = value; }
    }

    private bool isRecharge;

    public void Start()
    {
        arrowsPool = new List<Arrow>();
        for(int i = 0; i < arrowsCount; i++)
        {
            var arrowTemp = Instantiate(arrow, arrowSpawnPoint);
            arrowsPool.Add(arrowTemp);
            arrowTemp.gameObject.SetActive(false);
        }
        
    }

    public void SetDamage(int damage)
    {
        playerDamage += damage;

        for(int i = 0; i < arrowsCount; i++)
        {
            var arrowDamage = arrowsPool[i].GetComponent<TriggerDamage>();
            arrowDamage.Damage = playerDamage;
        }

    }

    void Update()
    {
        animator.SetBool("IsGrounded", IsGrounded);
        if (!isJumping && !IsGrounded)
            animator.SetTrigger("startFall");
        isJumping = isJumping && !IsGrounded;
        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction = Vector3.right;
        if (Input.GetKey(KeyCode.S))
            direction = Vector3.down;
        direction *= moveSpeed;
        direction.y = rigidbody.velocity.y;
        rigidbody.velocity = direction;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            animator.SetTrigger("startJump");
            rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            isJumping = true;
        }
        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        if (direction.x > 0)
            spriteRenderer.flipX = false;
        if (direction.x < 0)
            spriteRenderer.flipX = true;

        CheckFall();
        CheckShoot();
    }

    public void CheckShoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!isRecharge) 
            {
                animator.SetTrigger("shooting");
                isRecharge = true;
                StartCoroutine(Recharge());
            }
        }
    }
    void Shooting()
    {
        currentArrow = GetArrowFromPool();
        if (spriteRenderer.flipX)
            currentArrow.SetImpulse(Vector2.left, arrowForce, this);
        else
            currentArrow.SetImpulse(Vector2.right, arrowForce, this);
    }
    void CheckFall()
    {
        if (transform.position.y < minHeight && isCheatMode)
        {
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.position = new Vector2(0, 0);
        }

        else if (transform.position.y < minHeight)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Recharge()
    {
        yield return new WaitForSeconds(rechargeTime);
        isRecharge = false;
        yield break;
    }

    private Arrow GetArrowFromPool()
    {
      if(arrowsCount > 0)
        {
            var arrowTemp = arrowsPool[0];
            arrowsPool.Remove(arrowTemp);
            arrowTemp.transform.parent = null;
            arrowTemp.transform.position = arrowSpawnPoint.transform.position;
            arrowTemp.gameObject.SetActive(true);
            return arrowTemp;
        }
      return Instantiate(arrow, arrowSpawnPoint.position, Quaternion.identity);
    }
    public void returnArrowToPool(Arrow arrow)
    {
        if(!arrowsPool.Contains(currentArrow))
            arrowsPool.Add(currentArrow);

        currentArrow.transform.parent = arrowSpawnPoint;
        currentArrow.transform.position = arrowSpawnPoint.transform.position;
        currentArrow.gameObject.SetActive(false);
    }
}
