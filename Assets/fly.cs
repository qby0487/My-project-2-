using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class JumpPlatform : MonoBehaviour
//{
//    [Header("Platform Settings")]
//    //public float pauseDuration = 1.5f; // �Ȱ����ɶ��]��^
//    public float launchForce = 10f; // �u�g���O��
//    public bool isActive = true; // ���x�O�_�ҥ�

//    private void OnCollisionEnter(Collision collision)
//    {
//        // �ˬd�O�_�����a
//        if (isActive && collision.gameObject.CompareTag("Player"))
//        {
//            // ������a������ե�
//            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

//            if (playerRigidbody != null)
//            {
//                // �Ұʨ�{�ӳB�z�Ȱ��M�u�g
//                StartCoroutine(LaunchPlayer(playerRigidbody));
//            }
//        }
//    }

//    private System.Collections.IEnumerator LaunchPlayer(Rigidbody playerRigidbody)
//    {
//        // �Ȱ����a����
//        playerRigidbody.isKinematic = true;

//        // ���ݫ��w���Ȱ��ɶ�
//        yield return new WaitForSeconds(pauseDuration);

//        // ���s�ҥΪ��z�ĪG
//        playerRigidbody.isKinematic = false;

//        // �V�W�I�[�u�g�O
//        playerRigidbody.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
//    }

//    // �i�H�Ω�ʺA����x���ҥ�/�T��
//    public void SetPlatformActive(bool active)
//    {
//        isActive = active;
//    }
//}
