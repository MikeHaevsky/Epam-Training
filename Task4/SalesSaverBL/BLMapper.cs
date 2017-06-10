using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public class BLMapper
    {
        public SalesSaverDAL.Models.Manager Mapping(SalesSaverBL.Model.Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SalesSaverBL.Model.Manager, SalesSaverDAL.Models.Manager>());
            return Mapper.Map<SalesSaverBL.Model.Manager, SalesSaverDAL.Models.Manager>(manager);
        }
        public SalesSaverDAL.Models.Client Mapping(SalesSaverBL.Model.Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SalesSaverBL.Model.Client, SalesSaverDAL.Models.Client>());
            return Mapper.Map<SalesSaverBL.Model.Client, SalesSaverDAL.Models.Client>(client);
        }
        public SalesSaverDAL.Models.Product Mapping(SalesSaverBL.Model.Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SalesSaverBL.Model.Product, SalesSaverDAL.Models.Product>());
            return Mapper.Map<SalesSaverBL.Model.Product, SalesSaverDAL.Models.Product>(product);
        }
        public SalesSaverDAL.Models.Operation Mapping(SalesSaverBL.Model.Operation operation)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SalesSaverBL.Model.Operation, SalesSaverDAL.Models.Operation>());
            return Mapper.Map<SalesSaverBL.Model.Operation, SalesSaverDAL.Models.Operation>(operation);
        }
    }
}
