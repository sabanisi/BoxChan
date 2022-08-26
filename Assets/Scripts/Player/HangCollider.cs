using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangCollider : MonoBehaviour
{
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Player player;
    public Box collisionBox { private set; get; }//触れているハコ
    public bool isHang { get; set; }//ハコを持っているかどうか
    private Box thisCollisionBox;//今接触しているハコ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.CanOperate) return;
        if (!isHang && collision.tag == "Box")
        {
            thisCollisionBox = collision.GetComponent<Box>();
            if (groundCheck.IsGround())
            {
                EnterDeal();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!player.CanOperate) return;
        if (!isHang && collision.tag == "Box")
        {
            if (groundCheck.IsGround())
            {
                if (collisionBox == null)
                {
                    EnterDeal();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            if (collisionBox != null)
            {
                Box thisCollisionBox = collision.GetComponent<Box>();
                if (thisCollisionBox.myBlockEnum.Equals(BlockEnum.DamageBox))
                {
                    return;
                }
                if (collisionBox == thisCollisionBox)
                {
                    collisionBox.IsMoveTriangle = false;
                    collisionBox = null;
                }
            }
        }
    }

    private void EnterDeal()
    {
        if (collisionBox != null)
        {
            collisionBox.IsMoveTriangle = false;
            collisionBox = null;
        }

        if (thisCollisionBox.myBlockEnum.Equals(BlockEnum.DamageBox))
        {
            return;
        }
        collisionBox = thisCollisionBox;
        collisionBox.IsMoveTriangle = true;
    }
}
