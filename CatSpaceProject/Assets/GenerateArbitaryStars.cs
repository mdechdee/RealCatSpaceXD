using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArbitaryStars : MonoBehaviour {

    public int numStarsToGen = 16000;
	void Start () {
        GameObject s_star = gameObject.transform.Find("S_star").gameObject;
        GameObject m_star = gameObject.transform.Find("M_star").gameObject;
        GameObject l_star = gameObject.transform.Find("L_star").gameObject;
        for (int i = 1; i<=numStarsToGen; i++)
        {
            int sizeToCreate = (int)Random.Range(1,3);
            //GameObject newStar;
            Vector3 pos = new Vector3(Random.Range(-5000f, 5000f), Random.Range(-10f, 10f), Random.Range(-5000f, 5000f));
            if (sizeToCreate == 1)
                GameObject.Instantiate(s_star, pos, Quaternion.identity);
            else if (sizeToCreate == 2)
                GameObject.Instantiate(m_star, pos, Quaternion.identity);
            else
                GameObject.Instantiate(l_star, pos, Quaternion.identity);
            //newStar.transform.SetParent(GameObject.Find("ArbitaryStars").transform);
        }
	}
	
}
