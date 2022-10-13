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
        /**
        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnderecoId,Uf,Address")] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(endereco);
                    //await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var endereco = await _context.Enderecos
            //    .FirstOrDefaultAsync(m => m.EnderecoId == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.EnderecoId == id);
        }

        **/
    }
}
