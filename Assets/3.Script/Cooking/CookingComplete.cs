using UnityEngine;

public class CookingComplete : MonoBehaviour
{
    public LiquidBoil liquidBoil;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dish") && GameManager.instance.isCookingStart)
        {
            Dish _dish = other.gameObject.GetComponent<Dish>();

            TabletManager.instance._tablet_Star.StarUpdate(_dish.ch_Reward());
            GameManager.instance.StopCooking();

            _dish.onech = false;
            GameManager.instance.CampingExpCheck(50);
            liquidBoil.LiquidReset();  //�����׸��� �ʱ�ȭ
            liquidBoil.CookReset();    //�ʱ�ȭ
        }
    }
}
