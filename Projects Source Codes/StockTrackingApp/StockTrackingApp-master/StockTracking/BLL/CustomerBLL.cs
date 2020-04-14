using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DTO;
using StockTracking.DAL.DAO;
using StockTracking.DAL;

namespace StockTracking.BLL
{
	class CustomerBLL : IBLL<CustomerDetailDTO, CustomerDTO>
	{
		CustomerDAO dao = new CustomerDAO();
		SalesDAO salesdao = new SalesDAO();
		public bool Delete(CustomerDetailDTO entity)
		{
			CUSTOMER customer = new CUSTOMER();
			customer.ID = entity.ID;
			dao.Delete(customer);
			SALE sales = new SALE();
			sales.CustomerID = entity.ID;
			salesdao.Delete(sales);
			return true;
		}

		public bool GetBack(CustomerDetailDTO entity)
		{
			return dao.GetBack(entity.ID);
		}

		public bool Insert(CustomerDetailDTO entity)
		{
			CUSTOMER customer = new CUSTOMER();
			customer.CustomerName = entity.CustomerName;
			return dao.Insert(customer);

		}

		public CustomerDTO Select()
		{
			CustomerDTO dto = new CustomerDTO();
			dto.Customers = dao.Select();
			return dto;
		}

		public bool Update(CustomerDetailDTO entity)
		{
			CUSTOMER customer = new CUSTOMER();
			customer.ID = entity.ID;
			customer.CustomerName = entity.CustomerName;
			return dao.Update(customer);
		}
	}
}
