using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;
using StockTracking.DAL;

namespace StockTracking.BLL
{
    class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        CategoryDAO categorydao = new CategoryDAO();
        ProductDAO dao = new ProductDAO();
        SalesDAO salesdao = new SalesDAO();
        public bool Delete(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            dao.Delete(product);
            SALE sales = new SALE();
            sales.ProductID = entity.ProductID;
            salesdao.Delete(sales);
            return true;
        }

        public bool GetBack(ProductDetailDTO entity)
        {
            return dao.GetBack(entity.ProductID);
        }

        public bool Insert(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ProductName = entity.ProductName;
            product.CategoryID = entity.CategoryID;
            product.Price = entity.Price;
            return dao.Insert(product);
        }

        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.Categories = categorydao.Select();
            dto.Products = dao.Select();
            return dto;

        }

        public bool Update(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.Price = entity.Price;
            product.ProductName = entity.ProductName;
            product.StockAmount = entity.StockAmount;
            product.CategoryID = entity.CategoryID;
            return dao.Update(product);
        }
    }
}
