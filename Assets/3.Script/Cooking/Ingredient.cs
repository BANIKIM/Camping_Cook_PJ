using UnityEngine;

public interface IState
{
    void OnEnter();
    void OnUpdate();
    void OnExit();
}

public enum Ingredient_Type
{
    // 식재료 타입
    Beef = 1,
    Marshmallow,
    Salmon,
    Potato,
    Carrot,
    Onion,
    Asparagus,
    Mushroom,
}

[RequireComponent(typeof(Cooked_Ingredient))]
[RequireComponent(typeof(Seasoning_Ingredient))]
[RequireComponent(typeof(Skewer_Ingredient))]

public class Ingredient : MonoBehaviour
{
    public Ingredient_Type _ingredient_Type;
    public Cooked_Ingredient _cookedIngred;
    public Seasoning_Ingredient _seasoningIngred;
    public Skewer_Ingredient _skewerIngred;

    public int _sliceCount = 0;

    public Material _crossMat;
    public Material[] _materials;
    public MeshRenderer _mesh;

    private void Start()
    {
        TryGetComponent(out _seasoningIngred);
        TryGetComponent(out _cookedIngred);
        TryGetComponent(out _skewerIngred);
        _mesh = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        _cookedIngred.OnUpdate();
        _skewerIngred.OnUpdate();

    }

    public void Cook_ch_mat()// 쿡스테이터스에 따라 머테리얼 값을 변경한다
    {
        _mesh.material = _materials[(int)_cookedIngred._cooked_State];
    }

    public int CheckCookIdx()
    {
        // 굽기 단계 확인
        var ingred_type = ((int)_ingredient_Type * 10) + ((int)_cookedIngred._cooked_State);
        return ingred_type;
    }

    public int CheckPrepIdx()
    {
        // 손질 단계 확인
        var temp = _sliceCount.Equals(0) ? 0 : 1;
        var ingred_type = ((int)_ingredient_Type * 10000) + (temp * 1000) +
            ((int)_seasoningIngred.salt_s * 100) + ((int)_seasoningIngred.pepper_s * 10) +
            ((int)_skewerIngred.skewer_state);
        return ingred_type;
    }

}
