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

        // Content
        /*
        public async Task<IActionResult> Resultado(int? id)
        {
            if (id != null)
            {
                var endereco = await _context.Enderecos
                        .FirstOrDefaultAsync(m => m.EnderecoId == id);
                return View(endereco);
            }
            return NotFound();
        } */



        // GET: Enderecos
        public  IActionResult Index()
        {
            return View(model: _enderecoRepository.GetAll());
        }

        // GET: Enderecos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            return View(_enderecoRepository.GetById((int)id));
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
        public IActionResult Create([Bind("EnderecoId,Uf,Address")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {

                
                _enderecoRepository.Add(endereco);
                _enderecoRepository.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_enderecoRepository.GetById((int)id));
        }
        
        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("EnderecoId,Uf,Address")] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _enderecoRepository.Update(endereco);
                    _enderecoRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.EnderecoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
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

            return View(_enderecoRepository.GetById((int) id));
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _enderecoRepository.Remove(_enderecoRepository.GetById((int)id));
            _enderecoRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
            return (bool)_enderecoRepository.GetById(id);
        }

    }
}
