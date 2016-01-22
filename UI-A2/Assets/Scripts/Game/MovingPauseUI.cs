using UnityEngine;
using System.Collections;

public class MovingPauseUI : MonoBehaviour {

	public GameObject DestinationPoint;
	Vector3 InitialPos, FinalPos;
	float LastXDiff;
	bool setLeastXDiff;
	bool transit;
	bool animate;
	// Use this for initialization
	void Start () {
		InitialPos = gameObject.transform.position;
		FinalPos = DestinationPoint.transform.position;
		LastXDiff = 0;
		setLeastXDiff = true;
		transit = false;
		animate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (animate) {
			if (transit) {
				if (gameObject.transform.position.x != FinalPos.x) {
					Vector3 Direction = (FinalPos - InitialPos).normalized;
					Direction.y = 0;
					gameObject.transform.position += Direction * 350 * Time.deltaTime;
					float Xdiff = gameObject.transform.position.x - FinalPos.x;
					if(setLeastXDiff){
						LastXDiff = Xdiff;
						setLeastXDiff = false;
					}
					if (((Xdiff * Xdiff) < 20) || (Xdiff * Xdiff) > (LastXDiff * LastXDiff)) {
						Vector3 ClampPoint = new Vector3 (FinalPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
						gameObject.transform.position = ClampPoint;
						animate = false;
					}
				}
			} else {
				if (gameObject.transform.position.x != InitialPos.x) {
					Vector3 Direction = (InitialPos - FinalPos).normalized;
					Direction.y = 0;
					gameObject.transform.position += Direction * 1000 * Time.deltaTime;
					float Xdiff = gameObject.transform.position.x - InitialPos.x;
					if(setLeastXDiff){
						LastXDiff = Xdiff;
						setLeastXDiff = false;
					}
					if (((Xdiff * Xdiff) < 20) || (Xdiff * Xdiff) > (LastXDiff * LastXDiff)) {
						Vector3 ClampPoint = new Vector3 (InitialPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
						gameObject.transform.position = ClampPoint;
						animate = false;
					}
				}
			}
		}
	}

	public void Move(bool transitDir){
		transit = transitDir;
		animate = true;
		setLeastXDiff = true;
	}

	public void SnapBack(){
		Vector3 ClampPoint = new Vector3 (InitialPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.position = ClampPoint;
	}

	public void SnapFoward(){
		Vector3 ClampPoint = new Vector3 (FinalPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.position = ClampPoint;
	}
}
