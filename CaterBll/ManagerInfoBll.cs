using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public  partial class ManagerInfoBll
    {
        ManagerInfoDal managerInfoDal=new ManagerInfoDal();

        public List<ManagerInfo> GetList()
        {
            return managerInfoDal.GetList();
        }

        public bool Add(ManagerInfo managerInfo)
        {
            return managerInfoDal.Insert(managerInfo)>0;
        }

        public bool Edit(ManagerInfo managerInfo)
        {
            return managerInfoDal.Update(managerInfo)> 0;
        }

        public bool Delete(int id)
        {
            return managerInfoDal.Delete(id) > 0;
        }

        public LoginState State(string name,string pwd,out int type)
        {
            ManagerInfo mi= managerInfoDal.GetByName(name);
            type = -1;
            if (mi==null)
            {
                return LoginState.NameError;
            }
            //if (mi.MPwd==null)
            //{
            //    return LoginState.PwdError;
            //}
            else
            {
                if (mi.MPwd.Equals(MD5Helper.EncrytString(pwd)))
                {
                    type = mi.MType;
                    return LoginState.OK;
                }
                else
                {
                    return LoginState.PwdError;
                }
            }
 
        }
    }
}
