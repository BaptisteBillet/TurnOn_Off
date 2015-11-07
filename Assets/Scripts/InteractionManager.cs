using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractionManager : MonoBehaviour {

	float countSpacePress = 0;
	float countUDPress = 0;
	float countUDArrowPress = 0;
	float numSpacePresses = 10;
	float numUDPresses = 10;
	float numUDArrowPresses = 40;
	float speedDecrease = 0.5f;
	float speedDecreaseArrow = 0.9f;

	int swapUpDown = -1;
	int swapUpDownArrow = 1;

	public Image bar;
	private float swapTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - swapTime > 1) {


			if (CheckForGamepad() || Input.GetKeyDown(KeyCode.Space))
			{
				countSpacePress++;

			}
			if(swapUpDown > 0 && Input.GetKeyDown(KeyCode.U)) {
				swapUpDown *= -1;
				countUDPress++;
			}
			if(swapUpDown < 0 && Input.GetKeyDown(KeyCode.D)) {
				swapUpDown *= -1;
				countUDPress++;
			}

			
			if(swapUpDownArrow > 0 && Input.GetKeyDown(KeyCode.UpArrow)) {
				swapUpDownArrow *= -1;
				countUDArrowPress++;
			}
			if(swapUpDownArrow < 0 && Input.GetKeyDown(KeyCode.DownArrow)) {
				swapUpDownArrow *= -1;
				countUDArrowPress++;
			}
		}


		float progress = countSpacePress / numSpacePresses;

		if(countUDPress > 0){
			progress = countUDPress / numUDPresses;
		}
		else if(countUDArrowPress > 0){
			progress = countUDArrowPress / numUDArrowPresses;
		}

		
		if(progress >= 1){
			GameManager.current.SwapVideo();
			GameManager.current.ChangeStarted();
			countUDPress = 0;
			countUDArrowPress = 0;
			countSpacePress = 0;
			swapTime = Time.time;
		}
		
		if( countSpacePress > 0 )
			countSpacePress -= Time.deltaTime * speedDecrease;
		if( countUDPress > 0 )
			countUDPress -= Time.deltaTime * speedDecrease;
		if( countUDArrowPress > 0 )
			countUDArrowPress -= Time.deltaTime * speedDecreaseArrow;

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
