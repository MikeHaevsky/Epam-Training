﻿using SalesSaverBL.Model;
using SalesSaverDAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesSaverBL
{
    public class Handler
    {
        private SalesSaverDBContext DB
        {
            get;
            set;
        }
        private BLMapper DataMapper
        {
            get;
            set;
        }
        private SalesSaverBL.Model.Operation OperationModel
        {
            get;
            set;
        }
        public static Mutex mut = new Mutex();

        public Handler()
        {
            DataMapper = new BLMapper();
            DB = new SalesSaverDBContext();
            OperationModel = new Model.Operation();
        }
        public void ProcessedCSV(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileName = Path.GetFileName(filePath);
                char separator = Convert.ToChar(@Resource.StringSeparator);
                char separatorName = Convert.ToChar(@Resource.FileNameSeparator);
                string[] filenameElements = fileName.Split(separatorName);
                while (reader.EndOfStream != true)
                {
                    string line = reader.ReadLine();
                    string [] lineElements = line.Split(separator);

                    mut.WaitOne();
                    SalesSaverBL.Model.Manager managerBL = new SalesSaverBL.Model.Manager(filenameElements[0]);
                    Validate(managerBL);

                    SalesSaverBL.Model.Client clientBL = new Model.Client(lineElements[1]);
                    Validate(clientBL);

                    SalesSaverBL.Model.Product productBL = new SalesSaverBL.Model.Product(lineElements[2]);
                    Validate(productBL);

                    OperationModel.Data = lineElements[0].CreateDate();
                    OperationModel.Cost = lineElements[3].CreateCost();
                    DB.Operations.Add(this.DataMapper.Mapping(OperationModel));
                    DB.SaveChanges();
                    mut.ReleaseMutex();
                }
            }
        }

        #region Validate
        public void Validate(SalesSaverBL.Model.Manager managerBL)
        {
            SalesSaverDAL.Models.Manager managerDAL = DB.Managers.DefaultIfEmpty().FirstOrDefault(x => x.Nickname == managerBL.Nickname);
            if (managerDAL != null)
            {
                OperationModel.ManagerId = managerDAL.Id;
            }
            else
            {
                DB.Managers.Add(this.DataMapper.Mapping(managerBL));
            }
        }
        public void Validate(SalesSaverBL.Model.Client clientBL)
        {
            SalesSaverDAL.Models.Client clientDAL = DB.Clients.DefaultIfEmpty().FirstOrDefault(x => x.Nickname == clientBL.Nickname);
            if (clientDAL != null)
            {
                OperationModel.ClientId = clientDAL.Id;
            }
            else
            {
                SalesSaverDAL.Models.Client client1 = this.DataMapper.Mapping(clientBL);
                DB.Clients.Add(this.DataMapper.Mapping(clientBL));
            }
        }
        public void Validate(SalesSaverBL.Model.Product productBL)
        {
            SalesSaverDAL.Models.Product productDAL = DB.Products.DefaultIfEmpty().FirstOrDefault(x => x.Name == productBL.Name);
            if (productDAL != null)
            {
                OperationModel.ProductId = productDAL.Id;
            }
            else
            {
                DB.Products.Add(this.DataMapper.Mapping(productBL));
            }
        }
        #endregion
    }
}
