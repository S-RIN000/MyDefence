using UnityEngine;

namespace MyDefence
{
    public class WayPoints : MonoBehaviour
    {
        /// <summary>
        /// WayPoint(적이 지나가는 길의 분기점)들을 관리하는 클래스
        /// </summary>

        #region Variable
        //WayPoint(적이 지나가는 길의 분기점)들의 오브젝트를 저장하는 배열
        public static Transform[] points;      //enermy에서 접근해야 하기때문에 접근제한자가 public 
        #endregion

        #region Unity Event Method
        private void Start ()
        {
            //필드 초기화
            //WayPoint 배열 요소수 생성 [이 트랜스폼이 가지고 있는 자식의 갯수만큼]
            points = new Transform[this.transform.childCount];
            //Debug.Log($"WayPoint의 갯수: {this.transform.childCount}개");
            for (int i = 0; i < points.Length; i++)
            {
                //WayPoint의 transform을 순서대로 가져와서 배열에 저장하기
                points[i] = this.transform.GetChild(i);
            }
        }
        #endregion

  
    }
}
