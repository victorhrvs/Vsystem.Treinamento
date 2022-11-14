using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Business
{
    public class EnderecosBusiness
    {
        private readonly EnderecoRepository _enderecoRepository;
        public IEnumerable<Entities.Endereco> Enderecos { get; set; }
        public EnderecosBusiness(EnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        // GET: Enderecos
        public IEnumerable<Entities.Endereco> Index(EnderecoRepository _enderecoRepository)
        {
            return (Enderecos = _enderecoRepository.GetAll());
        }


        // GET: Enderecos/Details/5
        public Entities.Endereco Details(int? id)
        {
            return _enderecoRepository.GetById((int)id);
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Entities.Endereco Create([Bind("EnderecoId,Uf,Address")] Endereco endereco)
        {
            _enderecoRepository.Add(endereco);
            _enderecoRepository.Save();

            return endereco;
        }


        // GET: Enderecos/Edit/5
        public Entities.Endereco Edit(int? id)
        {


            return _enderecoRepository.GetById((int)id);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public Entities.Endereco Edit(int id, [Bind("EnderecoId,Uf,Address")] Endereco endereco)
        {
            try
            {
                _enderecoRepository.Update(endereco);
                _enderecoRepository.Save();
                return endereco;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.EnderecoId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            

        }

        
        
        // GET: Enderecos/Delete/5
        public Entities.Endereco Delete(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return _enderecoRepository.GetById((int)id);
        }

        // POST: Enderecos/Delete/5
        public void DeleteConfirmed(int id)
        {
            _enderecoRepository.Remove(_enderecoRepository.GetById((int)id));
            _enderecoRepository.Save();
        }

        private bool EnderecoExists(int id)
        {
            return (bool)_enderecoRepository.GetById(id);
        }



    }
}
