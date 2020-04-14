using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL;
using StockTracking.DAL.DAO;

namespace StockTracking.BLL
{
    public class CategoryBLL : IBLL<CategoryDetailDTO, CategoryDTO>
    {
        CategoryDAO dao = new CategoryDAO();
        ProductDAO productdao = new ProductDAO();
        public bool Delete(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY();
            category.ID = entity.ID;
            dao.Delete(category);
            PRODUCT product = new PRODUCT();
            product.CategoryID = entity.ID;
            productdao.Delete(product);
            return true;
        }

        public bool GetBack(CategoryDetailDTO entity)
        {
            return dao.GetBack(entity.ID);
        }

        public bool Insert(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY();
            category.CategoryName = entity.CategoryName;
            return dao.Insert(category);
        }

        public CategoryDTO Select()
        {
            CategoryDTO dto = new CategoryDTO();
            dto.Categories = dao.Select();
            return dto;
        }

        public bool Update(CategoryDetailDTO entity)
        {
            CATEGORY category = new CATEGORY();
            category.CategoryName = entity.CategoryName;
            category.ID = entity.ID;
            return dao.Update(category);
        }
    }
}
