using UnityEngine;

namespace TestAssignment
{
    public sealed class ProductObjectBuilder
    {
        public GameObject CreateProduct(Transform parentTransform)
        {
            var product = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var productView = product.AddComponent<ProductView>();
            productView.ProductMaterial = product.GetComponent<MeshRenderer>().material;
            productView.ProductType = ProductType.Red;
            productView.ProductMaterial.color = Color.red;
            product.transform.SetParent(parentTransform);
            return product;
        }
    }
}