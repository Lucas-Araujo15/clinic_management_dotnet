using clinic_management_dotnet.Data;
using clinic_management_dotnet.Dtos.Patient;
using clinic_management_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinic_management_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> FindAllPatients()
        {
            return await _context.Patients
                .Include(p => p.Address)
                .Select(p => new PatientDTO(p))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> FindPatientById(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(new PatientDTO(patient));
        }

        [HttpPost]
        public async Task<ActionResult<PatientDTO>> CreatePatient(CreatePatientDTO dto)
        {
            var patient = new PatientModel(dto);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            var patientDTO = new PatientDTO(patient);

            return CreatedAtAction("FindPatientById", new {id = patient.Id}, patientDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDTO dto)
        {
            var patient = await _context.Patients
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.UpdateInformation(dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.Address.Remove(patient.Address);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
