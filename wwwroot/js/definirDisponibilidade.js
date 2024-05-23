var diasSelecionados = {};

$(document).ready(function () {
    $('#calendar').datepicker({
        dateFormat: 'dd/mm/yy',
        beforeShowDay: function (date) {
            var stringDate = $.datepicker.formatDate('dd/mm/yy', date);
            if (diasSelecionados[stringDate]) {
                return [true, 'selected-day'];
            } else {
                return [true, ''];
            }
        },
        onSelect: function (dateText, inst) {
            if (Object.keys(diasSelecionados).length >= 20) {
                alert('Você só pode selecionar até 20 datas.');
                return;
            }

            diasSelecionados[dateText] = [];
            updateDiasSelecionados();
            $(this).datepicker('refresh');
        }
    });

    $('#btnSelecionarHoras').click(function () {
        $('#modalBody').empty();
        Object.keys(diasSelecionados).forEach(function (data) {
            var divData = $('<div></div>').text(data + ':');
            var adicionarHora = $('<button class="btn btn-adicionar-hora">+</button>');
            adicionarHora.click(function () {
                adicionarHoraParaData(data, $(this).parent());
            });
            divData.append(adicionarHora);
            $('#modalBody').append(divData);

            diasSelecionados[data].forEach(function (hora) {
                adicionarHoraParaData(data, $('#modalBody').find('div:contains("' + data + '")'));
                $('#modalBody').find('input[type="time"]').last().val(hora);
            });
        });

        $('#modalHoras').modal('show');
    });

    $('#btnSalvarHoras').click(function () {
        var dataToSend = [];
        Object.keys(diasSelecionados).forEach(function (data) {
            var horas = diasSelecionados[data].filter(hora => hora !== "");
            if (horas.length > 0) {
                var parts = data.split('/');
                var isoDate = new Date(parts[2], parts[1] - 1, parts[0]).toISOString(); // Converte para formato ISO

                dataToSend.push({
                    Data: isoDate,
                    HorasDisponibilidade: horas.map(hora => ({ Hora: hora }))
                });
            }
        });

        // Validação: Verifica se há dados a serem enviados
        if (dataToSend.length === 0) {
            alert("Por favor, selecione pelo menos uma data e horário.");
            return;
        }

        // Log para verificar dados antes do envio
        console.log('Dados a serem enviados:', JSON.stringify(dataToSend, null, 2));

        $.ajax({
            url: 'ParceiroDefinirDisponibilidadeAjax',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dataToSend),
            success: function (response) {
                console.log('Disponibilidade e horas definidas com sucesso', response);
                if (response.success) {
                    $('#modalHoras').modal('hide');
                    $('#modalSucesso').modal('show');
                    diasSelecionados = {};
                    $('#calendar').find('.selected-day').removeClass('selected-day');
                    $('#column1').empty();
                    $('#column2').empty();
                    $('#btnSelecionarHoras').prop('disabled', true);
                } else {
                    console.error('Erro ao definir disponibilidade e horas', response.message);
                    $('#modalErro').modal('show');
                }
            },
            error: function (xhr, status, error) {
                console.error('Erro ao enviar dados para o servidor:', xhr.responseText);
                $('#modalErro').modal('show');
            }
        });
    });

    $('#btnSucessoOK').click(function () {
        $('#modalSucesso').modal('hide');
    });

    $('#btnErroOK').click(function () {
        $('#modalErro').modal('hide');
    });

    $('#modalHoras .modal-header .close, #btnCancelarHoras').click(function () {
        $('#modalHoras').modal('hide');
    });

    function updateDiasSelecionados() {
        $('#column1').empty();
        $('#column2').empty();

        var colunaAtual = 1;
        Object.keys(diasSelecionados).forEach(function (data, index) {
            var horarios = diasSelecionados[data];
            var column = colunaAtual === 1 ? $('#column1') : $('#column2');
            var item = $('<div class="data-item"></div>');
            var texto = $('<span>' + data + ': ' + horarios.join(', ') + '</span>');
            var remover = $('<button class="remover-dia">X</button>');
            remover.click(function () {
                delete diasSelecionados[data];
                updateDiasSelecionados();
            });
            item.append(texto);
            item.append(remover);
            column.append(item);

            if (colunaAtual === 1 && Object.keys(diasSelecionados).indexOf(data) === 9) {
                colunaAtual = 2;
            }
        });

        $('#btnSelecionarHoras').prop('disabled', Object.keys(diasSelecionados).length === 0);
    }

    function adicionarHoraParaData(data, container) {
        var inputHora = $('<input type="time" class="form-control">');
        var divHora = $('<div class="hora-selecionada"></div>');
        var inputHoraContainer = $('<div></div>').append(inputHora);
        var removerHora = $('<button class="remover-hora">Remover</button>');
        removerHora.click(function () {
            var hora = inputHora.val();
            $(this).parent().remove();
            var index = diasSelecionados[data].indexOf(hora);
            if (index !== -1) {
                diasSelecionados[data].splice(index, 1);
            }
        });
        divHora.append(inputHoraContainer).append(removerHora);
        container.after(divHora);

        inputHora.change(function () {
            var hora = $(this).val();
            var index = diasSelecionados[data].indexOf(hora);
            if (index === -1 && hora !== "") {
                diasSelecionados[data].push(hora);
            }
        });
    }
});
