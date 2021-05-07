using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entidades;
using Catalog.Repository;
using Catalog.Services;

namespace Catalog.ServicesImp
{
    public class CitaServiceImp : CitaService
    {
        private readonly CitaRepository citaRepo;
        private readonly DiagnosticoRepository diagRepo;
        private readonly MedicoRepository medRepo;
        private readonly PacienteRepository pacRepo;
        public CitaServiceImp(CitaRepository citaRepo, DiagnosticoRepository diagRepo,
            MedicoRepository medRepo, PacienteRepository pacRepo)
        {
            this.citaRepo = citaRepo;
            this.diagRepo = diagRepo;
            this.medRepo = medRepo;
            this.pacRepo = pacRepo;
        }
        public async Task<bool> deleteAsync(long id)
        {
            try {
                var cita = await findByIdAsync(id);
                if (cita == null)
                    return true;
                if (cita.diagnostico != null)
                    await diagRepo.DeleteDiagnosticoAsync(cita.diagnostico.id);
                await citaRepo.DeleteCitaAsync(id);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<ICollection<Cita>> findAllAsync()
        {
            try {
                return (ICollection<Cita>) await citaRepo.GetCitasAsync();
            } catch (Exception) {
                return null;
            }
        }

        public async Task<Cita> findByIdAsync(long id)
        {
            try {
                return await citaRepo.GetCitaAsync(id);
            } catch (Exception) {
                return null;
            }
        }

        public async Task<long?> saveAsync(Cita cita)
        {
            try {
                Medico m = await medRepo.GetMedicoAsync(cita.medicoId);
                Paciente p = await pacRepo.GetPacienteAsync(cita.pacienteId);
                cita.medico = m;
                cita.paciente = p;
                return await citaRepo.CreateCitaAsync(cita);
            } catch (Exception) {
                return null;
            }
        }

        public async Task<bool> updateAsync(Cita cita)
        {
            try {
                var updatedCita = await findByIdAsync(cita.id);
                if (updatedCita == null)
                    return false;
                if (cita.fechaHora != null) updatedCita.fechaHora = cita.fechaHora;
                if (cita.motivo != null) updatedCita.motivo = cita.motivo;
                if (cita.paciente != null)
                    updatedCita.pacienteId = cita.pacienteId;
                if (cita.medico != null)
                    updatedCita.medicoId = cita.medicoId;
                await citaRepo.UpdateCitaAsync(updatedCita);
                return true;
            } catch (Exception) {
                return false;
            }
        }
    }
}