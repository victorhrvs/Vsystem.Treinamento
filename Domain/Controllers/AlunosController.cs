using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.Repositories;
using Domain.Entities;

namespace Domain.Views.Home
{
    public class AlunosController : Controller
    {
        private readonly AlunoRepository _alunoRepository;
        private readonly EnderecoRepository _enderecoRepository;

        public AlunosController(AlunoRepository alunoRepository, EnderecoRepository enderecoRepository)
        {
            _alunoRepository = alunoRepository;
            _enderecoRepository = enderecoRepository;
        }



        // GET: Alunos
        public IActionResult Index()
        {

            return View(_alunoRepository.GetAll());
        }

        // GET: Alunos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(_alunoRepository.GetById((int)id));
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["EnderecoFk"] = new SelectList(_enderecoRepository.GetAll(), "EnderecoId", "Address");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Matricula,Nome,Email,EnderecoFk")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                
                _alunoRepository.Add(aluno);
                _alunoRepository.Save();

                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoFk"] = new SelectList(_enderecoRepository.GetAll(), "EnderecoId", "Address", aluno?.EnderecoFk.ToString());
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

            var aluno = _alunoRepository.GetById((int)id);
                if (aluno == null)
                {
                    return NotFound();
                }
                ViewData["EnderecoFk"] = new SelectList(_enderecoRepository.GetAll(), "EnderecoId", "EnderecoId", aluno.EnderecoFk);
                return View(aluno);
            }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Matricula,Nome,Email,EnderecoFk")] Aluno aluno)
        {
            if (id != aluno.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _alunoRepository.Update(aluno);
                    _alunoRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Matricula))
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
            ViewData["EnderecoFk"] = new SelectList(_enderecoRepository.GetAll(), "EnderecoId", "Address", aluno.EnderecoFk);
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return View(_alunoRepository.GetById((int)id));
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _alunoRepository.Remove(_alunoRepository.GetById(id));
            _alunoRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
            {
            return (bool) _alunoRepository.GetById(id);
            }
            
        
    }
}