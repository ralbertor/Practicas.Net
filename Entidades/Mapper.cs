using System.Linq;
using AutoMapper;
namespace Catalog.Entidades
{
    public class Mapper : Profile{
        public Mapper(){
            CreateMap<Diagnostico, DTOs.DiagnosticoDTO.DiagnosticoDTO>();
            CreateMap<DTOs.DiagnosticoDTO.DiagnosticoDTO, Diagnostico>();
            CreateMap<Diagnostico, DTOs.DiagnosticoDTO.CreateDiagnosticoDTO>();
            CreateMap<DTOs.DiagnosticoDTO.CreateDiagnosticoDTO, Diagnostico>();
            CreateMap<Cita,DTOs.DiagnosticoDTO.CitaDTO>();
            CreateMap<DTOs.DiagnosticoDTO.CitaDTO, Cita>();

            CreateMap<Cita, DTOs.CitaDTO.CitaDTO>();
            CreateMap<DTOs.CitaDTO.CitaDTO,Cita>();
            CreateMap<Cita, DTOs.CitaDTO.CreateCitaDTO>();
            CreateMap<DTOs.CitaDTO.CreateCitaDTO,Cita>();

             CreateMap<Medico, DTOs.MedicoDTO.MedicoDTO>()
                .ForMember(dto=>dto.paciente, opt => opt
                    .MapFrom(m => m.pacientes
                        .Select(mp => mp.paciente).ToList()));

            CreateMap<DTOs.MedicoDTO.MedicoDTO, Medico>()
                .ForMember(m=> m.pacientes, opt => opt
                    .MapFrom(dto => dto.paciente
                        .Select(p => new MedicoPaciente{medicoId=dto.id,pacienteId=p.id})));

            CreateMap<Paciente, DTOs.PacienteDTO.PacienteDTO>()
                .ForMember(dto =>dto.medico, opt => opt
                    .MapFrom(p =>p.medicos
                        .Select(mp => mp.medico).ToList()));

             CreateMap<DTOs.PacienteDTO.PacienteDTO, Paciente>()
                .ForMember(p => p.medicos, opt => opt
                    .MapFrom(dto => dto.medico
                        .Select(m => new MedicoPaciente{medicoId=m.id, pacienteId=dto.id})));

            CreateMap<Cita, DTOs.PacienteDTO.CitaDTO>();
            CreateMap<DTOs.PacienteDTO.CitaDTO, Cita>();
            CreateMap<Paciente, DTOs.PacienteOnlyDTO>();
            CreateMap<DTOs.PacienteOnlyDTO, Paciente>();
            CreateMap<Medico, DTOs.MedicoOnlyDTO>();
            CreateMap<DTOs.MedicoOnlyDTO, Medico>();
            CreateMap<Diagnostico, DTOs.DiagnosticoOnlyDTO>();
            CreateMap<DTOs.DiagnosticoOnlyDTO, Diagnostico>();
            
            CreateMap<MedicoPaciente, DTOs.PacienteOnlyDTO>();
            CreateMap<DTOs.PacienteOnlyDTO, MedicoPaciente>();
            CreateMap<MedicoPaciente, DTOs.MedicoOnlyDTO>();
            CreateMap<DTOs.MedicoOnlyDTO, MedicoPaciente>();             
        }
    }
}