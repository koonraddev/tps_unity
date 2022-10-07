using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingTriggerLeftScript : MonoBehaviour
{
    public List<GameObject> leftPrefabsList;

    private int newPrefabNumber;
    private int lastPrefabNumber;
    private void OnTriggerExit(Collider exitInfo)
    {
        Ground_Script ground = exitInfo.GetComponent<Ground_Script>();
        if (ground != null)
        {
            try
            {
                string prefabName = exitInfo.gameObject.name;
                if (prefabName.Substring(prefabName.Length - 7, 7) == "(Clone)")
                {
                    lastPrefabNumber = System.Int32.Parse(prefabName.Substring(prefabName.Length - 8, 1));
                }
                else
                {
                    lastPrefabNumber = System.Int32.Parse(prefabName.Substring(prefabName.Length - 1, 1));
                }

                newPrefabNumber = randomIntExcept(lastPrefabNumber);
            }
            catch (System.FormatException)
            {
                lastPrefabNumber = 0;
                newPrefabNumber = 0;
            }
            finally
            {
                RenderGround(newPrefabNumber);
            }

        }

    }

    public int randomIntExcept(int except)
    {
        int result = Random.Range(0, leftPrefabsList.Count - 1);
        if (result >= except) result += 1;
        return result;
    }
    private void RenderGround(int prefabNumber)
    {
        Vector3 pos1 = gameObject.transform.position + (new Vector3(0f, 0.5f, leftPrefabsList[prefabNumber].transform.localScale.z - gameObject.transform.localScale.z - 1f));
        Instantiate(leftPrefabsList[prefabNumber], pos1, Quaternion.identity);
    }
}
