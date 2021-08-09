using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Project
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public float speed = 5f;
        [SerializeField] public float rotateSpeed = 1200f;
        
        private Animator animator;
        private Quaternion targetRotation;
        
        private void Awake()
        {
            // コンポーネント関連付け
            TryGetComponent(out animator);
            
            // 初期化
            targetRotation = transform.rotation;
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            // 入力ベクトルの取得
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
            var velocity = horizontalRotation * new Vector3(horizontal, 0, vertical);
            
            // 速度の取得
            var sprint = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
            var rotationSpeed = rotateSpeed * Time.fixedDeltaTime;
            
            // 移動方向を向く
            if (velocity.magnitude > 0.5f)
            {
                targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
            
            // キャラクターの移動
            transform.localPosition += velocity * speed * Time.fixedDeltaTime * sprint;

            // 移動速度をAnimatorに反転
            animator.SetFloat("Speed", velocity.magnitude * sprint, 0.1f, Time.fixedDeltaTime);
            
            // 左クリックで攻撃
            if (Input.GetMouseButton(0))
            {
                animator.SetBool("Attack1", true);
            }
            
        }

        void Attack1Start()
        {
            
        }

        void Attack1End()
        {
            animator.SetBool("Attack1", false);
        }
    }
    
}