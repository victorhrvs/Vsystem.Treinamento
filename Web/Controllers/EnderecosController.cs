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

namespace Domain.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly EnderecoRepository _enderecoRepository;
        public EnderecosController(EnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        // GET: Enderecos
        public IActionResult Index()
        {
            Business.EnderecosBusiness endereco = new Business.EnderecosBusiness(_enderecoRepository);
            return View(model: endereco.Index(_enderecoRepository));
        }

        // GET: Enderecos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Business.EnderecosBusiness endereco = new Business.EnderecosBusiness(_enderecoRepository);

            return View(endereco.Details(id));
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EnderecoId,Uf,Address")] Endereco novoEndereco)
        {
            if (ModelState.IsValid)
            {
                Business.EnderecosBusiness endereco = new Business.EnderecosBusiness(_enderecoRepository);
                endereco.Create(novoEndereco);

                return RedirectToAction(nameof(Index));
            }
            return View(novoEndereco);
        }


        // GET: Enderecos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Business.EnderecosBusiness endereco = new Business.EnderecosBusiness(_enderecoRepository);


            return View(endereco.Edit(id));
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EnderecoId,Uf,Address")] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Business.EnderecosBusiness local = new Business.EnderecosBusiness(_enderecoRepository);
                var res = local.Edit(id, endereco);
                if (res == null)
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return NotFound();
            }

        }



        // GET: Enderecos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var endereco = await _context.Enderecos
            //    .FirstOrDefaultAsync(m => m.EnderecoId == id);
            Business.EnderecosBusiness local = new Business.EnderecosBusiness(_enderecoRepository);
            
            return View(local.Delete(id));
        }

        // POST: Enderecos/Delete/5
        [HttpPost()]
        [Route("/deletar/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            Business.EnderecosBusiness local = new Business.EnderecosBusiness(_enderecoRepository);

            local.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
            return (bool)_enderecoRepository.GetById(id);
        }

    }
}
