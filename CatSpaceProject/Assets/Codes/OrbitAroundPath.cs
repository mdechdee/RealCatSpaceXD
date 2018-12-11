using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAroundPath : MonoBehaviour {

    // Use this for initialization
    //Vector3[] path;
    //private int startIndex;
    GameObject sun;
    public float orbitSpeed = 1;
    private Quaternion iniRot;
	void Start () {
        //float minDist = float.MaxValue;
        //GameObject thePath = gameObject.transform.parent.Find("Path").gameObject;
        //path = thePath.GetComponent<MeshFilter>().mesh.vertices;
        //print(path.Length);
        //for (int i = 0; i < path.Length; i++)
        //{
        //    float dist = Vector3.Distance(path[i], transform.position);
        //    if (dist < minDist)
        //    {
        //        startIndex = i;
        //        minDist = dist;
        //    }
        //}
        //StartCoroutine(MoveOverSeconds(gameObject, path[(startIndex + 1) % path.Length], 1f, (startIndex+1) % path.Length));
        sun = GameObject.Find("Sun");
        iniRot = transform.rotation;
    }

    private void Update()
    {
        transform.RotateAround(sun.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.rotation = iniRot;
    }

    //public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds, int index)
    //{
    //    float elapsedTime = 0;
    //    Vector3 startingPos = objectToMove.transform.position;
    //    while (elapsedTime < seconds)
    //    {
    //        objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
    //        elapsedTime += Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }
    //    objectToMove.transform.position = end;
    //    MoveOverSeconds(gameObject, path[(index + 1) % path.Length], 1f, (index+1)%path.Length);

    //}
}
