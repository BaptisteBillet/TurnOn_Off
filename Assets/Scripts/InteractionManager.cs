using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionManager : MonoBehaviour {

	float countCPress = 0;
	float countUDPress = 0;
	float countUDArrowPress = 0;
	float countFPress = 0;
	float numSpacePresses = 10;
	float numUDPresses = 10;
	float numUDArrowPresses = 40;
	float speedDecrease = 0.5f;
	float speedDecreaseArrow = 0.9f;

	int numStickNipples=60;
	float countStickNipples=0;

	int swapUpDown = -1;
	int swapUpDownArrow = 1;

	public Image bar;
	private float swapTime = 0;
	private float FTime = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - swapTime > 1)
		{


			if (CheckForGamepad() || Input.GetKeyDown(KeyCode.C))
			{
				countCPress++;
			}



			//UD PENIS
			if (swapUpDown > 0 && (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.L)))
			{
				swapUpDown *= -1;
				countUDPress++;
			}
			if (swapUpDown < 0 && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.R)))
			{
				swapUpDown *= -1;
				countUDPress++;
			}




			//NIPPLE KEYBOARD
			if (swapUpDownArrow > 0 && Input.GetKeyDown(KeyCode.RightArrow))
			{
				swapUpDownArrow *= -1;
				countUDArrowPress++;
			}

			if (swapUpDownArrow < 0 && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				swapUpDownArrow *= -1;
				countUDArrowPress++;
			}




			if (swapUpDownArrow > 0 && Input.GetKeyDown(KeyCode.UpArrow))
			{
				swapUpDownArrow *= -1;
				countUDArrowPress++;
			}
			if (swapUpDownArrow < 0 && Input.GetKeyDown(KeyCode.DownArrow))
			{
				swapUpDownArrow *= -1;
				countUDArrowPress++;
			}

			
			//FISTER
			if (Input.GetKey(KeyCode.F))
			{
				countFPress += Time.deltaTime * 2;
			}

			//NIPPLE GAMEPAD
			if (swapUpDown > 0 && Input.GetAxis("L_YAxis_1") < -0.6f)
			{
				swapUpDown *= -1;
				countStickNipples++;
			}
			if (swapUpDown < 0 && Input.GetAxis("L_YAxis_1") > 0.6f)
			{
				swapUpDown *= -1;
				countStickNipples++;
			}
		}
		///

		float progress = countCPress / numSpacePresses;

		if(countUDPress > 0){
			progress = countUDPress / numUDPresses;
		}
		else if(countUDArrowPress > 0){
			progress = countUDArrowPress / numUDArrowPresses;
		} else if(countStickNipples>0)
		{
			progress = countStickNipples / (float)numStickNipples;
		}else if(countFPress>0)
		{
			progress = countFPress / (float)FTime;
		}

		
		if(progress >= 1){
			GameManager.current.SwapVideo();
			GameManager.current.ChangeStarted();
			countUDPress = 0;
			countFPress = 0;
			countUDArrowPress = 0;
			countCPress = 0;
			countStickNipples = 0;
			swapTime = Time.time;
		}
		
		if( countCPress > 0 )
			countCPress -= Time.deltaTime * speedDecrease;
		if( countUDPress > 0 )
			countUDPress -= Time.deltaTime * speedDecrease;
		if( countUDArrowPress > 0 )
			countUDArrowPress -= Time.deltaTime * speedDecreaseArrow;
		if(countStickNipples>0)
		{
			countStickNipples-=Time.deltaTime*speedDecrease;
		}
		if(countFPress>0)
		{
			countFPress-=Time.deltaTime;
		}


		bar.rectTransform.sizeDelta = new Vector2(progress  * Screen.width, 10);


	}
	bool CheckForGamepad()
	{
		if 
			(
				(Input.GetButtonDown("A_1"))||
				(Input.GetButtonDown("B_1"))||
				(Input.GetButtonDown("X_1"))||
				(Input.GetButtonDown("Y_1"))
				)
		{
			return true;
		}
		return false;
	}
}
