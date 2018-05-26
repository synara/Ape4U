using RedeSocialCondominio.DTOs;
using RedeSocialCondominio.Enums;
using RedeSocialCondominio.Models;
using RedeSocialCondominio.Persistence;
using RedeSocialCondominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Util
{
    public class Util
    {

        protected static UnitOfWork unitOfWork = new UnitOfWork(new Models.ApplicationDbContext());

        public static bool ValidarCamposMudanca(MudancaViewModel vm)
        {
            var erroValidacao = false;
            var data = new DateTime();

            if (!string.IsNullOrEmpty(vm.Dia.ToString()))
                data = DateTime.Parse(vm.Dia.ToString());

            if (string.IsNullOrEmpty(vm.Nome) || vm.TipoMudancaId == 0 || string.IsNullOrEmpty(vm.Dia.ToString()) || string.IsNullOrEmpty(vm.Hora))
                erroValidacao = true;

            else if (data.Date < DateTime.Now.Date)
                erroValidacao = true;

            return erroValidacao;
        }

        public static string ValidarOcorrencia(OcorrenciasViewModel ocorrencia)
        {
            string mensagem = null;

            if (string.IsNullOrEmpty(ocorrencia.Assunto))
                mensagem = "O campo assunto é obrigatório.";
   
            if (string.IsNullOrEmpty(ocorrencia.Descricao))
                mensagem = "O campo descrição é obrigatório.";

            return mensagem;
        }

        public static DateTime ValidarHoras(string hora)
        {
            DateTime horaFormatada;
            var hoje = DateTime.Now.Date;

            if (String.IsNullOrEmpty(hora))
                horaFormatada = DateTime.Now.Date;
            else
                horaFormatada = Convert.ToDateTime(hora);

            return horaFormatada;
        }

        public static List<int> TransformarIntervaloHorariosEmArray(HorariosLocais horarioLocal)
        {
            List<int> horarios = new List<int>();

            for (int i = horarioLocal.HorarioInicial.Hour; i <= horarioLocal.HorarioFinal.Hour; i++)
            {
                if (i <= horarioLocal.HorarioFinal.Hour)
                {
                    horarios.Add(i);
                }
            }
            return horarios;
        }

        public static bool VerificarDisponibilidadeHorarioReserva(int horaInicial, int horarioFinal, List<HorariosLocais> horariosLocais)
        {
            var horarios = new List<int>();
            var existe = false;

            foreach (var hora in horariosLocais)
            {
                horarios = TransformarIntervaloHorariosEmArray(hora);

                if (horarios.Contains(horaInicial) && horarios.Contains(horarioFinal))
                    existe = true;
            }
            return existe;
        }

        public static List<int> TransformarHorariosJaReservadosEmArray(Reserva reserva)
        {
            List<int> horarios = new List<int>();
            var horaInicial = reserva.HoraInicio.Hour + reserva.HoraExtraInicial.Value.Hour;
            var horaFinal = reserva.HoraFim.Hour + reserva.HoraExtraFinal.Value.Hour;


            for (int i = horaInicial; i <= horaFinal; i++)
            {
                if (i <= horaFinal)
                    horarios.Add(i);
            }
            return horarios;
        }

        public static bool VerificarHorariosJaReservados(int horaInicial, int horaFinal, List<Reserva> reservas)
        {
            var horarios = new List<int>();
            var existe = false;

            foreach (var reserva in reservas)
            {
                horarios = TransformarHorariosJaReservadosEmArray(reserva);

                if (horarios.Contains(horaInicial) && horarios.Contains(horaFinal))
                    existe = true;
            }
            return existe;
        }

        public static string ValidarReserva(ReservaDTO dto, string userId)
        {
            string mensagem = null;
            var horaInicial = Convert.ToDateTime(dto.HoraDiaInicio);
            var horaFinal = Convert.ToDateTime(dto.HoraDiaFinal);
            var horaExtraInicial = ValidarHoras(dto.HoraDiaExtraInicial);
            var horaExtraFinal = ValidarHoras(dto.HoraDiaExtraFinal);
            var horaInicialTotal = horaInicial.Hour - horaExtraInicial.Hour;
            var horaFinalTotal = horaFinal.Hour + horaExtraFinal.Hour;
            var horariosDoLocal = unitOfWork.HorariosLocais.GetHorariosPorId(dto.LocalId);
            var reservasDoLocal = unitOfWork.Reservas.GetReservasPorHoraLocal(horaInicial.Date, dto.LocalId);

            if (Convert.ToDateTime(dto.HoraDiaInicio).DayOfWeek == DayOfWeek.Sunday)
                mensagem = "Não é permitido reservas espaços aos domingos!";


            else if (horaInicial.Date == horaFinal.Date && horaInicialTotal > horaFinalTotal)
                mensagem = "O horário de encerramento da reserva não pode ser antes do horário de início.";

            else if (horaInicial.Date < DateTime.Now)
                mensagem = "Data indisponível. Esse dia já passou.";

            else if (VerificarHorariosJaReservados(horaInicialTotal, horaFinalTotal, reservasDoLocal))
                mensagem = "Já existe uma reserva para esse local no horário em que você solicitou. Favor, informe outro horário.";

            if (string.IsNullOrEmpty(mensagem))
            {
                var horarios = VerificarDisponibilidadeHorarioReserva(horaInicialTotal, horaFinalTotal, horariosDoLocal);
                if (!horarios)
                    mensagem = "Não é possível registrar uma reserva nesse horário. Consulte os horários permitidos pelo condomínio.";
            }

            if (string.IsNullOrEmpty(dto.Descricao))
                mensagem = "É necessário fornecer uma descrição.";

            if (string.IsNullOrEmpty(dto.Nome))
                mensagem = "É necessário fornecer um nome para sua reserva.";

            return mensagem;
        }

        public static bool VerificarHorario(DateTime hora)
        {
            var de = DateTime.Parse(ConfigurationManager.AppSettings["HorarioInicioAgendamentoVisita"]);
            var ate = DateTime.Parse(ConfigurationManager.AppSettings["HorarioFimAgendamentoVisita"]);

            if (hora.Hour >= de.Hour && hora.Hour <= ate.Hour)
                return true;

            else return false;
        }

        public static string ValidarReuniao(ReuniaoViewModel vm)
        {
            string mensagem = null;

            if (string.IsNullOrEmpty(vm.Assunto))
                mensagem = "Um assunto deve ser informado.";
            else if (string.IsNullOrEmpty(vm.Descricao))
                mensagem = "Deve ser informada uma descrição da reunião.";
            else if (vm.Dia.Ticks == 0)
                mensagem = "Informe o dia da reunião.";
            else if (vm.HoraInicio.Ticks == 0)
                mensagem = "Informe o horário inicial da reunião.";
            else if (vm.HoraFim.Ticks == 0)
                mensagem = "Informe o horário final da reunião.";
            else if (vm.HoraInicio > vm.HoraFim)
                mensagem = "O horário inicial da reunião é maior que o final. Favor, verificar.";
            else if (vm.Dia < DateTime.Now)
                mensagem = "Não é permitido agendar uma reunião em uma data que já passou.";

            return mensagem;
        }

        public static TipoNotificacao VerificarTipoNotificacao(Notificacao n)
        {
            var tipoNotificacao = TipoNotificacao.Nenhum;

            if (string.IsNullOrEmpty(n.Espaco) && n.HoraInicial == null && n.HoraFinal == null)
                tipoNotificacao = TipoNotificacao.Ocorrencia;
            else if (!string.IsNullOrEmpty(n.Assunto) && n.HoraInicial.Value.Ticks != 0 && n.HoraFinal.Value.Ticks != 0)
                tipoNotificacao = TipoNotificacao.Reuniao;
            else if(!string.IsNullOrEmpty(n.Espaco))
                tipoNotificacao = TipoNotificacao.Reserva;

            return tipoNotificacao;
        }

        public static bool VerificarPerfil(string usuarioId)
        {
            var usuario = unitOfWork.Usuarios.GetUsuarioPorId(usuarioId).PerfilId;

            if(usuario == 1 || usuario == 4)
                return false;
            
            return true;
        }
    }
}

