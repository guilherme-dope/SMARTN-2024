﻿using Microsoft.EntityFrameworkCore;
using SMART.Web.Inferfaces;
using SMART.Web.Models;

namespace SMART.Web.Repositories
{
    public class RepositoryBase<T> : InterfaceModel<T>, IDisposable where T : class
    {
        protected SMARTNContext _DataContext;
        public bool _SaveChanges = true;

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _DataContext = new SMARTNContext();
        }

        public async Task<T> IncluirAsync(T objeto)
        {
            await _DataContext.Set<T>().AddAsync(objeto);

            if (_SaveChanges)
            {
                await _DataContext.SaveChangesAsync();
            }
            return objeto;
        }


        public T Alterar(T objeto)
        {
            _DataContext.Entry(objeto).State = EntityState.Modified;

            if (_SaveChanges)
            {
                _DataContext.SaveChanges();
            }
            return objeto;
        }

        public void Dispose()
        {
            _DataContext.Dispose();
        }

        public void Excluir(T objeto)
        {
            _DataContext.Set<T>().Remove(objeto);
            if (_SaveChanges)
            {
                _DataContext.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPk(variavel);
            Excluir(obj);
        }

        public T Incluir(T objeto)
        {
            _DataContext.Set<T>().Add(objeto);
            if (_SaveChanges)
            {
                _DataContext.SaveChanges();
            }
            return objeto;
        }

        public void SaveChanges()
        {
            _DataContext.SaveChanges();
        }

        public T SelecionarPk(params object[] variavel)
        {
            return _DataContext.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _DataContext.Set<T>().ToList();
        }
    }
}