using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMeshSbi : MonoBehaviour
{
    public static DrawMeshSbi instance;
    public Image brushPrefab;
    public GameObject meshPrefab, meshParent,player, uc;
    private float screenWidth,sideSpace;
    private float meshSideDistanceX;
    private Vector3 tempSingleMeshPosition;
    public List<Material> materials = new();
    private List<GameObject> singleMeshes = new();
    public bool isDrawable = false;
    public bool drawableRelase = false;


	private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(instance);
	}


	void Start()
    {
        screenWidth = Screen.width;
        sideSpace = (screenWidth - 800) / 2;
        meshSideDistanceX = sideSpace - 25;
    }


    void Update()
    {
        Vector3 position = Input.mousePosition;
        if (isDrawable && Input.GetMouseButton(0) && position.x > sideSpace + 25 && position.x < screenWidth-sideSpace-25 && position.y < 485 && position.y > 35)
        {
            Image newBrush = Instantiate(brushPrefab, transform);
            newBrush.transform.position = new(position.x, position.y, 0);
            CreateSingleMesh(position);
        }

        if(Input.GetMouseButtonUp(0) && isDrawable && singleMeshes.Count >5)
		{
            DeactivateDrawing();
            GameController.instance.isContinue = true;
            AlignMesh();
		}

        if(drawableRelase)
		{
            if(Input.GetMouseButtonUp(0))
			{
                drawableRelase = false;
                isDrawable = true;
			}
		}
    }

    void CreateSingleMesh(Vector3 position)
    {
        if(Vector3.Distance(position, tempSingleMeshPosition) > 1f)
		{
            tempSingleMeshPosition = position;
            float x = -1.92f + ((position.x - meshSideDistanceX) / 750) * 3.4f;
            float z = -1.05f + ((position.y - 35) / 450) * 2.125f;
            GameObject singleMesh = Instantiate(meshPrefab, meshParent.transform);
            singleMesh.transform.position = new(x, .9f, z);         
            //singleMesh.GetComponent<Renderer>().material = materials[Random.Range(0,10)];
            singleMeshes.Add(singleMesh);
        }     
    }

    public void DeactivateDrawing()
	{
        isDrawable = false;
        GetComponent<Image>().enabled = false;
        DeleteAllSprite();
    }

    public void ActivateDrawing()
	{
        drawableRelase = true;
        GetComponent<Image>().enabled = true;
    }

    public void BreakMesh(Vector3 position)
	{

        if(position.x > player.transform.position.x)  // sa�dan �arpm�� demektir..
		{
            foreach (GameObject singleMesh in singleMeshes)
            {
                if (singleMesh.transform.position.x+.2f > position.x)
				{
                    singleMesh.GetComponent<Collider>().enabled = false;
                    singleMesh.transform.parent = null;              
                }
            }
        }
        if (position.x < player.transform.position.x)  // soldan �arpm�� demektir..
        {
            foreach (GameObject singleMesh in singleMeshes)
            {
                if (singleMesh.transform.position.x - .2f < position.x)
                {
                    singleMesh.GetComponent<Collider>().enabled = false;
                    singleMesh.transform.parent = null;
                }
            }
        }
    }

    private void AlignMesh()
	{
        float minZ = 0;
        foreach(GameObject singleMesh in singleMeshes)
		{
            if(singleMesh.transform.localPosition.z < minZ)
			{
                minZ = singleMesh.transform.localPosition.z;
			}
		}

        float distance = uc.transform.localPosition.z - minZ;
        //meshParent.transform.position = new(meshParent.transform.position.x,meshParent.transform.position.y,meshParent.transform.position.z + distance);
        foreach (GameObject singleMesh in singleMeshes)
        {
            singleMesh.transform.localPosition = new(singleMesh.transform.localPosition.x,singleMesh.transform.localPosition.y,singleMesh.transform.localPosition.z + distance);
        }

	}

    public void DeleteAllSprite()
	{
        foreach(Transform child in transform)
		{
            Destroy(child.gameObject);
		}
    }

    public void DeleteAllMesh()
	{
        foreach (Transform child in meshParent.transform)
        {
            if(!child.CompareTag("uc") && !child.CompareTag("sap"))
            Destroy(child.gameObject);
        }
        singleMeshes.Clear();
    }

    public void StartingEvents()
    {
        Debug.Log("�al��t�");
        meshParent.transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        meshParent.transform.parent.transform.position = Vector3.zero;
        GameController.instance.isContinue = false;
        GameController.instance.score = 0;
        meshParent.transform.position = new Vector3(0, 1.1f, 1);
        DeleteAllMeshForStarting();
        DeleteAllSprite();
        UcKontrol.instance.isEnable = true;
    }

    public void DeleteAllMeshForStarting()
    {
        GameObject[] meshes = GameObject.FindGameObjectsWithTag("singleMesh");
		for (int i = 0; i < meshes.Length; i++)
		{
            Destroy(meshes[i].gameObject);
		}
        singleMeshes.Clear();
    }

}
