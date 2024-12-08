using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;
using Model.Entitys;
using Model.RequestModel.ImaganerService;

namespace Service.IService
{
    public interface IMaganerService
    {
        Task<Notification> AddEating(addEating newEating);


        Task< List<Eating>> GetListEating();

      Notification AddMenu(newMenuDay newMenu);
    }
}
