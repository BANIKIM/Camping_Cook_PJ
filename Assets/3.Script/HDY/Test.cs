using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
     ��� - �Ұ��, ����, �ƽ��Ķ�Ž�, ����, ���, ����, ����, ���ø�ο�
     ��� - �ұ�, ����
     
     ������ - ���ø�ο�, �����, �Ұ�⽺����ũ, ������Ʃ, ��ġ�÷���
     
     ���ø�ο�
     ����� - ���ø�ο�
     ���� - �ȱ�
     ���� - ���� 1
     �÷� - 1ȸ�� ���ÿ� ���ø�ο�

     �����
     ����� - ����, �ƽ��Ķ�Ž�
     ���� - ����(�ڸ��� 2), ����(���-�ұ�), ����(���-����), �ƽ��Ķ�Ž�(�ڸ��� 1)
     ���� - ����(���� 2)
     �÷� - ���ÿ� ����, �ƽ��Ķ�Ž�

     �Ұ�� ������ũ
     ����� - �Ұ��, ����
     ���� - �Ұ��(���-�ұ�), �Ұ��(���-����), ����(�ڸ��� 2)
     ���� - �Ұ��(���� 2)
     �÷� - ���ÿ� �Ұ��, ����

     ��ġ �÷���
     ����� - �Ұ��, ����, ����
     ���� - �Ұ��(���-�ұ�), �Ұ��(�ڸ��� 2) ����(�ڸ��� 2), ����(�ڸ��� 2), �ȱ�
     ���� - ���� 2
     �÷� - ���ÿ� ��ġ

     ������Ʃ
     ����� - �Ұ�� ���� ���
     ���� - �Ұ��(�ڸ��� 2), ���(�ڸ��� 2), ����(�ڸ��� 2)
     ���� - ���̱�
     �÷� - ���ÿ� ������Ʃ
     
     */
    /*
    ��� ȣ�� �� ���� ����� �������� ���ÿ� ��� ��Ḧ ���ϸ� �÷����� ���
    - ��� ȥ�� ������
    */
    public enum Ingredient
    {
        marshmallow = 0,
        beef, 
        salmon,
        asparagus,
        potato,
        carrot,
        onion,
        mushroom
    }

    public enum Cooking
    {
        cut_0 = 0, cut_1, cut_2, cut_3, 
        seasoning_s = 10, seasoning_p = 11,
        stick = 20,
        toast_1 = 30, toast_2, toast_3,
        toast_all = 40,
        boil_0 = 50, boil_1, boil_2
    }

    #region ����
    //private Ingredient[] Grilled_Salmon = { Ingredient.salmon, Ingredient.asparagus };
    //private Cooking[] how_cook = {Cooking.cut_1, Cooking.cut_3, 
    //                              Cooking.seasoning_s, Cooking.seasoning_p,
    //                              Cooking.toast_1};

    //private void Update()
    //{
    //    Check();
    //}

    //private void Check()
    //{

    //}
    #endregion

    private void Update()
    {

    }

    //����� ������
    private void Recipe_step()
    {
        int numRows = Ingredient.GetValues(typeof(Ingredient)).Length;
        int numCols = Cooking.GetValues(typeof(Cooking)).Length;

        int[,] GrilledSalmon = new int[numRows, numCols];

        GrilledSalmon[(int)Ingredient.asparagus, (int)Cooking.cut_1] = 1;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.cut_3] = 2;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.seasoning_s] = 3;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.seasoning_p] = 4;
        GrilledSalmon[(int)Ingredient.salmon, (int)Cooking.toast_2] = 5;
        
    }

    private void Check_call()
    {
        //�����뿡 �����Ǵ�� ��� ȣ��
        //��) ����� - ����, �ƽ��Ķ�Ž�
        

    }

    private void Check_plate() //���� ���� ��� ����
    {
        //���� ���� ���� ��ᰡ call list�� ���� ���ٸ� ���� ����

    }

}
