using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//
// アニメーション簡易プレビュースクリプト
// 2015/4/25 quad arrow
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]

public class IdleChanger : MonoBehaviour
{

	private Animator animator;				// Animatorへの参照
	private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
	private AnimatorStateInfo previousState;	// ひとつ前のステート状態を保存する参照

    
    private Rigidbody rigitbody;
    private bool isGround = true;
    private Vector3 Player_pos;
    //private float Player_pos_z;
    private bool douji = false;
    public float runSpeed;
    public float maxSpeed;
    public float jumpPower = 2f;
    public float ForceGravity = 100f;
    public float rotateSpeed = 1f;

    // Use this for initialization
    void Start ()
	{
		// 各参照の初期化
		animator = GetComponent<Animator> ();
		currentState = animator.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;

        rigitbody = this.transform.GetComponent<Rigidbody>();
        Player_pos = GetComponent<Transform>().position;
        //Player_pos_z = GetComponent<Transform>().position.z;

    }

    void Update()
    {
        Transform cameraTrans = GameObject.Find("unitychan").transform;


        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("is_running", true);
            //rigitbody.AddForce(transform.forward * runSpeed);
            Vector3 pos = cameraTrans.position;
            pos.z += 0.1f;
            cameraTrans.position = pos;
            douji = true;
            
        }
        else if (Input.GetKey(KeyCode.S))
        {

            animator.SetBool("is_running", true);
            Vector3 pos = cameraTrans.position;
            pos.z -= 0.1f;
            cameraTrans.position = pos;
            douji = true;
        }
        else
        {
            animator.SetBool("is_running", false);
            douji = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("is_running", true);
            Vector3 pos = cameraTrans.position;
            pos.x += 0.1f;
            cameraTrans.position = pos;
            douji = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("is_running", true);
            Vector3 pos = cameraTrans.position;
            pos.x -= 0.1f;
            cameraTrans.position = pos;
            douji = true;
        }
        else if(douji==false)
        {
            animator.SetBool("is_running", false);
        }


        
        if (isGround && Input.GetKeyDown("space"))
        {
            rigitbody.AddForce(transform.up * jumpPower);
            animator.SetBool("is_jumping", true);
        }

        Vector3 diff = transform.position - Player_pos;

        diff.y = 0f;
        if (diff.magnitude > 0.01f ) //ベクトルの長さが0.01fより大きい場合にプレイヤーの向きを変える処理を入れる(0では入れないので）
        {
            transform.rotation = Quaternion.LookRotation(diff);  //ベクトルの情報をQuaternion.LookRotationに引き渡し回転量を取得しプレイヤーを回転させる
        }

        Player_pos = transform.position; //プレイヤーの位置を更新

        //anim.SetBool("Run", false);

        
        Vector3 Vector_f = transform.position - Player_pos; // ==diff
        if (Input.GetKey(KeyCode.J))
        {
            animator.SetBool("Jab", true);

            RaycastHit rayhit;
            
            Ray ray = new Ray(Player_pos, Vector_f); //光線の取得

            if (Physics.Raycast(ray, out rayhit, 100f))
            {
                Rigidbody rd = rayhit.transform.GetComponent<Rigidbody>();
                if (rd.name == "Cylinder1" || rd.name == "Cylinder2")
                {
                    rd.AddForce(transform.forward * 100f); //力を加える

                }
            }
        }


    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("is_jumping", false);
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;

        }
    }



    //    void OnGUI()
    //	{	
    //		GUI.Box(new Rect(Screen.width - 200 , 45 ,120 , 350), "");
    //		if(GUI.Button(new Rect(Screen.width - 190 , 60 ,100, 20), "Jab"))
    //			anim.SetBool ("Jab", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 90 ,100, 20), "Hikick"))
    //			anim.SetBool ("Hikick", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 120 ,100, 20), "Spinkick"))
    //			anim.SetBool ("Spinkick", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 150 ,100, 20), "Rising_P"))
    //			anim.SetBool ("Rising_P", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 180 ,100, 20), "Headspring"))
    //			anim.SetBool ("Headspring", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 210 ,100, 20), "Land"))
    //			anim.SetBool ("Land", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 240 ,100, 20), "ScrewKick"))
    //			anim.SetBool ("ScrewK", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 270 ,100, 20), "DamageDown"))
    //			anim.SetBool ("DamageDown", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 300 ,100, 20), "Run"))
    //			anim.SetBool ("Run", true);
    //		if(GUI.Button(new Rect(Screen.width - 190 , 330 ,100, 20), "Run_end"))
    //			anim.SetBool ("Run", false);

    //;
    //	}
}
