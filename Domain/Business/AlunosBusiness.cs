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
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Domain.Business
{
    public class AlunosBusiness : Controller
    {
        private readonly AlunoRepository _alunoRepository;
        private readonly EnderecoRepository _enderecoRepository;

        public AlunosBusiness(AlunoRepository alunoRepository, EnderecoRepository enderecoRepository)
        {
            _alunoRepository = alunoRepository;
            _enderecoRepository = enderecoRepository;
        }



        // GET: Alunos
        public IEnumerable<Entities.Aluno> Index()
        {

            return _alunoRepository.GetAll();
        }

        // GET: Alunos/Details/5
        public Entities.Aluno Details(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return _alunoRepository.GetById((int)id);
        }

        // GET: Alunos/Create
        public void Create()
        {
            //ViewData["EnderecoFk"] = new SelectList(_enderecoRepository.GetAll(), "EnderecoId", "Address");
        }

        
        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Entities.Aluno Create([Bind("Matricula,Nome,Email,EnderecoFk")] Aluno aluno)
        {
            _alunoRepository.Add(aluno);
            _alunoRepository.Save();
            return aluno;
        }
        
        // GET: Alunos/Edit/5
        public Entities.Aluno Edit(int? id)
            {
                if (id == null)
                {
                    return null;
                }

            var aluno = _alunoRepository.GetById((int)id);
                if (aluno == null)
                {
                    return null;
                }
                ViewData["EnderecoFk"] = new SelectList(_enderecoRepository.GetAll(), "EnderecoId", "EnderecoId", aluno.EnderecoFk);
                return aluno;
            }
        
        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public Entities.Aluno Edit(int id, [Bind("Matricula,Nome,Email,EnderecoFk")] Aluno aluno)
        {

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
                        return null;
                    }
                    else
                    {
                        throw;
                    }
                }
                return aluno;
            }

        }
        
        // GET: Alunos/Delete/5
        public Entities.Aluno Delete(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return _alunoRepository.GetById((int)id);
        }

        // POST: Alunos/Delete/5
        public void DeleteConfirmed(int id)
        {
            _alunoRepository.Remove(_alunoRepository.GetById(id));
            _alunoRepository.Save();
        }

        private bool AlunoExists(int id)
            {
            return (bool) _alunoRepository.GetById(id);
            }


    }
}