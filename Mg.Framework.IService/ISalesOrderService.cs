using App.ViewModel;
using RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Mg.Framework.IService
{
    public interface ISalesOrderService: IBaseBill<VD_SalesOrder,VD_SalesOrderDetail>
    {
      //  IList<VD_SalesOrder> GetPageList(int pageIndex, int pageSize, out int total);
    }

    public interface ICustomerService: IBill<VD_Customer>
    {

    }

    public interface IPackingService : IBill<VD_Packing>
    {

    }
    public interface ISurfaceService : IBill<VD_Surface>
    {

    }

    public interface ISectionBarService : IBill<VD_SectionBar>
    {
        List<VD_SectionBar> GetHeatInsulationList(Guid? parentId);
    }


}
