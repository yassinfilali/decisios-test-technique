using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs;
using PersonApi.Models;
using PersonApi.Services;

namespace PersonApi.Controllers
{
    /// <summary>
    /// Contrôleur 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PersonnesController : ControllerBase 
    {
        private PersonneService _service;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="service">Service de gestion des personnes</param>
        public PersonnesController(PersonneService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cette méthode récupère toutes les personnes, avec filtres optionnels sur le nom et le prénom
        /// </summary>
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? nom, [FromQuery] string? prenom)
        {
            var personnes = _service.GetAll(nom, prenom);

            var list = personnes.Select(p => new PersonneDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                Prenom = p.Prenom
            }).ToList();


            return Ok(list);
        }

        /// <summary>
        /// Cette méthode récupère une personne
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var personne = _service.GetById(id);
            if (personne == null)
            {
                return NotFound();
            }

            var peId = new PersonneDTO
            {
                Id = personne.Id,
                Nom = personne.Nom,
                Prenom = personne.Prenom
            };


            return Ok(peId);
        }

        /// <summary>
        /// Cette méthode crée une nouvelle personne 
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] PersonneCreateUpdateDTO dto)
        {
            var personne = new Personne
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom
            };

            var created = _service.Create(personne);

            var peDto = new PersonneDTO
            {
                Id = personne.Id,
                Nom = personne.Nom,
                Prenom = personne.Prenom
            };

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, peDto);
        }

        /// <summary>
        /// Cette méthode met à jour une personne
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PersonneCreateUpdateDTO dto)
        {
            var existing = _service.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            var updated = new Personne
            {
                Id = id,
                Nom = dto.Nom,
                Prenom = dto.Prenom
            };

            _service.Update(id, updated);
            return NoContent();
        }

        /// <summary>
        /// Supprime une personne 
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var existing = _service.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
