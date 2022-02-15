using UnityEngine;

namespace TestAssignment
{
    public sealed class ProductView: MonoBehaviour
    {
        private ProductType _productType;
        private Material _productMaterial; 
        
        internal Material ProductMaterial
        {
            get => _productMaterial;
            set => _productMaterial = value; 
        }

        public ProductType ProductType
        {
            get => _productType;
            set => _productType = value;
        }
    }
}