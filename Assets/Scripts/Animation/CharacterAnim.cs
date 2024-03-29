using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public enum PlayerState 
{
    IDLE,
    WALK,
    RUN,
    JUMP,
    // 구현해야함. 주운물건 분류, 인벤토리도 만들어야할듯 ㅠㅠ
    PICKUP,
    CROUNCH,
    // 아직 스킬 기획을 못함. 애니메이션 못 구함.
    ATTACK,
    DIE,
}

public class CharacterAnim : MonoBehaviour
{
    public PlayerMovement pm;
    public CharacterInputMng playerInput;
    private void Update() 
    {
        switch((int)pm.playerState) {
        case 0:
            Debug.Log("IDLE");
            pm.characterAnimator.SetBool("Idle", true);
            pm.characterAnimator.SetBool("Run", false);
            pm.characterAnimator.SetBool("PickUp", false);
            pm.characterAnimator.SetFloat("Move", 0);
            break;
        case 1:
            Debug.Log("Walk");
            Vector3 moveDistance = pm.moveSpeed * playerInput.move * pm.characterRigidbody.transform.forward * Time.deltaTime;
            pm.characterRigidbody.MovePosition(pm.characterRigidbody.position + moveDistance);
            pm.characterAnimator.SetFloat("Move", playerInput.move);
            pm.characterAnimator.SetBool("Run", false);
            pm.characterAnimator.SetBool("PickUp", false);
            break;
        case 2:
            Debug.Log("Run");
            Vector3 moveDist = pm.runSpeed * playerInput.move * transform.forward * Time.deltaTime;
            pm.characterRigidbody.MovePosition(pm.characterRigidbody.position + moveDist);
            pm.characterAnimator.SetBool("Run", true);
            break;
        case 3:
            Debug.Log("Jump");
            pm.characterRigidbody.AddForce(Vector3.up * pm.jumpForce, ForceMode.Impulse);
            pm.characterAnimator.SetBool("Jump", true);
            break;
        case 4:
            Debug.Log("Pickup");
            pm.characterAnimator.SetBool("PickUp", true);
            //인벤 시스템
            break;  
        case 5:
            Debug.Log("Crounch");
            break;
        case 6:
            Debug.Log("Attack");
            break;
        case 7:
            Debug.Log("Die");
            break;
        }
    }
    
}