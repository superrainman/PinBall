using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;
	private float defaultAngle = 20;
	private float flickAngle = -20;

	// Use this for initialization
	void Start () 
	{
		this.myHingeJoint = GetComponent<HingeJoint>();

		SetAngle(this.defaultAngle);
        
	}
	
	// Update is called once per frame
	void Update () 
	{
		//キーが押された時
		if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle (this.flickAngle);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle (this.flickAngle);
		}

		//キーが離れた時
		if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
		{
			SetAngle (this.defaultAngle);
		}

		if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
		{
			SetAngle (this.defaultAngle);
		}

		//発展課題　スマホ対応

		if (Input.touchCount > 0)
		{
			for (int i = 0; i<Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);

				if (touch.phase == TouchPhase.Began)
				{

					if (Input.touches[i].position.x >= Screen.width / 2 && tag == "RightFripperTag")
					{
						SetAngle (this.flickAngle);
					}
					if (Input.touches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag")
					{
						SetAngle (this.flickAngle);
					}
				}
			

				if (touch.phase == TouchPhase.Ended)
				{
					if (Input.touches[i].position.x >= Screen.width / 2 && tag == "RightFripperTag")
					{
						SetAngle (this.defaultAngle);
					}

					if (Input.touches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag")
					{
						SetAngle (this.defaultAngle);
					}


				}
			}

		}
		
	}

	void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;

	}
}
