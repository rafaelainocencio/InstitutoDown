using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class CandidaturasController : Controller
    {
        private readonly ProjetoDbContext _context;

        public CandidaturasController(ProjetoDbContext context)
        {
            _context = context;
        }

        //Candidatar
        public async Task<IActionResult> Candidatar()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome");
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "Id", "Nome");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            ViewData["IdVaga"] = new SelectList(_context.Vagas, "Id", "Cargo");
            return View();
        }

        // GET: Candidaturas
        public async Task<IActionResult> Index()
        {
            var projetoDbContext = _context.Candidaturas.Include(c => c.Curso).Include(c => c.Empresa).Include(c => c.Usuario).Include(c => c.Vaga);
            return View(await projetoDbContext.ToListAsync());
        }

        // GET: Candidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas
                .Include(c => c.Curso)
                .Include(c => c.Empresa)
                .Include(c => c.Usuario)
                .Include(c => c.Vaga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Create
        public IActionResult Create()
        {
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome");
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "Id", "Nome");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome");
            ViewData["IdVaga"] = new SelectList(_context.Vagas, "Id", "Cargo");
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpresa,IdCurso,IdVaga,IdUsuario")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome", candidatura.IdCurso);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "Id", "Nome", candidatura.IdEmpresa);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", candidatura.IdUsuario);
            ViewData["IdVaga"] = new SelectList(_context.Vagas, "Id", "Cargo", candidatura.IdVaga);
            return View(candidatura);
        }

        // GET: Candidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas.FindAsync(id);
            if (candidatura == null)
            {
                return NotFound();
            }
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome", candidatura.IdCurso);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "Id", "Nome", candidatura.IdEmpresa);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", candidatura.IdUsuario);
            ViewData["IdVaga"] = new SelectList(_context.Vagas, "Id", "Cargo", candidatura.IdVaga);
            return View(candidatura);
        }

        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmpresa,IdCurso,IdVaga,IdUsuario")] Candidatura candidatura)
        {
            if (id != candidatura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaExists(candidatura.Id))
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
            ViewData["IdCurso"] = new SelectList(_context.Cursos, "Id", "Nome", candidatura.IdCurso);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "Id", "Nome", candidatura.IdEmpresa);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Nome", candidatura.IdUsuario);
            ViewData["IdVaga"] = new SelectList(_context.Vagas, "Id", "Cargo", candidatura.IdVaga);
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidaturas
                .Include(c => c.Curso)
                .Include(c => c.Empresa)
                .Include(c => c.Usuario)
                .Include(c => c.Vaga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatura = await _context.Candidaturas.FindAsync(id);
            _context.Candidaturas.Remove(candidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaExists(int id)
        {
            return _context.Candidaturas.Any(e => e.Id == id);
        }
    }
}
