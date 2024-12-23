using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
   [Header("Platform Settings")]
   public float pauseDuration = 1.5f; // �Ȱ����ɶ��]���^
   public float launchForce = 18.5f; // �u�g���O��
   public bool isActive = true; // ���x�O�_�ҥ�

   private void OnCollisionEnter2D(Collision2D collision)
    
   {
        //Debug.Log("testmessage");
       // �ˬd�O�_�����a
       if (isActive && collision.gameObject.CompareTag("Player"))
        {
         //   Debug.Log("testmessage2");
           // ������a������ե�
           Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

           if (playerRigidbody != null)
           {
               // �Ұʨ�{�ӳB�z�Ȱ��M�u�g
               StartCoroutine(LaunchPlayer(playerRigidbody));
           }
       }
   }

   private System.Collections.IEnumerator LaunchPlayer(Rigidbody2D playerRigidbody)
   {
       // �Ȱ����a����
       playerRigidbody.isKinematic = true;

       // ���ݫ��w���Ȱ��ɶ�
       yield return new WaitForSeconds(pauseDuration);

       // ���s�ҥΪ��z�ĪG
      playerRigidbody.isKinematic = false;

       // �V�W�I�[�u�g�O
       playerRigidbody.AddForce(Vector3.up * launchForce, ForceMode2D.Impulse);
   }

   // �i�H�Ω�ʺA����x���ҥ�/�T��
   public void SetPlatformActive(bool active)
   {
       isActive = active;
   }
}
