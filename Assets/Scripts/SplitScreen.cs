using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour{
	public Camera Camera1;
	public Camera Camera2;
	public float transitionTime = 1.0f;

	private float timer = 0.0f;
	private bool isSplit = false;
	private bool splitting = false;

    void Update()
    {
    	if (splitting == false){
	        if (Input.GetKeyDown("left shift"))
	        {
	        	splitting = true;
	        	Camera2.enabled = true;
	        }
    	}

        if (splitting == true)
        {
        	if (timer <= transitionTime)
        	{
        		if (isSplit) MergeScreen(timer);
        		else SplitScreenOnTwo(timer);
        	} 
        	else 
        	{
        		if (isSplit)
        		{
        			MergeScreen(transitionTime);
        			Camera2.enabled = false;
        		} else {
        			SplitScreenOnTwo(transitionTime);
        		}
        		isSplit = !isSplit;
        		splitting = false;
        		timer = 0.0f;
        	}
        	timer += Time.deltaTime;
        }
    }

    private void SplitScreenOnTwo(float timer)
    {
    	float screenChange = (timer / transitionTime) * 0.5f;
    	Camera1.rect = new Rect(0, 0, 1 - screenChange - 0.005f, 1);
    	Camera2.rect = new Rect(1 - screenChange, 0, screenChange, 1);
    }

    private void MergeScreen(float timer)
    {
    	float screenChange = (timer / transitionTime) * 0.5f;
    	Camera1.rect = new Rect(0, 0, 0.5f + screenChange, 1);
    	Camera2.rect = new Rect(0.5f + screenChange, 0, 0.5f - screenChange, 1);
    }
}