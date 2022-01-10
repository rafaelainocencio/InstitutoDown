using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly ProjetoDbContext _context;

        public MatriculasController(ProjetoDbContext context)
        {
            _context = context;
        }

        //MATRICULAR
        public IActionResult Matricular()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // GET: Matriculas
        public async Task<IActionResult> Index()
        {
            var projetoDbContext = _context.Matriculas.Include(m => m.Usuario).Include(m => m.Curso);
            return View(await projetoDbContext.ToListAsync());
        }

        // GET: Matriculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.Usuario)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // GET: Matriculas/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCurso,IdUsuario")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", matricula.IdUsuario);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome", matricula.IdCurso);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", matricula.IdUsuario);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome", matricula.IdCurso);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCurso,IdUsuario")] Matricula matricula)
        {
            if (id != matricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculaExists(matricula.Id))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", matricula.IdUsuario);
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome", matricula.IdCurso);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matricula = await _context.Matriculas
                .Include(m => m.Usuario)
                .Include(m => m.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matricula == null)
            {
                return NotFound();
            }

            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculaExists(int id)
        {
            return _context.Matriculas.Any(e => e.Id == id);
        }
    }
}
