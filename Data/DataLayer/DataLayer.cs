using CarParkDbAPI.Exceptions;
using CarParkDbAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkDbAPI
{
    public partial class DataLayerSingleton
    {
        #region Singleton
        private DataLayerSingleton()
        { 

        }
        private static DataLayerSingleton _instance;

        public static DataLayerSingleton Instance { get 
            {
                if (_instance == null)
                {
                    _instance = new DataLayerSingleton();
                }
                return _instance;
            } 
        }
        #endregion

        #region AddMethod
        public Autovehicul AdaugaAutovehicul(string nume, int producatorId)
        {
            using var ctx = new CarDBContext();

            if(!ctx.Producatori.Any(p=>p.Id == producatorId)) 
            {
                throw new InvalidIdException($"Id producator invalid {producatorId}");
            }
            var autovehicul = new Autovehicul
            {
                Nume = nume,
                ProducatorId = producatorId
            };

            ctx.Add(autovehicul);
            ctx.SaveChanges();

            return autovehicul;

        }
        #endregion

        #region AddProducer
        public Producator AdaugaProducator(string nume, string adresa)
        {
            using var ctx = new CarDBContext();

            var producator = new Producator
            {
                Nume = nume,
                Adresa = adresa
            };
            ctx.Add(producator);
            ctx.SaveChanges();

            return producator;
        }
        #endregion

        #region AddKey
        public Cheie AdaugaCheieLaAutovehicul(Guid codAcces, int autovehiculId)
        {
            using var ctx = new CarDBContext();
            var autovehicul = ctx.Autovehicule.FirstOrDefault(a => a.Id == autovehiculId);
            if(autovehicul == null ) 
            {
                throw new InvalidIdException($"Id producator invalid {autovehiculId}");
            }
            var cheie = new Cheie { CodAcces = codAcces };

            autovehicul.Chei.Add(cheie);

            ctx.SaveChanges();
            
            return cheie;

        }

        public Cheie AdaugaCheieLaAutovehicul2(Guid codAcces, int autovehiculId)
        {
            using var ctx = new CarDBContext();

            if (!ctx.Autovehicule.Any(p => p.Id == autovehiculId))
            {
                throw new InvalidIdException($"Id producator invalid {autovehiculId}");
            }
            var cheie = new Cheie
            {
                CodAcces = codAcces,
                AutovehiculId = autovehiculId
            };

            ctx.Add(cheie);
            ctx.SaveChanges();

            return cheie;

        }
        #endregion

        #region RemoveAutovehicle
        public void StergeAutovehicul(int id)
        {
            using var ctx = new CarDBContext();

            var autovehicul = ctx.Autovehicule.Include(a=>a.Chei).FirstOrDefault(a=>a.Id  == id);
            if(autovehicul == null) 
            {
                throw new InvalidIdException($"Id autovehicul invalid {id}");
            }

            autovehicul.Chei.ForEach(c =>
            {
                c.AutovehiculId = null;
            });

            ctx.Remove(autovehicul);
            ctx.SaveChanges();
        }
        #endregion

        #region RemoveProducer
        public void StergeProducator(int id)
        {
            var ctx = new CarDBContext();

            var producator = ctx.Producatori.Include(a=>a.Autovehicule).FirstOrDefault(a=>a.Id == id);
            if(producator == null)
            {
                throw new InvalidIdException($"Id producator invalid {id}");
            }

            producator.Autovehicule.ForEach(c => { c.ProducatorId  = null; });

            ctx.Remove(producator); 
            ctx.SaveChanges();  
        }
        #endregion
    }
}

