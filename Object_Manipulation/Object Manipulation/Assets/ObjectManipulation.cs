using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ObjectManipulation : MonoBehaviour
{
    public MeshRenderer ShiftingObject;
    public GameObject Cube;
    public GameObject Capsule;
    public GameObject Sphere;
    public GameObject Cylinder;
    public Button Save;
    public Button Load;
    public Slider RotateSpeed;
    public Slider X_Position;
    public Slider Y_Position;
    public Slider X_Scale;
    public Slider Y_Scale;
    public Slider Z_Scale;
    public Slider Red;
    public Slider Green;
    public Slider Blue;
    public Slider Shape;
    public Slider Metallic;
    public Slider Smoothness;
    public int shape;
    public float speed = 30f;
    public float x = -2f;
    public float y = 0f;
    public float z = 0f;
    public float scaleX = 2f;
    public float scaleY = 2f;
    public float scaleZ = 2f;
    public float red = 0f;
    public float blue = 0f;
    public float green = 0f;
    public float metallic = 0f;
    public float smoothness = 0f;
    List<float> save = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        Save.onClick.AddListener(DoSave);
        Load.onClick.AddListener(DoLoad);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * 0.5f * Time.deltaTime, speed * 0.2f * Time.deltaTime, speed * Time.deltaTime);
        transform.position = new Vector3(x, y, z);
        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        Color color = ShiftingObject.material.color;
        color.r = red;
        color.g = green;
        color.b = blue;
        ShiftingObject.material.color = color;
        ShiftingObject.material.SetColor("_EmissionColor", color);
        ShiftingObject.material.SetFloat("_Metallic", metallic);
        ShiftingObject.material.SetFloat("_Glossiness", smoothness);
        switch (shape)
        {
            case 0:
                GetComponent<MeshFilter>().mesh = Cube.GetComponent<MeshFilter>().mesh;
                break;
            case 1:
                GetComponent<MeshFilter>().mesh = Capsule.GetComponent<MeshFilter>().mesh;
                break;
            case 2:
                GetComponent<MeshFilter>().mesh = Sphere.GetComponent<MeshFilter>().mesh;
                break;
            case 3:
                GetComponent<MeshFilter>().mesh = Cylinder.GetComponent<MeshFilter>().mesh;
                break;
        }


    }

    public void AdjustRotation(float newSpeed)
    {
        speed = newSpeed;
    }

    public void AdjustXPosition(float newX)
    {
        x = newX;
    }

    public void AdjustZPosition(float newZ)
    {
        z = newZ;
    }

    public void AdjustScaleX(float newScaleX)
    {
        scaleX = newScaleX;
    }

    public void AdjustScaleY(float newScaleY)
    {
        scaleY = newScaleY;
    }

    public void AdjustScaleZ(float newScaleZ)
    {
        scaleZ = newScaleZ;
    }

    public void AdjustRed(float newRed)
    {
        red = 1 - newRed;
    }

    public void AdjustGreen(float newGreen)
    {
        green = 1 - newGreen;
    }

    public void AdjustBlue(float newBlue)
    {
        blue = 1 - newBlue;
    }

    public void Adjustshape(float newshape)
    {
        shape = (int)newshape;
    }

    public void AdjustMetallic(float newMetallic)
    {
        metallic = newMetallic;
    }

    public void AdjustSmoothness(float newSmoothness)
    {
        smoothness = newSmoothness;
    }

    void DoSave()
    {
        save.Clear();
        save.Add(RotateSpeed.value);
        save.Add(X_Position.value);
        save.Add(Y_Position.value);
        save.Add(X_Scale.value);
        save.Add(Y_Scale.value);
        save.Add(Z_Scale.value);
        save.Add(Red.value);
        save.Add(Green.value);
        save.Add(Blue.value);
        save.Add((float)Shape.value);
        save.Add(Metallic.value);
        save.Add(Smoothness.value);
        Debug.Log("you have saved");
    }

    void DoLoad()
    {
        if (save.Count != 0)
        {
            speed = save[0];
            x = save[1];
            z = save[2];
            scaleX = save[3];
            scaleY = save[4];
            scaleZ = save[5];
            red = 1 - save[6];
            green = 1 - save[7];
            blue = 1 - save[8];
            shape = (int)save[9];
            metallic = save[10];
            smoothness = save[11];
            RotateSpeed.value = save[0];
            X_Position.value = save[1];
            Y_Position.value = save[2];
            X_Scale.value = save[3];
            Y_Scale.value = save[4];
            Z_Scale.value = save[5];
            Red.value = save[6];
            Green.value = save[7];
            Blue.value = save[8];
            Shape.value = save[9];
            Metallic.value = save[10];
            Smoothness.value = save[11];
        }
        Debug.Log("you have loaded");
    }
}
