using UnityEngine;
using TMPro;

namespace Sample
{
    public class MatrixTest : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI matrixText;

        private Matrix4x4 matrix;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            matrix = this.transform.localToWorldMatrix;

            matrixText.text = $"{matrix.m00:0.##}, {matrix.m01:0.##}, {matrix.m02:0.##}, {matrix.m03:0.##}\n";
            matrixText.text += $"{matrix.m10:0.##}, {matrix.m11:0.##}, {matrix.m12:0.##}, {matrix.m13:0.##}\n";
            matrixText.text += $"{matrix.m20:0.##}, {matrix.m21:0.##}, {matrix.m22:0.##}, {matrix.m23:0.##}\n";
            matrixText.text += $"{matrix.m30:0.##}, {matrix.m31:0.##}, {matrix.m32:0.##}, {matrix.m33:0.##}";
        }
        #endregion
    }
}
