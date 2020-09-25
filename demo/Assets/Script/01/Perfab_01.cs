using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Perfab_01 : MonoBehaviour, IPointerDownHandler
{
    bool bDown = false;
    Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
    //float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //参数一：是预设 参数二：实例化预设的坐标  参数三：实例化预设的旋转角度
       //Instantiate(this);
        //这里 transform.position，transform.rotation分别代表的是相机和坐标和 旋转角度
    }

    // Update is called once per frame
    void Update()
    {
        if(bDown)
        {
            // tSpeed += speed * Time.deltaTime;
            //第一种方式：将Quaternion实例对象赋值给transform的rotation
            // rotations.eulerAngles = new Vector3(0.0f, tSpeed, 0.0f);
            //A.rotation = rotations;
            //第二种方式：将三位向量代表的欧拉角直接赋值给transform的eulerAngle
            //B.eulerAngles = new Vector3(0.0f, tSpeed, 0.0f);

            //第一种
            // transform.Rotate(new Vector3(90, 0, 0));
            // transform.Rotate(0,25*Time.deltaTime ,0,Space.Self );
            //第二种
            // transform.Rotate(Vector3.up ,90);
            //第三种 四元数
            //transform.rotation = Quaternion.Euler(45, 45, 45);
            //第四种 慢慢旋转
            //Quaternion targetRotation =   Quaternion.Euler(45, 45, 45);
            //transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,Time.deltaTime *3);
            //第五种绕某点旋转
            //transform.RotateAround(new Vector3(5, 5, 1), Vector3.up, 20*Time.deltaTime);
            //第六种欧拉角
            //transform.eulerAngles = new Vector3(90, 0, 0);
            //transform.localEulerAngles  = new Vector3(90, 0, 0);

            //慢慢旋转到指定角度
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * 3);
            //float temp = this.transform.localEulerAngles.y;
            //temp += speed;
            //this.transform.eulerAngles = new Vector3(0, temp, 0);
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        string strName = this.GetComponent<Component>().name;
        int index = strName.IndexOf('_');
        string strMaterial = "Material_And_Shader/01/Material_" + strName.Substring(index + 1, 2);
        this.GetComponent<Image>().material = Resources.Load<Material>(strMaterial);

        bDown = true;

        //this.transform.eulerAngles = new Vector3(this.transform.rotation.x, 0, this.transform.rotation.z);
       // this.transform.rotation = targetRotation;
    }
}
