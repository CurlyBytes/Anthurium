using Domain.WarehouseBoundedContext;
using Domain.WarehouseBoundedContext.ValueObjects;
using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Warehouse
{
    public class BussinessWareHouse : DomainEntity_T<BussinessWareHouse>, IHaveAggregateRoot
    {
        public string WareHouseName { get; private set; }

        public CodeName CodeName { get; private set; }

        public BussinessWareHouse(
            string wareHouseName
            ,CodeName codeName)
        {
            WareHouseName = wareHouseName;
            CodeName = codeName;
        }
    }
}
