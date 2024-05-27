$(document).ready(function () {
    // Simulação de dados de agendamentos
    var agendamentos = [
        { nomeCliente: "João da Silva", dataAgendamento: "2024-05-28", servico: "Troca de óleo", horario: "09:00" },
        { nomeCliente: "Maria Oliveira", dataAgendamento: "2024-05-29", servico: "Revisão", horario: "14:30" },
        { nomeCliente: "José Santos", dataAgendamento: "2024-05-30", servico: "Polimento", horario: "11:00" }
    ];

    // Limpa a tabela
    $("#tabelaAgendamentos").empty();

    // Adiciona os agendamentos na tabela
    agendamentos.forEach(function (agendamento) {
        $("#tabelaAgendamentos").append(`<tr>
            <td>${agendamento.nomeCliente}</td>
            <td>${formatarData(agendamento.dataAgendamento)}</td>
            <td>${agendamento.servico}</td>
            <td>${agendamento.horario}</td>
        </tr>`);
    });
});

// Função para formatar a data no formato "dd/mm/yyyy"
function formatarData(data) {
    var dataObj = new Date(data);
    var dia = dataObj.getDate().toString().padStart(2, '0');
    var mes = (dataObj.getMonth() + 1).toString().padStart(2, '0');
    var ano = dataObj.getFullYear();
    return `${dia}/${mes}/${ano}`;
}
